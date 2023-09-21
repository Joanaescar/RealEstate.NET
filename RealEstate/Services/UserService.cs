using RealEstate.Entites;
using RealEstate.Exceptions;
using RealEstate.Repositories;

namespace RealEstate.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddHouseAsync(int idUser, House house)
        {
            var user = await GetByIdAsync(idUser);

            if(user.Houses == null)
            {
                user.Houses = new List<House>();
            }

            user.Houses.Add(house);

            await _userRepository.SaveAsync();

        }

        public async Task<User> CreateAsync(User user)
        {
            var userTaken = await _userRepository.FindByUsernameAsync(user.Username); // já está a retorna valor logo existe aquele username

            if (userTaken != null)
            {
                throw new UserExistsException("Username is taken.");
            }
            user = await _userRepository.AddAsync(user);

            await _userRepository.SaveAsync();

            return user;
        }

        public async Task<User> GetByIdAsync(int idUser)
        {
            User? user = await _userRepository.FindByIdAsync(idUser);

            return user ?? throw new UserNotFoundException("Usernmame not found."); // como não há optional é a partir de ponto interrogação
            //este return o que esta a fazer é se o repositorio encontrar id retorna o user caso contrário retorna a exception criada
        }

        public async Task RemoveHouseAsync(int idUser, House house)
        {
            var user = await GetByIdAsync(idUser);

            var ownsHouse = user.Houses.Any(h => h.Id == house.Id); //verificar se o user tem alguma casa com aquele id

            if(!ownsHouse)
            {
                throw new HouseReservedByOtherException("House is already reserved");
            } 
            else
            {
                user.Houses.Remove(house);
                await _userRepository.SaveAsync();
            }
        }

        public async Task UpdateAsync(User user)
        {
            var existingUser = GetByIdAsync(user.Id);
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int idUser)
        {
            User user = await GetByIdAsync(idUser);

            await _userRepository.DeleteAsync(user);

            await _userRepository.SaveAsync();
        }
    }
}
