using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

		
			Console.WriteLine("Welcome to registration form page");
			Console.WriteLine("================================= \n\n\n");


			Console.Write("Enter user name : ");
			string userName = Console.ReadLine();

			Console.Write("Enter password : ");
			string password = Console.ReadLine();

			Console.WriteLine("\n\n");

			Console.WriteLine("Dear " + userName + ".");
			Console.Write(userName + " !! " + " You have registered successfully  \n\n\n");


			Console.WriteLine("Welcome to login Page");
			Console.WriteLine("==========================");
			Console.WriteLine("\n\n");

			Console.Write("Enter you user name : ");
			string UserName = Console.ReadLine();

			Console.Write("Enter your password : ");
			string Password = Console.ReadLine();

			Console.Write("\n\n");

				if (userName == UserName && password == Password)
				{
					Console.WriteLine("Login Succeed " + UserName );
					Console.Write("Welcome to Home " + UserName);

				}
				else
				{
					Console.Write("Username/Password is incorrcet, please try again  ");
				}




			Console.ReadLine();



		}
	}
}
