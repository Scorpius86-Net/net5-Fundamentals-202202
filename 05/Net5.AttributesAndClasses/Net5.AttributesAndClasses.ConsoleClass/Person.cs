using Net5.AttributesAndClasses.LibraryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AttributesAndClasses.ConsoleClass
{
    [MySpecial]
    public class Person:IPerson,IProfesional
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Person()
        {

        }
        public Person(string name)
        {
            Name = name;
        }
        public void Run()
        {
            Console.WriteLine("Running");
        }
        public void Run(int i)
        {
            Console.WriteLine($"Running - i : {i}");
        }
        public void Run(string s)
        {
            Console.WriteLine($"Running - s : {s}");
        }
        public void Work()
        {
            Console.WriteLine("Work");
        }
        public void Eat()
        {
            Console.WriteLine("Eat");
        }
    }
}
