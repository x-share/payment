/***********************************
 * Create Date: 2015/11/17 10:16:28
 * Author     ：赵赫昂
 * Description: 
 * ********************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Fuiou.Fuyou
{


    /// <summary>
    /// 交易类型
    /// </summary>
    public enum TradingQueryBusinessTypeEnum
    {

        /// <summary>
        /// 转账
        /// </summary>
        PWPC,
        /// <summary>
        /// 预授权
        /// </summary>
        PW13,
        /// <summary>
        /// 预授权撤销
        /// </summary>
        PWCF,
        /// <summary>
        /// 划拨
        /// </summary>
        PW03,
        /// <summary>
        /// 转账冻结
        /// </summary>
        PW14,
        /// <summary>
        /// 划拨冻结
        /// </summary>
        PW15,
        /// <summary>
        /// 冻结
        /// </summary>
        PWDJ,
        /// <summary>
        /// 解冻
        /// </summary>
        PWJD,
        /// <summary>
        /// 冻结付款到冻结
        /// </summary>
        PW19
    }


    /// <summary>
    /// 交易状态
    /// </summary>
    public enum TradingQueryTradingState 
    { 
        All=0,
        Seccuss=1,
        Failure=2
    }
}
