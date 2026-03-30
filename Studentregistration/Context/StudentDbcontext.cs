using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Studentregistration.Models;

namespace Studentregistration.Context
{
    public class StudentDbcontext: IdentityDbContext
    {
        private readonly DbContextOptions _options;
        public StudentDbcontext(DbContextOptions options) : base(options)
        {
        
        _options = options;
        }
      public  DbSet<Course>courses { get; set; }
      public  DbSet<Batch> batches { get; set; }
      public  DbSet<StudentRegistration> students { get; set; }

        public DbSet<AccountRegister> Accounts { get; set; }
    }
}
