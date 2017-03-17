using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 富友参数辅助类
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// 设置富友参数金额 以元为单位
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>返回富友规定单位金额</returns>
        public static int SetAmount(decimal amount)
        {
            return Convert.ToInt32(amount * 100);
        }
        /// <summary>
        /// 获取富友参数金额 以元为单位
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static decimal GetAmount(int amount)
        {
            return Convert.ToDecimal(amount) / 100;
        }

        /// <summary>
        /// 获取富友参数金额 以元为单位
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static decimal GetAmount(long amount)
        {
            try
            {
                return Convert.ToDecimal(amount) / 100;
            }catch{
                return 0;
            }
        }
    }
}
