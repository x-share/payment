/***********************************
 * Create Date:  14/11/12 14:37:33
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
    [XmlRoot("opResultSet")]
    public class DetailOpResultSet
    {
        [XmlElement("opResult")]
        public DetailOpResult Result { get; set; }
    }
}
