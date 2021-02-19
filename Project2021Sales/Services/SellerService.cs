using Project2021Sales.Data;
using Project2021Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Project2021Sales.Services
{
    public class SellerService
    {
        private readonly Project2021SalesContext _context;

        public SellerService(Project2021SalesContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
