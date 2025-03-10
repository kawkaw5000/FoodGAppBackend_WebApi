using FoodGappBackend_WebAPI.Data;
using FoodGappBackend_WebAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodGappBackend_WebAPI.Controllers
{
    public class BaseController : Controller
    {
        public String ErrorMessage;
        public FoodGappDbContext _db;
        public UserManager _userMgr;

        public int UserId { get { var userId = Convert.ToInt32(User.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value); return userId; } }

        public BaseController()
        {
            ErrorMessage = String.Empty;
            _db = new FoodGappDbContext();
            _userMgr = new UserManager();
        }
    }
}
