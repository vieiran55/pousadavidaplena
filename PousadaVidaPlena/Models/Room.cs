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

        public double Price
        {
            get
            {
                // Lógica para determinar o preço com base no RoomType
                switch (Type)
                {
                    case RoomType.Standard:
                        return 100.00; // Define o preço para o tipo Standard
                    case RoomType.Executivo:
                        return 150.00; // Define o preço para o tipo Executivos
                    case RoomType.Deluxe:
                        return 200.00; // Define o preço para o tipo Deluxe
                    default:
                        return 0.00; // Valor padrão ou tratamento de erro
                }
            }
        }

        public static List<Room> Rooms = new List<Room>();

        public Room() { }

        public Room(int id, int roomNumber, RoomType type, RoomStatus status)
        {
            Id = id;
            RoomNumber = roomNumber;
            Type = type;
            Status = status;
        }

        // Método para adicionar um quarto à lista
        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }
    }
}
