using System;

namespace Payment.Exception
{
    /// <summary>
    /// 未实现的支付功能
    /// </summary>
    public class UnrealizedPaymentException : System.Exception
    {
        public UnrealizedPaymentException() : base("未实现的支付功能")
        {

        }
    }
}
