using System;
using System.Collections.Generic;
using System.Linq;
using Utis.Minex.Common;
using Utis.Minex.Common.AuthData;
using Utis.Minex.Common.Enum;
using Utis.Minex.Common.Helpers;
using Utis.Minex.Common.Interfaces;using Utis.Minex.Common.Enum.Extensions;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Данные текущего авторизированного пользователя.
    /// </summary>
    public static class AuthorizedUserData
    {
        #region UserData

        public static bool IsDefaultAdministrator => IsAuthorized
                                                     && IdentityConstants.IsDefaultAdmin(UserName);

        public static bool IsAuthAdministrator => IsAuthorized
                                                  && IdentityConstants.IsAdmin(RoleName);

        public static string RoleName
        {
            get
            {
                if (!IsAuthorized)
                {
                    return IdentityConstants.UnauthorizedRole;
                }

                return _roleName;
            }
            private set => _roleName = value;
        }

        public static long UserId { get; private set; }
        public static string UserName
        {
            get => _userName;
            private set => _userName = value;
        }

        /// <summary>
        /// Идентификатор персоны к которой привязана учетная запись.
        /// </summary>
        public static long BindPersonId
        { get; private set; }

        /// <summary>
        /// Персона к которой привязана учетная запись (PersonDTO).
        /// </summary>
        public static object BindPersonDto
        { get; private set; }

        public static bool IsAuthorized
        {
            get => isAuthorized;
            private set => isAuthorized = value;
        }
        private static bool isAuthorized = false;

#if DEBUG
        //по умолчанию в отладке пусть будет "неавторизованный пользователь с именем как при входе в OC"
        private static string _userName = WindowsUserName();
        private static string _roleName = IdentityConstants.UnauthorizedRole;
#else
        private static string _userName = String.Empty;
        private static string _roleName = String.Empty;
#endif

        #endregion

        /// <summary>
        /// Событие уведомляющие о авторизации пользователя.
        /// </summary>
        public static event EventHandler<AuthEventArgs> EvAuth;

        static AuthorizedUserData()
        {
            SetUnAuthorized();
        }

        public static void SetUnAuthorized()
        {
            IsAuthorized = false;

            UserId = 0;
            UserName = string.Empty;

            RoleName = string.Empty;

            BindPersonId = 0;
            BindPersonDto = null;

            lock (lockCollMatrixAccessRights)
            {
                _collMatrixAccessRights.Clear();
            }

            lock (lockCollMatrixEventProcessingRights)
            {
                _collMatrixEventProcessingRights.Clear();
            }

            GraphicModuleRights = new ItemGraphicModuleRights();
            _reportTypes = new();
            TransportModuleRights = new ItemTransportModuleRights();

            RaiseAuthEvent();
        }

        public static void SetAuthorized(long userId,
                                         string userName,
                                         string roleName,
                                         object bindPersonDto,
                                         long bindPersonId)
        {
            IsAuthorized = true;

            UserId = userId;
            UserName = userName;
            RoleName = roleName;
            BindPersonDto = bindPersonDto;
            BindPersonId = bindPersonId;

            RaiseAuthEvent();
        }

        static void RaiseAuthEvent()
        {
            var authEventArgs =
                new AuthEventArgs(
                    isAuth: IsAuthorized,
                    userId: UserId,
                    userName: UserName,
                    roleName: RoleName,
                    allowTabAdministration: IsAuthAdministrator
                    );

            EvAuth?.Invoke(null, authEventArgs);
        }

        public static bool IsRoleNameValid() => !RoleName.IsNullOrEmpty() && !string.IsNullOrWhiteSpace(RoleName);

        public static void SetAuthorizedInDebugMode()
        {
#if DEBUG

            var allAccessRights = new List<ItemMatrixAccessRights>();

            foreach (var resource in System.Enum.GetValues<ResourceType>())
            {
                var defRights = resource.GetAccessActions();

                var right = new ItemMatrixAccessRights()
                {
                    ActionType = defRights.Any() ? defRights.ToCombined() : RoleActionType.Allowed,
                    ResourceType = resource,
                    RoleName = IdentityConstants.AdminRole
                };
                allAccessRights.Add(right);
            }

            ReFillToCollMatrixAccessRights(allAccessRights);

            var allEventRights = new List<ItemMatrixEventProcessingRights>();

            foreach (var resourceEvent in System.Enum.GetValues<ResourceEventType>())
            {
                allEventRights.Add(new ItemMatrixEventProcessingRights()
                {
                    ActionType = EventProcessingType.AckingOfMessages | EventProcessingType.AckingOfMessages,
                    ResourceType = resourceEvent,
                    RoleName = IdentityConstants.AdminRole
                });
            }

            ReFillCollMatrixEventProcessingRights(allEventRights);

            GraphicModuleRights = new ItemGraphicModuleRights()
            {
                AccessViewer3Dx = true,
                EnablePlayBack = true,
                EnableEmergencyCall = true,
                EnableEmergencyReset = true,
                EnablePagerCall = true,
                EnableSchemeEditor = true,
                EnableIndividualCalls = true,
                EnableEditor3D = true
            };

            ReportRights = ResourceTypeExtensions
                .GetResourcesByCategory(ResourceCategory.Reports)
                .ToList();

            TransportModuleRights = new ItemTransportModuleRights()
            {
                EnableOpenedDowntimeControl = true,
                EnableTransportChiefControl = true,
            };

            SetAuthorized(0,
                          IdentityConstants.DefaultAdminUserName,
                          IdentityConstants.AdminRole,
                          null,
                          0);
#endif
        }

        private static string WindowsUserName()
            => System.Security.Principal.WindowsIdentity.GetCurrent()?.Name;

        #region HoldMatrixAccessRights

        /// <summary>
        /// Список каталогов и доступов к ним. 
        /// </summary>
        private static List<ItemMatrixAccessRights> _collMatrixAccessRights = new();
        private static object lockCollMatrixAccessRights = new object();

        public static void AddToCollMatrixAccessRights(ItemMatrixAccessRights item)
        {
            lock (lockCollMatrixAccessRights)
            {
                _collMatrixAccessRights.Add(item);
            }
            RaiseAccessRightsChanged();
        }

        public static void ReFillToCollMatrixAccessRights(IEnumerable<ItemMatrixAccessRights> items)
        {
            lock (lockCollMatrixAccessRights)
            {
                _collMatrixAccessRights.Clear();
                _collMatrixAccessRights.AddRange(items);
            }
            RaiseAccessRightsChanged();
        }

        /// <summary>
        /// Получить текущие разрешения пользователя для указанного ресурса\таблицы.
        /// </summary>
        /// <param name="resourceObject">Имя ресурса.</param>
        public static RoleActionType GetActionTypeByCurrentRole(ResourceType resourceObject) =>
            GetActionTypeByRole(RoleName, resourceObject, RoleActionType.Forbidden);

        public static bool IsAllowedByHasp(ResourceType resourceObject)
        {
            return true;
        }

        /// <summary>
        /// Узнать разрешения указанной роли для указанного ресурса\таблицы.
        /// </summary>
        /// <param name="roleName">Имя роли.</param>
        /// <param name="resourceObject">Имя ресурса.</param>
        /// <param name="defRoleActionType">Уровень доступа по умолчанию.</param>
        public static RoleActionType GetActionTypeByRole(string roleName, ResourceType resourceObject, RoleActionType defRoleActionType)
        {
            if (string.IsNullOrWhiteSpace(roleName)
                || resourceObject <= 0
                || !IsAllowedByHasp(resourceObject))
            {
                return defRoleActionType;
            }

            if (resourceObject.In(ResourceType.WorkingBreakeJournal, ResourceType.DiscardedAccurateRfidEventDTO))
                return RoleActionType.Read;

            lock (lockCollMatrixAccessRights)
            {
                ItemMatrixAccessRights mar;
                // Уточнение прав редактирования светильников
                if (resourceObject == ResourceType.LampDTO)
                {
                    mar = _collMatrixAccessRights.FirstOrDefault(r =>
                        r.RoleName == roleName && r.ResourceType == ResourceType.LampBindingChange) ??
                            _collMatrixAccessRights.FirstOrDefault(r =>
                        r.RoleName == roleName && r.ResourceType == ResourceType.LampDTO);
                }
                else
                {
                    mar = _collMatrixAccessRights
                        .FirstOrDefault(o => o.RoleName == roleName && o.ResourceType == resourceObject);
                }

                if (mar != null)
                {
                    return mar.ActionType;
                }
            }

            return
                defRoleActionType;
        }

        public static bool TryRemoveItemMatrixAccessRights(ResourceType resourceObject)
        {
            var res = false;

            lock (lockCollMatrixAccessRights)
            {
                var mar =
                    _collMatrixAccessRights
                    .FirstOrDefault(o => o.ResourceType == resourceObject);

                if (mar != null)
                {
                    res = _collMatrixAccessRights.Remove(mar);
                }
            }

            if (res)
            {
                RaiseAccessRightsChanged();
            }

            return
                res;
        }

        #endregion

        #region HoldMatrixEventProcessingRights

        /// <summary>
        /// Список событий и типов обработки для них. 
        /// </summary>
        private static List<ItemMatrixEventProcessingRights> _collMatrixEventProcessingRights = new();
        private static object lockCollMatrixEventProcessingRights = new object();

        public static void AddToCollMatrixEventProcessingRights(ItemMatrixEventProcessingRights item)
        {
            lock (lockCollMatrixEventProcessingRights)
            {
                _collMatrixEventProcessingRights.Add(item);
            }
            RaiseAccessRightsChanged();
        }

        public static void ReFillCollMatrixEventProcessingRights(IEnumerable<ItemMatrixEventProcessingRights> items)
        {
            lock (lockCollMatrixEventProcessingRights)
            {
                _collMatrixEventProcessingRights.Clear();
                _collMatrixEventProcessingRights.AddRange(items);
            }
            RaiseAccessRightsChanged();
        }

        /// <summary>
        /// Получить текущие разрешения пользователя для указанного ресурса\таблицы.
        /// </summary>
        /// <param name="resourceObject">Имя ресурса.</param>
        public static EventProcessingType GetEventProcessingTypeByCurrentRole(ResourceEventType resourceObject) =>
            GetEventProcessingTypeByRole(RoleName, resourceObject, EventProcessingType.NonSet);

        /// <summary>
        /// Узнать разрешения указанной роли для указанного события.
        /// </summary>
        /// <param name="roleName">Имя роли.</param>
        /// <param name="resourceObject">Имя ресурса.</param>
        /// <param name="defProcessingType">Тип обработки сообщения по умолчанию.</param>
        public static EventProcessingType GetEventProcessingTypeByRole(string roleName, ResourceEventType resourceObject, EventProcessingType defProcessingType)
        {
            lock (lockCollMatrixEventProcessingRights)
            {
                if (!string.IsNullOrWhiteSpace(roleName))
                    if (resourceObject > 0)
                    {
                        var mar =
                            _collMatrixEventProcessingRights
                                .FirstOrDefault(o => o.RoleName == roleName && o.ResourceType == resourceObject);

                        if (mar != null)
                        {
                            return mar.ActionType;
                        }
                    }
            }

            return
                defProcessingType;
        }

        public static bool TryRemoveItemMatrixEventProcessingRights(ResourceEventType resourceObject)
        {
            var res = false;

            lock (lockCollMatrixEventProcessingRights)
            {
                var mar =
                    _collMatrixEventProcessingRights
                    .FirstOrDefault(o => o.ResourceType == resourceObject);

                if (mar != null)
                {
                    res = _collMatrixEventProcessingRights.Remove(mar);
                }
            }

            if (res)
            {
                RaiseAccessRightsChanged();
            }

            return
                res;
        }

        #endregion

        #region HoldGraphicModuleRights

        /// <summary>
        /// "Права доступа к графическому модулю" относящиеся к текущему авторизированному пользователю
        /// </summary>
        public static ItemGraphicModuleRights GraphicModuleRights
        {
            get => _graphicModuleRights;
            set
            {
                _graphicModuleRights = value;
                RaiseAccessRightsChanged();
            }
        }

        private static ItemGraphicModuleRights _graphicModuleRights = new ItemGraphicModuleRights();

        #endregion

        #region GetPermitByAssociatedResourceType

        /// <summary>
        /// Получить флаг наличия разрешений для указанного DTO
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static RoleActionType GetPermitByDTO(ObjectBaseDTO dto)
        {
            RoleActionType resultAllowed = RoleActionType.Allowed;
            RoleActionType resultForbidden = RoleActionType.Forbidden;

            var strSearchResource = dto?.GetType()?.Name;

            if (string.IsNullOrEmpty(strSearchResource))
                return resultForbidden;

            //поищем наименование ресурса в перечне
            if (System.Enum.TryParse(strSearchResource, out ResourceType resourceType))
            {
                return GetActionTypeByCurrentRole(resourceType);
            }

            return resultAllowed;
        }

        public static bool GetPermit(this ResourceType resourceType)
        {
            //для администратора даем доступ к распределению полномочий
            if (IsAuthAdministrator)
                if (resourceType == ResourceType.MatrixAccessRightsDTO)
                {
                    return true;
                }

            #region Пока не перешли на общую матрицу

            switch (resourceType)
            {
                case ResourceType.TransportChiefControl:
                    return _transportModuleRights.EnableTransportChiefControl;
                case ResourceType.OpenedDowntimeControl:
                    return _transportModuleRights.EnableOpenedDowntimeControl;
                case ResourceType.Viewer3D:
                    return _graphicModuleRights.AccessViewer3Dx;
                case ResourceType.PlayBack:
                    return _graphicModuleRights.EnablePlayBack;
                case ResourceType.SchemeEditor:
                    return _graphicModuleRights.EnableSchemeEditor;
                case ResourceType.Editor3D:
                    return _graphicModuleRights.EnableEditor3D;
                case ResourceType.EmergencyCall:
                    return _graphicModuleRights.EnableEmergencyCall;
                case ResourceType.EmergencyReset:
                    return _graphicModuleRights.EnableEmergencyReset;
                case ResourceType.PagerCall:
                    return _graphicModuleRights.EnablePagerCall;
                case ResourceType.IndividualCalls:
                    return _graphicModuleRights.EnableIndividualCalls;

                default:
                    if (resourceType.IsMatchResourceCategory(ResourceCategory.Reports))
                    {
                        return _reportTypes.Contains(resourceType);
                    }

                    break;
            }
            #endregion Пока не перешли на общую матрицу

            //UpdateByAllowFlags
            var allowFlags = GetActionTypeByCurrentRole(resourceType);
            if (!allowFlags.HasFlag(RoleActionType.Read))
            {
                return false;
            }


            //нет запрета на доступ (просмотр таблицы)
            return true;
        }

        #endregion

        private static List<ResourceType> _reportTypes = new();
        private static ItemTransportModuleRights _transportModuleRights;

        public static List<ResourceType> ReportRights
        {
            get => _reportTypes.ToList();
            set
            {
                _reportTypes = value;
                RaiseAccessRightsChanged();
            }
        }

        public static ItemTransportModuleRights TransportModuleRights
        {
            get => _transportModuleRights;
            set
            {
                _transportModuleRights = value;
                RaiseAccessRightsChanged();
            }
        }

        #region EvAccessRightsChanged

        /// <summary>
        /// Событие уведомляющие об изменении перечня разрешений для пользователя.
        /// </summary>
        public static event EventHandler EvAccessRightsChanged;

        /// <summary>
        /// Опубликовать событие об изменении перечня разрешений для пользователя.
        /// </summary>
        public static void RaiseAccessRightsChanged()
        {
            if (!IsAuthorized)
            {
                return;
            }
            EvAccessRightsChanged?.Invoke(null, EventArgs.Empty);
        }

        #endregion
    }
}
