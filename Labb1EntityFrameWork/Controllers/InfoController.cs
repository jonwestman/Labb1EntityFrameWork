using Labb1EntityFrameWork.Data;
using Labb1EntityFrameWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb1EntityFrameWork.Controllers
{
    public class InfoController : Controller
    {
        private readonly VacationContext _ctx;
        public InfoController(VacationContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<IActionResult> Index()
        {
            List<InfoViewModel> list = new List<InfoViewModel>();
            var items = await (from emp in _ctx.Employees
                               join vl in _ctx.VacationLists on emp.EmployeeId equals vl.FK_EmployeeId
                               join va in _ctx.Vacations on vl.FK_VacationId equals va.VacationId
                               select new
                               {
                                   FirstName = emp.FirstName,
                                   LastName = emp.LastName,
                                   VacayType=va.VacayType,
                                   StartDate=vl.StartDate, 
                                   EndDate=vl.EndDate

                               }
                               ).ToListAsync();
            foreach (var item in items)
            {
                InfoViewModel listItem = new InfoViewModel();
                listItem.FirstName = item.FirstName;
                listItem.LastName = item.LastName;
                list.Add(listItem);
            }

            return View(list);
        }
    }
}
