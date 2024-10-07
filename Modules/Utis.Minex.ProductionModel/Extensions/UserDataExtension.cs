using Utis.Minex.Common;
using Utis.Minex.Common.AuthData;
using Utis.Minex.ProductionModel;

namespace Utis.Minex.Modules.IdentityModule.Helpers
{
    public static class UserDataExtension
    {
        public static bool IsAdmin(this UserData userData) 
            => userData?.Role?.IsAdministrator() == true;

        public static bool IsDefaultAdmin(this UserData userData)
            => IdentityConstants.IsDefaultAdmin(userData?.UserName) && IsAdmin(userData);

        /// <summary>
        /// Поля которые могу был обновлены у сущности с клинта
        /// </summary>
        public static void UpdateFromClient(this UserData updatedData, UserData dataFromClient)
        {
            updatedData.IsBlocked = dataFromClient.IsBlocked;
            updatedData.BlockingReason = dataFromClient.BlockingReason;
            updatedData.PassChangeRequired = dataFromClient.PassChangeRequired;
            updatedData.Role = dataFromClient.Role;
        }
    }
}
