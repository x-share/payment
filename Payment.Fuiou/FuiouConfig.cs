using Payment.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Payment.Fuiou.Fuyou
{
    /// <summary>
    /// 富有配置
    /// </summary>
    public class FuiouConfig
    {
        const string C_KEY = "fuyouConfig";
        const string C_MERCHANTCODE = "MerchantCode"; //商户代码
        const string C_MERCHANTLOGIN = "MerchantLogin"; //商户登录账号
        const string C_FUYOUPRIVATEKEY = "FuyouPrivateKey"; //21密钥

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

        #region 金账户
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
        /// 商户登录账号
        /// </summary>
        public static string MerchantLogin
        {
            get
            {
                return Config.GetAppSetting().Settings[C_MERCHANTLOGIN].Value;
            }
        }

        /// <summary>
        /// 密钥
        /// </summary>
        public static string FuyouPrivateKey
        {
            get
            {
                return Config.GetAppSetting().Settings[C_FUYOUPRIVATEKEY].Value;
            }
        }
        /// <summary>
        /// 委托充值 接收地址
        /// </summary>
        public static string WtrechargeResultBackNotifyUrl
        {
            get
            {
                return Config.GetAppSetting().Settings["WtrechargeResult"].Value;
            }
        }

        /// <summary>
        /// 委托提现 接收地址
        /// </summary>
        public static string WtwithdrawResultBackNotifyUrl
        {
            get
            {
                return Config.GetAppSetting().Settings["WtwithdrawResult"].Value;
            }
        }
        #endregion

        #region 代收付

        /// <summary>
        /// 代收付 商户代码
        /// </summary>
        public static string DSFMerchantCode
        {
            get { return FuiouConfig.Config.GetAppSetting().Settings["DSF:MerchantCode"].Value; }
        }

        public static string PrivateKey {
            get { return FuiouConfig.Config.GetAppSetting().Settings[C_FUYOUPRIVATEKEY].Value; }
        }

        /// <summary>
        /// 代收付 接口对接密钥
        /// </summary>
        public static string DSFApiPrivateKey
        {
            get { return FuiouConfig.Config.GetAppSetting().Settings["DSF:APIPrivateKey"].Value; }
        }
        /// <summary>
        /// 代收付 操作员代码
        /// </summary>
        public static string DSFOpreatorCode
        {
            get { return FuiouConfig.Config.GetAppSetting().Settings["DSF:OpreatorCode"].Value; }
        }
        /// <summary>
        /// 代收付 地址
        /// </summary>
        public static string DSFAddress
        {
            get { return FuiouConfig.Config.GetAppSetting().Settings["DSF:FuyouAddress"].Value; }
        }
        /// <summary>
        /// 代收付 签约地址
        /// </summary>
        public static string DSFSignContractAddress
        {
            get { return FuiouConfig.Config.GetAppSetting().Settings["DSF:SignContractAddress"].Value; }
        }

        #endregion


        static Dictionary<string, string> _ApiAddress = null;
        static object lockApiAddress = new object();
        /// <summary>
        /// 富有接口地址
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
                            foreach (System.Configuration.KeyValueConfigurationElement k in settings)
                            {
                                if (!_ApiAddress.ContainsKey(k.Key) && k.Key.StartsWith("Fuyou."))
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
