﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullstack.Core.Models
{
    public class Ingredient
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }

}

