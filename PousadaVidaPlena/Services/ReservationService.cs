using PousadaVidaPlena.Data;
using PousadaVidaPlena.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using PousadaVidaPlena.Services.Exceptions;

namespace PousadaVidaPlena.Services
{
    public class ReservationService
    {
        private readonly PousadaContext _context;

        public ReservationService(PousadaContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> FindAllAsync()
        {
            return await _context.Reservation.ToListAsync();
        }

        public async Task InsertAsync(Reservation obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Reservation> FindByIdAsync(int id)
        {
            return await _context.Reservation.Include(obj => obj.Room).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Reservation.FindAsync(id);
                _context.Reservation.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(Reservation obj)
        {
            bool hasAny = await _context.Reservation.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}