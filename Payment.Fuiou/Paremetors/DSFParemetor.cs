using Payment.Fuiou.Fuyou;
using System.Collections.Generic;
using Payment.Serialize;
using System;

namespace Payment.Fuiou.Paremetors
{

    /// <summary>
    /// 富有代收付
    /// </summary>
    public abstract class DSFParemetor : BaseParemetor
    {

        #region Field
        /// <summary>
        /// 商户代码
        /// </summary>
        public virtual string MerchantCode
        {
            get { return FuiouConfig.DSFMerchantCode; }
        }
        /// <summary>
        /// 接口对接密钥
        /// </summary>
        protected virtual string ApiPrivateKey
        {
            get { return FuiouConfig.DSFApiPrivateKey; }
        }
        /// <summary>
        /// 操作员代码
        /// </summary>
        protected virtual string OpreatorCode
        {
            get { return FuiouConfig.DSFOpreatorCode; }
        }

        /// <summary>
        /// 请求类型
        /// </summary>
        protected virtual string ReqestType { get { return ""; } }

        string _xmlData = "";
        /// <summary>
        /// 请求参数
        /// </summary>
        public virtual string XmlData { get { return _xmlData; } }
        /// <summary>
        /// 校验值
        /// </summary>
        protected virtual string Mac
        {
            get
            {
                return md5(string.Format("{0}|{1}|{2}|{3}", MerchantCode, ApiPrivateKey, ReqestType, XmlData), 32);
                //return EncryptionHelper.MD5(string.Format("{0}|{1}|{2}|{3}", MerchantCode, PrivateKey, ReqestType, XmlData), "");
            }
        }

        public override string Type
        {
            get
            {
                return "fuiou";
            }
        }

        #endregion

        #region construct
        /// <summary>
        /// 
        /// </summary>
        public DSFParemetor() { }

        #endregion

        #region override basemethod
        /// <summary>
        /// 访问地址
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.DSFAddress;
        }
        /// <summary>
        /// 获取富有报文数据
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, string> GetFormatData()
        {
            _xmlData = new FuiouXml(this).GetXml();
            return new SortedDictionary<string, string>() 
                    { 
                        {"merid"    ,MerchantCode},
                        {"reqtype"  ,ReqestType},
                        {"xml"      ,XmlData},
                        {"mac"      ,Mac}
                    };
        }
        #endregion


        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string md5(string str, int code)
        {
            if (code == 16) //16位MD5加密（取32位加密的9~25字符）
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
            }
            else//32位加密
            {

                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
            }
        }

        public override IDeserializable GetDeserializer()
        {
            return new XMLSerialize();
        }
        public override string GetLog4netAppender()
        {
            return "fuyou";
        }
    }
}
