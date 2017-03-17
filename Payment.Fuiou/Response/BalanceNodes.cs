/***********************************
 * Create Date:  2014/10/15 PM 5:07:18
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
    [Serializable]
    [XmlRoot("results")]
    public class BalanceNodes
    {
        [XmlElement("result")]
        public BalanceSubResult SubResult;

        public BalanceNodes() { }
    }
}
