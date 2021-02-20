using Project2021Sales.Data;
using Project2021Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project2021Sales.Services
{
    public class DepartmentService
    {
        private readonly Project2021SalesContext _context;

        public DepartmentService(Project2021SalesContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
