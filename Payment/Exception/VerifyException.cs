using System;

namespace Payment.Exception
{
    /// <summary>
    /// 银联请求异常 用于在发送请求时 验证签名失败
    /// </summary>
    public class VerifyException : System.Exception
    {
        public VerifyException() { }
        public VerifyException(string message) : base(message) { }
        public VerifyException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
