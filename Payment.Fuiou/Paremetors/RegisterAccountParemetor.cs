/***********************************
 * Create Date: 2015/10/23 12:02:46
 * Author     ：赵赫昂
 * Description: 
 * ********************************/

using Payment.Fuiou.Fuyou;
using System.Collections.Generic;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 1 注册用户 
    /// </summary>
    public class RegisterAccountParemetor : FuiouParemetor
    {
        #region Properties

        /// <summary>
        /// 客户姓名 
        /// </summary> 
        [Paremetor("cust_nm")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 身份证号[Y]
        /// </summary>
        [Paremetor("certif_id")]
        public string IdentityNo { get; set; }

        /// <summary>
        /// 手机号码[Y]
        /// </summary>
        [Paremetor("mobile_no")]
        public string PhoneNo { get; set; }

        /// <summary>
        ///  邮箱地址[Y]
        /// </summary>
        [Paremetor("email")]
        public string Email { get; set; }

        /// <summary>
        /// 开户行地区代码 
        /// </summary>
        [Paremetor("city_id")]
        public string BankAreaCode { get; set; }

        /// <summary>
        /// 开户行行别
        /// </summary>
        [Paremetor("parent_bank_id")]
        public string BankLevel { get; set; }

        /// <summary>
        ///开户支行名称
        /// </summary>
        [Paremetor("bank_nm")]
        public string BankName { get; set; }

        /// <summary>
        /// 户名
        /// </summary>
        [Paremetor("capAcntNm")]
        public string AccountName { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Paremetor("capAcntNo")]
        public string AccountNo { get; set; }

        /// <summary>
        ///提现密码
        /// </summary>
        [Paremetor("password")]
        public string Password { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [Paremetor("lpassword")]
        public string LoginPassword { get; set; }


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
            //bank_nm+"|"+capAcntNm+"|"+capAcntNo+"|"+certif_id+"|"+city_id+"|"+cust_nm+"|"+email+"|"+lpassword+"|"+mchnt_cd+"|"+mchnt_txn_ssn+"|"+mobile_no+"|"+parent_bank_id+"|"+password+"|"+rem
            return new string[] { "bank_nm","capAcntNm","capAcntNo","certif_id","city_id","cust_nm","email",
"lpassword","mchnt_cd","mchnt_txn_ssn","mobile_no","parent_bank_id","password","rem", "signature"
            };
        }

        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.Reg.Action"];
        }
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.CustomerName, 30, "客户姓名");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.IdentityNo, 20, "身份证号码");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.PhoneNo, 11, "手机号码");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.BankAreaCode, 4, "开户行地区代码");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.BankLevel, 4, "开户行行别");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.AccountNo, 30, "账号");
        }
    }
}
