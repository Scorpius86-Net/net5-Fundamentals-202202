using System;
using System.Collections.Generic;
using System.Linq;

namespace Net5.FunctionalProgramming.Samples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Alumno> alumnos = new List<Alumno>();
            LoadAlumnos(alumnos);

            bool isErick = false;
            
            foreach (Alumno alumno in alumnos)
            {
                /*
                if (alumno.FirstName.Equals("Erick"))
                {
                    isErick = true;
                    break;
                }
                */
                if (IsErick(alumno.FirstName))
                {
                    isErick = true;
                    break;
                }

            }

            if (isErick)
            {
                Console.WriteLine("Found Erick");
            }
            else
            {
                Console.WriteLine("Not Found Erick");
            }

            /////////////////////////////////////////////           

            if (alumnos.Any(alumno => IsErick(alumno.FirstName)))
            {
                Console.WriteLine("Found Erick");
            }
            else
            {
                Console.WriteLine("Not Found Erick");
            }

            /////////////////////////////////////////////           

            if (alumnos.Any(alumno => alumno.FirstName.Equals("Erick")))
            {
                Console.WriteLine("Found Erick");
            }
            else
            {
                Console.WriteLine("Not Found Erick");
            }

            Lambda lambda = new Lambda();
            lambda.DoWork();

        }

        static bool IsErick(string firstName)
        {
            if (firstName.Equals("Erick"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void LoadAlumnos(List<Alumno> alumnos)
        {
            for (int i = 0; i < 10; i++)
            {
                Alumno alumno = new Alumno { FirstName = $"Alumno-{i + 1}" };
                alumnos.Add(alumno);
            }

            alumnos.Add(new Alumno { FirstName = "Erick" });
        }

    }
}
