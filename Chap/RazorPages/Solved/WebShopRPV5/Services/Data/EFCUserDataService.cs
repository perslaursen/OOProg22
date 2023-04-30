
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

/// <summary>
/// Implementation of User data service.
/// </summary>
public class EFCUserDataService : EFCDataServiceAppBase<User>, IUserDataService
{
    private PasswordHasher<string> _passwordHasher = new PasswordHasher<string>();

    public override int Create(User user)
    {
        user.Password = _passwordHasher.HashPassword(user.UserName, user.Password);
        return base.Create(user);
    }

    public User? VerifyUser(string providedUserName, string providedPassword)
    {
        User? user = GetAll().FirstOrDefault(u => u.UserName == providedUserName);

        if (user == null || 
            _passwordHasher.VerifyHashedPassword(
                providedUserName, 
                user.Password, 
                providedPassword) 
            != PasswordVerificationResult.Success)
            return null;

        return user;
    }
}
