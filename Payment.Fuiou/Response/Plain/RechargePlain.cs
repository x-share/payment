/***********************************
 * Create Date: 2015/10/26 11:28:05
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
    [XmlRoot("plain")]
    public class RechargePlain : FuiouBasePlain
    {
        /// <summary>
        /// 返回结果描述
        /// </summary>
        [XmlElement("resp_desc")]
        public string ResponseDesc { get; set; }

        /// <summary>
        /// 交易用户	
        /// </summary>
        [XmlElement("login_id")]
        public string LoginId { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        [XmlElement("amt")]
        public decimal Amt { get; set; }
    }
}
