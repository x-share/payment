/***********************************
 * Create Date: 2015/11/16 17:03:37
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
    public class TradingQueryPlain : FuiouBasePlain
    {
        /// <summary>
        /// 业务类型
        /// </summary>
        [XmlElement("busi_tp")]
        public string busi_tp { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        [XmlElement("total_number")]
        public string total_number  { get; set; }

        /// <summary>
        /// results
        /// </summary>
        [XmlElement("results")]
        public TradingQueryPlainResults Results { get; set; }

    }

    [XmlRoot("results")]
    public class TradingQueryPlainResults 
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public List<TradingQueryPlainResult> ResultList { get; set; }

    }


    [XmlRoot("result")]
    public class TradingQueryPlainResult
    {
//<ext_tp>扩展类型</ext_tp>
//<txn_date>交易日期</txn_date>
//<txn_time>交易时分</txn_time>
//<src_tp>交易请求方式</src_tp>
//<mchnt_ssn>交易流水</mchnt_ssn>
//<txn_amt>交易金额</txn_amt>
//<txn_amt_suc>成功交易金额</txn_amt_suc>
//<contract_no>合同号</contract_no>
//<out_fuiou_acct_no>出账用户虚拟账户</out_fuiou_acct_no>
//<out_cust_no>出账用户名</out_cust_no>
//<out_artif_nm>出账用户名称</out_artif_nm>
//<in_fuiou_acct_no>入账用户虚拟账户</in_fuiou_acct_no>
//<in_cust_no>入账用户名</in_cust_no>
//<in_artif_nm>入账用户名称</in_artif_nm>
//<remark>交易备注</remark>
//<txn_rsp_cd>交易返回码</txn_rsp_cd>
//<rsp_cd_desc>交易返回码描述</rsp_cd_desc>

        /// <summary>
        /// 扩展类型
        /// </summary>
        [XmlElement("ext_tp")]
        public string ExtendedType { get; set; }

        /// <summary>
        /// 交易日期
        /// </summary>
        [XmlElement("txn_date")]
        public string TradingDate { get; set; }


        /// <summary>
        /// 交易时分
        /// </summary>
        [XmlElement("txn_time")]
        public string TradingTime { get; set; }


        /// <summary>
        /// 交易流水
        /// </summary>
        [XmlElement("mchnt_ssn")]
        public string TradingSSN { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        [XmlElement("txn_amt")]
        public string TradingAmount { get; set; }


        /// <summary>
        /// 成功交易金额
        /// </summary>
        [XmlElement("txn_amt_suc")]
        public string TradingAmountSuccess{ get; set; }

     
        /// <summary>
        /// 合同号
        /// </summary>
        [XmlElement("contract_no")]
        public string ContractNo { get; set; }

        /// <summary>
        /// 出账用户虚拟账户
        /// </summary>
        [XmlElement("out_fuiou_acct_no")]
        public string OutFuiouAccountNo { get; set; }

        /// <summary>
        /// 出账用户名
        /// </summary>
        [XmlElement("out_cust_no")]
        public string OutCustomerNo { get; set; }

        /// <summary>
        /// 出账用户名称
        /// </summary>
        [XmlElement("out_artif_nm")]
        public string OutArtifName { get; set; }

        /// <summary>
        /// 入账用户虚拟账户
        /// </summary>
        [XmlElement("in_fuiou_acct_no")]
        public string InFuiouAccountNo { get; set; }

        /// <summary>
        /// 入账用户名
        /// </summary>
        [XmlElement("in_cust_no")]
        public string InCustomerNo { get; set; }

        /// <summary>
        /// 入账用户名称
        /// </summary>
        [XmlElement("in_artif_nm")]
        public string InArtifName { get; set; }


        /// <summary>
        /// 交易备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }


        /// <summary>
        /// 交易返回码
        /// </summary>
        [XmlElement("txn_rsp_cd")]
        public string TradingResponseCode { get; set; }



        /// <summary>
        /// 交易返回码描述
        /// </summary>
        [XmlElement("rsp_cd_desc")]
        public string ResponseCodeDescript { get; set; }

    }
}
