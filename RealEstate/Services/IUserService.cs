using RealEstate.Entites;

namespace RealEstate.Services
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int idUser);
        Task<User> CreateAsync(User user);

        Task AddHouseAsync(int idUser, House house);

        Task RemoveHouseAsync(int idUser, House house);

        Task UpdateAsync(User user);

        Task DeleteAsync(int idUser);
    }
}
