using HW04_02_2025.Data;
using HW04_02_2025.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW04_02_2025.Web.Controllers
{
    public class HomeController : Controller
    {
        private static string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=People;Integrated Security=true;TrustServerCertificate=yes;";
        Manager db = new(_connectionString);

        public IActionResult Index()
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
            if(ids.Count != 0)
            {
                db.DeleteMultiple(ids);
                TempData["message"] = $"{ids.Count} people deleted successfully";

            }
            return Redirect("/");
        }
        

        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(List<Person> p)
        {
            var db = new Manager(_connectionString);
            db.AddMultiple(p);  
            TempData["message"] = $"{p.Count} People added successfully"; 
            return Redirect("/");
        }
    }
}
