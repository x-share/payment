using Payment.Unspay.UnspayExternal;
using System.Collections.Generic;

namespace Payment.Unspay.DelegatePay
{
    /// <summary>
    /// 实时代付接口
    /// </summary>
    public class WDelegatePayParemetor : UnspayParemetor
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        [Paremetor("name")]
        public string Name { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        [Paremetor("cardNo")]
        public string CardNo { get; set; }
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
        /// 付款目的
        /// </summary>
        [Paremetor("purpose")]
        public string Purpose { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Paremetor("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Paremetor("responseUrl")]
        public string ResponseUrl { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cardNo"></param>
        /// <param name="purpose"></param>
        /// <param name="amount"></param>
        public WDelegatePayParemetor(string name, string cardNo, string purpose, decimal amount)
        {
            Name = name;
            CardNo = cardNo;
            Purpose = purpose;
            Amount = amount.ToString("f2");
            ResponseUrl = UnspayConfig.GetAppSetting("YSB.WNotice");
        }

        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULL(this.Purpose, "扣款目的");
            yield return VALIDATE.NOTNULL(this.Amount.ToString(), "金额");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.Name, 32, "用户姓名");
            yield return VALIDATE.NOTNULL(this.CardNo, "银行卡号");
            yield return VALIDATE.NOTNULL(this.ResponseUrl, " 响应地址");
        }

        public override string GetRequestUrl()
        {
            return UnspayConfig.ApiAddress["YSB.URL.WDelegatePay"];
        }

        protected override string[] GetDataFields()
        {
            return new string[] { "accountId", "name", "cardNo", "orderId", "purpose", "amount", "responseUrl", "mac" };
        }
    }

    /// <summary>
    /// 实时代付-结果
    /// </summary>
    public class WDelegatePayResult : DelegateCollectResult
    {

    }

}
