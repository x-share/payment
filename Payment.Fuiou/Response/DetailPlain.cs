/***********************************
 * Create Date:  14/11/12 14:35:39
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
    [XmlRoot("plain")]
    public class DetailPlain
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("resp_code")]
        public string ResponseCode { get; set; }

        /// <summary>
        /// 商户代码
        /// </summary>
        [XmlElement("mchnt_cd")]
        public string MerchantCode { get; set; }

        /// <summary>
        /// 商户流水账号
        /// </summary>
        [XmlElement("mchnt_txn_ssn")]
        public string MerchantNumber { get; set; }


        [XmlElement("opResultSet")]
        public DetailOpResultSet ResultSets { get; set; }

    }
}
