using _04.BorderControl;


int input = int.Parse(Console.ReadLine());
List<Citizen> namesOfCitizens = new();
List<Rebel> namesOfRebels = new();

for(int i = 0; i < input; i++)
{
    string[] arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if(arguments.Length  == 4)
    {
        Citizen person  = new Citizen(arguments[0], int.Parse(arguments[1]), arguments[2], arguments[3]);
        namesOfCitizens.Add(person);
    }
    else
    {
        Rebel rebel = new Rebel(arguments[0], int.Parse(arguments[1]), arguments[2]);
        namesOfRebels.Add(rebel);
    }
}

string name;
int result = 0;
bool foundName = false;

while((name = Console.ReadLine()) != "End")
{
    foreach(Citizen person in namesOfCitizens)
    {
        foundName = false;
        if(person.Name == name)
        {
            person.BuyFood();
            result += person.Food;
            person.Food = 0;
            foundName = true;
            break;
        }
    }
    if (foundName)
    {
        continue;
    }

    foreach(Rebel rebel in namesOfRebels)
    {
        if(rebel.Name == name)
        {
            rebel.BuyFood();
            result += rebel.Food;
            rebel.Food = 0;
            break;
        }
    }

}

Console.WriteLine(result);


