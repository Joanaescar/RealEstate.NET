using RealEstate.Entites;

namespace RealEstate.Services
{
    public interface IHouseService
    {
        Task<House> RegisterAsync(House house);
        Task<House> GetByIdAsync(int idHouse);
        Task<IEnumerable<House>> ListAsync();
        Task ReserveAsync(int idHouse, int idUser);
        Task UnreserveAsync(int idHouse, int idUser);
        Task DeleteAsync(int idHouse);
    }
}
