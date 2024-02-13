using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Enums;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetUser()
        {
            return await _context.Users.OrderByDescending(user => user.Orders.Count()).FirstAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.Where(user => user.Status == UserStatus.Inactive).ToListAsync();
        }
    }
}
