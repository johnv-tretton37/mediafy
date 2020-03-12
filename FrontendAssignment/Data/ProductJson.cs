using System.Text.Json.Serialization;

namespace FrontendAssignment.Data
{
    public class ProductJson
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("fromPrice")]
        public string FromPrice { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("timesViewed")]
        public int TimesViewed { get; set; }
    }
}