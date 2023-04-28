
using Microsoft.AspNetCore.Identity;

/// <summary>
/// Implementation of User data service. Uses password hashing.
/// </summary>
public class EFCUserDataService : EFCDataServiceAppBase<User>, IUserDataService
{
	private PasswordHasher<string> _passwordHasher = new PasswordHasher<string>();

	/// <summary>
	/// Creates new User, with hashed password.
	/// </summary>
	/// <returns>Id for new User</returns>
	public override int Create(User t)
	{
		t.Password = _passwordHasher.HashPassword(t.UserName, t.Password);
		return base.Create(t);
	}


	public User? VerifyUser(string providedUserName, string providedPassword)
	{
		User? user = GetAll().FirstOrDefault(u => u.UserName == providedUserName);

		if (user == null || _passwordHasher.VerifyHashedPassword(providedUserName, user.Password, providedPassword) != PasswordVerificationResult.Success)
			return null;

		return user;
	}
}
