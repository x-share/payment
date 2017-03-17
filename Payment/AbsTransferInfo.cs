using Payment.Serialize;
using System;

namespace Payment
{
    public class AbsTransferInfo : AbsAccount
    {
        /// <summary>
        /// 转出账户
        /// </summary>
        public AbsAccount From { get; set; }
        /// <summary>
        /// 转入账户
        /// </summary>
        public AbsAccount To { get; set; }

        public override string Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override IDeserializable GetDeserializer()
        {
            throw new NotImplementedException();
        }

        public override string GetLog4netAppender()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 转账结构
    /// </summary>
    public sealed class TransferInfo : AbsTransferInfo
    {

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// 转账时间
        /// </summary>
        public DateTime Time { get; set; }

        private TransferInfo() { }
        private TransferInfo(AbsAccount from, AbsAccount to, decimal amount, string notes, DateTime time)
        {
            From = from;
            To = to;
            Amount = amount;
            Notes = notes;
            Time = time;
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="amount"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public static AbsTransferInfo Create(AbsAccount from, AbsAccount to, decimal amount, string notes = "")
        {
            return new TransferInfo(from, to, amount, notes, DateTime.Now);
        }
    }
}
