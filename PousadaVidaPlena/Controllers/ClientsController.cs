// ClientsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PousadaVidaPlena.Data;
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
    public async Task<IActionResult> Index()
    {
        var clients = await _context.Client.ToListAsync();
        return View(clients);
    }

    public IActionResult Create()
    {
        return View();
    }

    // POST: Clients/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Address,PhoneNumber,Email,Companions")] Client client)
    {
        if (ModelState.IsValid)
        {
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
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,PhoneNumber,Email")] Client client, ClientEditAction submitButton)
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
