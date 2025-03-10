using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodGappBackend_WebAPI.Models;

[Table("UserRole")]
public partial class UserRole
{
    [Key]
    [Column("UserRole")]
    public int UserRole1 { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }
}
