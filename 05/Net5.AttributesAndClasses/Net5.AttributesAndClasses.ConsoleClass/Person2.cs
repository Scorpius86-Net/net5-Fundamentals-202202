using Net5.AttributesAndClasses.LibraryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AttributesAndClasses.ConsoleClass
{
    public class Person2 : IPerson
    {
        public string Name { get ; set ; }
        public Address Address { get ; set ; }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void Run(int i)
        {
            throw new NotImplementedException();
        }

        public void Run(string s)
        {
            throw new NotImplementedException();
        }
    }
}
