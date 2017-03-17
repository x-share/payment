using System;

namespace Payment.Exception
{
    /// <summary>
    /// 禁用的接口
    /// </summary>
    public class DisableApiException : System.Exception
    {
        public DisableApiException() { }
        public DisableApiException(string message) : base(message) { }
        public DisableApiException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
