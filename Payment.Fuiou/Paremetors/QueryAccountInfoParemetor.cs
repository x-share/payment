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
    /// 参数:8查询账户信息 	用户信息查询接口
    /// </summary>
    public class QueryAccountInfoParemetor : FuiouParemetor
    {

         public QueryAccountInfoParemetor() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCustNoPhone">待查询的登录帐户列表</param>
        /// <param name="strMchntTxnDtTradingDate">交易日期 8位交易代码 格式：yyyyMMdd</param>
         public QueryAccountInfoParemetor(string strCustNoPhone, string strMchntTxnDtTradingDate = "")
        {
            this.CustNoPhone = strCustNoPhone;
            this.MchntTxnDtTradingDate =string.IsNullOrEmpty(strMchntTxnDtTradingDate)?DateTime.Now.ToString("yyyyMMdd"):strMchntTxnDtTradingDate;
        }


        #region Properties

        /// <summary>
        /// 交易日期 8位交易代码
        /// </summary> 
        [Paremetor("mchnt_txn_dt")]
        public string MchntTxnDtTradingDate { get; set; }

        /// <summary>
        /// 待查询的登录帐户列表  查询企业注册的手机号，多个帐号请以”|”分隔 （最多只能同时查10个用户）
        /// </summary> 
        [Paremetor("user_ids")]
        public string CustNoPhone { get; set; }



        #endregion


        /// <summary>
        /// 字段
        /// </summary>
        /// <returns></returns>
        protected override string[] GetDataFields()
        {
            //：mchnt_cd+"|"+mchnt_txn_dt+"|"+mchnt_txn_ssn+"|"+user_ids
            return new string[] { "mchnt_cd", "mchnt_txn_dt", "mchnt_txn_ssn", "user_ids", "signature" };
        }

        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.QueryUserInfs.Action"];
        }
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.MchntTxnDtTradingDate, 8, "交易日期");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.CustNoPhone, 120, "待查询的登录帐户列表");
        }
    }
}