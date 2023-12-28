using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PousadaVidaPlena.Data;
using PousadaVidaPlena.Models;

public class ReservationAvailabilityService
{
    private readonly PousadaContext _context;

    public ReservationAvailabilityService(PousadaContext context)
    {
        _context = context;
    }

    public List<Room> GetAvailableRooms(DateTime checkInDate, DateTime checkOutDate)
    {
        // Consulta para obter quartos disponíveis
        var availableRooms = _context.Room
            .Where(room => !_context.Reservation.Any(reservation =>
                reservation.RoomId == room.Id &&
                ((reservation.CheckInDate >= checkInDate && reservation.CheckInDate < checkOutDate) ||
                (reservation.CheckOutDate > checkInDate && reservation.CheckOutDate <= checkOutDate) ||
                (reservation.CheckInDate <= checkInDate && reservation.CheckOutDate >= checkOutDate))))
            .ToList();

        return availableRooms;
    }
}
