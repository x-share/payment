using System;
using System.Collections.Generic;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 查询交易（条件可组合） 
    /// </summary>
    [Paremetor("qrytransreq", 0)]
    public class QueryTransRequest : DSFParemetor
    {
        #region Fields
        /// <summary>
        /// 版本号
        /// </summary>
        [Paremetor("ver", 1)]
        public string Version { get { return "1.00"; } }
        /// <summary>
        /// 业务代码
        /// 代收AC01  代付AP01
        /// </summary>
        [Paremetor("busicd", 2)]
        public string BusinessCode { get; set; }
        /// <summary>
        /// 原请求流水
        /// </summary>
        [Paremetor("orderno", 3)]
        public string OrderNo { get; set; }
        /// <summary>
        /// 开始日期 Format(yyyyMMdd)
        /// </summary>
        [Paremetor("startdt", 4)]
        public string StartTime { get; set; }
        /// <summary>
        /// 结束日期 Format(yyyyMMdd)::日期段不能超过15天
        /// </summary>
        [Paremetor("enddt", 5)]
        public string EndTime { get; set; }
        /// <summary>
        /// 交易状态
        /// </summary>
        [Paremetor("transst", 6)]
        public string TransState { get; set; }
        #endregion

        /// <summary>
        /// 请求类型
        /// </summary>
        protected override string ReqestType { get { return "qrytransreq"; } }

        /// <summary>
        /// 时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string DATE(DateTime time)
        {
            return time.ToString("yyyyMMdd");
        }
    }
    /// <summary>
    /// 查询返回
    /// </summary>
    [System.Xml.Serialization.XmlRoot("qrytransrsp")]
    public class QueryTransResponse : DSFCommonResponse
    {

        /// <summary>
        /// 交易未发送
        /// </summary>
        public const string CONST_STATE_0 = "0";
        /// <summary>
        /// 交易已发送且成功
        /// </summary>
        public const string CONST_STATE_1 = "1";
        /// <summary>
        /// 交易已发送且失败
        /// </summary>
        public const string CONST_STATE_2 = "2";
        /// <summary>
        /// 交易发送中
        /// </summary>
        public const string CONST_STATE_3 = "3";
        /// <summary>
        /// 交易已发送且超时
        /// </summary>
        public const string CONST_STATE_7 = "7";




        /// <summary>
        /// 相应列表
        /// </summary>
        [System.Xml.Serialization.XmlElement("trans")]
        public List<Trans> Trans { get; set; }
    }

    /// <summary>
    /// 相应列表
    /// </summary>
    public class Trans
    {

        #region Fields

        /// <summary>
        /// 原请求日期
        /// </summary>
        [System.Xml.Serialization.XmlElement("merdt")]
        public string OrgRequestTime { get; set; }
        /// <summary>
        /// 原请求流水
        /// </summary>
        [System.Xml.Serialization.XmlElement("orderno")]
        public string OrgOrderNo { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        [System.Xml.Serialization.XmlElement("accntno")]
        public string AccantNo { get; set; }
        /// <summary>
        /// 账户名称
        /// </summary>
        [System.Xml.Serialization.XmlElement("accntnm")]
        public string AccantName { get; set; }
        /// <summary>
        /// 交易金额 单位：分
        /// </summary>
        [System.Xml.Serialization.XmlElement("amt")]
        public int Amount { get; set; }
        /// <summary>
        /// 企业流水号
        /// </summary>
        [System.Xml.Serialization.XmlElement("entseq")]
        public string EnterpriseNo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [System.Xml.Serialization.XmlElement("memo")]
        public string Notes { get; set; }
        /// <summary>
        /// 交易状态
        /// </summary>
        [System.Xml.Serialization.XmlElement("state")]
        public string State { get; set; }
        /// <summary>
        /// 交易结果
        /// </summary>
        [System.Xml.Serialization.XmlElement("result")]
        public string Result { get; set; }
        /// <summary>
        /// 结果原因
        /// </summary>
        [System.Xml.Serialization.XmlElement("reason")]
        public string Reason { get; set; }
        #endregion

    }
}
