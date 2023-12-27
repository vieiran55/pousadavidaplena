﻿// ReservationsController.cs
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PousadaVidaPlena.Data;
using PousadaVidaPlena.Models;
using PousadaVidaPlena.Models.ViewModels;
using PousadaVidaPlena.Services;
using SalesCurso.Services;

public class ReservationsController : Controller
{
    private readonly PousadaContext _context;
    private readonly RoomService _roomService;
    private readonly ClientService _clientService;
    private readonly EmployeeService _employeeService;
    private readonly ReservationService _reservationService;

    public ReservationsController(PousadaContext context, RoomService roomService, ClientService clientService, EmployeeService employeeService, ReservationService reservationService)
    {
        _context = context;
        _roomService = roomService;
        _clientService = clientService;
        _employeeService = employeeService;
        _reservationService = reservationService;
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
    // POST: Reservations/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Reservation reservation)
    {
 
  
            await _reservationService.InsertAsync(reservation);
            return RedirectToAction(nameof(Index));
        


    }

    // GET: Reservations/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var reservation = await _context.Reservation.FindAsync(id);
        if (reservation == null)
        {
            return NotFound();
        }
        ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", reservation.ClientId);
        ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Name", reservation.EmployeeId);
        ViewData["RoomId"] = new SelectList(_context.Room, "Id", "RoomNumber", reservation.RoomId);
        return View(reservation);
    }

    // ... (implementar os métodos restantes como Delete, etc.)
}
