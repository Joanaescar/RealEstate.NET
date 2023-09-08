using RealEstate.Database;
using RealEstate.Entites;
using RealEstate.Respositories;

namespace RealEstate.Repositories
{
    public class HouseRepository : IHouseRespository
    {
        private readonly REDbContext _redbContext;
        public HouseRepository(REDbContext rEDbContext)
        {
            _redbContext = rEDbContext;
        }

        public void Delete(int idHouse)
        {
            var findHouse = _redbContext.Houses.Find(idHouse);
            if (findHouse != null)
            {
                _redbContext.Remove(findHouse);
            }
        }

        public IEnumerable<House> GetAll()
        {
            return _redbContext.Houses;
        }

        public House GetById(int idHouse)
        {
            return _redbContext.Houses.Find(idHouse);
        }

        public void Insert(House house)
        {
            _redbContext.Add(house);
        }

        public void Save()
        {
            _redbContext.SaveChanges();
        }

        public void Update(House house)
        {
            var houseDb = _redbContext.Houses.Find(house.Id);

            if (houseDb != null)
            {
                house.Price = houseDb.Price;
                house.State = houseDb.State;
                house.Rooms = houseDb.Rooms;
                house.Type = houseDb.Type;
                house.Size = houseDb.Size;
            }
        }
    }
}
