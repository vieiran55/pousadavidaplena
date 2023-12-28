using Microsoft.EntityFrameworkCore;
using PousadaVidaPlena.Data; // Certifique-se de ajustar o namespace conforme o seu projeto
using PousadaVidaPlena.Models; // Certifique-se de ajustar o namespace conforme o seu projeto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PousadaVidaPlena.Services
{
    public class ReservationRecordService
    {
        private readonly PousadaContext _context; // Certifique-se de ajustar para o contexto do seu projeto

        public ReservationRecordService(PousadaContext context) // Certifique-se de ajustar para o contexto do seu projeto
        {
            _context = context;
        }

        public async Task<List<Reservation>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Reservation select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.CheckInDate >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.CheckOutDate <= maxDate.Value);
            }
            return await result
                .Include(x => x.Client)
                .Include(x => x.Employee)
                .Include(x => x.Room)
                .OrderByDescending(x => x.CheckInDate)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Employee, Reservation>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Reservation select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.CheckInDate >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.CheckOutDate <= maxDate.Value);
            }
            return await result
                .Include(x => x.Client)
                .Include(x => x.Employee)
                .Include(x => x.Room)
                .OrderByDescending(x => x.CheckInDate)
                .GroupBy(x => x.Employee) // Certifique-se de ajustar para a propriedade do departamento no seu modelo Employee
                .ToListAsync();
        }
    }
}
