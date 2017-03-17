using System.Collections.Generic;

namespace Payment.Unspay.UnspayExternal
{
    /// <summary>
    /// 订单状态查询接口
    /// </summary>
    public class QueryOrderStatusParemetor : UnspayParemetor
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [Paremetor("orderId")]
        public string OrderId { get; set; }

        public QueryOrderStatusParemetor(string orderId)
        {
            OrderId = orderId;
        }

        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULL(this.OrderId, "订单号");
        }

        public override string GetRequestUrl()
        {
            return UnspayConfig.ApiAddress["YSB.URL.QueryOrderStatus"];
        }

        protected override string[] GetDataFields()
        {
            return new string[] { "accountId", "orderId", "mac" };
        }

    }

    /// <summary>
    /// 订单状态查询接口 结果
    /// </summary>
    public class QueryOrderStatusResult : UnspayResult
    {
        /// <summary>
        /// 交易状态
        /// </summary>
        public enum EStatus
        {
            /// <summary>
            /// None
            /// </summary>
            None,
            /// <summary>
            /// Success
            /// </summary>
            Success,
            /// <summary>
            /// Handing
            /// </summary>
            Handing,
            /// <summary>
            /// Failure
            /// </summary>
            Failure
        }


        /// <summary>
        /// ： 00，成功； 10，处理中； 20，失败
        /// </summary>
        [Newtonsoft.Json.JsonProperty("status")]
        public string StatusStr { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public EStatus Status
        {
            get
            {
                switch (StatusStr ?? "")
                {
                    case "00":
                        return EStatus.Success;
                    case "10":
                        return EStatus.Handing;
                    case "20":
                        return EStatus.Failure;
                }
                return EStatus.None;
            }
        }

        /// <summary>
        /// 交易结果描述信息；仅当result_code为0000时出现
        /// </summary>
        [Newtonsoft.Json.JsonProperty("desc")]
        public string Desc { get; set; }
        /// <summary>
        /// 此次交易是否成功
        /// </summary>
        public override bool IsSucess
        {
            get
            {
                if ((!string.IsNullOrEmpty(ResponseCode) && ResponseCode == "0000") && (Status == EStatus.Success || Status == EStatus.Handing))
                {
                    if (Status == EStatus.Handing)
                        PayErrorType = PayErrorType.NeedQuery;
                    return true;
                }
                return false;
            }
        }
    }
}
