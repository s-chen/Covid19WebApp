namespace Covid19.Core.RetrieveDataService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Covid19.Core.RetrieveDataService.Domain;
    using Flurl;
    using Flurl.Http;
    using Newtonsoft.Json;

    public class RetrieveDataService : IRetrieveDataService
    {
        private const string Covid19BaseUrl = "https://api.covid19api.com/";

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            var url = Covid19BaseUrl.AppendPathSegment("countries");
            var result = await url.GetStringAsync();

            var schema = JsonConvert.DeserializeObject<IEnumerable<Schema.Country>>(result);

            var countries = MapCountries(schema);

            return countries;
        }

        private static IEnumerable<Country> MapCountries(IEnumerable<Schema.Country> schema)
        {
            var countries = new List<Country>();

            foreach (var c in schema)
            {
                var country = new Country
                {
                    Name = c.Name,
                    AlternativeName = c.AltName,
                    IsoIdentifier = c.Identifier
                };

                countries.Add(country);
            }

            return countries;
        }
    }
}
