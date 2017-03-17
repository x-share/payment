namespace Payment.Unspay.DelegatePay
{


    /// <summary>
    /// 委托代扣 商户账户余额及保证金余额查询接口
    /// </summary>
    public class WQueryBlanceParemetor : UnspayParemetor
    {
        /// <summary>
        /// Address
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return UnspayConfig.ApiAddress["YSB.URL.WQueryBlance"];
        }
        /// <summary>
        /// Mac fields
        /// </summary>
        /// <returns></returns>
        protected override string[] GetDataFields()
        {
            return new string[] { "accountId", "mac" };
        }
    }



    /// <summary>
    /// 委托代扣 商户账户余额及保证金余额查询接口 结果
    /// </summary>
    public class WQueryBlanceResult : UnspayResult
    {
        /// <summary>
        /// 保证金余额
        /// </summary>
        [Newtonsoft.Json.JsonProperty("bailBalance")]
        public decimal BailBalance { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [Newtonsoft.Json.JsonProperty("balance")]
        public decimal Balance { get; set; }
    }


}
