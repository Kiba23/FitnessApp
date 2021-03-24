using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Model
{
    [Serializable]
    /// <summary>
    /// Приём пищи
    /// </summary>
    public class Eating
    {
        public DateTime Moment { get; }
        public Dictionary<Food, double> Dishes { get; }
        public User User { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User can't be empty.", nameof(user));
            Moment = DateTime.UtcNow;
            Dishes = new Dictionary<Food, double>();
        }

        public void Add(Food foodConsumed, double amount)
        {
            var productExist = Dishes.Keys.FirstOrDefault(f => f.Name.Equals(foodConsumed.Name));

            if (productExist == null)
            {
                Dishes.Add(foodConsumed, amount);
            }
            else
            {
                Dishes[productExist] += amount;
            }
        }
    }
}
