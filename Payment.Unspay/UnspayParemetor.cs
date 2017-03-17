using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Payment.Serialize;
using System;

namespace Payment.Unspay
{
    /// <summary>
    /// 银生宝基础接口
    /// </summary>
    public class UnspayParemetor : BaseParemetor
    {

        const string mac = "mac";

        string _merchantCode = "";
        /// <summary>
        /// 商户编号
        /// </summary>
        [Paremetor("accountId")]
        public string MerchantCode
        {
            get
            {
                if (_merchantCode == "")
                    _merchantCode = UnspayConfig.MerchantCode;
                return _merchantCode;
            }
        }
        string _key = "";
        /// <summary>
        /// 秘钥
        /// </summary>
        public string Key
        {
            get
            {
                if (_key == "")
                    _key = UnspayConfig.Key;
                return _key;
            }
        }

        public override string Type
        {
            get
            {
                return "unspay";
            }
        }


        #region Abstract Method
        /// <summary>
        /// 获取字段
        /// </summary>
        /// <returns></returns>
        protected virtual string[] GetDataFields() { return null; }
        #endregion

        #region Virtual  Method

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <returns></returns>
        public virtual VALIDATE Validate()
        {
            VALIDATE_CONTROLLER vc = new VALIDATE_CONTROLLER();
            vc.ADDRANGE_VALIDATE(__MustValidateFields().ToArray());
            vc.ADDRANGE_VALIDATE(__GetValidateFields());

            if (vc.HASERRO())
                return vc.FIRSTERRO();
            else
                return VALIDATE.OKRES();
        }

        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerable<VALIDATE> SetValiDateFields()
        {
            return null;
        }

        /// <summary>
        /// 获取签名数据
        /// </summary>
        /// <returns></returns>
        public virtual string GetSignature()
        {
            var orderFields = __GetDataFieldsOrderByAsc();
            var value = __GetFieldValue(orderFields);
            List<object> paras = new List<object>();
            foreach (var item in orderFields)
            {
                if (item == mac) continue;
                if (value.ContainsKey(item))
                {
                    bool isNotNullOrEmpty = value[item] != null && value[item].ToString() != "";
                    if (isNotNullOrEmpty || !IsFilterNullOrEmptyField())
                    {
                        paras.Add(item + "=" + value[item]);
                    }
                }
            }
            paras.Add("key=" + Key);
            return md5(string.Join("&", paras.ToArray()));
        }

        /// <summary>
        /// 非必需参数值为空时不参与签名的生成。
        /// </summary>
        /// <returns></returns>
        protected virtual bool IsFilterNullOrEmptyField()
        {
            return true;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, string> GetFormatData()
        {
            SortedDictionary<string, string> condition = new SortedDictionary<string, string>();
            var fields = __GetDataFields();
            var value = __GetFieldValue(fields);
            foreach (var item in fields)
            {
                if (item == mac)
                {
                    condition.Add(mac, System.Web.HttpUtility.UrlEncode(GetSignature(), Encoding.UTF8));
                }
                else
                {
                    if (value.ContainsKey(item))
                        condition.Add(item, value[item].ToString());
                }
            }
            return condition;
        }

        #endregion

        #region Private  Method

        private string[] __GetDataFields()
        {
            var fields = this.GetDataFields();
            if (fields == null) return new string[] { };
            return fields;
        }

        private string[] __GetDataFieldsOrderByAsc()
        {
            var fields = __GetDataFields();
            return fields;
            //return (from f in __GetDataFields()
            //        orderby f
            //        select f.Trim()).ToArray();
        }

        //用户传入数据的字段
        private PropertyInfo[] __GetUserProperties()
        {
            var t = this.GetType();
            var props = t.GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(p => p.GetCustomAttributes(typeof(ParemetorAttribute), true)
                    .FirstOrDefault() != null)
                    .ToArray();
            if (props == null)
                props = new PropertyInfo[] { };
            return props;
        }

        private IDictionary<string, object> __GetFieldValue(string[] fields)
        {
            IDictionary<string, object> values = new Dictionary<string, object>();
            var properties = __GetUserProperties();
            foreach (var item in fields)
            {
                if (item == mac) continue;
                var aim = properties.Where(p => (p.GetCustomAttributes(typeof(ParemetorAttribute), true).FirstOrDefault() as ParemetorAttribute).FieldName == item).FirstOrDefault().GetValue(this);
                values.Add(item, aim);
            }
            return values;
        }

        private VALIDATE[] __GetValidateFields()
        {
            var fs = SetValiDateFields();
            if (fs == null) return new VALIDATE[] { };
            return fs.ToArray();
        }

        //必须验证的字段
        private IEnumerable<VALIDATE> __MustValidateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.MerchantCode, 30, "商户代码");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.Key, 8000, "KEY 不能为空");
        }
        #endregion

        /// <summary>
        /// 获取地址
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return "";
        }

        private string md5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper();
        }

        public override IDeserializable GetDeserializer()
        {
            return JsonSerialize.New();
        }

        public override string GetLog4netAppender()
        {
            return "ysbLog";
        }
    }
}
