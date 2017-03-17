using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;

namespace Payment.Configuration
{
    public class PathHelper
    {
        //分隔符
        static char[] split1 = new char[] { '\\' };
        static char[] split2 = new char[] { '/' };
        static char[] split3 = new char[] { System.IO.Path.DirectorySeparatorChar };

        //系统变量匹配
        static Regex enVarRegex = new Regex(@"^%\w*%$");


        /// <summary>
        /// 获取配置的地址
        /// 支持相对地址/系统变量/绝对地址
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigPath(string key)
        {
            return GetPath(ConfigurationManager.AppSettings[key]);
        }

        /// <summary>
        /// 获取路径 支持相对、绝对和系统变量
        /// </summary>
        /// <param name="configPath"></param>
        /// <returns></returns>
        public static string GetPath(string configPath)
        {
            if (string.IsNullOrEmpty(configPath)) return "";

            string path = "", config = configPath;

            if (enVarRegex.IsMatch(config)) // 系统环境变量
            {
                config = GetGetEnvironmentVariable(config.Trim('%'));
            }

            if (System.IO.Path.IsPathRooted(config))
            {
                path = config;
            }
            else
            {
                path = Combine(AppDomain.CurrentDomain.BaseDirectory, config);
            }

            return path ?? string.Empty;
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="splist"></param>
        /// <returns></returns>
        internal static List<string> Split(string str, char[] splist)
        {
            return str.Split(splist, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        /// <summary>
        /// 拼接字符串
        /// </summary>
        /// <param name="partWithRoot">带有系统盘符的路径</param>
        /// <param name="part2"></param>
        /// <returns></returns>
        internal static string Combine(string partWithRoot, string part2)
        {
            var s1 = Split(part2, split1);
            var s2 = Split(part2, split2);

            var s3 = s1.Count > s2.Count ? s1 : s2;
            var b = Split(partWithRoot, split3);

            var bindex = b.Count - 1;
            for (int i = 0; i < s3.Count; i++)
            {
                if (s3[i].Trim() == "..")
                {
                    if (bindex >= 0)
                    {
                        s3[i] = b[bindex] = "";
                        bindex--;
                    }
                }
                else
                {
                    break;
                }
            }

            if (b.Count > 0)
                b[0] = b[0] + @"\";
            return System.IO.Path.Combine(System.IO.Path.Combine(b.ToArray()), System.IO.Path.Combine(s3.ToArray()));
        }

        /// <summary>
        /// 获取系统变量
        /// </summary>
        /// <param name="variab"></param>
        /// <returns></returns>
        private static string GetGetEnvironmentVariable(string variab)
        {
            string config = System.Environment.GetEnvironmentVariable(variab);
            if (string.IsNullOrEmpty(config))
                config = System.Environment.GetEnvironmentVariable(variab, EnvironmentVariableTarget.User);
            if (string.IsNullOrEmpty(config))
                config = System.Environment.GetEnvironmentVariable(variab, EnvironmentVariableTarget.Machine);
            return config ?? string.Empty;
        }
    }
}
