using Payment.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Payment.Unspay
{
    /// <summary>
    /// 银生宝配置
    /// </summary>
    public class UnspayConfig
    {
        const string C_KEY = "ysbConfig";
        const string C_MERCHANTCODE = "YSB.MerchantCode"; //商户代码
        //const string C_MERCHANTLOGIN = "MerchantLogin"; //商户登录账号
        const string C_PRIVATEKEY = "YSB.Key"; //21密钥
        const string C_CONTRACTID = "YSB.ContractId";

        private static object objLock = new object();
        private static ICustomConfig _config = null;

        /// <summary>
        /// 系统自定义配置文件
        /// </summary>
        public static ICustomConfig Config
        {
            get
            {
                if (_config == null)
                    lock (objLock)
                        if (_config == null)
                            _config = PMSConfiguration.GetDefaultConfigByPath(C_KEY);
                return _config;
            }
        }

        #region 银生宝
        /// <summary>
        /// 商户代码
        /// </summary>
        public static string MerchantCode
        {
            get
            {
                return Config.GetAppSetting().Settings[C_MERCHANTCODE].Value;
            }
        }
        /// <summary>
        /// 商户协议编号
        /// </summary>
        public static string ContractId
        {
            get
            {
                return Config.GetAppSetting().Settings[C_CONTRACTID].Value;
            }
        }

        ///// <summary>
        ///// 商户登录账号
        ///// </summary>
        //public static string MerchantLogin
        //{
        //    get
        //    {
        //        return Config.GetAppSetting().Settings[C_MERCHANTLOGIN].Value;
        //    }
        //}

        /// <summary>
        /// 密钥
        /// </summary>
        public static string Key
        {
            get
            {
                return Config.GetAppSetting().Settings[C_PRIVATEKEY].Value;
            }
        }

        #endregion

        static Dictionary<string, string> _ApiAddress = null;
        static object lockApiAddress = new object();
        /// <summary>
        /// 银生宝地址
        /// </summary>
        public static Dictionary<string, string> ApiAddress
        {
            get
            {
                if (_ApiAddress != null)
                {
                    return _ApiAddress;
                }

                lock (lockApiAddress)
                {
                    if (_ApiAddress == null)
                    {
                        _ApiAddress = new Dictionary<string, string>();
                        var settings = Config.GetAppSetting().Settings;
                        if (settings.Count > 0)
                        {
                            foreach (KeyValueConfigurationElement k in settings)
                            {
                                if (!_ApiAddress.ContainsKey(k.Key) && k.Key.StartsWith("YSB.URL."))
                                {
                                    _ApiAddress.Add(k.Key, k.Value);
                                }
                            }
                        }
                    }
                }
                return _ApiAddress;
            }
        }


        /// <summary>
        ///  AppSetting 数据
        /// </summary>
        public static KeyValueConfigurationCollection Settings
        {
            get
            {
                return Config.GetAppSetting().Settings;
            }
        }

        /// <summary>
        /// 获取AppSetting 数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSetting(string key)
        {
            var set = Settings;
            if (set.AllKeys.Contains(key))
                return Config.GetAppSetting().Settings[key].Value;
            return "";
        }
    }
}
