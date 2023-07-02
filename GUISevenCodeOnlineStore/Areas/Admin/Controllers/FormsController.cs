using GUISevenCodeOnlineStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GUISevenCodeOnlineStore.Controllers
{
    [Area("Admin")]
    public class FormsController : Controller
    {
        private List<City> cities;
        private List<State> states;

        public FormsController()
        {
            cities = new List<City>();
            states = new List<State>();

            states.Add(new State() { StateID=1,stateName="Egypt"});
            states.Add(new State() { StateID=2,stateName="Minya"});

            cities.Add(new City() { StateID = 1, CityID = 1, cityName = "Maddi" });
            cities.Add(new City() { StateID = 1, CityID = 2, cityName = "Misr City" });
            cities.Add(new City() { StateID = 2, CityID = 3, cityName = "Beni Mazar" });
            cities.Add(new City() { StateID = 1, CityID = 4, cityName = "October" });
            cities.Add(new City() { StateID = 2, CityID = 5, cityName = "Samoulte" });
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult testing()
        {
            IEnumerable<SelectListItem> listItems = (
                from obj in states
                select new SelectListItem()
                {
                    Text = obj.stateName,
                    Value = obj.StateID.ToString()
                }
                ).ToList();
            return View(listItems);
        }

        public PartialViewResult GetCity(int stateid)
        {
            IEnumerable<SelectListItem> selectListItems =
            (
                from obj in cities
                where obj.StateID == stateid
                select new SelectListItem()
                {
                    Value = obj.CityID.ToString(),
                    Text = obj.cityName
                }
            ).ToList();

            return PartialView("_CityPartial",selectListItems);
        }
    }
}
