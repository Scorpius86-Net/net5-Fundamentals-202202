using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AttributesAndClasses.ConsoleClass
{
    public abstract class AnimalAbstract
    {
        public abstract void Eat();
        public abstract void Sleep();
        public void DoThing()
        {

        }
        public virtual void Run()
        {
            Console.WriteLine("Animal - Run");
        }
    }
}
