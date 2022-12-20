using Microsoft.EntityFrameworkCore;
using P1_ASP.Models;



namespace P1_ASP.Context
{
    public class ContextDB : DbContext
    {



        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {




        }
        public DbSet<ClassProjects> ClassProjects { get; set; }


    }
}