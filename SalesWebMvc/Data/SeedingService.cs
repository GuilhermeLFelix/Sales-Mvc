using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computers");

            Seller s1 = new Seller(1, "Bob Bronw", "bob@gmail.com", new DateTime(1998, 4, 21), 1000, d1);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000, SaleStatus.Billed, s1);

            _context.Department.AddRange(d1);
            _context.Seller.AddRange(s1);
            _context.SalesRecord.AddRange(sr1);

            _context.SaveChanges();
        }
    }
}
