/***********************************
 * Create Date:  14/11/12 14:51:17
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
    [XmlRoot("details")]
    public class DetailPageList
    {
        [XmlElement("detail")]
        public List<DetailPageItem> Items { get; set; }
    }
}
