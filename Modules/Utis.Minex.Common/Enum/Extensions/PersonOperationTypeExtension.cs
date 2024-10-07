
namespace Utis.Minex.Common.Enum
{
    /// <summary>Extensions for persen operations</summary>
    public static class PersonOperationTypeExtension
    {
        public static PersonOperationType GetNext(this PersonOperationType prevOper, bool isMine)
        {
            bool prevIsMine = prevOper.IsInMine();

            return
                (prevIsMine && isMine)  ? PersonOperationType.Shaft :     //Был в шахте, там и остался:           "В шахте"
                (prevIsMine && !isMine) ? PersonOperationType.OutShaft :  //Был в шахте, теперь на поверхности:   "Выход из шахты"
                (!prevIsMine && isMine) ? PersonOperationType.InShaft :   //Был на поверхности, теперь в шахте:   "Вход в шахту"
                                        PersonOperationType.Surface;      //Был на поверхности, там и остался:    "Поверхность"
        }

        /// <summary>
        /// Фактически в шахте?
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsInMine(this PersonOperationType type)
        {
            return type == PersonOperationType.InShaft || type == PersonOperationType.Shaft;
        }

        /// <summary>
        /// Событие входа или выхода
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsInOrOut(this PersonOperationType type)
        {
            return type == PersonOperationType.InShaft || type == PersonOperationType.OutShaft;
        }
    }
}
