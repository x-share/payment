using Payment.Fuiou.Fuyou;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 参数:划拨预冻结
    /// </summary>
    public class TransferBuAndFreezeParemetor : TransferBmuAndFreezeParemetor
    {

        public TransferBuAndFreezeParemetor()
        { }

        public TransferBuAndFreezeParemetor(decimal amount, string strInAccount, string strOutAccountNo, string strRemark = "") : base(amount,strInAccount ,strOutAccountNo, strRemark) { }



        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.TransferBuAndFreeze.Action"];
        }
    }

}
