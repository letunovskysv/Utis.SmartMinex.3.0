namespace Utis.Minex.Common.Enum
{
    /// <summary>Extensions for reader data</summary>
    public static class ReaderDataExExtension
    {
        /// <summary>Функция определения признака нажатия кнопки</summary>
        public static bool GetButton(this ReaderDataEx data)
        {
            return data.HasFlag(ReaderDataEx.Button);
        }

        /// <summary>Функция получения номера антенны</summary>
        public static int GetAntennaNumber(this ReaderDataEx data)
        {
            int antenna = 0;

            if (data == ReaderDataEx.Antenna1)
                antenna = 1;
            else if (data == ReaderDataEx.Antenna2)
                antenna = 2;
            else if (data == ReaderDataEx.Antenna3)
                antenna = 3;
            else if (data == ReaderDataEx.Antenna4)
                antenna = 4;

            return antenna;
        }
    }
}
