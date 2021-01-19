using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreMockUp.Data;
using WebStoreMockUp.Entities;
using Microsoft.EntityFrameworkCore;


namespace WebStoreMockUp.Controllers
{
    /*Creating my own API Controller
         * Note the using .mvc has no view so the client has the view
         * We will be using Angular to setup the view of our app.....
        */
    [ApiController]
    [Route("api/[controller]")] //This tell the client where to find my Api controller

    public class UsersController : ControllerBase
    {
        //This called dependency injection
        private readonly DataContext _context; //gives us access within our class to our database via the dbContext

        //Retreving data from my database
        public UsersController(DataContext context)
        {
            _context = context;
        }

        //Were creating endpoints to check our database for information

        [HttpGet] //is used to send data to the clent to be seen from the server

        //Use "IEnumerable" for simple iterations through a collection of a specified type
        //Use List to return the values with the database or more complex features (sort, search, or manipulate)
        //Best Practices is when you need to get data from the database is to do it asynchronous for scaleability
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("{id}")] //is used to send data to the clent based on the id of the user

        //Use "IEnumerable" for simple iterations through a collection of a specified type
        //Use List to return the values with the database or more complex features (sort, search, or maniupate)
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //var user = _context.Users.Find(); //only needed if you pan on manipulating the data of the user
            return await _context.Customers.FindAsync(id);
        }
    }
}
