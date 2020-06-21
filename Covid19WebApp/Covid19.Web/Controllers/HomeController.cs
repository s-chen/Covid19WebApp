namespace Covid19.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Covid19.Core.RetrieveDataService;
    using Covid19.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRetrieveDataService retrieveDataService;

        public HomeController(ILogger<HomeController> logger, IRetrieveDataService retrieveDataService)
        {
            _logger = logger;
            this.retrieveDataService = retrieveDataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<ViewResult> Countries()
        {
            var countries = await this.retrieveDataService.GetCountriesAsync();
            return this.View(countries);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
