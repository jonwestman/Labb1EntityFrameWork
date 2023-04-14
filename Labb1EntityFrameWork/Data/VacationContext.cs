using Labb1EntityFrameWork.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1EntityFrameWork.Data
{
    public class VacationContext : DbContext
    {
        public VacationContext(DbContextOptions<VacationContext> options) :base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationList> VacationLists { get; set; }
        //public DbSet<Vacation> MyProperty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
