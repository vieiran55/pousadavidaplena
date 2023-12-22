// ClientsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PousadaVidaPlena.Data;
using PousadaVidaPlena.Migrations;
using PousadaVidaPlena.Models;
using PousadaVidaPlena.Models.Enums;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

public class ClientsController : Controller
{
    private readonly PousadaContext _context;

    public ClientsController(PousadaContext context)
    {
        _context = context;
    }

    // GET: Clients
    public async Task<IActionResult> Index(string searchString)
    {

        // Lógica de busca aqui, por exemplo:
        var clients = await _context.Client
            .Where(c => string.IsNullOrEmpty(searchString) ||
            c.Name.Contains(searchString) ||
            c.Email.Contains(searchString) ||
            c.Cpf.Contains(searchString)) 

            .ToListAsync();

        return View(clients);
    }
    public IActionResult Create()
    {
        return View();
    }

    // POST: Clients/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Address,City,State,Country,PhoneNumber,Email,BirthDate,Gender,Nationality,Rg,Cpf")] Client client)
    {
        if (ModelState.IsValid)
        {
            if (_context.Employee.Any(e => e.PhoneNumber == client.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "PhoneNumber já cadastrado.");
                return View(client);
            }
            if (_context.Employee.Any(e => e.Email == client.Email))
            {
                ModelState.AddModelError("Email", "Email já cadastrado.");
                return View(client);
            }

            _context.Add(client);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Cliente adicionado com sucesso!";
            return RedirectToAction(nameof(Index));
        }
        return View(client);
    }

    // GET: Clients/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var client = await _context.Client.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        return View(client);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,City,State,Country,PhoneNumber,Email,BirthDate,Gender,Nationality,Rg,Cpf")] Client client, ClientEditAction submitButton)
    {
        if (id != client.Id)
        {
            return NotFound();
        }

        if (submitButton == ClientEditAction.EditClient)
        {
            // Lógica para edição de Client
            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(client);
                    await _context.SaveChangesAsync();

                    TempData["Message"] = "Cliente editado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        return View(client);
    }

    // GET: Clients/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var client = await _context.Client
            .FirstOrDefaultAsync(m => m.Id == id);
        if (client == null)
        {
            return NotFound();
        }

        return View(client);
    }

    // POST: Clients/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = await _context.Client.FindAsync(id);
        _context.Client.Remove(client);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ClientExists(int id)
    {
        return _context.Client.Any(e => e.Id == id);
    }

    // GET: Clients/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var client = await _context.Client
            .FirstOrDefaultAsync(m => m.Id == id);

        if (client == null)
        {
            return NotFound();
        }

        return View(client);
    }
}
