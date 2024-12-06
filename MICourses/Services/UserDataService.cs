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
        public async Task<User> AuthenticateUserAsync(string loginOrEmail, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => (u.Login == loginOrEmail || u.Email == loginOrEmail) && u.Password == password);

            return user; // Возвращаем пользователя, если логин и пароль корректны
        }


        /// <summary>
        /// Проверяет существование пользователя по логину или email.
        /// </summary>
        /// <param name="loginOrEmail">Логин или Email пользователя</param>
        /// <returns>True, если пользователь существует, иначе false.</returns>
        public async Task<bool> CheckUserExistsAsync(string loginOrEmail)
        {
            return await _context.Users
                .AnyAsync(u => u.Login == loginOrEmail || u.Email == loginOrEmail);
        }

        /// <summary>
        /// Проверяет правильность пароля для указанного логина или email.
        /// </summary>
        /// <param name="loginOrEmail">Логин или Email пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>True, если пароль правильный, иначе false.</returns>
        public async Task<bool> VerifyPasswordAsync(string loginOrEmail, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Login == loginOrEmail || u.Email == loginOrEmail);

            if (user == null)
            {
                return false;
            }

            return user.Password == password;
        }

        public async Task<bool> CheckUserExistsAsync(string login, string email)
        {
            return await _context.Users.AnyAsync(u => u.Login == login || u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

    }
}
