/***********************************
 * Create Date:  14/11/12 14:52:18
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

    [XmlRoot("detail")]
    public class DetailPageItem
    {
        /// <summary>
        /// 交易流水号
        /// </summary>
        [XmlElement("transSsn")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 记账时间
        /// </summary>
        [XmlElement("rec_crt_ts")]
        public string RecordDateTime { get; set; }

        /// <summary>
        /// 账面余额出账金额
        /// </summary>
        [XmlElement("ct_debit_amt")]
        public string AccountOfBookBalance { get; set; }

        /// <summary>
        /// 账面余额入账金额
        /// </summary>
        [XmlElement("ct_credit_amt")]
        public string RecordedOfBookBalance { get;set;}

        /// <summary>
        /// 可用余额出账金额
        /// </summary>
        [XmlElement("ca_debit_amt")]
        public string AccountOfAvailableBalance { get; set; }

        /// <summary>
        /// 可用余额入账金额
        /// </summary>
        [XmlElement("ca_credit_amt")]
        public string RecordedOfAvailableBalance { get; set; }

        /// <summary>
        /// 未转结余额出账金额
        /// </summary>
        [XmlElement("cu_debit_amt")]
        public string ProcessingOfAccountBalance { get;set;}

        /// <summary>
        ///未转结余额入账金额 
        /// </summary>
        [XmlElement("cu_credit_amt")]
        public string ProcessingOfRecordBalance { get; set; }

        /// <summary>
        /// 冻结余额出账金额
        /// </summary>
        [XmlElement("cf_debit_amt")]
        public string FreezeAccountBalance { get;set;}

        /// <summary>
        /// 冻结余额入账金额
        /// </summary>
        [XmlElement("cf_credit_amt")]
        public string FreezeRecordBalance { get;set;}

        /// <summary>
        /// 账面余额
        /// </summary>
        [XmlElement("ct_balance")]
        public string BookBalance { get; set; }

        /// <summary>
        /// 可用余额
        /// </summary>
        [XmlElement("ca_balance")]
        public string AvailableBalance { get; set; }

        /// <summary>
        /// 未转结余额
        /// </summary>
        [XmlElement("cu_balance")]
        public string ProcessingBalance { get; set; }

        /// <summary>
        /// 冻结余额
        /// </summary>
        [XmlElement("cf_balance")]
        public string FreezeBalance { get; set; }

        /// <summary>
        /// 摘要信息
        /// </summary>
        [XmlElement("book_digest")]
        public string SummaryInfo { get; set; }

    }
}
