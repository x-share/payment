/***********************************
 * Create Date: 2015/10/23 14:13:22
 * Author     ：赵赫昂
 * Description: 
 * ********************************/

using Payment.Fuiou.Fuyou;
using System;
using System.Collections.Generic;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 参数:12 冻结
    /// </summary>
    public class UnFreezeParemetor : FuiouParemetor
    {
          public UnFreezeParemetor() { }

       

          /// <summary>
          /// 
          /// </summary>
          /// <param name="amount">冻结金额</param>
          /// <param name="strPhoneNo">冻结目标登录账户</param>
          /// <param name="strRemark"></param>
          public UnFreezeParemetor(decimal amount, string strPhoneNo, string strRemark = "")
          {
              this.PhoneNo = strPhoneNo;
              this.Remark = strRemark;
              this.Amount = amount;
          }

        #region Properties

        /// <summary>
        /// 冻结目标登录账户 
        /// </summary> 
        [Paremetor("cust_no")]
        public string PhoneNo { get; set; }

        /// <summary>
        /// 冻结金额
        /// </summary>
        public decimal Amount { get; set; }

        [Paremetor("amt")]
        internal string Amt
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
            //amt + "|" + cust_no + "|" + mchnt_cd + "|" + mchnt_txn_ssn + "|" + rem;
            return new string[] { "amt", "cust_no", "mchnt_cd", "mchnt_txn_ssn" , "rem", "signature" };
        }

        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.UnFreeze.Action"];
        }
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.PhoneNo, 60, "冻结目标登录账户");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.Amt, 12, "冻结金额");
        }
    }
}