using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PousadaVidaPlena.Data;
using PousadaVidaPlena.Models;
using System.Linq;
using System.Threading.Tasks;

public class RoomsController : Controller
{
    private readonly PousadaContext _context;

    public RoomsController(PousadaContext context)
    {
        _context = context;
    }

    // GET: Quarto
    public async Task<IActionResult> Index()
    {
        var quartos = await _context.Room.ToListAsync();
        return View(quartos);
    }


    // GET: Quarto/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var quarto = await _context.Room
            .FirstOrDefaultAsync(m => m.Id == id);
        if (quarto == null)
        {
            return NotFound();
        }

        return View(quarto);
    }

    // GET: Rooms/Details/5
    public async Task<IActionResult> RoomDetails(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var room = await _context.Room
            .FirstOrDefaultAsync(m => m.Id == id);

        if (room == null)
        {
            return NotFound();
        }

        // Retorne os detalhes do quarto em formato JSON
        return Json(new
        {
            RoomNumber = room.RoomNumber,
            Type = room.Type.ToString(),
            Status = room.Status.ToString(),
            Price = room.Price
            // Adicione outras propriedades conforme necessário
        });
    }

    // GET: Quarto/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Quarto/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,RoomNumber,Type,Status,Price")] Room quarto)
    {
        // Verificar se o número do quarto já existe
        if (_context.Room.Any(r => r.RoomNumber == quarto.RoomNumber))
        {
            ModelState.AddModelError("RoomNumber", "Já existe um quarto com este número.");
            return View(quarto);
        }

        if (ModelState.IsValid)
        {
            _context.Add(quarto);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Quarto adicionado com sucesso!";
            return RedirectToAction(nameof(Index));
        }
        return View(quarto);
    }

    // GET: Quarto/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var quarto = await _context.Room.FindAsync(id);
        if (quarto == null)
        {
            return NotFound();
        }
        return View(quarto);
    }

    // POST: Quarto/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,RoomNumber,Type,Status,Price")] Room quarto)
    {
        // Verificar se o número do quarto já existe
        if (_context.Room.Any(r => r.RoomNumber == quarto.RoomNumber && r.Id != quarto.Id))
        {
            ModelState.AddModelError("RoomNumber", "Já existe um quarto com este número.");
            return View(quarto);
        }

        if (id != quarto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(quarto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(quarto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(quarto);
    }

    // GET: Quarto/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var quarto = await _context.Room
            .FirstOrDefaultAsync(m => m.Id == id);
        if (quarto == null)
        {
            return NotFound();
        }

        return View(quarto);
    }

    // POST: Quarto/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var quarto = await _context.Room.FindAsync(id);
        _context.Room.Remove(quarto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RoomExists(int id)
    {
        return _context.Room.Any(e => e.Id == id);
    }
}
