using demoCRUD.Models;
using demoCRUD.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace demoCRUD.Controllers
{
    
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DAL empdal;
        public HomeController(ILogger<HomeController> logger, DAL employeeDAL)
        {
            _logger = logger;
            empdal = employeeDAL;
        }
        [HttpPost]
        public IActionResult AddEmployee([FromBody]Emp Employee)
        {
            if (Employee == null)
            {
                return BadRequest("Employee is null.");
            }
             empdal.Add(Employee.Name, Employee.Email,Employee.Phone);
            return Json("Employee added");
        }
        [HttpPost]
        public IActionResult UpdateEmployee([FromBody] Emp Employee)
        {
            
            empdal.updatemp(Employee.Id,Employee.Name,Employee.Email,Employee.Phone);
            return Json("Employee updated");
        }
        [HttpPost]
        public IActionResult DeleteEmployee([FromBody] Emp Employee)
        {
            empdal.deletemp(Employee.Id);
            return Json("Employee deleted");
        }
        [HttpGet]
        public IActionResult Index(string Search)
        {
            IEnumerable<Emp>  employees = empdal.getAll(Search);
            return View(employees);
        }

        public IActionResult create()
        {
            return View();
        }

        public IActionResult Edit()
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
