using DataLayer.Entities;

namespace ServiceLayer.I_R;

public interface IUser
{
    Task CreateUserAsync(string firstname, string lastname,
        string email, string password, string address, int zipcode);
    Task<User> GetUserByGuidAsync(Guid id);
    Task UpdateUserAsync(User updatedUser);
    Task DeleteUserByGuidAsync(Guid id);
}
