/***********************************
 * Create Date: 2015/10/26 11:25:29
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
    public class QueryAccountInfoParemetorPlain : FuiouBasePlain
    {
        [XmlElement("results")]
        public QueryAccountInfoParemetorPlainResults QueryResult { get; set; }
    }
}
