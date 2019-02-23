using Abp.Authorization;
using Pizza.Authorization.Roles;
using Pizza.Authorization.Users;

namespace Pizza.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
