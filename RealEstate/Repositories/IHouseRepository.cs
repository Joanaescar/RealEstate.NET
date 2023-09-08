using RealEstate.Entites;
using System;

namespace RealEstate.Respositories
{
	public interface IHouseRespository
	{
		IEnumerable<House> GetAll(); //retorna todas as casas

		House GetById(int idHouse); // retorna uma casa por id

		void Insert(House house);

		void Update(House house);

		void Delete(int idHouse);

		void Save();
	}
}
