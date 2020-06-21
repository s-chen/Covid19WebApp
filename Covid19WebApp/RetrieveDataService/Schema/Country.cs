namespace Covid19.Core.RetrieveDataService.Schema
{
    using Newtonsoft.Json;

    public class Country
    {
        [JsonProperty("Country")]
        public string Name { get; set; }

        [JsonProperty("Slug")]
        public string AltName { get; set; }

        [JsonProperty("ISO2")]
        public string Identifier { get; set; }
    }
}
