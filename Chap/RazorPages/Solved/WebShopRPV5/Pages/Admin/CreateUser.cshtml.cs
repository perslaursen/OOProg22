
using Microsoft.AspNetCore.Authorization;

namespace WebShopRP.Pages.Admin
{
    // Annotation ensures that only users with "admin" role can access this page.
    [Authorize(Roles = "admin")] 
    public class CreateUserModel : CreatePageModel<User>
    {
        public CreateUserModel(IUserDataService userDataService)
            : base(userDataService, "/Index")
        {
        }
    }
}
