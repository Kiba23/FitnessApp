using FitnessApp.BL.Controller;
using System;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Welcome to the FitnessApp!!! ----\t");

            Console.WriteLine("Enter your UserName:");
            var name = Console.ReadLine();
            //mb check here

            Console.WriteLine("Enter your gender:");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter your birth date:");
            DateTime.TryParse(Console.ReadLine(), out DateTime birthDate);

            Console.WriteLine("Enter your weight:");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter your height:");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}
