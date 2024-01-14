using System;

Person[] people = new Person[]
{
    new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
    new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
    new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
    new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
    new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
    new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
};


int totalAge = people.Sum(p => p.Age);
Console.WriteLine($"Den totale alder: {totalAge}");
Console.WriteLine("");

int countNielsen = people.Count(p => p.Name.Contains("Nielsen"));
Console.WriteLine($"Så mange hedder Nielsen: {countNielsen}");
Console.WriteLine("");

Person oldestPerson = people.OrderByDescending(p => p.Age).FirstOrDefault();
Console.WriteLine($"Ældste person: {oldestPerson.Name}, {oldestPerson.Age} år ");
Console.WriteLine("");

Person? mobilNummer = people.FirstOrDefault(p => p.Phone == "+4543215687");
Console.WriteLine($"Personen med nummeret +4543215687: {mobilNummer.Name}");
Console.WriteLine("");

var over30 = people.Where(p => p.Age > 30);
Console.WriteLine("Folk over 30:");
over30
    .Select(person => $"{person.Name}, {person.Age} år")
    .ToList()
    .ForEach(Console.WriteLine);
Console.WriteLine("");

var peopleWithoutCountryCode = people.Select(p =>
{
    var updatedPerson = new Person
    {
        Name = p.Name,
        Age = p.Age,
        Phone = p.Phone?.Replace("+45", "")
    };
    return updatedPerson;
}).ToArray();
Console.WriteLine("Liste uden +45:");
peopleWithoutCountryCode
    .Select(p => $"Navn: {p.Name}, Alder: {p.Age}, Telefon: {p.Phone}")
    .ToList()
    .ForEach(Console.WriteLine);
Console.WriteLine("");

var under30 = people.Where(p => p.Age < 30);
Console.WriteLine("Folk under 30:");
under30
    .Select(person => $"Navn: {person.Name}, Telefon: {person.Phone}")
    .ToList()
    .ForEach(Console.WriteLine);
Console.WriteLine("");






class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
}

