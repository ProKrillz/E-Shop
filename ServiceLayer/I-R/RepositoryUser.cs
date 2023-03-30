using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTO;
using System.Diagnostics.Metrics;

namespace ServiceLayer.I_R;

public class RepositoryUser : IUser
{
    readonly EfCoreContext _coreContext;
    public RepositoryUser(EfCoreContext context)
        => _coreContext = context;

    public async Task CreateUserAsync(string firstname, string lastname, 
        string email, string password, string address, int zipcode)
    {
        _coreContext.User.Add(new()
        {
            FirstName = firstname,
            Lastname = lastname,
            Email = email,
            Address = address,
            Password = password,
            Fk_ZipCodeId = zipcode
        });
        await _coreContext.SaveChangesAsync();
    }
    public async Task<User> GetUserByGuidAsync(Guid id)
    {
        User foundUser = await _coreContext.User.Where(u => u.UserId == id).FirstOrDefaultAsync();
        if (foundUser != null)
        {
            return foundUser;
        }
        // Vil lave error logging
        return null;//new Exception();
    }
    public async Task UpdateUserAsync(User updatedUser) 
    { 
        _coreContext.Update(updatedUser);
        await _coreContext.SaveChangesAsync();
    }
    public async Task DeleteUserByGuidAsync(Guid id)
    {
        User found = _coreContext.User.SingleOrDefault(u => u.UserId == id);
        if (found != null)
        {
            found.Disable = true;
            await _coreContext.SaveChangesAsync();
        }
    }

}
