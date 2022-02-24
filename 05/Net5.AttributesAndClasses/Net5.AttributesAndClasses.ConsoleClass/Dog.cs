using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AttributesAndClasses.ConsoleClass
{
    public class Dog : AnimalAbstract
    {
        public override void Eat()
        {
            Console.WriteLine("Dog - Eat");
        }

        public override void Sleep()
        {
            Console.WriteLine("Dog - Sleep");
        }
    }
}
