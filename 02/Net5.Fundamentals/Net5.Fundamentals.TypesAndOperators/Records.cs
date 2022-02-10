using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Fundamentals.TypesAndOperators
{
    public record Pet(string name, string age)
    {
        public void ShredTheFurniture()
        {
            Console.WriteLine("Shredding furniture");
        }
    }

    public record Dog (string name, string age):Pet(name, age)
    {
        public void WagTail()
        {
            Console.WriteLine("It's tail wagging time");
        }

        public override string ToString()
        {
            string ss = "1";
            ss = ss + "2";
            ss = ss + "3";
            ss = ss + "4";
			
			StringBuilder sss = new StringBuilder();
			sss.AppendLine()
			

            StringBuilder s = new StringBuilder();
            base.PrintMembers(s);
            return $"{s.ToString()} is a dog";
        }
    }

}
