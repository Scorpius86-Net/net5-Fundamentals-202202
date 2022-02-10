using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Net5.Fundamentals.TypesAndOperators
{
    public class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = a + 2;

            bool test = true;

            //int c = a + test;

            float temperature;
            string name;
            MyClass myClass = new MyClass();

            char firstLetter = 'C';            
            var limit = 3;            

            int[] source = { 1, 2, 3, 4, 5 };
            var query = from item in source  where item <= limit select item;

            myClass.MyProperty = 5;
            ChangeMyClass(myClass);
            Console.WriteLine(myClass.MyProperty);

            a = 5;
            ChangeValue(a);
            Console.WriteLine(a);

            int aa = 123;
            System.Int32 bb = 123;
            var hexa = 0x2A;
            var binary = 0b_0010_1010;
            decimal dec = 105_52;

            //camelCase
            //PascalCase
            //min var, parm , attr             
            //mayus class, metod, prop

            string cadena = "test";
            char letter = 'D';

            var characters = new[]
            {
                'j',
                '\u006A',
                '\x00A',
                (char)106
            };

            Console.WriteLine(string.Join(" ", characters));

            Console.WriteLine((int)Season.Autum);
            Console.WriteLine(Season.Autum.ToString());

            var error = ErrorCode.ConnectionLost;

            var test1 = ((ushort)ErrorCode.ConnectionLost) == 100;
            var test2 = ErrorCode.ConnectionLost == error;

            Coords coords = new Coords(1, 2, 3);

            (MyClass obj,string name, int age) tuple = (new MyClass(),"tr", 25);
            Console.WriteLine(tuple.name);

            bool? eval = null;
            int? num = null;
            int  numNotNull = 0;
            MyClass obj2 = null;
            string cad = null;

            //Console.WriteLine(num.Value);

            Dog dog = new Dog("Firulais", "5");
            Console.WriteLine(dog.ToString());

            int numInt = 123456789;
            long numLong = numInt;

            Derived derived = new Derived();
            Base baseClass = derived;

            Giraffe g = new Giraffe();
            Animal animal = g;

            Giraffe g2 = (Giraffe)animal;

            Convert.ToInt32("15");
            int.Parse("5");
            int.TryParse("sdfsd", out a);

            int i = 3;
            Console.WriteLine($"i = {i}");
            Console.WriteLine($"++i = {++i}");
            Console.WriteLine($"i = {i}");

            ++i;
            i++;

            if (!test && eval.Value)
            {

            }
            if (test)
            {
                a = 5;
            }
            else
            {
                a = 6;
            }

            if (!num.HasValue)
            {
                num = 5;
            }
            else
            {
                num = num.Value;
            }

            num = (num == null ? 5 : num);
            num = num ?? 5;

            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6 };

            nums.ForEach(num => {
                Console.WriteLine(num);
                Console.WriteLine(num);
            });
        }

        static void NumPrint(int num)
        {
            Console.WriteLine(num);
            Console.WriteLine(num);
        }

        static void ChangeMyClass(MyClass param)
        {
            param.MyProperty = 20;
        }

        static void ChangeValue(int param)
        {
            param = 20;
        }
    }
}
