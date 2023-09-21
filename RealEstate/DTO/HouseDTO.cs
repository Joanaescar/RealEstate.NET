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
    }

}
