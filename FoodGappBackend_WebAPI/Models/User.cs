using System;
using System.Collections.Generic;

namespace FoodGappBackend_WebAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<UserInfo> UserInfos { get; set; } = new List<UserInfo>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
