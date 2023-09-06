using RealEstate.Entites;
using System.Net.NetworkInformation;

namespace RealEstate.DTO
{
    public class HouseDTO
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int Rooms { get; set; }
        public int Size { get; set; }
        public HouseType Type { get; set; }
        public HouseState State { get; set; }



        public static HouseDTO fromModel(House house)
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

        public static House fromDTO(HouseDTO houseDto)
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
    }

}
