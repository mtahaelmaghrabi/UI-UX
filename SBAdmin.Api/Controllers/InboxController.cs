using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SBAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InboxController : ControllerBase
    {
        // GET: api/Inbox
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Inbox/5
        [HttpGet("{id}", Name = "Get")]
        public int Get(int id)
        {
            Random rnd = new Random();
            return rnd.Next(1, 99);

        }
    }
}