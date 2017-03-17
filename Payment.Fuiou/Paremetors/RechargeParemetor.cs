/***********************************
 * Create Date: 2015/10/23 9:38:47
 * Author     ：赵赫昂
 * Description: 
 * ********************************/

using Payment.Fuiou.Fuyou;
using System;
using System.Collections.Generic;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 参数:29 快速充值
    /// </summary>
    public class RechargeParemetor : FuiouParemetor
    {
        #region Properties

        /// <summary>
        /// 用户登录名 
        /// </summary> 
        [Paremetor("login_id")]
        public string LoginId { get; set; }

        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal Amount { get; set; }

        [Paremetor("amt")]
        internal string Amt
        {
            get { return Convert.ToInt32(Amount * 100).ToString(); }
        }

        /// <summary>
        /// 商户返回地址 
        /// </summary>
        [Paremetor("page_notify_url")]
        public string PageNotifyUrl { get; set; }

        /// <summary>
        /// 商户后台通知地址 
        /// </summary>
        [Paremetor("back_notify_url")]
        public string BackNotifyUrl { get; set; }

        #endregion


        /// <summary>
        /// 字段
        /// </summary>
        /// <returns></returns>
        protected override string[] GetDataFields()
        {
          
            return new string[] { "amt", "back_notify_url", "login_id", "mchnt_cd", "mchnt_txn_ssn", "page_notify_url", "signature" };
        }

        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.Recharge.Action"];
        }
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.LoginId, 60, "用户登录名");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.Amt, 12, "充值金额");         
            yield return VALIDATE.CANNULLANDLIMITLENGTH(this.PageNotifyUrl, 200, "商户返回地址");
        }
    }

}
