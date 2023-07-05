using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    public class SmartPhone : ICallable, IBrowseable
    {
        public string Browse(string url)
        {
            if (!ValidateURL(url))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

      

        public string Call(string number)
        {
            if (!ValidateNumber(number))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {number}";
        }

        private bool ValidateNumber(string number)
        {
            return number.All(c => char.IsDigit(c));
        }

        private bool ValidateURL(string url)
        {
            return url.All(c => !char.IsDigit(c));
        }




    }
}
