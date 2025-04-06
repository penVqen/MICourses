﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MICourses.Models;

public partial class Test
{
    [Key]
    public int ID_Test { get; set; }

    public int ID_Lesson { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    [Required]
    [StringLength(1000)]
    public string Description { get; set; }

    public bool? IsFinal { get; set; }

    [ForeignKey("ID_Lesson")]
    [InverseProperty("Tests")]
    public virtual Lesson ID_LessonNavigation { get; set; }

    [InverseProperty("ID_TestNavigation")]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    [InverseProperty("ID_TestNavigation")]
    public virtual ICollection<Users_Test> Users_Tests { get; set; } = new List<Users_Test>();
}