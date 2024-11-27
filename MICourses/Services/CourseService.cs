﻿using MICourses.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MICourses.Services
{
    public class CourseService
    {
        private readonly MIDatabaseContext _context;

        public CourseService(MIDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить список всех курсов.
        /// </summary>
        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}