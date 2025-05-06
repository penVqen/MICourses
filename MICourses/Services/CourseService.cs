using MICourses.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MICourses.Services
{
    public class CourseService
    {
        private readonly MIContext _context;

        public CourseService(MIContext context)
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

        /// <summary>
        /// Записать студента на курс и создать чат.
        /// </summary>
        public async Task EnrollStudentInCourse(int studentId, int courseId, int teacherId)
        {
            // Проверяем, не записан ли студент уже
            var existingEnrollment = await _context.Users_Courses
                .FirstOrDefaultAsync(uc => uc.ID_User == studentId && uc.ID_Course == courseId && !uc.Author);

            if (existingEnrollment == null)
            {
                var enrollment = new Users_Course
                {
                    ID_User = studentId,
                    ID_Course = courseId,
                    Status = false,
                    Author = false
                };
                _context.Users_Courses.Add(enrollment);
                await _context.SaveChangesAsync();
            }

            // Проверяем существование чата
            var existingChat = await _context.Chats
                .FirstOrDefaultAsync(c =>
                    c.StudentID == studentId &&
                    c.TeacherID == teacherId &&
                    c.CourseID == courseId);

            if (existingChat == null)
            {
                var chat = new Chat
                {
                    StudentID = studentId,
                    TeacherID = teacherId,
                    CourseID = courseId
                };
                _context.Chats.Add(chat);
                await _context.SaveChangesAsync();
            }
        }
    }
}