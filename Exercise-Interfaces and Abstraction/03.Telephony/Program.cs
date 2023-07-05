using System;
using System.Linq;
using _03.Telephony;

string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] urlLinks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

ICallable phone;
foreach (string number in numbers)
{

    if (number.Length == 10)
    {
        phone = new SmartPhone();
    }
    else
    {
        phone = new StationaryPhone();
    }
    try
    {
        Console.WriteLine(phone.Call(number));
    }
    catch(Exception ex) 
    {
        Console.WriteLine(ex.Message);
    }
        

}
IBrowseable browseable = new SmartPhone();

foreach (string urlLink in urlLinks)
{
    try
    {
        Console.WriteLine(browseable.Browse(urlLink));
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
}
