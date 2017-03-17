/***********************************
 * Create Date:  2014/10/15 AM 9:54:10
 * Author     ：Aaron Yuan
 * Description: 
 * ********************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Payment.Fuiou.Response
{
    /// <summary>
    /// 查询余额对应的results下的子节点
    /// </summary>
    [XmlRoot("result")]
    [Serializable]
    public class BalanceSubResult
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [XmlElement("user_id")]
        public string UserID { get; set; }

        /// <summary>
        /// 账面中余额
        /// </summary>
        [XmlElement("ct_balance")]
        public string AccountTotalBalance { get; set; }

        /// <summary>
        /// 可用余额
        /// </summary>
        [XmlElement("ca_balance")]
        public string AccountBalance { get; set; }

        /// <summary>
        /// 冻结余额
        /// </summary>
        [XmlElement("cf_balance")]
        public string BlockedBalance { get; set; }

        /// <summary>
        /// 未转结余额
        /// </summary>
        [XmlElement("cu_balance")]
        public string processingBalance { get; set; }

        public BalanceSubResult() { }
    }
}
