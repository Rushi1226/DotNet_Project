using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet_MiniProject.Models;

namespace DotNet_MiniProject
{
    public static class MainView
    {
        internal static int login()
        {
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("                                          Student/Learning Management System");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("Press 0 to exit application");
                Console.WriteLine("Press 1 for Registration");
                Console.WriteLine("Press 2 to login as a Student");
                Console.WriteLine("Press 3 to login as a Admin");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                
            } while (!int.TryParse(Console.ReadLine(), out userInput));

            return userInput;
        }
    }
}
