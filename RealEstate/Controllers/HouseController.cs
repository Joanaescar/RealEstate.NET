using Microsoft.AspNetCore.Mvc;
using RealEstate.DTO;
using RealEstate.Entites;
using RealEstate.Respositories;

namespace RealEstate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HouseController : ControllerBase // como extende do controller base ela adiciona automaticamente a dependencia
    {
        private readonly IHouseRespository _houseRepository;
        public HouseController(IHouseRespository houseRespository)
        {
            _houseRepository = houseRespository;
        }

        [HttpGet(Name = "GetHouses")] // é uma identificação
        public async Task<IEnumerable<House>> GetAllAsync() // é um get que me vai retorna todas as houses que tiverem no repositorio
        {
            return await _houseRepository.FindAllAsync();
        }

        [HttpPost(Name = "AddHouse")]
        public async Task<House> AddAsync([FromBody] HouseDTO houseDTO)
        {
            House house = HouseDTO.fromDTO(houseDTO);
            House entity = await _houseRepository.AddAsync(house);
            await _houseRepository.SaveAsync();
            return entity;
        }
    }
}
