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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data de Check-out")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Estado da Reserva")]
        public ReservationStatus ReservationStatus { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Valor Total")]
        [Range(100.0, 500000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ReservationAmount { get; set; }
        [Display(Name = "Observações")]
        public string Observations { get; set; }

        public Reservation() { }

        public Reservation(int id, Client client,
             Employee employee, Room room, DateTime checkInDate, DateTime checkOutDate,
            ReservationStatus reservationStatus, double reservationAmount, string observations)
        {
            Id = id;
            Client = client;
            Employee = employee;
            Room = room;

            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            ReservationStatus = reservationStatus;
            ReservationAmount = reservationAmount;
            Observations = observations;  // Adição da propriedade de observações
        }
    }

}
