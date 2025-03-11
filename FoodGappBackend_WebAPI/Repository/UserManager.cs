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
        public User GetUserById(int userId)
        {
            return _userRepo.Get(userId);
        }  
        // Get User by Email
        public User GetUserByEmail(string email)
        {
            return _userRepo._table.Where(e => e.Email == email).FirstOrDefault();
        }

        // SignIn Register user
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

            errMsg = "Login Successful";
            return ErrorCode.Success;
        }

        // Create or Register Account
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

        public ErrorCode CreateRole (Role r, ref string errMsg)
        {
            if (_role.Create(r, out errMsg) != ErrorCode.Success)
            {
                return ErrorCode.Error;
            }

            return ErrorCode.Success;
        }

        public ErrorCode CreateUserRole(UserRole ur, ref string errMsg)
        {
            if(_userRole.Create(ur, out errMsg) != ErrorCode.Success)
            {
                return ErrorCode.Error;
            }

            return ErrorCode.Success;
        }

    }
}
