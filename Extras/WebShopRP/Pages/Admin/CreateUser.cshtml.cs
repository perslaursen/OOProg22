
using Microsoft.AspNetCore.Authorization;

namespace WebShopRP.Pages.Admin
{
    [Authorize(Roles = "admin")] // Ensuring that only users with "admin" role can access this page.
    public class CreateUserModel : CreatePageModel<User>
    {
        public CreateUserModel(IUserDataService userDataService)
            : base(userDataService, "/Index")
        {
        }
    }
}
