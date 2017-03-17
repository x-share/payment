/***********************************
 * Create Date: 2015/10/23 15:53:55
 * Author     ：赵赫昂
 * Description: 
 * ********************************/

using Payment.Fuiou.Fuyou;
using System;
using System.Collections.Generic;

namespace Payment.Fuiou.Paremetors
{

    /// <summary>
    /// 参数：7.	划拨 (个人与个人之间)
    /// </summary>
    public class DirectlyDeductedParemetor : FuiouParemetor
    {
        
         public DirectlyDeductedParemetor() { }
        

         /// <summary>
         /// 
         /// </summary>
         /// <param name="amount">金额</param>
         /// <param name="strOutPhoneNo">出账账户</param>
         /// <param name="strPhoneNO">入账账户</param>
         /// <param name="strPreAuthNo">预授权</param>
         /// <param name="strRem"></param>
         public DirectlyDeductedParemetor(decimal amount, string strOutPhoneNo, string strPhoneNO, string strPreAuthNo = "", string strRem = "")
        {
            this.Amount=amount;
            this.OutPhoneNo = strOutPhoneNo;
            this.PhoneNo = strPhoneNO;
            this.PreAuthNo = strPreAuthNo;
            this.Rem = strRem;
        }

        #region Properties

        /// <summary>
        /// 付款登录账户 
        /// </summary> 
        [Paremetor("out_cust_no")]
        public string OutPhoneNo { get; set; }

        /// <summary>
        /// 收款登录账户 
        /// </summary>
        [Paremetor("in_cust_no")]
        public string PhoneNo { get; set; }

        /// <summary>
        /// 转账金额 单位元 2位小数
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 转账金额
        /// </summary>
        [Paremetor("amt")]
        internal string Money
        {
            get { return Convert.ToInt32(Amount * 100).ToString(); }
        }

        /// <summary>
        /// 预授权合同号
        /// </summary>
        [Paremetor("contract_no")]
        public string PreAuthNo { get; set; }


        /// <summary>
        /// 备注 
        /// </summary>
        [Paremetor("rem")]
        public string Rem { get; set; }

        #endregion


        /// <summary>
        /// 字段
        /// </summary>
        /// <returns></returns>
        protected override string[] GetDataFields()
        {
            //amt + "|" +contract_no+"|"+in_cust_no+"|"+ mchnt_cd + "|" + mchnt_txn_ssn+"|"+ out_cust_no +"|"+ rem
            return new string[] { "amt", "contract_no", "in_cust_no", "mchnt_cd", "mchnt_txn_ssn", "out_cust_no", "rem", "signature" };
        }

        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.TransferBu.Action"];
        }
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.OutPhoneNo, 60, "付款登录账户");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.PhoneNo, 60, "收款登录账户");
            yield return VALIDATE.CANNULLANDLIMITLENGTH(this.Money, 12, "转账金额");
        }
    }
}
