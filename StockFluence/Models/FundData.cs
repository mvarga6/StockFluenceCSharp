using Newtonsoft.Json;

namespace StockFluence.Models
{
    /// <summary>
    /// The primary fund data model.  All APIs return some 
    /// form of this model.
    /// </summary>
    public class FundData
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }

        [JsonProperty("sentimentscore")]
        public int? SentimentScore { get; set; }

        [JsonProperty("positive")]
        public int? Positive { get; set; }

        [JsonProperty("neutral")]
        public int? Neutral { get; set; }

        [JsonProperty("negative")]
        public int? Negative { get; set; }

        [JsonProperty("change")]
        public decimal? Change { get; set; }

        [JsonProperty("sentiment")]
        public string Sentiment { get; set; }

        [JsonProperty("strength")]
        public int? Strength { get; set; }

        [JsonProperty("passion")]
        public int? Passion { get; set; }

        [JsonProperty("reach")]
        public int? Reach { get; set; }

        [JsonProperty("quote")]
        public decimal? Quote { get; set; }

        [JsonProperty("prediction")]
        public decimal? Prediction { get; set; }

        [JsonProperty("prediction_sentiment")]
        public int? PredictionSentiment { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }
    }
}
