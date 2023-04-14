using Labb1EntityFrameWork.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1EntityFrameWork.Data
{
    public class VacationContext : DbContext
    {
        public VacationContext()
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Vacation> MyProperty { get; set; }
    }
}
