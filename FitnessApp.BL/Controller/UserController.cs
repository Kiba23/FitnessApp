using FitnessApp.BL.Model;
using System;
using System.IO;
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
        public User User { get; }

        /// <summary>
        /// Getting User's data.
        /// </summary>
        public UserController() // Deserialization from bin file. It will be used in DI in the future. Note: change for list of User in the future
        {
            var binFormattor = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (binFormattor.Deserialize(fs) is User user) // in the future realize here for multiple users (List<User>)
                {
                    User = user;
                }

                // TODO: What to do when we haven't read the user's data?
            }
        }

        /// <summary>
        /// Creating new controller for user.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            // TODO: Checker

            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);
        }

        /// <summary>
        /// Saving User's data.
        /// </summary>
        public void Save() // Serialization to bin file. It will be used in DI in the future
        {
            var binFormattor = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                binFormattor.Serialize(fs, User);
            }
        }
    }
}
