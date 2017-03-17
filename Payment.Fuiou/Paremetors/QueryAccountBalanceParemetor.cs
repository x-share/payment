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
    /// 参数:3查询余额
    /// </summary>
    public class QueryAccountBalanceParemetor : FuiouParemetor
    {

        public QueryAccountBalanceParemetor() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCustNoPhone">待查询的登录帐户列表</param>
        /// <param name="strMchntTxnDtTradingDate">交易日期 8位交易代码 格式：yyyyMMdd</param>
        public QueryAccountBalanceParemetor(string strCustNoPhone, string strMchntTxnDtTradingDate="")
        {
            this.CustNoPhone = strCustNoPhone;
            this.MchntTxnDtTradingDate =string.IsNullOrEmpty( strMchntTxnDtTradingDate)?DateTime.Now.ToString("yyyyMMdd"):strMchntTxnDtTradingDate;
        }

        #region Properties

        /// <summary>
        /// 交易日期 8位交易代码 格式：yyyyMMdd
        /// </summary> 
        [Paremetor("mchnt_txn_dt")]
        public string MchntTxnDtTradingDate { get ; set; }

        /// <summary>
        /// 待查询的登录帐户列表 
        /// </summary> 
        [Paremetor("cust_no")]
        public string CustNoPhone { get; set; }

      

        #endregion


        /// <summary>
        /// 字段
        /// </summary>
        /// <returns></returns>
        protected override string[] GetDataFields()
        {
            //cust_no+"|"+ "|"+mchnt_cd+"|"+mchnt_txn_dt"|"+ mchnt_txn_ssn 
            return new string[] { "cust_no", "mchnt_cd", "mchnt_txn_dt", "mchnt_txn_ssn", "signature" };
        }

        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.BalanceAction.Action"];
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