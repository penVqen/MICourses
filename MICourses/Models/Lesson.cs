﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MICourses.Models;

public partial class Lesson
{
    [Key]
    public int ID_Lesson { get; set; }

    public int ID_Course { get; set; }

    public int Number { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [Required]
    [StringLength(1000)]
    public string Description { get; set; }

    [Required]
    public string Text { get; set; }

    [InverseProperty("ID_LessonNavigation")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    [ForeignKey("ID_Course")]
    [InverseProperty("Lessons")]
    public virtual Course ID_CourseNavigation { get; set; }

    [InverseProperty("ID_LessonNavigation")]
    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();

    [InverseProperty("ID_LessonNavigation")]
    public virtual ICollection<Users_Lesson> Users_Lessons { get; set; } = new List<Users_Lesson>();
}