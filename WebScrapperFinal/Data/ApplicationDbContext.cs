using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WebScrapperFinal.Models;

namespace WebScrapperFinal.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UniversityCourses> UniversityCourses { get; set; }
        public DbSet<UniversityDocuments> UniversityDocument { get;set; }
      
       
    }
}
