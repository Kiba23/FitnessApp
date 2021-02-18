using System;

namespace FitnessApp.BL.Model
{
    // TODO: Realize different formats for entering gender, for example: M/F, Male/Female, m/f, male/female, ...
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Name of Gender
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Creating of new gender
        /// </summary>
        /// <param name="name">Name of gender</param>
        public Gender(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Gender can't be null or empty", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
