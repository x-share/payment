using System.Collections.Generic;

namespace Payment.Unspay.UnspayExternal
{
    /// <summary>
    /// 委托代扣接口
    /// </summary>
    public class DelegateCollectParemetor : UnspayParemetor
    {
        /// <summary>
        /// 扣款目的
        /// </summary>
        [Paremetor("purpose")]
        public string Purpose { get; set; }

        /// <summary>
        /// 金额 保留两位销售  decimal.ToString("f2");
        /// </summary>
        [Paremetor("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 手机号 银行预留手机号
        /// </summary>
        [Paremetor("phoneNo")]
        public string PhoneNo { get; set; }

        /// <summary>
        ///  子协议编号 
        /// </summary>
        [Paremetor("subContractId")]
        public string SubContractId { get; set; }

        string _SSN = "";
        /// <summary>
        /// 订单号
        /// </summary>
        [Paremetor("orderId")]
        public string OrderId
        {
            get
            {
                if (_SSN == "")
                    _SSN = SSN.GetSSN();
                return _SSN;
            }
        }
        /// <summary>
        /// 响应地址
        /// </summary>
        [Paremetor("responseUrl")]
        public string ResponseUrl { get; set; }


        public DelegateCollectParemetor(string purpose, decimal amount, string subContractId, string responseUrl, string phoneNo)
        {
            Purpose = purpose;
            Amount = amount.ToString("f2");
            SubContractId = subContractId;
            ResponseUrl = responseUrl;
            PhoneNo = phoneNo;
        }

        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULL(this.Purpose, "扣款目的");
            yield return VALIDATE.NOTNULL(this.Amount.ToString(), "金额");
            yield return VALIDATE.NOTNULL(this.SubContractId, "子协议编号");
            yield return VALIDATE.NOTNULL(this.OrderId, "订单号");
            yield return VALIDATE.NOTNULL(this.ResponseUrl, " 响应地址");
        }

        public override string GetRequestUrl()
        {
            return UnspayConfig.ApiAddress["YSB.URL.DelegateCollect"];
        }

        protected override string[] GetDataFields()
        {
            return new string[] { "accountId", "subContractId", "orderId", "purpose", "amount", "phoneNo", "responseUrl", "mac" };
        }
    }


    /// <summary>
    /// 委托代扣接口 返回结果
    /// </summary>
    public class DelegateCollectResult : UnspayResult
    {
        /// <summary>
        /// 此次交易是否成功
        /// </summary>
        public override bool IsSucess
        {
            get
            {
                if (base.IsSucess)
                    base.PayErrorType = PayErrorType.NeedQuery;
                return base.IsSucess;
            }
        }
    }


}
