using Utis.Minex.Common;
using Utis.Minex.Common.AuthData;
using Utis.Minex.ProductionModel;

namespace Utis.Minex.Modules.IdentityModule.Helpers
{
    public static class RoleExtension
    {
        public static bool IsAdministrator(this Role role)
            => IdentityConstants.IsAdmin(role.Name);
    }
}
