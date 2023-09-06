using RealEstate.Entites;

namespace RealEstate.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }


        public static UserDto fromModel(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
            };
        }

        public static User fromDto(UserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                Username = dto.Username,
            };
        }
    }
}
