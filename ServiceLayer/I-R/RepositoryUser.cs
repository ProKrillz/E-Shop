using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ServiceLayer.I_R;

public class RepositoryUser : RepositroyBase<User>, IUser
{
    readonly EfCoreContext _coreContext;
    public RepositoryUser(EfCoreContext context) : base(context)
        => _coreContext = context;

    public User Login(string email, string password)
    {
        return _coreContext.User.Where(e => e.Email == email && e.Password == password).FirstOrDefault();
    }
    
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
        User foundUser = await _coreContext.User.Where(u => u.UserId == id && u.Disable == false).FirstOrDefaultAsync();
        if (foundUser != null)    
            return foundUser;
        
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
