using Payment.Fuiou.Fuyou;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 签约接口
    /// </summary>
    [Paremetor("custmrBusi")]
    public class DSFSignContractRequest : DSFParemetor
    {

        #region Fields
        /// <summary>
        /// 签约来源，取值DSF
        /// </summary>
        [Paremetor("srcChnl", 1)]
        public string SrcChnl { get { return "DSF"; } }

        string _busiCd = "AC01";
        /// <summary>
        /// 业务代码，默认AC01
        /// </summary>
        [Paremetor("busiCd", 2)]
        public string BusinessCode
        {
            get { return _busiCd; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _busiCd = value;
                }
            }
        }
        /// <summary>
        /// 行别代码
        /// </summary>
        [Paremetor("bankCd", 3)]
        public string BankCode { get; set; }
        /// <summary>
        /// 户名
        /// </summary>
        [Paremetor("userNm", 4)]
        public string UserName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Paremetor("mobileNo", 5)]
        public string MobileNo { get; set; }
        /// <summary>
        /// 证件类型  0:身份证   1:护照     2:军官证   3:士兵证   4:回乡证   5:户口本   6:外国护照 7:其他 
        /// </summary>
        [Paremetor("credtTp", 6)]
        public int CredtTp { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        [Paremetor("credtNo", 7)]
        public string CredtNo { get; set; }
        /// <summary>
        /// 账户类型 /// 01：借记卡/// 02：贷记卡/// 03：准贷记卡
        /// </summary>
        [Paremetor("acntTp", 8)]
        public string AccantTp { get; set; }
        /// <summary>
        /// 账户号
        /// </summary>
        [Paremetor("acntNo", 9)]
        public string AccantNo { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        [Paremetor("mchntCd", 10)]
        public override string MerchantCode { get { return base.MerchantCode; } }
        /// <summary>
        /// 回拨标志，默认0不回拨
        /// </summary>
        [Paremetor("isCallback", 11)]
        public string IsCallback { get; set; }
        /// <summary>
        /// 保留字段1
        /// </summary>
        [Paremetor("reserved1", 12)]
        public string Reserved1 { get; set; }
        /// <summary>
        /// 签名字段
        /// </summary>
        //[AttributeParemetor("signature", 13)]
        public string Signature { get; private set; }

        #endregion

        #region Override Method
        /// <summary>
        /// XML 数据
        /// </summary>
        public override string XmlData
        {
            get
            {
                var xmlObj = new FuiouXml(this);
                xmlObj.AppendNode("signature", SHA1(SHA1(getEncryptionData()) + "|" + base.ApiPrivateKey));
                return xmlObj.GetXml();
            }
        }

        public override IDictionary<string, string> GetFormatData()
        {
            return new SortedDictionary<string, string>() { { "xml", XmlData } };
        }

        public override string GetRequestUrl()
        {
            return FuiouConfig.DSFSignContractAddress;
        }

        #endregion

        #region Private Method
        private string getEncryptionData()
        {
            var arr = new string[] { this.SrcChnl, this.BusinessCode, this.BankCode, this.UserName, this.MobileNo, this.CredtTp.ToString(), this.CredtNo, this.AccantTp, this.AccantNo, this.MerchantCode, this.IsCallback, this.Reserved1 };
            Array.Sort(arr);
            return string.Join("|", arr);
        }


        private static string SHA1(string str)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = UTF8Encoding.Default.GetBytes(str);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            return str_sha1_out.Replace("-", "");
        }
        #endregion

    }


    /// <summary>
    /// 签约返回结果
    /// </summary>
    [System.Xml.Serialization.XmlRoot("custmrBusi")]
    public class DSFSignContractResponse
    {

        #region Fields
        /// <summary>
        /// 响应码
        /// </summary>
        [System.Xml.Serialization.XmlElement("respCd")]
        public string ResponseCode { get; set; }
        /// <summary>
        /// 响应描述
        /// </summary>
        [System.Xml.Serialization.XmlElement("respDesc")]
        public string Description { get; set; }
        /// <summary>
        /// 协议号
        /// </summary>
        [System.Xml.Serialization.XmlElement("contractNo")]
        public string ContractNo { get; set; }
        /// <summary>
        /// 签约状态
        /// </summary>
        [System.Xml.Serialization.XmlElement("contractSt")]
        public string ContractState { get; set; }
        /// <summary>
        /// 卡号户名验证结果
        /// </summary>
        [System.Xml.Serialization.XmlElement("acntIsVerify1")]
        public string AccantIsVerify1 { get; set; }
        /// <summary>
        /// 卡号密码验证结果
        /// </summary>
        [System.Xml.Serialization.XmlElement("acntIsVerify2")]
        public string AccantIsVerify2 { get; set; }
        /// <summary>
        /// 户名证件号验证结果
        /// </summary>
        [System.Xml.Serialization.XmlElement("acntIsVerify3")]
        public string AccantIsVerify3 { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public bool Result
        {
            get { return (!string.IsNullOrEmpty(ResponseCode) && ResponseCode == "0000"); }
        }
        #endregion

    }

}
