using MICourses.Models;

namespace MICourses.Services
{
    /// <summary>
    /// Сервис для управления текущим пользователем.
    /// </summary>
    public class CurrentUserService
    {
        private User _currentUser;

        /// <summary>
        /// Устанавливает текущего авторизованного пользователя.
        /// </summary>
        /// <param name="user">Объект пользователя.</param>
        public void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        /// <summary>
        /// Получает информацию о текущем пользователе.
        /// </summary>
        /// <returns>Объект пользователя или null, если пользователь не авторизован.</returns>
        public User GetCurrentUser()
        {
            return _currentUser;
        }

        /// <summary>
        /// Удаляет текущего пользователя (выход из системы).
        /// </summary>
        public void Logout()
        {
            _currentUser = null;
        }

        /// <summary>
        /// Проверяет, авторизован ли пользователь.
        /// </summary>
        /// <returns>True, если пользователь авторизован; иначе False.</returns>
        public bool IsAuthenticated()
        {
            return _currentUser != null;
        }
    }
}
