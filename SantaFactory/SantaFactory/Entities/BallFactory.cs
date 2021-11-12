﻿using SantaFactory.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaFactory.Entities
{
   public class BallFactory : IToyFactory
    {
        public Toy CreateNew()
        {

            return new Car();
        }

      
    }
}
