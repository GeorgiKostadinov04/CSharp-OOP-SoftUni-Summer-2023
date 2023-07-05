using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl
{
    public class Pet : IBirthdate
    {
        public Pet(string name, string birthDate) 
        {
            Name = name;
            Birthdate = birthDate;
        }

        public string Name { get; private set; }
        public string Birthdate { get; private set; }
    }
}
