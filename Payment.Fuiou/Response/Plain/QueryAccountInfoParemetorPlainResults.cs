/***********************************
 * Create Date: 2015/10/26 11:26:27
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
    [XmlRoot("results")]
    public class QueryAccountInfoParemetorPlainResults
    {
        [XmlElement("result")]
        public List<QueryAccountInfoParemetorPlainResultsResult> UserList { get; set; }
    }
}
