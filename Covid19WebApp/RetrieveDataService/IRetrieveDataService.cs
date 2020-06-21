namespace Covid19.Core.RetrieveDataService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Covid19.Core.RetrieveDataService.Domain;

    public interface IRetrieveDataService
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
    }
}