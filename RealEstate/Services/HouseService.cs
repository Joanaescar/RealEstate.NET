using RealEstate.Database;
using RealEstate.Entites;
using RealEstate.Exceptions;
using RealEstate.Respositories;

namespace RealEstate.Services
{
    public class HouseService: IHouseService
    {
        private readonly IHouseRespository _houseRespository;
        private readonly IUserService _userService;
        public HouseService(IHouseRespository houseRespository, IUserService userService) {
            _houseRespository = houseRespository;
            _userService = userService;
        }

        public async Task DeleteAsync(int idHouse)
        {
            House house = await GetByIdAsync(idHouse);

            await _houseRespository.DeleteAsync(house);

            await _houseRespository.SaveAsync();
        }

        public async Task<House> GetByIdAsync(int idHouse)
        {
            House? house = await _houseRespository.FindByIdAsync(idHouse);

            return house ?? throw new HouseNotFoundException("House not found.");
        }

        public async Task<IEnumerable<House>> ListAsync()
        {
            return await _houseRespository.FindAllAsync();
        }

        public async Task<House> RegisterAsync(House house)
        {
            house.State = HouseState.Available;
            
            house = await _houseRespository.AddAsync(house);

            await _houseRespository.SaveAsync();

            return house;
        }

        public async Task ReserveAsync(int idHouse, int idUser)
        {
            House house = await GetByIdAsync(idHouse);

            if(house.State == HouseState.Reserved)
            {
                throw new HouseReservedException("House already reserved");
            }

            house.State = HouseState.Reserved;

            //user para ficar assignado a casa
            await _userService.AddHouseAsync(idUser, house);

            await _houseRespository.SaveAsync();
        }

        public async Task UnreserveAsync(int idHouse, int idUser)
        {

            House house = await GetByIdAsync(idHouse);

            if (house.State == HouseState.Available) 
            {
                throw new HouseAlreadyAvailableException("House is already available");
            }

            await _userService.RemoveHouseAsync(idUser, house);

            house.State = HouseState.Available;

            await _houseRespository.SaveAsync();
        }

    }
}
