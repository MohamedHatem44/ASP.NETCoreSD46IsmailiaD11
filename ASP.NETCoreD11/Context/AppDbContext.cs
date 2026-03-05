using ASP.NETCoreD11.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreD11.Context
{
    public class AppDbContext : DbContext
    {
        /*------------------------------------------------------------------*/
        public AppDbContext() : base() { }
        /*------------------------------------------------------------------*/
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        /*------------------------------------------------------------------*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var _employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Ahmed", Age = 26 , Salary = 1234 },
                new Employee { Id = 2, Name = "Mohamed", Age = 36 , Salary = 2234 },
                new Employee { Id = 3, Name = "Sara", Age = 46 , Salary = 4234 },
                new Employee { Id = 4, Name = "Omar", Age = 25 , Salary = 5234 },
                new Employee { Id = 5, Name = "Ali", Age = 23 , Salary = 6234 },
                new Employee { Id = 6, Name = "Mai", Age = 36 , Salary = 7234 },
                new Employee { Id = 7, Name = "Ramy", Age = 49 , Salary = 8234 },
                new Employee { Id = 8, Name = "Hamada", Age = 18 , Salary = 9234 },
                new Employee { Id = 9, Name = "Hatem", Age = 26 , Salary = 10234 },
                new Employee { Id = 10, Name = "Osama", Age = 25 , Salary = 17234 },
            };

            modelBuilder.Entity<Employee>().HasData(_employees);
            base.OnModelCreating(modelBuilder);
        }
        /*------------------------------------------------------------------*/
        public virtual DbSet<Employee> Employees { get; set; }
        /*------------------------------------------------------------------*/
    }
}
