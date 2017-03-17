/***********************************
 * Create Date:  14/11/12 14:44:26
 * Author     ： Aaron Yuan
 * Description: 
 * ********************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Payment.Fuiou.Response
{
    [XmlRoot("opResult")]
    public class DetailOpResult
    {
        // <summary>
        /// 用户名
        /// </summary>
        [XmlElement("user_id")]
        public string UserID { get; set; }

        /// <summary>
        /// 期初账面中余额
        /// </summary>
        [XmlElement("ct_balance")]
        public string AccountTotalBalance { get; set; }

        /// <summary>
        /// 期初可用余额
        /// </summary>
        [XmlElement("ca_balance")]
        public string AccountBalance { get; set; }

        /// <summary>
        /// 期初冻结余额
        /// </summary>
        [XmlElement("cf_balance")]
        public string BlockedBalance { get; set; }

        /// <summary>
        /// 期初未转结余额
        /// </summary>
        [XmlElement("cu_balance")]
        public string ProcessingBalance { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        [XmlElement("total_number")]
        public string TotalNumber { get; set; }

        [XmlElement("details")]
        public DetailPageList DetailList { get; set; }

    }
}
