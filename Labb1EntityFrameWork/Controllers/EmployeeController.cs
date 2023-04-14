using Labb1EntityFrameWork.Data;
using Microsoft.AspNetCore.Mvc;

namespace Labb1EntityFrameWork.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly VacationContext _ctx;
        public EmployeeController(VacationContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
