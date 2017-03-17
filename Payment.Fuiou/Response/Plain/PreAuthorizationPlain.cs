/***********************************
 * Create Date: 2015/10/26 11:24:29
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
    public class PreAuthorizationPlain : FyBasePlain
    {
        /// <summary>
        /// 预授权合同号
        /// </summary>
        [XmlElement("contract_no")]
        public string ContractNo { get; set; }
    }
}
