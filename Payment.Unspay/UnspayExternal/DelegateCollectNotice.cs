using System.Collections.Generic;

namespace Payment.Unspay.UnspayExternal
{
    /// <summary>
    /// 委托代扣结果通知
    /// </summary>
    public class DelegateCollectNotice : UnspayParemetor
    {
        /// <summary>
        /// 响应码
        /// </summary>
        [Paremetor("result_code")]
        public string ResultCode { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        [Paremetor("result_msg")]
        public string ResultMsg { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [Paremetor("amount")]
        public string Amount { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Paremetor("orderId")]
        public string OrderId { get; set; }

        /// <summary>
        /// 数字签名
        /// </summary>
        public string MAC
        {
            get; set;
        }

        public DelegateCollectNotice(string resultCode, string resultMsg, string amount, string orderId, string mAC)
        {
            ResultCode = resultCode;
            ResultMsg = resultMsg;
            Amount = amount;
            OrderId = orderId;
            MAC = mAC;
        }
        protected override string[] GetDataFields()
        {
            return new string[] { "accountId", "orderId", "amount", "result_code", "result_msg", "mac" };
        }
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULL(this.ResultCode, "响应码");
            yield return VALIDATE.CANNULLANDLIMITLENGTH(this.ResultMsg, 8000, "返回信息");
            yield return VALIDATE.NOTNULL(this.Amount, "金额");
            yield return VALIDATE.NOTNULL(this.MAC, "订单号");
        }

        /// <summary>
        /// 是否合法
        /// </summary>
        /// <returns></returns>
        public bool IsValidate()
        {
            return !string.IsNullOrEmpty(MAC) && GetSignature() == MAC;
        }
        public override string GetRequestUrl()
        {
            return "";
        }

        protected override bool IsFilterNullOrEmptyField()
        {
            return false;
        }

    }
}
