using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstates.Services.Contracts;
using RealEstates.Services.Models.Districts;
using RealEstates.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstates.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDistrictService districtService;

        public HomeController(IDistrictService districtService)
        {
            this.districtService = districtService;
        }

        public IActionResult Index()
        {
            IEnumerable<DistrictViewDto> topDistrictByAveragePrice = this.districtService.GetTopDistrictsByAveragePrice(500);
            return View(topDistrictByAveragePrice);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
