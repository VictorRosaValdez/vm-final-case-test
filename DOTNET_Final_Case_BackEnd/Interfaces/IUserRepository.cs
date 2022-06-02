using DOTNET_Final_Case_BackEnd.DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Final_Case_BackEnd.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Abstract method for get all users.
        /// </summary>
        /// <returns>A list of userDto.</returns>
        Task<ActionResult<IEnumerable<UserReadDTO>>> GetUsersAsync();

        /// <summary>
        /// Abstract method for get a user by Id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The userDto object.</returns>
        Task<ActionResult<UserReadDTO>> GetUserAsync(int id);



        /// <summary>
        /// Abstract method for create a user.
        /// </summary>
        /// <param name="userDto">userDto object.</param>
        /// <returns>The new userDto object</returns>
        Task<ActionResult<UserReadDTO>> PostUserAsync(UserCreateDTO userDto);

        /// <summary>
        /// Abstract method to update a user.
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="userDto">UserDto object</param>
        /// <returns>UserDto object.</returns>
        Task<ActionResult<UserUpdateDTO>> PutUserAsync(int id, UserUpdateDTO userDto);

        /// <summary>
        /// Abstract method to delete a user.
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns></returns>
        Task<ActionResult<UserDeleteDTO>> DeleteUserAsync(int id);
    }
}
