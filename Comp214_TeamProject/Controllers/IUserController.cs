using Comp214_TeamProject.Database.Models;

namespace Comp214_TeamProject.Controllers
{
    /// <summary>
    /// Interface containing all the methods that must be implemented by the UserController.
    /// </summary>
    interface IUserController
    {
        /// <summary>
        /// Performs the user login in the application and returns the logged user.
        /// </summary>
        /// <param name="email">The user's e-mail</param>
        /// <param name="password">The user's password</param>
        /// <returns>The Logged user.</returns>
        User Login(string email, string password);

        /// <summary>
        /// Registers the user with the given data in the system.
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="password">The user's password</param>
        /// <param name="firstName">The user's firsrt name</param>
        /// <param name="lastName">The user's last name</param>
        /// <returns>The registered user</returns>
        User Register(string email, string password, string firstName, string lastName);

        /// <summary>
        /// Updates the profile for the user with the given data in the system.
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="firstName">The user's firsrt name</param>
        /// <param name="lastName">The user's last name</param>
        /// <returns>The registered user</returns>
        User UpdateProfile(string email, string firstName, string lastName);
    }
}
