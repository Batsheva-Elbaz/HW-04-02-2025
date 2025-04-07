using HW04_02_2025.Data;
using HW04_02_2025.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW04_02_2025.Web.Controllers
{
    public class HomeController : Controller
    { 
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=People;Integrated Security=true;TrustServerCertificate=yes;";
       
        public IActionResult Index()
        {
            return View();
        }

       public IActionResult ShowPeople()
        {
            var db = new Manager(_connectionString);
            var vm = new ShowPeopleModel
            {
               person = db.GetAll()
            };

            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult DeleteMany(List<int> ids)
        {
            var db = new Manager(_connectionString);
            db.DeleteMultiple(ids);
            TempData["message"] = $"{ids.Count} people deleted successfully";
            return Redirect("/home/ShowPeople");
        }
        public IActionResult ShowFurnitureAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(List<Person> p)
        {
            var db = new Manager(_connectionString);
            db.AddMultiple(p);
            TempData["message"] = $"{p.Count} People added successfully";
            return Redirect("/home/ShowPeople");
        }
    }
}
