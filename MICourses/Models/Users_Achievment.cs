﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MICourses.Models;

public partial class Users_Achievment
{
    [Key]
    public int ID_Users_Achievments { get; set; }

    public int ID_User { get; set; }

    public int ID_Achievment { get; set; }

    [ForeignKey("ID_Achievment")]
    [InverseProperty("Users_Achievments")]
    public virtual Achievment ID_AchievmentNavigation { get; set; }

    [ForeignKey("ID_User")]
    [InverseProperty("Users_Achievments")]
    public virtual User ID_UserNavigation { get; set; }
}