﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryPattern.Take2
{
    public class DropdownMenu
    {
        public DropdownMenu()
            => new Button { Type = "Default Button" };
    }
}
