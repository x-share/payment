using System;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 单笔付款(payforreq)
    /// </summary>
    [Paremetor("payforreq")]
    public class PayforRequest : DSFParemetor
    {

        #region Fileds
        /// <summary>
        /// 版本号 (只读)
        /// </summary>
        [Paremetor("ver", 1)]
        public string Version { get { return "1.00"; } }
        /// <summary>
        /// 请求日期(只读)
        /// </summary>
        [Paremetor("merdt", 2)]
        public string RequestDate { get { return DateTime.Now.ToString("yyyyMMdd"); } }

        string _orderno = "";
        /// <summary>
        /// 请求流水(只读)
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
        /// 城市代码
        /// </summary>
        [Paremetor("cityno", 5)]
        public string CityNo { get; set; }
        /// <summary>
        /// 支行名称
        /// </summary>
        [Paremetor("branchnm", 6)]
        public string BranchName { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        [Paremetor("accntno", 7)]
        public string AccantNo { get; set; }
        /// <summary>
        /// 账户名称
        /// </summary>
        [Paremetor("accntnm", 8)]
        public string AccantName { get; set; }
        /// <summary>
        /// 金额(单位分)
        /// </summary>
        [Paremetor("amt", 9)]
        public int Amount { get; set; }

        string _entseq = "";
        /// <summary>
        /// 企业流水号(只读)
        /// </summary>
        [Paremetor("entseq", 10)]
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
        [Paremetor("memo", 11)]
        public string Notes { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Paremetor("mobile", 12)]
        public string Mobile { get; set; }
        #endregion

        /// <summary>
        /// 请求类型
        /// </summary>
        protected override string ReqestType { get { return "payforreq"; } }
    }

    /// <summary>
    /// 单笔付款返回值
    /// </summary>
    [System.Xml.Serialization.XmlRoot("payforrsp")]
    public class SinglePayResponse : DSFCommonResponse { }

}
