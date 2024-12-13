using MICourses.Models;
using Microsoft.EntityFrameworkCore;

namespace MICourses.Services
{
    public interface IAchievementService
    {
        Task CheckAndAssignAchievements(int userId);
    }

    public class AchievementService : IAchievementService
    {
        private readonly MIContext _dbContext;

        public AchievementService(MIContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CheckAndAssignAchievements(int userId)
        {
            var achievements = await _dbContext.Achievments.ToListAsync();

            foreach (var achievement in achievements)
            {
                bool alreadyHas = await _dbContext.Users_Achievments
                    .AnyAsync(ua => ua.ID_User == userId && ua.ID_Achievment == achievement.ID_Achievment);

                if (alreadyHas)
                    continue;

                var query = achievement.Condition.Replace("@UserId", userId.ToString());
                int result = await _dbContext.Database.ExecuteSqlRawAsync(query);

                if (result > 0)
                {
                    var userAchievement = new Users_Achievment
                    {
                        ID_User = userId,
                        ID_Achievment = achievement.ID_Achievment
                    };

                    _dbContext.Users_Achievments.Add(userAchievement);
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
