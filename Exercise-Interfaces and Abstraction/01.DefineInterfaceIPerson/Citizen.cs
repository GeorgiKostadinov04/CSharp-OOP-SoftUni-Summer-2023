

namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {

        public Citizen(string name, int age, string id, string brithdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = brithdate;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public string Birthdate { get; private set; }

        public string Id  { get; private set; }
    }
}
