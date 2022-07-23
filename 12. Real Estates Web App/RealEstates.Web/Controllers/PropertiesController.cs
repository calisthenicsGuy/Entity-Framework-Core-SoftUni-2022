using Microsoft.AspNetCore.Mvc;
using RealEstates.Services.Contracts;
using RealEstates.Services.Models.Properties;
using System.Collections;
using System.Collections.Generic;

namespace RealEstates.Web.Controllers
{
    public class PropertiesController : Controller
    {
        private IPropertyService propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        public IActionResult Search()
        {
            return this.View();
        }

        public IActionResult DoSearch(int minPrice, int maxPrice)
        {
            IEnumerable<PropertyViewDto> properties = this.propertyService.SearchByPrice(minPrice, maxPrice);
            return this.View(properties);
        }
    }
}
