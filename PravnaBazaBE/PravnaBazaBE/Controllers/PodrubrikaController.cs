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
    [Route("api/Podrubrika")]
    [ApiController]
    public class PodrubrikaController : ControllerBase
    {
        obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();

        // GET: api/Podrubrika
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Podrubrika>>> Get()
        {
            return await _context.Podrubrika.ToListAsync();
        }



        // GET: api/Podrubrika/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Podrubrika>> Get(int id)
        {
            return await _context.Podrubrika.FindAsync(id);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<IEnumerable<Podrubrika>>> Post(int id)
        {
            var podrubrike = from p in _context.Podrubrika
                             where p.IdRubrika == id
                             select p;
            return await podrubrike.ToListAsync();
        }

        
      
    }
}
