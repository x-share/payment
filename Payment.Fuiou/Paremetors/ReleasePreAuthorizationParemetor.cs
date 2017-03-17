/***********************************
 * Create Date: 2015/10/23 15:17:39
 * Author     ：赵赫昂
 * Description: 
 * ********************************/

using Payment.Fuiou.Fuyou;
using System.Collections.Generic;

namespace Payment.Fuiou.Paremetors
{

    /// <summary>
    /// 参数:5.	预授权撤销
    /// </summary>
    public class ReleasePreAuthorizationParemetor : FuiouParemetor
    {
        public ReleasePreAuthorizationParemetor() {  }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strOutPhoneNo">出账账户 预授权个人用户</param>
        /// <param name="strPhoneNO">入账账户 企业账户或个人用户</param>
        /// <param name="strPreauthNo">预授权合同号</param>
        /// <param name="strRem">备注</param>
        public ReleasePreAuthorizationParemetor(string strOutPhoneNo, string strPhoneNO, string strPreauthNo, string strRem="")
        {
            this.OutPhoneNo = strOutPhoneNo;
            this.PhoneNo = strPhoneNO;
            this.PreAuthNo = strPreauthNo;
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
        /// 预授权合同号
        /// </summary>
        [Paremetor("contract_no")]
        public string PreAuthNo{ get; set; }

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
            //contract_no + "|" + in_cust_no +"|"+ mchnt_cd + "|" + mchnt_txn_ssn +"|"+ out_cust_no +"|"+ rem;
            return new string[] { "contract_no", "in_cust_no", "mchnt_cd", "mchnt_txn_ssn", "out_cust_no", "rem", "signature" };
        }

        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.PreAuthCancel.Action"];
        }
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.OutPhoneNo, 60, "出账账户");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.PhoneNo, 60, "入账账户");
            yield return VALIDATE.CANNULLANDLIMITLENGTH(this.PreAuthNo, 30, "预授权合同号");
        }
    }
}
