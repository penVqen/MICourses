﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MICourses.Models;

public partial class Course
{
    public int ID_Course { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string StudyPeriod { get; set; }

    public string Language { get; set; }

    public bool ForBeginners { get; set; }
}