namespace Payment.Serialize
{
    /// <summary>
    /// 可序列化
    /// </summary>
    public interface ISerializable
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        string Serialize<T>(T obj) where T : class;
    }
}
