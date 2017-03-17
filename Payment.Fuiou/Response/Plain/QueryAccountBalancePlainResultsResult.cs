/***********************************
 * Create Date: 2015/10/26 11:23:27
 * Author     ：赵赫昂
 * Description: 
 * ********************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Payment.Fuiou.Response.Plain
{
    [XmlRoot("result")]
    public class QueryAccountBalancePlainResultsResult
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
        public long AccountTotalBalance { get; set; }

        
        /// <summary>
        /// 可用余额 单位分
        /// </summary>
        [XmlElement("ca_balance")]
        public long AccountBalance { get; set; }


        

        /// <summary>
        /// 冻结余额 单位分
        /// </summary>
        [XmlElement("cf_balance")]
        public long BlockedBalance { get; set; }

       

        /// <summary>
        /// 未转结余额
        /// </summary>
        [XmlElement("cu_balance")]
        public long ProcessingBalance { get; set; }

    }
}
