using PousadaVidaPlena.Data;
using PousadaVidaPlena.Models;
using Microsoft.EntityFrameworkCore;

namespace PousadaVidaPlena.Services
{
    public class EmployeeService
    {
        private readonly PousadaContext _context;

        public EmployeeService(PousadaContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> FindAllAsync()
        {
            return await _context.Employee.OrderBy(x => x.Name).ToListAsync();
        }
    }
}