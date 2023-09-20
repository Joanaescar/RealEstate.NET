using Microsoft.AspNetCore.Mvc;
using RealEstate.DTO;
using RealEstate.Entites;
using RealEstate.Exceptions;
using RealEstate.Respositories;
using RealEstate.Services;

namespace RealEstate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HouseController : ControllerBase // como extende do controller base ela adiciona automaticamente a dependencia
    {
        private readonly IHouseService _houseService;
        public HouseController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        [HttpGet(Name = "GetHouses")] // é uma identificação
        public async Task<IEnumerable<House>> GetAllAsync() // é um get que me vai retorna todas as houses que tiverem no repositorio
        {
            return await _houseService.ListAsync();
        }

        [HttpPost(Name = "AddHouse")]
        public async Task<House> AddAsync([FromBody] HouseDTO houseDTO)
        {
            House house = HouseDTO.fromDTO(houseDTO);
            House entity = await _houseService.RegisterAsync(house);
            return entity;
        }

        [HttpDelete(Name = "DeleteHouse")]
        public async Task DeleteAsync([FromRoute] int id)
        {
            await _houseService.DeleteAsync(id);
        }

        [HttpPut("Reserve/{id}", Name = "ReserveHouse")]
        public async Task ReserveAsync([FromRoute] int id, [FromBody] UserDto userDto)
        {
            User user = UserDto.fromDto(userDto);

            if(user != null)
            {
                await _houseService.ReserveAsync(id, user.Id);
            }
            else
            {
                throw new UserNotFoundException("User not found.");
            }
       
        }

        [HttpPut("Unreserve/{id}", Name = "UnreserveHouse")]
        public async Task UnreserveAsync([FromRoute] int id, [FromBody] UserDto userDto)
        {
            User user = UserDto.fromDto(userDto);

            if (user != null)
            {
                await _houseService.UnreserveAsync(id, user.Id);
            }
            else
            {
                throw new UserNotFoundException("User not found.");
            }
        }
    }
}
