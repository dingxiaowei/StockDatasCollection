using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StockDatasCollection.Models;

namespace StockDatasCollection.Services
{
    /// <summary>
    /// Fetches real-time stock data from Sina Finance API (hq.sinajs.cn).
    /// Response is GBK-encoded; each line has the format:
    ///   var hq_str_sh600519="贵州茅台,1789.00,...,2026-02-26,15:00:04,00";
    /// </summary>
    public class StockDataCollector
    {
        private static readonly HttpClient _httpClient;
        private static readonly Encoding _gbk = Encoding.GetEncoding("GBK");

        static StockDataCollector()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Referer", "https://finance.sina.com.cn/");
            _httpClient.Timeout = TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// Fetches data for all provided stock codes and returns parsed data points.
        /// </summary>
        public async Task<List<StockDataPoint>> FetchAsync(List<StockCode> codes)
        {
            if (codes == null || codes.Count == 0)
                return new List<StockDataPoint>();

            string codeList = string.Join(",", codes.ConvertAll(c => c.Code));
            string url = $"http://hq.sinajs.cn/list={codeList}";

            byte[] responseBytes = await _httpClient.GetByteArrayAsync(url);
            string dataText = _gbk.GetString(responseBytes);

            return ParseResponse(dataText, DateTime.Now);
        }

        private List<StockDataPoint> ParseResponse(string text, DateTime collectedAt)
        {
            var results = new List<StockDataPoint>();
            // Each line: var hq_str_sh600519="...data...";
            var lineRegex = new Regex(@"var hq_str_(\w+)=""([^""]*)"";", RegexOptions.Compiled);

            foreach (Match m in lineRegex.Matches(text))
            {
                string code = m.Groups[1].Value;        // e.g. "sh600519"
                string payload = m.Groups[2].Value;     // CSV content inside quotes

                if (string.IsNullOrWhiteSpace(payload)) continue;

                string[] f = payload.Split(',');
                if (f.Length < 3) continue;

                var point = new StockDataPoint
                {
                    StockCode = code,
                    CollectedAt = collectedAt,
                    StockName = SafeGet(f, 0),
                    OpenPrice = SafeGet(f, 1),
                    PreClosePrice = SafeGet(f, 2),
                    CurrentPrice = SafeGet(f, 3),
                    HighPrice = SafeGet(f, 4),
                    LowPrice = SafeGet(f, 5),
                    BidPrice = SafeGet(f, 6),
                    AskPrice = SafeGet(f, 7),
                    Volume = SafeGetLong(f, 8),
                    Turnover = SafeGet(f, 9),
                    // Buy 1-5
                    Buy1Vol = SafeGetLong(f, 10), Buy1Price = SafeGet(f, 11),
                    Buy2Vol = SafeGetLong(f, 12), Buy2Price = SafeGet(f, 13),
                    Buy3Vol = SafeGetLong(f, 14), Buy3Price = SafeGet(f, 15),
                    Buy4Vol = SafeGetLong(f, 16), Buy4Price = SafeGet(f, 17),
                    Buy5Vol = SafeGetLong(f, 18), Buy5Price = SafeGet(f, 19),
                    // Sell 1-5
                    Sell1Vol = SafeGetLong(f, 20), Sell1Price = SafeGet(f, 21),
                    Sell2Vol = SafeGetLong(f, 22), Sell2Price = SafeGet(f, 23),
                    Sell3Vol = SafeGetLong(f, 24), Sell3Price = SafeGet(f, 25),
                    Sell4Vol = SafeGetLong(f, 26), Sell4Price = SafeGet(f, 27),
                    Sell5Vol = SafeGetLong(f, 28), Sell5Price = SafeGet(f, 29),
                    // Trailing
                    TradeDate = SafeGet(f, 30),
                    TradeTime = SafeGet(f, 31),
                    StatusCode = SafeGet(f, 32)
                };
                results.Add(point);
            }
            return results;
        }

        private static string SafeGet(string[] arr, int idx)
            => (idx < arr.Length) ? arr[idx].Trim() : string.Empty;

        private static long SafeGetLong(string[] arr, int idx)
        {
            if (idx >= arr.Length) return 0;
            long.TryParse(arr[idx].Trim(), out long val);
            return val;
        }
    }
}
