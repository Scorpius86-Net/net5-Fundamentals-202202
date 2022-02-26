using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.FunctionalProgramming.Samples
{
    public class Lambda
    {
        delegate int operationDelegate(int x, int y);
        public void DoWork()
        {
            Print(5, 5, Suma);
            Print(5, 5, (int a, int b)=>
            {
                //To Do
                //To Do
                //To Do
                //To Do
                return a + b;
            });
            Print(5, 5, (a, b) => a + b);
            Print(4, 2, (x, y) => x * y);
            Print(6, 6, (a, b) => a + b);
            Print(144, 666, (x, y) => x * y);

            FunctionDelegate();
            ActionDelegate();
        }

        private void FunctionDelegate()
        {

            Func<string, string> selector = ToUpper;
            List<string> words = new List<string> { "Naranja", "Manzana", "Articulo", "elefante" };
            //List<string> aWords = words.Select(ToUpper).ToList();
            //IEnumerable<string> aWords = words.Select((str) =>
            //{
            //    return str.ToUpper();
            //});
            //IEnumerable<string> aWords = words.Select((str) => str.ToUpper());
            List<string> aWords = words.Select(selector).ToList();

            aWords.ForEach(word =>
            {
                Console.WriteLine(word);
            });
        }

        private void ActionDelegate()
        {
            Action<string> messageTarget;
            string[] args = Environment.GetCommandLineArgs();

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"args[{i}] = {args[i]}");
            }
            
            if (args.Length > 1)
            {
                messageTarget = ShowWindowsMessage;
            }
            else
            {
                messageTarget = Console.WriteLine;
            }

            if (args.Length > 1)
            {
                messageTarget(args[1]);
            }
            else
            {
                messageTarget("No tiene argumentos");
            }
        }

        private int Suma(int a,int b)
        {
            return a + b;
        }
        private void Print(int a,int b,operationDelegate operation)
        {
            int result = operation(a,b);
            Console.WriteLine($"Imprimiendo : {result}");
        }

        private string ToUpper(string s)
        {
            return s.ToUpper();
        }

        private void ShowWindowsMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
