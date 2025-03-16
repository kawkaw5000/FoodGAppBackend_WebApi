using FoodGappBackend_WebAPI.Models;
using static FoodGappBackend_WebAPI.Utils.Utilities;

namespace FoodGappBackend_WebAPI.Repository
{
    public class UserManager
    {
        private readonly BaseRepository<User> _userRepo;
        private readonly BaseRepository<Role> _role;
        private readonly BaseRepository<UserRole> _userRole;

        public UserManager()
        {
            _userRepo = new BaseRepository<User>();
            _role = new BaseRepository<Role>();
            _userRole = new BaseRepository<UserRole>();
        }

        // Get User By UserId
        /// <summary>
        /// Get User acc by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>UserId</returns>
        public User GetUserById(int userId)
        {
            return _userRepo.Get(userId);
        }  

        public UserRole GetUsersRoleByUserId(int userId)
        {
            return _userRole._table.Where(ur => ur.UserId == userId).FirstOrDefault();
        }

        public Role GetRoleNameByRoleId(int? roleId)
        {
            return _role._table.Where(r => r.RoleId == roleId).FirstOrDefault();
        }

        // Get User by Email
        /// <summary>
        /// Get User account using Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>True</returns>
        public User GetUserByEmail(string email)
        {
            return _userRepo._table.Where(e => e.Email == email).FirstOrDefault();
        }

        // SignIn user
        /// <summary>
        /// Check the Email and Password match from the database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="errMsg"></param>
        /// <returns>Success if matched, and Invalid if its not existed</returns>
        public ErrorCode SignIn(string email, string password, ref string errMsg)
        {
            var userSignIn = GetUserByEmail(email);
            if (userSignIn == null)
            {
                errMsg = "Invalid username or password.";
                return ErrorCode.Error;
            }

            if (!userSignIn.Password.Equals(password))
            {
                errMsg = "Invalid username or password.";
                return ErrorCode.Error;
            }

            errMsg = "Login Successfulss";
            return ErrorCode.Success;
        }

        // Create or Register Account
        /// <summary>
        /// Create Query to add new user to database
        /// </summary>
        /// <param name="u"></param>
        /// <param name="errMsg"></param>
        /// <returns>Success if the Email is not already existed</returns>
        public ErrorCode SignUp(User u, ref string errMsg)
        {
            if (GetUserByEmail(u.Email) != null)
            {
                errMsg = "Username Already Exist";
                return ErrorCode.Error;
            }

            if (_userRepo.Create(u, out errMsg) != ErrorCode.Success)
            {
                return ErrorCode.Error;
            }

            return ErrorCode.Success;
        }

    }
}
