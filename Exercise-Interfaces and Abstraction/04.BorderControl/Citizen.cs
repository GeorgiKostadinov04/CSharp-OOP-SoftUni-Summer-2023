using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.BorderControl.Interfaces;

namespace _04.BorderControl
{
    public class Citizen : IId , IBirthdate, IBuyer
    {
        public Citizen(string name, int age, string id, string birthDate) 
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthDate;
            Food = 0;
        }

        

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
