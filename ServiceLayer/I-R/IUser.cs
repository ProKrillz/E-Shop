using DataLayer.Entities;

namespace ServiceLayer.I_R;

public interface IUser : IBase<User>
{
    User Login(string email, string password);
    /// <summary>
    /// Create User
    /// </summary>
    /// <param name="firstname"></param>
    /// <param name="lastname"></param>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <param name="address"></param>
    /// <param name="zipcode"></param>
    /// <returns></returns>
    Task CreateUserAsync(string firstname, string lastname,
        string email, string password, string address, int zipcode);
    /// <summary>
    /// Load User By Guid 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<User> GetUserByGuidAsync(Guid id);
    /// <summary>
    /// Update user
    /// </summary>
    /// <param name="updatedUser"></param>
    /// <returns></returns>
    Task UpdateUserAsync(User updatedUser);
    /// <summary>
    /// Set is disable to true
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteUserByGuidAsync(Guid id);
}
