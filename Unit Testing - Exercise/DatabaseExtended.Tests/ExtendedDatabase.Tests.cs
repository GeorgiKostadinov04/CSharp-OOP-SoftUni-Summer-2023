namespace DatabaseExtended.Tests;

using System;
using ExtendedDatabase;
using NUnit.Framework;

[TestFixture]
public class ExtendedDatabaseTests
{

    [Test]
    public void PersonConstructorShouldSetValuesCorrectly()
    {
        string username = "George";
        long Id = 121212;

        Person person = new Person(Id, username);

        Assert.AreEqual(person.Id, Id);
        Assert.AreEqual(person.UserName, username);
    }


    [Test]
    public void CreatingDatabaseShouldBeCorrect()
    {
        //Arrange
        string username = "george";
        long id = 12121212;
        Person person = new Person(id, username);
        Person[] people = { person };
        Database database = new Database(people);
        int actualResult = database.Count;
        int expectedResult = 1;

        //Act
        //database = new Database(1, 2); - moved to setup

        Assert.AreEqual(actualResult, expectedResult);
    }

    [Test]
    public void DatabaseAddRangeMethodShouldThrowExceptionIfArrayHaveMoreThan16Elements()
    {
        string username = "george";
        long id = 12121212;
        Person person = new Person(id, username);
        Person[] people = new Person[17];

        for (int i = 0; i < people.Length; i++)
        {
            people[i] = person;
        }
        Database database = new Database();

        ArgumentException exception = Assert.Throws<ArgumentException>(() => database = new Database(people), "Provided data length should be in range [0..16]!");

        Assert.AreEqual("Provided data length should be in range [0..16]!", exception.Message);
    }

    [Test]
    public void DatabaseAddMethodShouldInceaseCount()
    {
        string username1 = "pesho";
        long id1 = 12;
        string username2 = "vanko";
        long id2 = 13;

        Person person1 = new Person(id1, username1);
        Person person2 = new Person(id2, username2);

        Database database = new Database(person1);

        database.Add(person2);

        int expectedResult = 2;
        int actualResult = database.Count;

        Assert.AreEqual(expectedResult, actualResult);

    }

    [Test]
    public void DatabaseAddMethodShouldThrowExceptionIfArraySizeIs16()
    {
        Person[] people =
              {
        new Person(1, "Pesho"),
        new Person(2, "Gosho"),
        new Person(3, "Ivan_Ivan"),
        new Person(4, "Pesho_ivanov"),
        new Person(5, "Gosho_Naskov"),
        new Person(6, "Pesh-Peshov"),
        new Person(7, "Ivan_Kaloqnov"),
        new Person(8, "Ivan_Draganchov"),
        new Person(9, "Asen"),
        new Person(10, "Jivko"),
        new Person(11, "Toshko"),
        new Person(12, "Moshko"),
        new Person(13, "Foshko"),
        new Person(14, "Loshko"),
        new Person(15, "Roshko"),
        new Person(16, "Boshko"),
        };
        Person person = new Person(17, "Otvara");
        Database database = new Database(people);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(person));

        Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
    }

    [Test]
    public void DatabaseAddMethodShouldThrowExceptionIfUsernameAlreadyExists()
    {
        Person person = new Person(1, "gogo");

        Database database = new Database(person);

        Person personTwo = new Person(2, "gogo");

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(personTwo));

        Assert.AreEqual("There is already user with this username!", exception.Message);

    }

    [Test]
    public void DatabaseAddMethodShouldThrowExceptionIfIdAlreadyExists()
    {
        Person person = new Person(1, "gogo");

        Database database = new Database(person);

        Person personTwo = new Person(1, "gogoo");

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(personTwo));

        Assert.AreEqual("There is already user with this Id!", exception.Message);
    }

    [Test]
    public void DatabaseRemoveMethodShouldDecreaseCountCorrectly()
    {
        Person[] people = {
            new Person(1, "gegata"),
            new Person(2, "andreikata")
        };

        Database database = new Database(people);
        database.Remove();
        int expectedResult = 1;

        Assert.AreEqual(expectedResult, database.Count);
    }

    [Test]
    public void DatabaseRemoveMethodShouldThrowExceptionIfCountIsZero()
    {
        Database database = new();

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Remove());

    }
    [TestCase("Georgi")]
    [TestCase("neno")]

    public void DatabaseFindByUserNameMethodShouldWorkCorrectly(string username)
    {
        Person person = new Person(1, username);
        Database database = new Database(person);

        Person actualPerson = database.FindByUsername(username);

        Assert.AreEqual(person, actualPerson);

    }
    [TestCase(null)]
    [TestCase("")]
    public void DatabaseFindByUsernameMethodShouldThrowExceptionIfUsernameIsNull(string username)
    {
        Database database = new();
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(()
            => database.FindByUsername(username));

        Assert.AreEqual("Username parameter is null!", exception.ParamName);
    }
    [TestCase("vanko")]
    [TestCase("Joro")]
    public void DatabaseFindByUsernameMethodShouldThrowExceptionIfUsernameDoesNotExsist(string username)
    {
        Database database = new();
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database.FindByUsername(username));

        Assert.AreEqual("No user is present by this username!", exception.Message);
    }

    [Test]
    public void DatabaseFindByNameMethodShouldBeCaseSensitive()
    {
        string expectedResult = "Googa";

        Database database = new(new Person(1, "googa"));
        string actualResult = database.FindByUsername("googa").UserName;

        Assert.AreNotEqual(expectedResult, actualResult);

    }
    [TestCase(1)]
    [TestCase(2)]
    public void DatabaseFindByIdMehtodShouldWorkCorrectly(long id)
    {
        Person person = new Person(id, "belqta");
        Database database = new(person);

        Person actualPerson = database.FindById(id);

        Assert.AreEqual(person, actualPerson);
    }

    [TestCase(-1)]
    [TestCase(-10)]

    public void DatabaseFindByIdMehtodShouldThrowExceptionIfIdIsNegativeNumber(long id)
    {
        Person person = new Person(id, "Gogo");
        Database database = new(person);
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(()
            => database.FindById(id));

        Assert.AreEqual("Id should be a positive number!", exception.ParamName);
    }

    [TestCase(1)]
    [TestCase(2)]

    public void DatabaseFindByIdMethodShouldThrowExceptionIfThereIsNotUserWithSuchId(long id)
    {
        Database database = new();

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database.FindById(id));
        Assert.AreEqual("No user is present by this ID!", exception.Message);
    }
}