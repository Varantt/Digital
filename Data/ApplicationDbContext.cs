using Digital.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Digital.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }

        public DbSet <Approval> Approvals { get; set; }
    }
}
