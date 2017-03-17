using System;

namespace Payment.Exception
{
    /// <summary>
    /// 网络异常
    /// </summary>
    public class NetException : System.Exception
    {
        public NetException() { }
        public NetException(string message) : base(message) { }
        public NetException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
