using RealEstate.DTO;
using RealEstate.Entites;

namespace RealEstate.Extensions
{
    public static class ModelExtensions
    {

        public static HouseDTO ToDTO(this House house)
        {
            return new HouseDTO
            {
                Id = house.Id,
                Price = house.Price,
                Rooms = house.Rooms,
                Size = house.Size,
                Type = house.Type,
                State = house.State
            };
        }

        public static House ToEntity(this HouseDTO houseDto)
        {
            return new House
            {
                Id = houseDto.Id,
                Price = houseDto.Price,
                Rooms = houseDto.Rooms,
                Size = houseDto.Size,
                Type = houseDto.Type,
                State = houseDto.State
            };
        }

        public static UserDto ToDTO(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
            };
        }

        public static User ToEntity(this UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Username = userDto.Username,
                Password = userDto.Password,
                Email = userDto.Email,
            };
        }
    }
}
