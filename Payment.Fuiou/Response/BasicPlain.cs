/***********************************
 * Create Date:  2014/10/15 PM 2:59:09
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
    [XmlRoot("plain")]
    public class BasicPlain
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


        [XmlElement("contract_no")]
        public string ContractNo { get; set; }
    }

    /// <summary>
    /// 富有返回基本数据
    /// </summary>
    [XmlRoot("plain")]
    public class FyBasePlain
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
    }

    /// <summary>
    /// 富有返回基本数据
    /// </summary>
    [XmlRoot("plain")]
    public class FyBasePlain2 : FyBasePlain
    {
        /// <summary>
        /// 返回码说明
        /// </summary>
        [XmlElement("desc_code")]
        public string Description { get; set; }

    }

}
