using FoodGappBackend_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static FoodGappBackend_WebAPI.Utils.Utilities;

namespace FoodGappBackend_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class FoodLoggingController : BaseController
    {
        [HttpPost("createUserfood")]
        public IActionResult CreateUserFoodLog([FromBody] Food foodlog)
        {
            if(_foodLogMgr.CreateFood(foodlog, ref ErrorMessage) != ErrorCode.Success)
            {
                return BadRequest(new { error = "Food Log Error" });
            }

            return Ok(new { message = "Food Log Created Successfully"});
        }
    }
}
