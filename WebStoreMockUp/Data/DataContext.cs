using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStoreMockUp.Entities;

namespace WebStoreMockUp.Data
{
    //This acts as the bridge between my code and my database
    //This is achieved creating my own class that derives from DbContext class
    public class DataContext : DbContext
    {
        //Will add comment later
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        //Used to Query or Save instances of the class used to create my database set
        public DbSet<AppUser> Customers { get; set; }
    }
}
