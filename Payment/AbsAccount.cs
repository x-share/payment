using Payment.Exception;
using Payment.Serialize;

namespace Payment
{
    /// <summary>
    /// 账户基础信息
    /// </summary>
    public abstract class AbsAccount
    {
        /// <summary>
        /// 第三方支付类型
        /// </summary>
        public abstract string Type { get; }

        public abstract IDeserializable GetDeserializer();
        public abstract string GetLog4netAppender();
    }

    /// <summary>
    /// 第三方支付返回的数据
    /// </summary>
    public interface IPayReturnValue
    {
        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="value"></param>
        void SetValue(object value);
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        object GetValue();

    }


    /// <summary>
    /// 结果
    /// </summary>
    public class AbsResult : IPayReturnValue
    {
        /// <summary>
        /// 账户类型
        /// </summary>
        public virtual string TYPE { get; set; }
        /// <summary>
        /// 此次交易是否成功
        /// </summary>
        public virtual bool IsSucess { get; set; }
        /// <summary>
        /// 返回码
        /// </summary>
        public virtual string ResponseCode { get; set; }
        /// <summary>
        /// 返回码描述
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 异常类型
        /// </summary>
        public PayErrorType PayErrorType = PayErrorType.None;

        /// <summary>
        /// 第三方支付返回的数据
        /// </summary>
        public object PayReturnValue { get; set; }


        protected AbsResult() { }

        public void Set(string t, bool isSucc, string code, string des)
        {
            TYPE = t;
            IsSucess = isSucc;
            ResponseCode = code;
            Description = des;
        }
        public void Set(string t, bool isSucc, string code, System.Exception e)
        {


            if (e is NetException)
            {
                PayErrorType = PayErrorType.NetException;
                code = "9997";
            }
            else if (e is TypeConvertException)
                PayErrorType = PayErrorType.TypeConvertException;
            else if (e is UnrealizedPaymentException)
                PayErrorType = PayErrorType.UnrealizedPaymentException;
            else if (e is DisableApiException)
            {
                PayErrorType = PayErrorType.DisableApi;
                code = "9990";
            }
            else if (e is VerifyException)
            {
                //银联验签失败
                PayErrorType = PayErrorType.VerifyException;
                code = "9996";
            }
            else
            {
                PayErrorType = PayErrorType.OtherException;
            }

            Set(t, isSucc, code, e.Message);

        }

        public void SetValue(object value)
        {
            this.PayReturnValue = value;
        }

        public object GetValue()
        {
            return this.PayReturnValue;
        }
    }

}