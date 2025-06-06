﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MICourses.Models;

public partial class Course
{
    [Key]
    public int ID_Course { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; }

    [Required]
    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    [StringLength(50)]
    public string StudyPeriod { get; set; }

    [Required]
    [StringLength(50)]
    public string Language { get; set; }

    public bool ForBeginners { get; set; }

    [InverseProperty("ID_CourseNavigation")]
    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    [InverseProperty("ID_CourseNavigation")]
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    [InverseProperty("ID_CourseNavigation")]
    public virtual ICollection<Users_Course> Users_Courses { get; set; } = new List<Users_Course>();
}