// Reservation.cs
using PousadaVidaPlena.Models;
using PousadaVidaPlena.Models.Enums;

namespace PousadaVidaPlena.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public ReservationStatus Status { get; set; }
        public List<Disponibility> Disponibilities { get; set; } = new List<Disponibility>();


        public Reservation()
        {
        }

        public Reservation(int id, DateTime dataInicio, DateTime dataFim, int roomId, Room room, ReservationStatus status)
        {
            Id = id;
            DataInicio = dataInicio;
            DataFim = dataFim;
            RoomId = roomId;
            Room = room;
            Status = status;
        }
    }
}
