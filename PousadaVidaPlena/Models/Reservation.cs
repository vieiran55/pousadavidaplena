// Reservation.cs
using System;
using System.ComponentModel.DataAnnotations;
using PousadaVidaPlena.Models.Enums;

namespace PousadaVidaPlena.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Display(Name = "NrReservation#")]
        public int NrReservation { get; set; }
        public Client Client { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Cliente")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public Employee Employee { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Funcionário")]
        public int EmployeeId { get; set; }

        public Room Room { get; set; }
 
        [Display(Name = "Quarto")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data de Check-in")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data de Check-out")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Estado da Reserva")]
        public ReservationStatus ReservationStatus { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Valor Total")]
        [Range(100.0, 500000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ReservationAmount { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Observações")]
        public string Observations { get; set; }

        public Reservation() { }

        public Reservation(int id, int nrReservation, Client client,
             Employee employee, Room room, DateTime checkInDate, DateTime checkOutDate,
            ReservationStatus reservationStatus, double reservationAmount, string observations)
        {
            Id = id;
            NrReservation = nrReservation;
            Client = client;
            Employee = employee;
            Room = room;

            CheckInDate = new DateTime(checkInDate.Year, checkInDate.Month, checkInDate.Day, 14, 0, 0);
            CheckOutDate = new DateTime(checkOutDate.Year, checkOutDate.Month, checkOutDate.Day, 12, 0, 0);
            ReservationStatus = reservationStatus;
            ReservationAmount = reservationAmount;
            Observations = observations;  // Adição da propriedade de observações
        }
    }

}
