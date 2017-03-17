/***********************************
 * Create Date:  2014/10/15 AM 9:44:03
 * Author     ：Aaron Yuan
 * Description: 
 * ********************************/

using System;
using System.Xml.Serialization;


namespace Payment.Fuiou.Response
{

    /// <summary>
    /// 查询余额时的结果
    /// 对应 AP节点下的Plain节点
    /// </summary>
    [XmlRoot("plain")]
    [Serializable]
    public class BalancePlain
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
        
        /// <summary>
        /// 结果
        /// </summary>
        [XmlElement("results")]
        public BalanceNodes Results;

        public BalancePlain() { }
                
    }
}
