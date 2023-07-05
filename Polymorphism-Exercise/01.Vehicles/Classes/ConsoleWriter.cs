using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Vehicles.Interfaces;

namespace _01.Vehicles.Classes
{
    internal class ConsoleWriter : IWriter
    {
        public void WriteLine(string value) => Console.WriteLine(value);
        
    }
}
