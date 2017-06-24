﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlusConsultingCodeTestGrid.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public int SafetyStockLevel { get; set; }
        public int ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }

    }
}