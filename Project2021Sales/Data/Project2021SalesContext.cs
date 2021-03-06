﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2021Sales.Models;

namespace Project2021Sales.Data
{
    public class Project2021SalesContext : DbContext
    {
        public Project2021SalesContext (DbContextOptions<Project2021SalesContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
    }
}
