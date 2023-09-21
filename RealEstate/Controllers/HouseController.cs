using Microsoft.AspNetCore.Mvc;
using RealEstate.DTO;
using RealEstate.Entites;
using RealEstate.Exceptions;
using RealEstate.Extensions;
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
        public async Task<IEnumerable<HouseDTO>> GetAllAsync() // é um get que me vai retorna todas as houses que tiverem no repositorio
        {
            var houses = await _houseService.ListAsync();
            return houses.Select(house => house.ToDTO()); //select funciona como map
        }

        [HttpPost(Name = "AddHouse")]
        public async Task<HouseDTO> AddAsync([FromBody] HouseDTO houseDTO)
        {
            House house = houseDTO.ToEntity();
            House entity = await _houseService.RegisterAsync(house);
            return entity.ToDTO();
        }

        [HttpDelete("{id}", Name = "DeleteHouse")]
        public async Task DeleteAsync([FromRoute] int id)
        {
            await _houseService.DeleteAsync(id);
        }

        [HttpPut("Reserve/{id}", Name = "ReserveHouse")]
        public async Task ReserveAsync([FromRoute] int id, [FromBody] UserDto userDto)
        {
            User user = userDto.ToEntity();

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
            User user = userDto.ToEntity();

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
