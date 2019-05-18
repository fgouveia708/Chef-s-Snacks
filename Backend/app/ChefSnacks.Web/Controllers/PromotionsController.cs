using ChefSnacks.Core.Entities.Enum;
using ChefSnacks.Web.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ChefSnacks.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Promotions")]
    public class PromotionsController : Controller
    {
        // GET: api/Promotions
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(EnumHelper.Read<Promotion, PromotionAttribute>().Select(s => new
            {
                Value = s.Value,
                Name = s.Name,
                Description = s.Description
            }).OrderBy(o => o.Value));
        }

    }
}
