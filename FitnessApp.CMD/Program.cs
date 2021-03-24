using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
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

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Enter your gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                double weight = ParseDouble(nameof(weight));
                double height = ParseDouble(nameof(height));

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What to do you want to do?");
            Console.WriteLine("\"E\" - enter your eating(ingestion)");
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var dishes = EnterEating();
                eatingController.Add(dishes.Food, dishes.Weight);

                foreach (var item in eatingController.Eating.Dishes)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
            else throw new Exception("Wrong key.");

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Enter name of a product: ");
            var foodName = Console.ReadLine();

            var calories = ParseDouble("calories(калорийность)");
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbohydrates = ParseDouble("carbohydrates");
            var weight = ParseDouble("weight of a portion");

            var product = new Food(foodName, proteins, fats, carbohydrates, calories);

            return (product, weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Enter your birth date: ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong date format. Try again.");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Wrong {name} format. Try again.");
                }
            }
        }
    }
}
