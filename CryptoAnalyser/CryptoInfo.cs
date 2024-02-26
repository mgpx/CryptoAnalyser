using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAnalyser
{
    //https://api.coinmarketcap.com/data-api/v3/cryptocurrency/listing?start=1&limit=200&sortBy=market_cap&sortType=desc&convert=USD&cryptoType=all&tagType=all&audited=false
    public class CryptoInfo
    {
        public Data data { get; set; }
        public Status status { get; set; }
    }

    
    public class AuditInfoList
    {
        public string coinId { get; set; }
        public string auditor { get; set; }
        public int auditStatus { get; set; }
        public object auditTime { get; set; }
        public string reportUrl { get; set; }
        public string score { get; set; }
        public string contractAddress { get; set; }
        public string contractPlatform { get; set; }
    }

    public class CryptoCurrencyList
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public List<string> tags { get; set; }
        public int cmcRank { get; set; }
        public int marketPairCount { get; set; }
        public double circulatingSupply { get; set; }
        public object selfReportedCirculatingSupply { get; set; }
        public double totalSupply { get; set; }
        public object maxSupply { get; set; }
        public int isActive { get; set; }
        public DateTime lastUpdated { get; set; }
        public DateTime dateAdded { get; set; }
        public List<Quote> quotes { get; set; }
        public bool isAudited { get; set; }
        public List<int> badges { get; set; }
        public List<AuditInfoList> auditInfoList { get; set; }
        public Platform platform { get; set; }
    }

    public class Data
    {
        public List<CryptoCurrencyList> cryptoCurrencyList { get; set; }
        public string totalCount { get; set; }
    }

    public class Platform
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public string token_address { get; set; }
    }

    public class Quote
    {
        public string name { get; set; }
        public double price { get; set; }
        public double volume24h { get; set; }
        public double marketCap { get; set; }
        public double percentChange1h { get; set; }
        public double percentChange24h { get; set; }
        public double percentChange7d { get; set; }
        public DateTime lastUpdated { get; set; }
        public double percentChange30d { get; set; }
        public double percentChange60d { get; set; }
        public double percentChange90d { get; set; }
        public double fullyDilluttedMarketCap { get; set; }
        public double marketCapByTotalSupply { get; set; }
        public double dominance { get; set; }
        public double turnover { get; set; }
        public double ytdPriceChangePercentage { get; set; }
        public double percentChange1y { get; set; }
        public double? tvl { get; set; }
    }


    public class Status
    {
        public DateTime timestamp { get; set; }
        public string error_code { get; set; }
        public string error_message { get; set; }
        public string elapsed { get; set; }
        public int credit_count { get; set; }
    }


}
