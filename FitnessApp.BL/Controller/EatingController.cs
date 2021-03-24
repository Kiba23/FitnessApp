using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private const string DISHES_FILE_NAME = "dishes.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";

        private readonly User user;
        public List<Food> Dishes { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can't be null or empty.", nameof(user));

            Dishes = GetAllDishes();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var product = Dishes.SingleOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Dishes.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllDishes()
        {
            return Load<List<Food>>(DISHES_FILE_NAME) ?? new List<Food>();
        }

        private void Save()
        {
            base.Save(DISHES_FILE_NAME, Dishes);
            base.Save(EATINGS_FILE_NAME, Eating);
        }
    }
}
