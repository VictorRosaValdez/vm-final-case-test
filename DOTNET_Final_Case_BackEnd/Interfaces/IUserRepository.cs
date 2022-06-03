using DOTNET_Final_Case_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Final_Case_BackEnd.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Abstract method to get all users.
        /// </summary>
        /// <returns>A list of user objects.</returns>
        Task<ActionResult<IEnumerable<User>>> GetUsersAsync();

        /// <summary>
        /// Abstract method to get a user by Id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The user object.</returns>
        Task<ActionResult<User>> GetUserAsync(int id);



        /// <summary>
        /// Abstract method to create a user.
        /// </summary>
        /// <param name="domainUser">User type.</param>
        /// <returns>The new user object</returns>
        Task<ActionResult<User>> PostUserAsync(User domainuser);

        /// <summary>
        /// Abstract method to update a user.
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="domainUser">User type</param>
        /// <returns>UserDto object.</returns>
        Task<ActionResult<User>> PutUserAsync(int id, User domainUser);

        /// <summary>
        /// Abstract method to delete a user.
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns></returns>
        Task<ActionResult<User>> DeleteUserAsync(int id);
    }
}
