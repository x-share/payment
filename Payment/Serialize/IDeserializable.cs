using System;

namespace Payment.Serialize
{
    /// <summary>
    /// 可反序列化
    /// </summary>
    public interface IDeserializable
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Deserialize<T>(string value) where T : class;
    }

    public interface IStringSerializeStruct
    {
        string Value { get; set; }
    }

    public class StringSerialize : IDeserializable, ISerializable
    {

        public T Deserialize<T>(string value) where T : class
        {
            var ins = Activator.CreateInstance<T>();
            if (ins is IStringSerializeStruct)
            {
                var obj = ins as IStringSerializeStruct;
                obj.Value = value;
            }
            return ins;
        }

        public string Serialize<T>(T obj)
           where T : class
        {
            if (obj != null && obj is IStringSerializeStruct)
            {
                return (obj as IStringSerializeStruct).Value;
            }
            return "";
        }
    }
}
