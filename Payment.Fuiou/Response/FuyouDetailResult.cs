/***********************************
 * Create Date:  14/11/12 14:10:12
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
    [XmlRoot("ap")]
    public class FuyouDetailResult
    {
        [XmlElement("plain")]
        public DetailPlain Plain { get; set; }

        [XmlElement("signature")]
        public string Signature { get; set; }
    }
}
