using System;

namespace Payment.Exception
{
    /// <summary>
    /// 类型转换异常
    /// </summary>
    public class TypeConvertException : System.Exception
    {
        public TypeConvertException() { }
        public TypeConvertException(string message) : base(message) { }
        public TypeConvertException(string message, System.Exception innerException) : base(message, innerException) { }
    }

}
