using RealEstate.Entites;

namespace RealEstate.Respositories
{
	public interface IHouseRespository
	{
		Task<IEnumerable<House>> FindAllAsync();

		Task<House?> FindByIdAsync(int idHouse); // retorna uma casa por id

		Task<House> AddAsync(House house);

		Task UpdateAsync(House house);

		Task DeleteAsync(House house);

		Task SaveAsync();
	}
}
