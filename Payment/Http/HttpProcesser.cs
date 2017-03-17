using Payment.Exception;
using Payment.Serialize;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Http
{

    /// <summary>
    /// 
    /// </summary>
    public class HttpProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public static IHttpProcesser Processer { get { return new HttpProcesser(); } }
        public static IHttpProcesser GetProcesser(IDeserializable des, string log)
        {
            return new HttpProcesser(des, log);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class HttpProcesser : IHttpProcesser
    {

        string LOG_PAY_FUYOU = "default";

        IDeserializable iDeserialize = null;
        public HttpProcesser()
        {
            iDeserialize = new XMLSerialize();
        }
        public HttpProcesser(IDeserializable des, string log)
        {
            iDeserialize = des;
            LOG_PAY_FUYOU = log;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fyParemetor"></param>
        /// <returns></returns>
        public T Request<T>(BaseParemetor fyParemetor) where T : class
        {
            return Request<T>(fyParemetor.GetFormatData(), fyParemetor.GetRequestUrl());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public T Request<T>(SortedDictionary<string, string> data, string url) where T : class
        {
            return Request<T>(data, url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public T Request<T>(IDictionary<string, string> data, string url) where T : class
        {
            return httpRequest<T>(url, getParamters(data));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string getParamters(IDictionary<string, string> data)
        {
            StringBuilder sbparameterStr = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in data)
            {
                sbparameterStr.AppendFormat("{0}={1}&", kv.Key, kv.Value);
            }
            return sbparameterStr.ToString().TrimEnd('&');
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private T httpRequest<T>(string url, string data) where T : class
        {
            string guid = Guid.NewGuid().ToString();
            string responseResult = "";
            try
            {
                //Log.Manager.Logger(LOG_PAY_FUYOU).Write(new { Type = "Request", Guid = guid, Url = url, Data = data });
                responseResult = HttpHelper.GetResponseContent(url, data);
                var result = ConvertToT<T>(responseResult);
                //Log.Manager.Logger(LOG_PAY_FUYOU).Write(new { Type = "Reponse", Guid = guid, Data = result, ResponseData = responseResult });
                return result;
            }
            catch (System.Exception e)
            {
                //Log.Manager.Logger(LOG_PAY_FUYOU).Write(new { Type = "Exception", Guid = guid, Url = url, Data = data, ResponseData = responseResult, ExceptionMess = e.Message + "|||" + e.StackTrace });
                if (e is TypeConvertException)
                    throw e;
                else
                    throw new NetException(e.Message);
            }
            // return default(T);
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public T ConvertToT<T>(string data) where T : class
        {
            return iDeserialize.Deserialize<T>(data);
        }
    }
}
