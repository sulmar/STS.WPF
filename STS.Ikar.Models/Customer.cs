﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.Models
{
    public class Customer : Base
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
