/***********************************
 * Create Date:  2014/10/15 AM 10:15:43
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
    /// 查询余额时结果对象
    /// </summary>
    [XmlRoot("ap")]
    [Serializable]
    public class BalanceResult
    {
        [XmlElement("plain")]
        public BalancePlain Plain;

        [XmlElement("signature")]
        public string Signature { get; set; }

        public BalanceResult() { }
    }
}
