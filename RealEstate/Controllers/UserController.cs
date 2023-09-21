using Microsoft.AspNetCore.Mvc;
using RealEstate.DTO;
using RealEstate.Entites;
using RealEstate.Extensions;
using RealEstate.Services;

namespace RealEstate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<UserDto> GetAsync([FromRoute]int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return user.ToDTO();
        }

        [HttpPost]
        public async Task<UserDto> CreateAsync([FromBody] UserDto userDto)
        {
            User user = userDto.ToEntity();
            var entity = await _userService.CreateAsync(user);
            return entity.ToDTO();
        }

        [HttpDelete("{id}")]
        public async Task RemoveAsync([FromRoute] int id)
        {
            await _userService.DeleteAsync(id);
        }

        [HttpPut("{id}")] 
        public async Task EditAsync([FromRoute] int id, [FromBody] UserDto userDto)
        {
            User user = userDto.ToEntity();
            await _userService.UpdateAsync(user);
        }

    }
}
