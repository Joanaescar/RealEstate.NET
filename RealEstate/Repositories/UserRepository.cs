using Microsoft.EntityFrameworkCore;
using RealEstate.Database;
using RealEstate.Entites;

namespace RealEstate.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly REDbContext _context;
        public UserRepository(REDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
           var entity = await _context.Users.AddAsync(user);
            return entity.Entity;
        }

        public Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> FindAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> FindByIdAsync(int idUser)
        {
            return await _context.Users.FindAsync(idUser);
        }

        public async Task<User?> FindByUsernameAsync(string username)
        {
            return await _context.Users // uma lista de users que a base de dados contem
                .Where(u => u.Username.Equals(username)) // where é o filter onde filtramos pelo username passado na função
                .FirstOrDefaultAsync();// where retorna uma lista logo é queremos o primeiro ou null

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
