using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Entites
{
    public class House
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public float Price { get; set; }
        public int Rooms { get; set; }
        public int Size { get; set; }
        public HouseType Type { get; set; }
        public HouseState State { get; set;}
    }
}
