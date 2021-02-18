using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// Controller for User.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// User of the app.
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Creating new controller for user.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Username can't be empty.", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name.Equals(userName));

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Getting User's data.
        /// </summary>
        private List<User> GetUsersData() // Deserialization from bin file. It will be used in DI in the future
        {    
            var binFormattor = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    if (binFormattor.Deserialize(fs) is List<User> users)
                        return users;
                    else
                        return new List<User>();
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        /// <summary>
        /// Setting all parameters except Username. Executing if user's name haven't found in list/database.
        /// </summary>
        public void SetNewUserData(string genderName, 
                                    DateTime birthDate, 
                                    double weight = 1, 
                                    double height = 1)
        {
            #region Parameters checking (a lot of ifs)
            if (genderName == null)
            {
                throw new ArgumentNullException("Gender can't be empty.", nameof(genderName));
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

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Saving User's data.
        /// </summary>
        public void Save() // Serialization to bin file. It will be used in DI in the future
        {
            var binFormattor = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                binFormattor.Serialize(fs, Users);
            }
        }
    }
}
