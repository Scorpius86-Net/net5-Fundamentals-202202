using Net5.AttributesAndClasses.ConsoleClass.Entities;
using Net5.AttributesAndClasses.ConsoleClass.Repositories;
using Net5.AttributesAndClasses.LibraryClasses;
using System;
using System.Collections.Generic;

namespace Net5.AttributesAndClasses.ConsoleClass
{
    internal class Program
    {
        public delegate void MyDelegate(int i);
        static void Main(string[] args)
        {
            //PersonalInternal personalInternal = new PersonalInternal();            
            Address address;

            ProcessPerson processPerson = new ProcessPerson();
            IPerson person = new Person() { Name = "Erick" };
            processPerson.ProcessNameByReference(person);
            Console.WriteLine(person.Name);

            person = new Person() { Name = "Erick" };
            processPerson.ProcessNameWhitoutReference(person);
            Console.WriteLine(person.Name);

            RunDelegate(processPerson.MyMethodOne, 2);
            RunDelegate(processPerson.MyMethodTwo, 33);

            Human human = new Human();
            HumanDerivade humanDerivade = new HumanDerivade();

            humanDerivade.Run();
            humanDerivade.CustomRun();

            human.Run();
            person.Run();

            int a = 5;
            int b = 3;
            Swap<int>(ref a,ref b);
            Console.WriteLine($"a : {a}, b : {b}");

            string aa = "One";
            string bb = "Two";
            Swap<string>(ref aa, ref bb);
            Console.WriteLine($"aa : {aa}, bb : {bb}");

            GenericMethod<int, string>(4, "dds");
            GenericMethod<int, int>(4, 3);
            GenericMethod<double, int>(4, 3);

            Dog dog = new Dog();
            dog.DoThing();
            dog.Run();

            Cat cat = new Cat();
            cat.Run();

            //ProductRepository productRepository = new ProductRepository();            
            //productRepository.Insert(new Product { ProductId = 1, Descrption = "Teclado" });

            GenericRepository<Product> productRepository = new GenericRepository<Product>();
            productRepository.Insert(new Product { ProductId = 1, Descrption = "Teclado" });

            Product mouse = new Product { ProductId = 2, Descrption = "Mouse" };
            productRepository.Insert(mouse);

            Product monitor = new Product { ProductId = 3, Descrption = "Monitor" };
            productRepository.Insert(monitor);

            Product monitor2 = new Product { ProductId = 3, Descrption = "Monitor V2" };
            productRepository.Update(monitor,monitor2);

            productRepository.Delete(mouse);

            List<Product> products = productRepository.List();

            GenericRepository<Customer> customerRepository = new GenericRepository<Customer>();
            Customer customer = new Customer { CustomerId = 1, Name = "Erick", LastName = "Aróstegui" };
            customerRepository.Insert(customer);
            List<Customer> customers = customerRepository.List();

            GenericRepository<Sale> saleRepository = new GenericRepository<Sale>();
            Sale sale = new Sale { Id = 1, Description = "Venta de Laptop", Total = 200 };
            saleRepository.Insert(sale);
            List<Sale> sales = saleRepository.List();

        }

        static public void RunDelegate(MyDelegate myDelegate, int i)
        {
            myDelegate(i);
        }

        static void Swap<T>(ref T a,ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        }
        /*
        static void Swap(ref string a, ref string b)
        {
            string temp;
            temp = a;
            a = b;
            b = temp;
        }
        */

        static void GenericMethod<T,TT>(T a, TT b)
        {
            T temp;
            temp = a;

            TT temp2;
            temp2 = b;
        }
    }
}
