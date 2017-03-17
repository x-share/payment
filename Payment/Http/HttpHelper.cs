using System.Text;
using System.Net;

namespace Payment.Http
{
    /// <summary>
    /// 请求帮助类
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// 发起请求获取数据
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="data">发送的数据</param>        
        /// <returns></returns>
        public static string GetResponseContent(string url, string data)
        {
            string result = string.Empty;

            WebClient webClient = new WebClient();
            byte[] sendData = Encoding.UTF8.GetBytes(data);
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            webClient.Headers.Add("ContentLength", sendData.Length.ToString());

            byte[] recData = webClient.UploadData(url, "POST", sendData);
            result = Encoding.UTF8.GetString(recData);

            return result;

        }

    }
}
