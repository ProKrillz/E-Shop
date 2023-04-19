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
    public async Task<User> GetUserByGuidAsync(Guid id)
    {
        User foundUser = await _coreContext.User.Where(u => u.UserId == id && u.Disable == false).Include(u => u.Ordres).Include(u => u.ZipCode).FirstOrDefaultAsync();
        if (foundUser != null)    
            return foundUser;
        
        // Vil lave error logging
        return null;//new Exception();
    }
}
