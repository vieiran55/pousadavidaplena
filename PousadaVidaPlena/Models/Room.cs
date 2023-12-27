using PousadaVidaPlena.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PousadaVidaPlena.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Numero do Quarto")]
        [Range(101, 500, ErrorMessage = "{0} deve ser entre {1} e {2}")]
        public int RoomNumber { get; set; }

        public RoomType Type { get; set; }
        public RoomStatus Status { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Price")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Price { get; set; } // Agora inclui um setter

        public static List<Room> Rooms = new List<Room>();

        public Room() { }

        public Room(int id, int roomNumber, RoomType type, RoomStatus status, double price)
        {
            Id = id;
            RoomNumber = roomNumber;
            Type = type;
            Status = status;
            Price = price;
        }

        // Método para adicionar um quarto à lista
        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }
    }
}
