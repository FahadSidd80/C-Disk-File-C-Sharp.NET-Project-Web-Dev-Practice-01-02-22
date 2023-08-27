using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
      
public class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("I am a base class");
        }
    }
    public class ChildClass : BaseClass
    {
        public ChildClass()
        {
            Console.WriteLine("I am a child class");
        }
        static void Main()
        {
            ChildClass CC = new ChildClass();
        }
            Console.readline();
    }
        

}

}

