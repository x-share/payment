using System;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 账户验证（单笔）
    /// </summary>
    [Paremetor("verifyreq")]
    public class Verifyrequest : DSFParemetor
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
        /// 证件类型  0身份证 1护照 2军官证 3士兵证 4户口本 7其他
        /// </summary>
        [Paremetor("certtp", 7)]
        public int CertificateType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Paremetor("certno", 8)]
        public string CertificateNo { get; set; }
        #endregion

        /// <summary>
        /// 请求类型
        /// </summary>
        protected override string ReqestType { get { return "verifyreq"; } }
    }
    /// <summary>
    /// 验证用户返回值
    /// </summary>
    [System.Xml.Serialization.XmlRoot("verifyrsp")]
    public class VerifyResponse : DSFCommonResponse { }

}
