using Payment.Fuiou.Fuyou;
using System;
using System.Collections.Generic;

namespace Payment.Fuiou.Paremetors
{

    /// <summary>
    /// 参数:转账预冻结
    /// </summary>
    public class TransferBmuAndFreezeParemetor : FuiouParemetor
    {

        public TransferBmuAndFreezeParemetor() { }

        //     Amount = 12.22m,
        //     InAccountNo = "14875369800",
        //     OutAccountNo = "14855554411",
        //     Remark = "Remark",

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount">转账金额</param>
        /// <param name="strInAccount">收款登录账户</param>
        /// <param name="strOutAccountNo">付款登录账户</param>
        /// <param name="strRemark"></param>
        public TransferBmuAndFreezeParemetor(decimal amount,string  strInAccount,string strOutAccountNo,string strRemark="") 
        {
            this.Amount = amount;
            this.InAccountNo = strInAccount;
            this.OutAccountNo = strOutAccountNo;
            this.Remark = strRemark;
        }

        #region Properties

        /// <summary>
        /// 付款登录账户
        /// </summary>
        [Paremetor("out_cust_no")]
        public string OutAccountNo { get; set; }

        /// <summary>
        /// 收款登录账户
        /// </summary>
        [Paremetor("in_cust_no")]
        public string InAccountNo { get; set; }

        /// <summary>
        /// 转账金额
        /// </summary>
        public decimal Amount { get; set; }


        [Paremetor("amt")]
        internal string FuiouAmount
        {
            get { return Convert.ToInt32(Amount * 100).ToString(); }
        }

        /// <summary>
        /// 备注
        /// </summary>
        [Paremetor("rem")]
        public string Remark { get; set; }

        #endregion


        /// <summary>
        /// 字段
        /// </summary>
        /// <returns></returns>
        protected override string[] GetDataFields()
        {
            return new string[] { "mchnt_cd", "mchnt_txn_ssn", "amt", "in_cust_no", "rem", "out_cust_no", "signature" };
        }

        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.TransferBmuAndFreeze.Action"];
        }
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.OutAccountNo, 60, "付款登录账户");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.InAccountNo, 60, "收款登录账户");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.FuiouAmount, 12, "转账金额");
            yield return VALIDATE.CANNULLANDLIMITLENGTH(this.Remark, 100, "备注");
        }
    }
}
