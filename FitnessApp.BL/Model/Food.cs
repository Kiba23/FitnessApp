using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Name of the food
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки за 100 грамм продукта
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры за 100 грамм продукта
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы за 100 грамм продукта
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории за 100 грамм продукта
        /// </summary>
        public double Calories { get; }

        public Food(string name) : this(name, 0, 0, 0, 0) { } // calling wider constructor with default params

        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            // TODO: checker

            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return $"Food: {Name} - {Proteins} - {Fats} - {Carbohydrates} - {Calories}";
        }
    }
}
