﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork.Models
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string SignKey { get; set; }
    }
}
