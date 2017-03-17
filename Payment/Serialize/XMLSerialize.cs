using Payment.Exception;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Payment.Serialize
{
    /// <summary>
    /// XML序列化
    /// </summary>
    public class XMLSerialize : IDeserializable, ISerializable
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Deserialize<T>(string value) where T : class
        {
            if (typeof(T).Name == "String") return value as T;

            T result = Activator.CreateInstance<T>();
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                XmlTextReader reader = new XmlTextReader(new StringReader(value));
                result = (T)ser.Deserialize(reader);
            }
            catch (System.Exception e)
            {
                throw new TypeConvertException("数据无法转换成类型" + typeof(T).Name);
            }
            if (result is IPayReturnValue)
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
            return SERIALIZER.Serializer<T>(obj);
        }
    }
}
