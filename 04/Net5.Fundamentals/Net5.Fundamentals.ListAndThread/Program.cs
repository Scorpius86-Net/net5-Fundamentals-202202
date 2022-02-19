using System;

namespace Net5.Fundamentals.ListAndThread
{
    public class Program
    {
        static void Main(string[] args)
        {
            string opt;
            bool exit = false;
            ListAndThread listAndThread = new ListAndThread();

            do
            {
                Console.Clear();
                Console.WriteLine("List And Thread");
                Console.WriteLine("===============");
                Console.WriteLine(" 1 - Array");
                Console.WriteLine(" 2 - List");
                Console.WriteLine(" 3 - Dictionary");
                Console.WriteLine(" 4 - SorteList");
                Console.WriteLine(" 5 - HashTable");
                Console.WriteLine(" 6 - Stack");
                Console.WriteLine(" 7 - Queue");
                Console.WriteLine(" 8 - Tuple");
                Console.WriteLine(" 9 - ValueTuple");
                Console.WriteLine("10 - Thread");
                Console.WriteLine("11 - Task");
                Console.WriteLine("12 - StreamReader");
                Console.WriteLine("13 - StreamWriter");
                Console.WriteLine("99 - exit");
                Console.WriteLine("");
                Console.Write("Seleccione una opcion : ");
                opt = Console.ReadLine();
                Console.Clear();

                switch (opt)
                {
                    default:
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Presione un a tecla para continuar");
                    Console.ReadKey();
                }

            } while (!exit);
        }
    }
}
