using SkiaSharp;
using System;
using System.IO;
using System.Linq;
using MICourses.Models;

namespace MICourses.Services
{
    public class CertificateService
    {
        public string GenerateAndSaveCertificate(int userId, int courseId, string templatePath, string saveDirectory, MIContext context)
        {
            var user = context.Users.FirstOrDefault(u => u.ID_User == userId);
            if (user == null) throw new Exception("User not found");
            string userName = $"{user.Surname} {user.Name} {user.MiddleName}".Trim();

            var course = context.Courses.FirstOrDefault(c => c.ID_Course == courseId);
            if (course == null) throw new Exception("Course not found");

            var teacherCourse = context.Users_Courses
                .FirstOrDefault(uc => uc.ID_Course == courseId && uc.Author);
            if (teacherCourse == null) throw new Exception("Course author not found");

            var teacher = context.Users.FirstOrDefault(u => u.ID_User == teacherCourse.ID_User);
            string teacherName = teacher != null ? $"{teacher.Surname} {teacher.Name[0]}. {teacher.MiddleName[0]}.".Trim() : "";

            string completionDate = DateTime.Now.ToString("dd.MM.yyyy");

            using var bitmap = SKBitmap.Decode(templatePath);
            using var canvas = new SKCanvas(bitmap);

            var paint = new SKPaint
            {
                TextSize = 14,
                IsAntialias = true,
                Color = SKColors.Black,
                Typeface = SKTypeface.FromFamilyName("Arial")
            };

            var font = new SKFont(paint.Typeface, 14);

            float startX = 350;
            float startY = 270;
            float lineSpacing = 50;

            DrawText(canvas, "Настоящий сертификат подтверждает, что", startX, startY, SKTextAlign.Left, font, paint);
            DrawText(canvas, userName, startX, startY + lineSpacing, SKTextAlign.Left, font, paint);
            canvas.DrawLine(startX, startY + lineSpacing + 5, startX + 400, startY + lineSpacing + 5, paint);

            DrawText(canvas, "Успешно прошел обучение на курсе", startX, startY + lineSpacing * 2, SKTextAlign.Left, font, paint);
            DrawText(canvas, course.Name, startX, startY + lineSpacing * 3, SKTextAlign.Left, font, paint);
            canvas.DrawLine(startX, startY + lineSpacing * 3 + 5, startX + 400, startY + lineSpacing * 3 + 5, paint);

            DrawText(canvas, "Дата", startX, startY + lineSpacing * 4, SKTextAlign.Left, font, paint);
            DrawText(canvas, completionDate, startX, startY + lineSpacing * 5, SKTextAlign.Left, font, paint);
            canvas.DrawLine(startX, startY + lineSpacing * 5 + 5, startX + 200, startY + lineSpacing * 5 + 5, paint);

            float teacherOffsetX = startX + 290;
            DrawText(canvas, "Преподаватель курса", teacherOffsetX, startY + lineSpacing * 4, SKTextAlign.Left, font, paint);
            DrawText(canvas, teacherName, teacherOffsetX, startY + lineSpacing * 5, SKTextAlign.Left, font, paint);
            canvas.DrawLine(teacherOffsetX, startY + lineSpacing * 5 + 5, teacherOffsetX + 200, startY + lineSpacing * 5 + 5, paint);

            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);

            string fileName = $"Certificate_{userId}_{courseId}.png";
            string filePath = Path.Combine(saveDirectory, fileName);

            if (!Directory.Exists(saveDirectory)) Directory.CreateDirectory(saveDirectory);
            File.WriteAllBytes(filePath, data.ToArray());

            var certificate = new Certificate
            {
                ID_User = userId,
                ID_Course = courseId,
                CompletionDate = DateTime.Now,
                CertificatePath = filePath
            };

            context.Certificates.Add(certificate);
            context.SaveChanges();

            return filePath;
        }

        private void DrawText(SKCanvas canvas, string text, float x, float y, SKTextAlign textAlign, SKFont font, SKPaint paint)
        {
            paint.TextAlign = textAlign;
            canvas.DrawText(text, x, y, font, paint);
        }
    }
}
