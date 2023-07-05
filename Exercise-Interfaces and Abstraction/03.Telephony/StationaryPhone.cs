using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (!ValidateNumber(number))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {number}";
        }

        private bool ValidateNumber(string number)
        {
            return number.All(c => char.IsDigit(c));
        }
    }
}
