﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSalesProject.Models
    {
    public class Product
        {
        public int Id { get; set; }
        public string PartNbr { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string Photopath { get; set; }
        public int? VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public Product() { }
        }
    }
