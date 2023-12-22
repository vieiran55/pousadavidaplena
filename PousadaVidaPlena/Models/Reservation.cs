// Reservation.cs
using System;
using System.ComponentModel.DataAnnotations;
using PousadaVidaPlena.Models.Enums;

namespace PousadaVidaPlena.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Client Client { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Cliente")]
        public int ClientId { get; set; }

        public Employee Employee { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Funcionário")]
        public int EmployeeId { get; set; }

        public Room Room { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Quarto")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data de Check-in")]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data de Check-out")]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Estado da Reserva")]
        public ReservationStatus ReservationStatus { get; set; }
        public Reservation() { }

        public Reservation(int id, Client client,
             Employee employee, Room room, DateTime checkInDate, DateTime checkOutDate,
            ReservationStatus reservationStatus)
        {
            Id = id;
            Client = client;
            Employee = employee;
            Room = room;

            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            ReservationStatus = reservationStatus;

        }
    }

}
