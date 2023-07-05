using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.BorderControl.Interfaces;

namespace _04.BorderControl
{
    public class Robot : IId
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; private set; }
        public string Id { get; private set; }

    }
}
