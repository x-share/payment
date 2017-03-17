using Payment.Unspay.UnspayExternal;

namespace Payment.Unspay.DelegatePay
{
    /// <summary>
    /// 结果通知
    /// </summary>
    public class WDelegatePayNotice : DelegateCollectNotice
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="resultMsg"></param>
        /// <param name="amount"></param>
        /// <param name="orderId"></param>
        /// <param name="mAC"></param>
        public WDelegatePayNotice(string resultCode, string resultMsg, string amount, string orderId, string mAC)
            : base(resultCode, resultMsg, amount, orderId, mAC)
        {
        }
    }
}
