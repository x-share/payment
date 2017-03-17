using System.Collections.Generic;

namespace Payment
{
    /// <summary>
    /// 支付基础基础参数
    /// </summary>
    public abstract class BaseParemetor : AbsAccount
    {
        #region Abstract Method
        /// <summary>
        /// 获取富有格式数据
        /// </summary>
        /// <returns></returns>
        public abstract IDictionary<string, string> GetFormatData();
        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public abstract string GetRequestUrl();

        #endregion
    }
}
