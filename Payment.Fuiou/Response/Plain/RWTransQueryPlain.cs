using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Payment.Fuiou.Response.Plain
{
    [XmlRoot("plain")]
    public class RWTransQueryPlain : FuiouBasePlain
    {
        /// <summary>
        /// 业务类型
        /// </summary>
        [XmlElement(" busi_tp")]
        public string BusiType { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        [XmlElement("total_number")]
        public int Total{ get; set; }

        [XmlElement("results")]
        public RWTransQueryPlainResults Results { get; set; }
    }

    [XmlRoot("results")]
    public class RWTransQueryPlainResults
    {
        [XmlElement("result")]
        public List<RWTransQueryPlainResult> Data { get; set; }
    }

    [XmlRoot("result")]
    public class RWTransQueryPlainResult
    {
        /// <summary>
        /// 扩展类型
        /// </summary>
        [XmlElement("ext_tp")]
        public string ExtType { get; set; }
        /// <summary>
        /// 充值提现日期
        /// </summary>
        [XmlElement("txn_date")]
        public string Date { get; set; }
        /// <summary>
        /// 充值提现时分
        /// </summary>
        [XmlElement("txn_time")]
        public string Time { get; set; }
        /// <summary>
        /// 充值提现流水
        /// </summary>
        [XmlElement("mchnt_ssn")]
        public string SSN { get; set; }
        /// <summary>
        /// 充值提现金额
        /// </summary>
        [XmlElement("txn_amt")]
        public int Amount { get; set; }
        /// <summary>
        /// 用户虚拟账户
        /// </summary>
        [XmlElement("fuiou_acct_no")]
        public string AccountNo { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [XmlElement("cust_no")]
        public string CustNo { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [XmlElement("artif_nm")]
        public string UserName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }
        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("txn_rsp_cd")]
        public string Code { get; set; }
        /// <summary>
        /// 返回码描述
        /// </summary>
        [XmlElement("rsp_cd_desc")]
        public string Desc { get; set; }
    }
}
