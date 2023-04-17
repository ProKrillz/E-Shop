using DataLayer.Entities;

namespace ServiceLayer.I_R;

public interface IUser : IBase<User>
{
    User Login(string email, string password);
    Task<User> GetUserByGuidAsync(Guid id);

}
