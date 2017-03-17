using Payment.Unspay.UnspayExternal;

namespace Payment.Unspay.DelegatePay
{
    /// <summary>
    /// 订单状态查询接口
    /// </summary>
    public class WQueryOrderStatusParemetor : QueryOrderStatusParemetor
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderId"></param>
        public WQueryOrderStatusParemetor(string orderId) : base(orderId) { }

        /// <summary>
        /// The address of request
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return UnspayConfig.ApiAddress["YSB.URL.WQueryOrderStatus"];
        }
    }

    /// <summary>
    /// 订单状态查询 结果
    /// </summary>
    public class WQueryOrderStatusResult : QueryOrderStatusResult
    {

    }
}
