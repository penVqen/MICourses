using MICourses.Models;
using Microsoft.EntityFrameworkCore;

namespace MICourses.Services
{
    public class UserDataService
    {
        private readonly MIContext _context;

        public UserDataService(MIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Проверяет данные пользователя для входа.
        /// </summary>
        /// <param name="loginOrEmail">Логин или Email пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>True, если пользователь авторизован, иначе false.</returns>
        public async Task<bool> AuthenticateUserAsync(string loginOrEmail, string password)
        {
            // Ищем пользователя по логину или email
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Login == loginOrEmail || u.Email == loginOrEmail);

            // Проверяем, найден ли пользователь и совпадает ли пароль
            if (user != null && user.Password == password)
            {
                return true; // Пользователь успешно авторизован
            }

            return false; // Неверный логин/пароль
        }
    }
}
