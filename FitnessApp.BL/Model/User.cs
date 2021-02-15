using System;

namespace FitnessApp.BL.Model
{
    public class User
    {
        public string Name { get; }
        public Gender Gender { get; }
        public DateTime BirthDate { get; }
        public double Weight { get; set; }
        public double Height { get; set; }

        /// <summary>
        /// Creating of new User (Constructor)
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="birthDate">Birth Date.</param>
        /// <param name="weight">Weight.</param>
        /// <param name="height">Height.</param>
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight, 
                    double height)
        {
            #region Parameters checking (a lot of ifs)
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can't be empty.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Gender can't be empty.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Unreal Birth Date.", nameof(birthDate));
            }

            if (weight <= 0 || weight > 500)
            {
                throw new ArgumentException("Unreal Weight.", nameof(weight));
            }

            if (height <= 0 || height > 300)
            {
                throw new ArgumentException("Unreal Height.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return $"User: {Name} - {Gender} - {BirthDate} - {Weight} - {Height}.";
        }
    }
}
