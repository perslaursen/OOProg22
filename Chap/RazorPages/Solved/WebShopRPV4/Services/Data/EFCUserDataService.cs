
using Microsoft.AspNetCore.Identity;

/// <summary>
/// Implementation of User data service.
/// </summary>
public class EFCUserDataService : EFCDataServiceAppBase<User>, IUserDataService
{
	public User? VerifyUser(string providedUserName, string providedPassword)
	{
		User? user = GetAll().FirstOrDefault(u => u.UserName == providedUserName);

		if (user == null || user.Password != providedPassword)
			return null;

		return user;
	}
}
