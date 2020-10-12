using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PravnaBazaBE.Models;

namespace PravnaBazaBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();
        // GET: api/Home
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rubrika>>> GetRubrika()
        {
            
            return await _context.Rubrika.ToListAsync();
        }

        // GET: api/Home/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Rubrika>> Get(int id)
        {
            return await _context.Rubrika.FindAsync(id);
        }

        
    }
}
