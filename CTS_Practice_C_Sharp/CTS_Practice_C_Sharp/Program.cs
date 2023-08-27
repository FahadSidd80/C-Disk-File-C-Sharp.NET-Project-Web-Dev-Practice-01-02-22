using System;


namespace CTS_Practice_C_Sharp
{

    class Car
    {
        public String model = "Mustang";
    }
    class Program
    {
      
        private string model = "tata";
        public static void Main(string[] args)
        {

            Car c = new Car();
            Console.WriteLine(c.model);

            Program t = new Program();
            Console.WriteLine(t.model);

            int x = 10;

            if (x % 2 == 0)
            {
                Console.WriteLine("Even Number !!");
            }
            else
            {
                Console.WriteLine("Odd Number !!");
            }

        }
    }


}
