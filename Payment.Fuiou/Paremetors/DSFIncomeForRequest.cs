using System;

namespace Payment.Fuiou.Paremetors
{

    /// <summary>
    /// 单笔收款
    /// </summary>
    [Paremetor("incomeforreq", 0)]
    public class IncomeForRequest : DSFParemetor
    {

        #region Fields

        /// <summary>
        /// 版本号
        /// </summary>
        [Paremetor("ver", 1)]
        public string Version { get { return "1.00"; } }
        /// <summary>
        /// 请求日期
        /// </summary>
        [Paremetor("merdt", 2)]
        public string RequestDate { get { return DateTime.Now.ToString("yyyyMMdd"); } }
        string _orderno = "";
        /// <summary>
        /// 请求流水
        /// </summary>
        [Paremetor("orderno", 3)]
        public string OrderNo
        {
            get
            {
                if (string.IsNullOrEmpty(_orderno))
                    _orderno = SSN.GetSSNWithoutPre();
                return _orderno;
            }
        }
        /// <summary>
        /// 总行代码
        /// </summary>
        [Paremetor("bankno", 4)]
        public string BankNo { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        [Paremetor("accntno", 5)]
        public string AccantNo { get; set; }
        /// <summary>
        /// 账户名称
        /// </summary>
        [Paremetor("accntnm", 6)]
        public string AccantName { get; set; }
        /// <summary>
        /// 金额(单位分)
        /// </summary>
        [Paremetor("amt", 7)]
        public int Amount { get; set; }
        string _entseq = "";
        /// <summary>
        /// 企业流水号
        /// </summary>
        [Paremetor("entseq", 8)]
        public string EnterpriseNo
        {
            get
            {
                if (string.IsNullOrEmpty(_entseq))
                    _entseq = SSN.GetSSNWithoutPre();
                return _entseq;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        [Paremetor("memo", 9)]
        public string Notes { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Paremetor("mobile", 10)]
        public string Mobile { get; set; }
        /// <summary>
        /// 证件类型 0身份证 1护照 2军官证 3士兵证 5户口本 7其他
        /// </summary>
        [Paremetor("certtp", 11)]
        public int CertificateType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Paremetor("certno", 12)]
        public string CertificateNo { get; set; }
        #endregion

        /// <summary>
        /// 请求类型
        /// </summary>
        protected override string ReqestType { get { return "sincomeforreq"; } }

    }
    /// <summary>
    /// 单笔收款返回值
    /// </summary>
    [System.Xml.Serialization.XmlRoot("incomeforrsp")]
    public class SingleCollectResponse : DSFCommonResponse
    {

    }


}
