using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Utis.Minex.Common.Enum;
using Utis.Minex.Common.Interfaces;

namespace Utis.Minex.ClientUpdater
{
    /// <summary>
    /// Установщик
    /// </summary>
    public interface IUpdater
    {
        /// <summary>
        /// Заменитель пробелов для работы с WinApi
        /// </summary>
        const char ReplacerOfSpaces = '^';
        /// <summary>
        /// Наименование канала связи с сервисом обновления
        /// </summary>
        const string ServicePipeName = "utis_update_service";

        /// <summary>
        /// Собираемый Exe файл текущего пакета
        /// </summary>
        static string PathExeActivePackage { get; private set; }


        /// <summary>
        /// Прогресс обновления
        /// </summary>
        event Action<IProgressEvent> OnProgress;

        static IUpdater()
        {
            PathExeActivePackage = Process.GetCurrentProcess().MainModule?.FileName ?? string.Empty;
        }

        /// <summary>
        /// Начать обновление
        /// </summary>
        Task StartUpdating();

        /// <summary>
        /// Получить данные о пакетах. => надо синхронизировать с упаковкой дистрибутивов
        /// </summary>
        /// <param name="clientType"></param>
        /// <param name="nameProduct"></param>
        /// <param name="exeFileName"></param>
        /// <returns></returns>
        //static bool CheckNameProduct(PackageType clientType, out string nameProduct, out string exeFileName)
        //{
        //    var package = PackagesData.GetPackage(clientType);
        //    package.FullName
        //    nameProduct = exeFileName = string.Empty;
        //    switch (clientType)
        //    {
        //        case PackageType.SeniorLampman:
        //            nameProduct = "UtisMinexSeniorLampman";
        //            exeFileName = "Utis.Minex.SeniorLampman";
        //            break;
        //        case PackageType.Dispatcher:
        //            nameProduct = "UtisMinexDispatcherClient";
        //            exeFileName = "Utis.Minex.DispatcherClient";
        //            break;
        //        case PackageType.Updater:
        //            nameProduct = "UtisMinexClientUpdater";
        //            exeFileName = "Utis.Minex.ClientUpdater";
        //            break;
        //        case PackageType.Server:
        //            nameProduct = "UtisMinexServer";
        //            exeFileName = "Utis.Minex.Server";
        //            break;
        //    }

        //    return !string.IsNullOrEmpty(nameProduct);
        //}
    }
}
