namespace Utis.Minex.Common
{
    #region Using
    #endregion Using

    /// <summary>Интерфейс сериализации/десериализации xml</summary>
    public interface ISerializer
    {
        byte[] Serialize<T>(T tData, System.Text.Encoding encoding = null) where T : class;

        T Deserialize<T>(byte[] tData, System.Text.Encoding encoding = null) where T : class;

        string GetString(byte[] tData, System.Text.Encoding encoding = null);
    }
}
