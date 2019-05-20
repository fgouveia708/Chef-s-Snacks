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
    [Route("api/Ingredients")]
    public class IngredientsController : Controller
    {
        private IIngredientService ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }
        // GET: api/Ingredients
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ingredientService.GetIngredients());
        }

        //// GET: api/Ingredients/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Ingredients
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Ingredients/5
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
