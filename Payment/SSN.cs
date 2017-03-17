using System;
using System.Collections.Generic;

namespace Payment
{
    /// <summary>
    /// 流水号生成器
    /// </summary>
    public class SSN
    {
        static readonly SSN _instance = new SSN();
        static Dictionary<string, int> _dic = new Dictionary<string, int>();
        static Dictionary<string, int> _dic2 = new Dictionary<string, int>();

        static object lockObj1 = new object();
        static object lockObj2 = new object();
        private SSN() { }
        private string GetKey()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");//length=18
        }

        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <returns></returns>
        public static string GetSSN()
        {
            lock (lockObj1)
            {
                string key = _instance.GetKey();
                if (_dic.ContainsKey(key))
                    _dic[key]++;
                else
                {
                    _dic.Clear();
                    _dic.Add(key, 1);
                }
                return string.Format("PH{0}{1}", key, _dic[key]);
            }
        }
        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <returns></returns>
        public static string GetSSNWithoutPre()
        {
            lock (lockObj2)
            {
                string key = _instance.GetKey();
                if (_dic2.ContainsKey(key))
                    _dic2[key]++;
                else
                {
                    _dic2.Clear();
                    _dic2.Add(key, 1);
                }
                return string.Format("{0}{1}", key, _dic2[key]);
            }
        }
    }
}
