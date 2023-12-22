// ReservationCreateViewModel.cs
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using PousadaVidaPlena.Models.Enums;

namespace PousadaVidaPlena.Models.ViewModels
{
    public class ReservationCreateViewModel
    {
        public Reservation Reservation { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
