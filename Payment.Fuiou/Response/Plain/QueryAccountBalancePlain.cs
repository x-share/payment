/***********************************
 * Create Date: 2015/10/26 11:18:44
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
    public class QueryAccountBalancePlain : FyBasePlain
    {
        /// <summary>
        /// 返回结果描述
        /// </summary>
        [XmlElement("results")]
        public QueryAccountBalancePlainResults Results { get; set; }
    }
}
