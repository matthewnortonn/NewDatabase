using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NewDatabase.Models
{
    public class Context : DbContext
    {
        //Constructor
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categorys { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
           mb.Entity<Category>().HasData(
              new Category { CategoryId = 1, CategoryName="Home"},
               new Category { CategoryId = 2, CategoryName = "School" },
               new Category { CategoryId = 3, CategoryName = "Work" },
               new Category { CategoryId = 4, CategoryName = "Church" }
               );

        
        }
    }
}
