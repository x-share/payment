using System.Configuration;

namespace Payment.Configuration
{

    /// <summary>
    /// 自定义配置文件
    /// </summary>
    public interface ICustomConfig
    {
        /// <summary>
        /// 配置文件
        /// </summary>
        /// <returns></returns>
        System.Configuration.Configuration GetConfiguration();
        /// <summary>
        ///  表示的 Windows Communication Foundation (WCF) 的主配置节
        /// </summary>
        /// <returns></returns>
        System.ServiceModel.Configuration.ServiceModelSectionGroup GetModelSectionGroup();
        /// <summary>
        /// 对连接字符串配置文件节进行编程访问
        /// </summary>
        /// <returns></returns>
        System.Configuration.ConnectionStringsSection GetConnectionStringsSection();

        /// <summary>
        /// 为 appSettings 配置节提供配置系统支持
        /// </summary>
        /// <returns></returns>
        AppSettingsSection GetAppSetting();
    }
}
