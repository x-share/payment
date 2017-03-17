using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace Payment.Configuration
{
    internal class CustomConfig : ICustomConfig
    {
        string configPath = "";
        public CustomConfig(string path)
        {
            this.configPath = path;
        }

        public System.Configuration.Configuration GetConfiguration()
        {
            if (string.IsNullOrEmpty(configPath))
                return null;
            ExeConfigurationFileMap execfgMap = new ExeConfigurationFileMap();
            execfgMap.ExeConfigFilename = configPath;
            return ConfigurationManager.OpenMappedExeConfiguration(execfgMap, ConfigurationUserLevel.None);
        }

        public ServiceModelSectionGroup GetModelSectionGroup()
        {
            System.Configuration.Configuration cfg = GetConfiguration();
            return ServiceModelSectionGroup.GetSectionGroup(cfg);
        }

        public ConnectionStringsSection GetConnectionStringsSection()
        {
            return GetConfiguration().ConnectionStrings;
        }

        public AppSettingsSection GetAppSetting()
        {
            return GetConfiguration().AppSettings;
        }
    }

    internal class SysConfig : ICustomConfig
    {
        static bool isWeb = false; //是Bs 还是cs
        static bool isValidate = false; //是否经过验证
        static System.Configuration.Configuration _systemConfig = null;

        //检查客户端
        private bool IsCheckedClient()
        {
            if (isValidate) return isWeb;
            try
            {
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            catch
            {
                isWeb = true;
            }
            isValidate = true;
            return isValidate;
        }

        public System.Configuration.Configuration GetConfiguration()
        {
            if (_systemConfig != null)
                return _systemConfig;

            if (IsCheckedClient())
            {
                if (isWeb)
                {
                    if (System.IO.File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "web.config")))
                    {
                        _systemConfig = new CustomConfig(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "web.config")).GetConfiguration();
                    }
                }
                else
                {
                    _systemConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                }
            }

            return _systemConfig;

        }

        public ServiceModelSectionGroup GetModelSectionGroup()
        {
            return
                ServiceModelSectionGroup.GetSectionGroup(GetConfiguration());

        }

        public ConnectionStringsSection GetConnectionStringsSection()
        {
            return
                GetConfiguration().GetSection("connectionStrings") as ConnectionStringsSection;
        }

        public AppSettingsSection GetAppSetting()
        {
            return
                GetConfiguration().GetSection("appSettings") as AppSettingsSection;
        }
    }
}
