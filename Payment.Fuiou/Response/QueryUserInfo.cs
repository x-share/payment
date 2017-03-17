using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Payment.Fuiou.Response
{
    /// <summary>
    /// 用户信息查询返回结果
    /// </summary>
    [Serializable]
    [XmlRoot("ap")]
    public class QueryUserInfo
    {
        public bool IsErro { get; set; }

        [XmlElement("plain")]
        public QueryUserInfoPlan Plan { get; set; }
        [XmlElement("signature")]
        public string Signature { get; set; }
    }

    public class QueryUserInfoPlan
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

        [XmlElement("results")]
        public UserCollection QueryResult { get; set; }
        //public List<UserInfo> Users { get; set; }

    }
  
    [Serializable]
    [XmlRoot("results")]
    public class UserCollection
    {
        [XmlElement("result")]
        public List<UserInfo> UserList { get; set; }
    }
   
    [Serializable]
    [XmlRoot("result")]
    public class UserInfo
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