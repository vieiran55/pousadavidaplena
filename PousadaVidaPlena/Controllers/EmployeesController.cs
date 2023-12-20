// EmployeesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PousadaVidaPlena.Data;
using PousadaVidaPlena.Models;
using PousadaVidaPlena.Models.Enums;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

public class EmployeesController : Controller
{
    private readonly PousadaContext _context;

    public EmployeesController(PousadaContext context)
    {
        _context = context;
    }

    // GET: Employees
    public async Task<IActionResult> Index(string searchString)
    {
        // Lógica de busca aqui, por exemplo:
        var employees = await _context.Employee
            .Where(e => string.IsNullOrEmpty(searchString) ||
                        e.Name.Contains(searchString) ||
                        e.Email.Contains(searchString))
            .ToListAsync();

        return View(employees);
    }

    [HttpGet]
    public IActionResult Create()
    {
        // Lógica para ação Create com método GET
        return View();
    }

    // POST: Employees/Create
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Address,City,State,Country,PhoneNumber,Email,BirthDate,Gender,Nationality,Rg,Cpf,EmployeeFunction")] Employee employee)
    {
        if (ModelState.IsValid)
        {
            if (_context.Employee.Any(e => e.PhoneNumber == employee.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "PhoneNumber já cadastrado.");
                return View(employee);
            }
            if (_context.Employee.Any(e => e.Email == employee.Email))
            {
                ModelState.AddModelError("Email", "Email já cadastrado.");
                return View(employee);
            }
            if (_context.Employee.Any(e => e.Rg == employee.Rg))
            {
                ModelState.AddModelError("Rg", "Rg já cadastrado.");
                return View(employee);
            }

            if (_context.Employee.Any(e => e.Cpf == employee.Cpf))
            {
                ModelState.AddModelError("Cpf", "Cpf já cadastrado.");
                return View(employee);
            }
            // Lógica para gerar a Matricula automaticamente a partir de 1001
            var lastMatricula = _context.Employee.OrderByDescending(e => e.Matricula).FirstOrDefault()?.Matricula ?? 1000;
            employee.Matricula = (lastMatricula == 0) ? 1001 : lastMatricula + 1;

            _context.Add(employee);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Funcionário adicionado com sucesso!";
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }

    // GET: Employees/Edit/5
    // EmployeesController.cs
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _context.Employee
            .Where(e => e.Id == id)
            .Select(e => new Employee
            {
                Id = e.Id,
                Matricula = e.Matricula,
                Name = e.Name,
                Address = e.Address,
                City = e.City,
                State = e.State,
                Country = e.Country,
                PhoneNumber = e.PhoneNumber,
                Email = e.Email,
                BirthDate = e.BirthDate,
                Gender = e.Gender,
                Nationality = e.Nationality,
                Rg = e.Rg,
                Cpf = e.Cpf,
                EmployeeFunction = e.EmployeeFunction
            })
            .FirstOrDefaultAsync();

        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Matricula,Name,Address,City,State,Country,PhoneNumber,Email,BirthDate,Gender,Nationality,Rg,Cpf")] Employee employee)
    {
        if (id != employee.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {


                _context.Update(employee);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Funcionário editado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        return View(employee);
    }

    // GET: Employees/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _context.Employee
            .FirstOrDefaultAsync(m => m.Id == id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // POST: Employees/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var employee = await _context.Employee.FindAsync(id);
        _context.Employee.Remove(employee);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EmployeeExists(int id)
    {
        return _context.Employee.Any(e => e.Id == id);
    }

    // GET: Employees/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _context.Employee
            .FirstOrDefaultAsync(m => m.Id == id);

        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }
}
