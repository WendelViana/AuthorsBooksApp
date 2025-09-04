using Newtonsoft.Json;

namespace AuthorsBooksApp.Models
{
    public class Book
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("price")]
        public double? Price { get; set; }
    }
}