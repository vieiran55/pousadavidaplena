// ReservationsController.cs
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PousadaVidaPlena.Data;
using PousadaVidaPlena.Models;
using PousadaVidaPlena.Models.ViewModels;
using PousadaVidaPlena.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ReservationsController : Controller
{
    private readonly PousadaContext _context;
    private readonly RoomService _roomService;
    private readonly ClientService _clientService;
    private readonly EmployeeService _employeeService;
    private readonly ReservationService _reservationService;
    private readonly ReservationValidationService _reservationValidationService;

    public ReservationsController(
        PousadaContext context,
        RoomService roomService,
        ClientService clientService,
        EmployeeService employeeService,
        ReservationService reservationService,
        ReservationValidationService reservationValidationService)
    {
        _context = context;
        _roomService = roomService;
        _clientService = clientService;
        _employeeService = employeeService;
        _reservationService = reservationService;
        _reservationValidationService = reservationValidationService;
    }

    // GET: Reservations
    public async Task<IActionResult> Index()
    {
        var reservations = await _context.Reservation
            .Include(r => r.Client)
            .Include(r => r.Employee)
            .Include(r => r.Room)
            .ToListAsync();

        return View(reservations);
    }


    [HttpGet]
    public IActionResult GetReservationAmount(string checkInDate, string checkOutDate, int roomId)
    {
        // Converta as strings de datas para objetos DateTime
        if (DateTime.TryParse(checkInDate, out DateTime parsedCheckInDate) &&
            DateTime.TryParse(checkOutDate, out DateTime parsedCheckOutDate))
        {
            // Faça a lógica necessária para calcular o valor da reserva com base nas datas e no quarto
            // Substitua a lógica abaixo pela lógica real do seu aplicativo
            var reservationAmount = CalculateReservationAmount(parsedCheckInDate, parsedCheckOutDate, roomId);

            // Retorne as informações da reserva em formato JSON
            return Json(new { price = reservationAmount });
        }

        // Se as datas não puderem ser convertidas, retorne um objeto vazio ou uma mensagem de erro
        return Json(new { });
    }

    private double CalculateReservationAmount(DateTime checkInDate, DateTime checkOutDate, int roomId)
    {
        // Substitua esta lógica pelo cálculo real do valor da reserva com base nas datas e no quarto
        // Esta é apenas uma lógica de exemplo
        // Você pode acessar o banco de dados ou usar qualquer outra lógica para calcular o preço
        var room = _context.Room.FirstOrDefault(r => r.Id == roomId);

        if (room != null)
        {
            // Adicione aqui a lógica para calcular o preço com base nas datas e no quarto
            var price = room.Price * (checkOutDate - checkInDate).TotalDays;
            return price;
        }

        return 0;
    }

    // GET: Reservations/Create
    public async Task<IActionResult> Create()
    {
        var clients = await _clientService.FindAllAsync();
        var rooms = await _roomService.FindAllAsync();
        var employees = await _employeeService.FindAllAsync();

        var viewModel = new ReservationCreateViewModel { Clients = clients, Rooms = rooms, Employees = employees };
        return View(viewModel);
    }

    // POST: Reservations/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Reservation reservation)
    {
        // Verifica se a reserva é válida usando o serviço de validação
        if (await _reservationValidationService.IsReservationValidAsync(reservation))
        {

            // Fixe as horas de check-in e check-out
            reservation.CheckInDate = new DateTime(reservation.CheckInDate.Year, reservation.CheckInDate.Month, reservation.CheckInDate.Day, 14, 0, 0);
            reservation.CheckOutDate = new DateTime(reservation.CheckOutDate.Year, reservation.CheckOutDate.Month, reservation.CheckOutDate.Day, 12, 0, 0);

            // Se a reserva for válida, insira-a
            var lastReserva = _context.Reservation.OrderByDescending(e => e.NrReservation).FirstOrDefault()?.NrReservation ?? 1000;
            reservation.NrReservation = (lastReserva == 0) ? 1001 : lastReserva + 1;
            await _reservationService.InsertAsync(reservation);
            return RedirectToAction(nameof(Index));
        }

        // Se a reserva não for válida, redirecione de volta ao formulário com uma mensagem de erro
        ModelState.AddModelError(string.Empty, "Já existe uma reserva para o quarto nas datas selecionadas.");
        var clients = await _clientService.FindAllAsync();
        var rooms = await _roomService.FindAllAsync();
        var employees = await _employeeService.FindAllAsync();
        var viewModel = new ReservationCreateViewModel { Clients = clients, Rooms = rooms, Employees = employees, Reservation = reservation };
        return View(viewModel);
    }

    // GET: Reservations/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not provided" });
        }

        var reservation = await _reservationService.FindByIdAsync(id.Value);

        if (reservation == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Reservation not found" });
        }

        var clients = await _clientService.FindAllAsync();
        var rooms = await _roomService.FindAllAsync();
        var employees = await _employeeService.FindAllAsync();

        var viewModel = new ReservationCreateViewModel
        {
            Clients = clients,
            Rooms = rooms,
            Employees = employees,
            Reservation = reservation
        };

        return View(viewModel);
    }

    // POST: Reservations/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Reservation reservation)
    {
        if (id != reservation.Id)
        {
            return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
        }

        try
        {
            await _reservationService.UpdateAsync(reservation);
            return RedirectToAction(nameof(Index));
        }
        catch (ApplicationException e)
        {
            return RedirectToAction(nameof(Error), new { message = e.Message });
        }
    }

    // GET: Reservations/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var reservation = await _context.Reservation
            .Include(r => r.Client)
            .Include(r => r.Employee)
            .Include(r => r.Room)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (reservation == null)
        {
            return NotFound();
        }
        return View(reservation);
    }

    public IActionResult GeneratePdf(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var reservation = _context.Reservation
            .Include(r => r.Client)
            .Include(r => r.Employee)
            .Include(r => r.Room)
            .FirstOrDefault(m => m.Id == id);

        if (reservation == null)
        {
            return NotFound();
        }

        // Gere o PDF com base nos dados da reserva
        byte[] pdfBytes = PdfGenerator.GenerateReservationPdf(reservation);

        // Retorne o PDF como um arquivo para download
        return File(pdfBytes, "application/pdf", $"Reservation_{id}.pdf");
    }

    // GET: Reservations/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var reservation = await _context.Reservation
            .Include(r => r.Client)
            .Include(r => r.Employee)
            .Include(r => r.Room)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (reservation == null)
        {
            return NotFound();
        }

        return View(reservation);
    }

    // POST: Reservations/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var reservation = await _context.Reservation.FindAsync(id);
        _context.Reservation.Remove(reservation);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


    // ... (implementar os métodos restantes como Delete, etc.)
}
