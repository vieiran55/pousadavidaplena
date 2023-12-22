using PousadaVidaPlena.Data;
using PousadaVidaPlena.Models;
using Microsoft.EntityFrameworkCore;

namespace PousadaVidaPlena.Services
{
    public class ClientService
    {
        private readonly PousadaContext _context;

        public ClientService(PousadaContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> FindAllAsync()
        {
            return await _context.Client.OrderBy(x => x.Name).ToListAsync();
        }
    }
}