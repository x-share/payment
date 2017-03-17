/***********************************
 * Create Date: 2015/10/29 10:28:59
 * Author     ：赵赫昂
 * Description: 
 * ********************************/

using Payment.Fuiou.Fuyou;
using System;
using System.Collections.Generic;

namespace Payment.Fuiou.Paremetors
{

    ///<summary>
    /// 1.		委托充值
    ///    商户通过此接口发起对应用户的提现。前提包含：
    ///充值上线100W；
    ///充值用户必须签约；
    ///充值用户没有修改未生效
    ///如果提现金额超过风控限制，需要等待用户确认才能发起提现，接口将返回0001（受理成功），后期等待通知；
    ///否则，立即发起提现（不需要用户确认），成功将返回0000；
    /// </summary>
    public class WtrechargeParemetor : FuiouParemetor
    {

        public WtrechargeParemetor() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strLoginId">用户登录名</param>
        /// <param name="amount">金额</param>
        /// <param name="strRem">备注</param>
        public WtrechargeParemetor(string strLoginId, decimal amount, string strRem="")
        {
            this.LoginId = strLoginId;
            this.Amount = amount;
            this.Rem = strRem;
        }


        /// <summary>
        /// 后台通知地址 
        /// </summary>
        [Paremetor("back_notify_url")]
        public string BackNotifyUrl
        {
            get
            {
                return FuiouConfig.WtrechargeResultBackNotifyUrl;
            }
          
        }

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
        /// rem 
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
            //amt+"|"+ back_notify_url + "|"+ login_id + "|"+ mchnt_cd +"|" +mchnt_txn_ssn+"|"+rem
            return new string[] { "amt", "back_notify_url", "login_id", "mchnt_cd", "mchnt_txn_ssn", "rem", "signature" };
        }
        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.Wtrecharge.Action"];
        }
       
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(LoginId, 11, "委托充值用户");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(Amt, 12, "委托充值金额");
            yield return VALIDATE.CANNULLANDLIMITLENGTH(BackNotifyUrl, 256, "后台通知地址");

        }

    }
}
