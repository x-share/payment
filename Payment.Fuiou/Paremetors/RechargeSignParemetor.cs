/***********************************
 * Create Date: 2015/10/23 9:38:25
 * Author     ：赵赫昂
 * Description: 
 * ********************************/

using Payment.Fuiou.Fuyou;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 30网银充值 和快速充值的区别是 网银充值是签约客户
    /// </summary>
    public class RechargeSignParemetor : RechargeParemetor
    {
        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.RechargeSign.Action"];
        }
    }
}
