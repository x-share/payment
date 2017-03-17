/***********************************
 * Create Date: 2015/10/26 11:22:13
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
    public class QueryAccountBalancePlainResults
    {
        /// <summary>
        /// 返回结果描述
        /// </summary>
        [XmlElement("result")]
        public List<QueryAccountBalancePlainResultsResult> ResultsList { get; set; }

    }

}
