namespace Payment.Serialize
{
    /// <summary>
    /// Json序列化
    /// </summary>
    public class JsonSerialize : IDeserializable, ISerializable
    {

        public static JsonSerialize New()
        {
            return new JsonSerialize();
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Deserialize<T>(string value) where T : class
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
            if (result != null && (result is IPayReturnValue))
                (result as IPayReturnValue).SetValue(value);
            return result;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize<T>(T obj) where T : class
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
}
