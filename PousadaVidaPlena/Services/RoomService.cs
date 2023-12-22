using PousadaVidaPlena.Data;
using PousadaVidaPlena.Models;
using Microsoft.EntityFrameworkCore;

namespace PousadaVidaPlena.Services
{
    public class RoomService
    {
        private readonly PousadaContext _context;

        public RoomService(PousadaContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> FindAllAsync()
        {
            return await _context.Room.OrderBy(x => x.RoomNumber).ToListAsync();
        }
    }
}