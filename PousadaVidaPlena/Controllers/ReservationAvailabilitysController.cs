using Microsoft.AspNetCore.Mvc;
using PousadaVidaPlena.Services;
using System;
using System.Threading.Tasks;

namespace PousadaVidaPlena.Controllers
{
    public class ReservationAvailabilitysController : Controller
    {
        private readonly ReservationAvailabilityService _reservationAvailabilityService;

        public ReservationAvailabilitysController(ReservationAvailabilityService reservationAvailabilityService)
        {
            _reservationAvailabilityService = reservationAvailabilityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchAvailableRooms()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchAvailableRooms(DateTime checkInDate, DateTime checkOutDate)
        {
            var availableRooms = _reservationAvailabilityService.GetAvailableRooms(checkInDate, checkOutDate);

            ViewData["CheckInDate"] = checkInDate.ToString("dd/MM/yyyy");
            ViewData["CheckOutDate"] = checkOutDate.ToString("dd/MM/yyyy");

            return View(availableRooms);
        }
    }
}
