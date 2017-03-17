/***********************************
 * Create Date:  2014/10/14 PM 6:36:29
 * Author     ：Aaron Yuan
 * Description:  预授权是返回的结果，对应<plain>节点
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
    /// 预授权结果中，对应的<plain> 节点
    /// </summary>
    public class Pre_AuthPlain
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
        /// 商户流水号
        /// </summary>
        [XmlElement("mchnt_txn_ssn")]
        public string MerchantNumber { get; set; }

        /// <summary>
        /// 预授权合同号
        /// </summary>
        [XmlElement("contract_no")]
        public string ContractNumber { get; set; }

    }
}
