using Payment.Fuiou.Fuyou;
using System.Collections.Generic;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 参数:42 商户P2P网站免登录用户更换银行卡接口
    /// </summary>
    public class ChangeCardParemetor : FuiouParemetor
    {
        
        /// <summary>
        /// 个人用户
        /// </summary>
        [Paremetor("login_id")]
        public string User { get; set; }
        
        /// <summary>
        /// 商户返回地址
        /// </summary>
        [Paremetor("page_notify_url")]
        public string NotifyUrl { get; set; }
        
        /// <summary>
        /// 字段
        /// </summary>
        /// <returns></returns>
        protected override string[] GetDataFields()
        {
            return new string[] { "login_id", "mchnt_cd", "mchnt_txn_ssn", "page_notify_url","signature" };
        }

        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.ChangeCard.Action"];
        }
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.User, 11, "用户登录ID");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.NotifyUrl, 200, "商户前端接收交易结果地址");
        }
    }
}
