//this class is used to handle our db tables

using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDBContext : DbContext

    //constructor

    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }



    public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }


    }
}


    
    

