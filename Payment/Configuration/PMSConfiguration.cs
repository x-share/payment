using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace Payment.Configuration
{

    public class PMSConfiguration
    {

        const string WCF_CONFIG = "serverConfig";

        /// <summary>
        /// 系统默认配置
        /// </summary>
        public static ICustomConfig SysConfig
        {
            get
            {
                return new SysConfig();
            }
        }

        /// <summary>
        /// 获取用户自定义配置文件 
        /// </summary>
        /// <param name="path">文件的路径</param>
        /// <returns></returns>
        public static ICustomConfig GetCustomConfig(string path)
        {
            return new CustomConfig(path);
        }

        /// <summary>
        /// 获取用户自定义配置文件
        /// </summary>
        /// <param name="path">文件的路径</param>
        /// <returns></returns>
        public static System.Configuration.Configuration GetCustomConfiguration(string path)
        {
            return GetCustomConfig(path).GetConfiguration();
        }

        /// <summary>
        /// 通过配置的Key 获取自定义配置文件的路径
        /// </summary>
        /// <param name="key">在项目的config中 appSetting/add </param>
        /// <returns></returns>
        public static string GetConfigPath(string key)
        {
            return PathHelper.GetConfigPath(key);
        }

        /// <summary>
        /// 如果系统中自定义配置文件 则返回系统配置文件
        /// </summary>
        /// <param name="key">文件的配置KEY</param>
        /// <returns></returns>
        public static ICustomConfig GetDefaultConfigByPath(string key)
        {
            string path = GetConfigPath(key);
            if (string.IsNullOrEmpty(path))
                return SysConfig;
            else
                return GetCustomConfig(path);
        }

        /// <summary>
        /// 获取系统的WCF服务配置
        /// key=serverConfig
        /// </summary>
        /// <returns></returns>
        public static ServiceModelSectionGroup GetDefaultWCFServiceModelSectionGroup()
        {
            string path = "";
            if (!TryGetConfigPath(out path))
                return ServiceModelSectionGroup.GetSectionGroup(SysConfig.GetConfiguration());
            return PMSConfiguration.GetCustomConfig(path).GetModelSectionGroup();
        }
        /// <summary>
        /// 获取系统的数据库连接配置
        /// key=dbConfig
        /// </summary>
        /// <returns></returns>
        public static ConnectionStringSettingsCollection GetDefaultConnectionStringSettings()
        {
            string path = "";
            if (!TryGetConfigPath(out path))
                return SysConfig.GetConnectionStringsSection().ConnectionStrings;
            return PMSConfiguration.GetCustomConfig(path).GetConnectionStringsSection().ConnectionStrings;
        }

        /// <summary>
        /// 获取系统的AppSettingsSection
        /// </summary>
        /// <returns></returns>
        public static AppSettingsSection GetDefaultAppSettings()
        {
            string path = "";
            if (!TryGetConfigPath(out path))
                return SysConfig.GetAppSetting();
            return PMSConfiguration.GetCustomConfig(path).GetAppSetting();
        }

        private static bool TryGetConfigPath(out string path)
        {
            path = PMSConfiguration.GetConfigPath(WCF_CONFIG);
            return !(string.IsNullOrEmpty(path) || !System.IO.File.Exists(path));
        }


        static Dictionary<string, string> cacheDic = new Dictionary<string, string>();

        static object objLockGetConnectionString = new object();
        public static string GetConnectionString(string name, string configKey = "dbConfig")
        {
            string key = string.Format("{0}-connect-{1}", configKey, name);
            if (!cacheDic.ContainsKey(key))
            {
                lock (objLockGetConnectionString)
                {
                    if (!cacheDic.ContainsKey(key))
                    {
                        var cons = GetDefaultConfigByPath(configKey).GetConnectionStringsSection().ConnectionStrings;
                        if (cons[name] == null)
                            throw new System.Exception(string.Format("配置[{0}]文件,没有配置连接字符串[{1}]", configKey, name));
                        else
                            cacheDic.Add(key, cons[name].ConnectionString);
                    }
                }

            }
            return cacheDic[key];
        }

        public static string GetAppSetting(string key, string configKey = "default")
        {
            string dicKey = string.Format("{0}-appSetting-{1}", configKey, key);

            if (!cacheDic.ContainsKey(dicKey))
            {
                var sets = GetDefaultConfigByPath(configKey).GetAppSetting().Settings;
                if (sets[key] == null)
                    throw new System.Exception(string.Format("配置[{0}]文件,AppSetting没有配置Key[{1}]", configKey, key));
                else
                    cacheDic.Add(dicKey, sets[key].Value);
            }
            return cacheDic[dicKey];
        }

        /// <summary>
        /// 清理缓存
        /// </summary>
        public static void ClearCache()
        {
            try
            {
                cacheDic.Clear();
            }
            catch { }
        }
    }
}
