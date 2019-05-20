using ChefSnacks.Core.Interfaces;
using ChefSnacks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Net;

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

        // GET: api/Snacks/Price/2e7bf943-7b46-42a8-9d53-130ce8eff10f
        [HttpGet("Price/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var snack = snackService.GetSnacks().FirstOrDefault(c => c.Id == id);

                if (snack == null)
                    return NotFound();

                var price = snackService.GetPrice(snack);

                return Ok(new
                {
                    Price = price,
                    PriceFormat = price.ToString("C", CultureInfo.CurrentCulture)
                });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        // GET: api/Snacks/PricePromotion/
        [HttpGet("PricePromotion")]
        public IActionResult Get([FromBody]CustomSnackModel model)
        {
            return Ok();
        }

        //// POST: api/Snacks
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Snacks/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
