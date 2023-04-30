
public partial class User : IHasId, IUpdateFromOther<User>
{
    public void Update(User tOther)
    {
        UserName = tOther.UserName;
        Password = tOther.Password;
    }
}

