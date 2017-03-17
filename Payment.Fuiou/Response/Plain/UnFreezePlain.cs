/***********************************
 * Create Date: 2015/10/26 11:27:38
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
    public class UnFreezePlain : FuiouBasePlain
    {
        /// <summary>
        /// 请求解冻金额
        /// </summary>
        [XmlElement("amt")]
        public string Amt { get; set; }

        /// <summary>
        /// 成功解冻金额
        /// </summary>
        [XmlElement("suc_amt")]
        public string SucAmt { get; set; }
    }
}
