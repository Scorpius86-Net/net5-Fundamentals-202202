using Net5.AttributesAndClasses.LibraryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AttributesAndClasses.ConsoleClass
{
    public interface IPerson
    {
        string Name { get; set; }
        Address Address { get; set; }

        void Run();
        void Run(int i);
        void Run(string s);
    }
}
