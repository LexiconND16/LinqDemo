using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>() {
                new Person() { Name = "Alexandra", BirthDate = DateTime.Parse("1980-09-02") },
                new Person() { Name = "Bertil", BirthDate = DateTime.Parse("1975-03-12") },
                new Person() { Name = "Calle", BirthDate = DateTime.Parse("1988-01-21") },
                new Person() { Name = "Denise", BirthDate = DateTime.Parse("1984-09-17") },
            };


            var oldPeople = people
                .Select(p => new
                {
                    Name = p.Name,
                    BirthDate = p.BirthDate,
                    Age = (int)((DateTime.Now - p.BirthDate).TotalDays / 365)
                })
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Name);

            var oldPeoplesName = oldPeople
                .Select(p => p.Name);

            var oldestPerson = oldPeoplesName.Last();

            //Console.WriteLine(oldestPerson);
            //return;

            //var oldPeople = new List<Person>();
            //foreach (var person in people) {
            //    var age = (int)((DateTime.Now - person.BirthDate).TotalDays / 365);
            //    if (age > 30) oldPeople.Add(person);
            //}

            foreach (var person in oldPeople.Skip(1))
            {
                Console.WriteLine(person);
            }



        }
    }

    internal class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"{this.Name}, birthdate: {this.BirthDate}";
        }
    }
}
