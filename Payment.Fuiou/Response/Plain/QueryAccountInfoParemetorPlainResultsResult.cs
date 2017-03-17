/***********************************
 * Create Date: 2015/10/26 11:26:52
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
    [XmlRoot("result")]
    public class QueryAccountInfoParemetorPlainResultsResult
    {
        /// <summary>
        /// 手机号
        /// </summary>
        [XmlElement("mobile_no")]
        public string Phone { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [XmlElement("cust_nm")]
        public string Name { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        [XmlElement("certif_id")]
        public string CertificateId { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }
        /// <summary>
        /// 开户行地区代码
        /// </summary>
        [XmlElement("city_id")]
        public string CityId { get; set; }
        /// <summary>
        /// 开户行行别
        /// </summary>
        [XmlElement("parent_bank_id")]
        public string BankType { get; set; }
        /// <summary>
        /// 开户行支行名称
        /// </summary>
        [XmlElement("bank_nm")]
        public string BankName { get; set; }
        /// <summary>
        /// 帐号
        /// </summary>
        [XmlElement("capAcntNo")]
        public string AccountNo { get; set; }
    }

}
