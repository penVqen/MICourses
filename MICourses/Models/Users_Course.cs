﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MICourses.Models;

public partial class Users_Course
{
    [Key]
    public int ID_Users_Courses { get; set; }

    public int ID_User { get; set; }

    public int ID_Course { get; set; }

    public bool Status { get; set; }

    public bool Author { get; set; }

    [ForeignKey("ID_Course")]
    [InverseProperty("Users_Courses")]
    public virtual Course ID_CourseNavigation { get; set; }

    [ForeignKey("ID_User")]
    [InverseProperty("Users_Courses")]
    public virtual User ID_UserNavigation { get; set; }
}