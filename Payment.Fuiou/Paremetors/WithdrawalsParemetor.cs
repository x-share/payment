/***********************************
 * Create Date: 2015/10/23 9:58:47
 * Author     ：赵赫昂
 * Description: 
 * ********************************/

using Payment.Fuiou.Fuyou;
using System.Collections.Generic;

namespace Payment.Fuiou.Paremetors
{

    /// <summary>
    /// 参数:31提现
    /// </summary>
    public class WithdrawalsParemetor : RechargeParemetor
    {

        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.Withdrawals.Action"];
        }
       
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(base.LoginId, 60, "用户登录名");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(base.Amt, 12, "提现金额");
            yield return VALIDATE.CANNULLANDLIMITLENGTH(base.PageNotifyUrl, 200, "商户返回地址");
        }

    }
}
