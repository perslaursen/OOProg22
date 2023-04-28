
public interface IUserDataService : IDataService<User>
{
    /// <summary>
    /// Verifies that a provided user name and password matches a known user profile.
    /// </summary>
    /// <returns>User matching the provided information, otherwise null.</returns>
    User? VerifyUser(string providedUserName, string providedPassword);
}
