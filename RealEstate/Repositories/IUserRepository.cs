using RealEstate.Entites;

namespace RealEstate.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> FindAllAsync();

        Task<User?> FindByIdAsync(int idUser);

        Task<User?> FindByUsernameAsync(string username);

        Task<User> AddAsync(User user);
        Task DeleteAsync(User user);

        Task UpdateAsync(User user);

        Task SaveAsync();
    }
}
