namespace Payment.Unspay
{
    /// <summary>
    /// 银生宝 基础结果
    /// </summary>
    public class UnspayResult : AbsResult
    {
        /// <summary>
        /// 账户类型
        /// </summary>
        public override string TYPE
        {
            get
            {
                return "unspay";
            }
        }

        /// <summary>
        /// 返回码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result_code")]
        public override string ResponseCode
        {
            get; set;
        }

        /// <summary>
        /// 返回码描述
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result_msg")]
        public override string Description
        {
            get; set;
        }

        /// <summary>
        /// 此次交易是否成功
        /// </summary>
        public override bool IsSucess
        {
            get
            {
                return !string.IsNullOrEmpty(ResponseCode) && ResponseCode == "0000";
            }
        }
    }
}
