using KursProjectLast.DAL.DatabaseContext;
using KursProjectLast.DAL.Repositories.IRepositories;
using KursProjectLast.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KursProjectLast.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<User> Add(User user)
        {
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Check(User user)
        {
            var test = _dataContext.Users.FirstOrDefault(m => m.UserName == user.UserName && m.Password == user.Password);
            if (test != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Delete(int userId)
        {
            User user = await _dataContext.Users.FindAsync(userId);
            user.IsDeleted = true;
            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<User>> Get()
        {
            List<User> users = await _dataContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> Get(int userId)
        {
            User user = await _dataContext.Users.FindAsync(userId);
            return user;
        }

        public async Task<User> Update(User user)
        {
            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }
    }
}
