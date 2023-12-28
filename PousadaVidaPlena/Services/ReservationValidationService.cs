// ReservationValidationService.cs
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PousadaVidaPlena.Data;
using PousadaVidaPlena.Models;

namespace PousadaVidaPlena.Services
{
    public class ReservationValidationService
    {
        private readonly PousadaContext _context;

        public ReservationValidationService(PousadaContext context)
        {
            _context = context;
        }

        public async Task<bool> IsReservationValidAsync(Reservation reservation)
        {
            // Verifica se existem reservas conflitantes para o quarto e datas/horas selecionadas
            var conflictingReservations = await _context.Reservation
                .Where(r =>
                    r.RoomId == reservation.RoomId &&
                    ((r.CheckInDate.Date == reservation.CheckInDate.Date && r.CheckInDate.TimeOfDay < reservation.CheckOutDate.TimeOfDay && r.CheckOutDate.TimeOfDay > reservation.CheckInDate.TimeOfDay) ||
                     (r.CheckOutDate.Date == reservation.CheckOutDate.Date && r.CheckOutDate.TimeOfDay > reservation.CheckInDate.TimeOfDay && r.CheckInDate.TimeOfDay < reservation.CheckOutDate.TimeOfDay) ||
                     (r.CheckInDate.Date < reservation.CheckInDate.Date && r.CheckOutDate.Date > reservation.CheckInDate.Date) ||
                     (r.CheckInDate.Date < reservation.CheckOutDate.Date && r.CheckOutDate.Date > reservation.CheckOutDate.Date) ||
                     (r.CheckInDate.Date >= reservation.CheckInDate.Date && r.CheckOutDate.Date <= reservation.CheckOutDate.Date)))
                .ToListAsync();

            // Se houver reservas conflitantes, a reserva não é válida
            return !conflictingReservations.Any();
        }
    }
}
