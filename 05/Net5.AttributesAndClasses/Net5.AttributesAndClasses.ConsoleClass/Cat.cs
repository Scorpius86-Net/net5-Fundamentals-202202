using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AttributesAndClasses.ConsoleClass
{
    public class Cat : AnimalAbstract
    {
        public override void Eat()
        {
            Console.WriteLine("Cat - Eat");
        }

        public override void Sleep()
        {
            Console.WriteLine("Cat - Sleep");
        }

        public override void Run()
        {
            Console.WriteLine("Cat - run");
            base.Run();
        }
    }
}
