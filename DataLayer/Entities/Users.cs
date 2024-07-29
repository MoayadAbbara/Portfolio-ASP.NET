using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities;

public partial class Users
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }
    public bool isAdmin {  get; set; }
}
