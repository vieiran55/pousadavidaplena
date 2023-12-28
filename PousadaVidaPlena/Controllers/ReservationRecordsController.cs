using Microsoft.AspNetCore.Mvc;
using PousadaVidaPlena.Services; // Certifique-se de ajustar o namespace conforme o seu projeto
using System;
using System.Threading.Tasks;
using PousadaVidaPlena.Models; // Certifique-se de ajustar o namespace conforme o seu projeto

namespace PousadaVidaPlena.Controllers
{
    public class ReservationRecordsController : Controller
    {
        private readonly ReservationRecordService _reservationRecordService;

        public ReservationRecordsController(ReservationRecordService reservationRecordService)
        {
            _reservationRecordService = reservationRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _reservationRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _reservationRecordService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
