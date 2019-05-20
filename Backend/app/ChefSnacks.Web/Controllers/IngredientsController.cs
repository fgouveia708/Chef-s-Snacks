using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ChefSnacks.Core.Entities;
using ChefSnacks.Core.Interfaces;
using ChefSnacks.Web.Models;
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

        // GET: api/Ingredients/PricePromotion/2e7bf943-7b46-42a8-9d53-130ce8eff10f/1
        [HttpGet("PricePromotion/{id}/{amount}")]
        public IActionResult Get(Guid id, int amount)
        {
            try
            {
                var ingredient = ingredientService.GetIngredients().FirstOrDefault(c => c.Id == id);

                if (ingredient == null)
                    return NotFound();

                return Ok(ingredientService.GetPricePromotion(ingredient, amount));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // GET: api/Ingredients/PricePromotion/
        [HttpPost("PricePromotion/")]
        public IActionResult Get([FromBody]IngredientModel model)
        {
            try
            {
                if (!model.Ingredients.Any())
                {
                    return BadRequest("Ingredientes devem ser maior que zero.");
                }
                else if (model.Total == 0)
                {
                    return BadRequest("Total deve ser maior que zero.");
                }

                return Ok(ingredientService.GetPricePromotion(model.Ingredients, model.Total));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
