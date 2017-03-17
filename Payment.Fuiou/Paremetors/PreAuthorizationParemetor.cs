/***********************************
 * Create Date: 2015/10/23 14:56:32
 * Author     ：赵赫昂
 * Description: 
 * ********************************/

using Payment.Fuiou.Fuyou;
using System;
using System.Collections.Generic;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 参数:4 预授权
    /// </summary>
    public class PreAuthorizationParemetor : FuiouParemetor
    {
        public PreAuthorizationParemetor() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount">预授权金额</param>
        /// <param name="strOutPhoneNo">出账账户</param>
        /// <param name="strPhoneNo">入账账户</param>
        /// <param name="strRem">备注</param>
        public PreAuthorizationParemetor(decimal amount,string strOutPhoneNo,string strPhoneNo,string strRem="") {
            this.Amount = amount;
            this.OutPhoneNo = strOutPhoneNo;
            this.PhoneNo = strPhoneNo;
            this.Rem = strRem;
        }

        #region Properties

        /// <summary>
        /// 出账账户 
        /// </summary> 
        [Paremetor("out_cust_no")]
        public string OutPhoneNo { get; set; }

        /// <summary>
        /// 入账账户 
        /// </summary>
        [Paremetor("in_cust_no")]
        public string PhoneNo { get; set; }

        /// <summary>
        /// 预授权金额
        /// </summary>
        public decimal Amount { get; set; }

        [Paremetor("amt")]
        internal string Money
        {
            get { return Convert.ToInt32(Amount * 100).ToString(); }
        }

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
            //amt + "|" + in_cust_no +"|"+ mchnt_cd + "|" + mchnt_txn_ssn +"|"+ out_cust_no +"|"+ rem;
            return new string[] { "amt", "in_cust_no", "mchnt_cd", "mchnt_txn_ssn", "out_cust_no", "rem", "signature" };
        }

        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.PreAuth.Action"];
        }
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.OutPhoneNo, 60, "出账账户");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.PhoneNo, 60, "入账账户");
            yield return VALIDATE.CANNULLANDLIMITLENGTH(this.Money, 12, "预授权金额");
        }
    }
}
