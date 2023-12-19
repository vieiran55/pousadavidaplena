using PousadaVidaPlena.Models.Enums;

namespace PousadaVidaPlena.Models
{
    public class Disponibility
    {
        public int Id { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public RoomStatus Status { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public Disponibility() { }

        public Disponibility(int id, DateTime dataInicio, DateTime dataFim, int roomId, Room room)
        {
            Id = id;
            DataInicio = dataInicio;
            DataFim = dataFim;
            RoomId = roomId;
            Room = room;
        }

        public void AtualizarStatus()
        {
            DateTime today = DateTime.Now.Date;

            // Verificar se o quarto está disponível com base nas datas
            if ((DataInicio <= today || DataInicio == null) && (DataFim >= today || DataFim == null))
            {
                Status = RoomStatus.Disponivel;
            }
            else
            {
                Status = RoomStatus.Indisponivel;
            }
        }
    }


}
