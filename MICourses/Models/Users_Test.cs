﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MICourses.Models;

public partial class Users_Test
{
    [Key]
    public int ID_Users_Tests { get; set; }

    public int ID_User { get; set; }

    public int ID_Test { get; set; }

    public int? Score { get; set; }

    [ForeignKey("ID_Test")]
    [InverseProperty("Users_Tests")]
    public virtual Test ID_TestNavigation { get; set; }

    [ForeignKey("ID_User")]
    [InverseProperty("Users_Tests")]
    public virtual User ID_UserNavigation { get; set; }
}