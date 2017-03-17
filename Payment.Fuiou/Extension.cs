using Payment.Fuiou.Paremetors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Fuiou.Fuyou
{
    /// <summary>
    /// 针对富友参数特性 进行相应的扩展
    /// </summary>
    public static class Extension
    {

        /// <summary>
        /// 富友参数扩展 》
        /// 首先对象数据是富友返回，或者根据规则生成的情况下生成的数据，可用此方法》
        /// 获取富友参数金额 得到的数据是以元为单位
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static decimal GetFyAmount(this int amount)
        {
            return Helper.GetAmount(amount);
        }

        public static decimal GetFyAmount(this long amount)
        {
            return Helper.GetAmount(amount);
        }
        /// <summary>
        /// 富友参数扩展
        /// 设置富友参数金额 输入的数据以元为单位
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static int SetFyAmount(this decimal amount)
        {
            return Helper.SetAmount(amount);
        }
    }
}
