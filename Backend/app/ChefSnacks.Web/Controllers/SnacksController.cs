using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChefSnacks.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChefSnacks.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Snacks")]
    public class SnacksController : Controller
    {
        private ISnackService snackService;

        public SnacksController(ISnackService snackService)
        {
            this.snackService = snackService;
        }
        // GET: api/Snacks
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(snackService.GetSnacks());
        }

        // GET: api/Snacks/5
        [HttpGet("Price/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(snackService.GetPrice(id));
        }

        // POST: api/Snacks
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Snacks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
