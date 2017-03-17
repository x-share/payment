using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Payment.Fuiou.Fuyou;
using Payment.Serialize;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 富有基础参数
    /// </summary>
    public class FuiouParemetor : BaseParemetor
    {

        const string FIELD_SIGNATURE = "signature";

        #region Base Properties

        string _merchantCode = "";
        /// <summary>
        /// 获取商户代码
        /// </summary>
        [Paremetor("mchnt_cd")]
        public string MerchantCode
        {
            get
            {
                if (_merchantCode == "")
                    _merchantCode = FuiouConfig.MerchantCode;
                return _merchantCode;
            }
        }

        string _merchantLogin = "";
        /// <summary>
        /// 获取商户登录账号
        /// </summary>
        public string MerchantLogin
        {
            get
            {
                if (_merchantLogin == "")
                    _merchantLogin = FuiouConfig.MerchantLogin;
                return _merchantLogin;
            }
        }

        string _SSN = "";
        /// <summary>
        /// 获取获取SSN流水号
        /// </summary>
        [Paremetor("mchnt_txn_ssn")]
        public string SSN
        {
            get
            {
                if (_SSN == "")
                    _SSN = Payment.SSN.GetSSN();
                return _SSN;
            }
        }

        public override string Type
        {
            get
            {
                return "fuiou";
            }
        }

        #endregion

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
                if (item == FIELD_SIGNATURE) continue;
                if (value.ContainsKey(item))
                    paras.Add(value[item]);
            }
            return RSAHelper.Sign(string.Join("|", paras.ToArray()), FuiouConfig.PrivateKey);
        }

        /// <summary>
        /// 获取富有格式数据
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, string> GetFormatData()
        {
            SortedDictionary<string, string> condition = new SortedDictionary<string, string>();
            var fields = __GetDataFields();
            var value = __GetFieldValue(fields);
            foreach (var item in fields)
            {
                if (item == FIELD_SIGNATURE)
                {
                    condition.Add(FIELD_SIGNATURE, System.Web.HttpUtility.UrlEncode(GetSignature(), Encoding.UTF8));
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
            //var fields = __GetDataFields();
            //return fields;
            return (from f in __GetDataFields()
                    orderby f
                    select f.Trim()).ToArray();
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
                if (item == FIELD_SIGNATURE) continue;
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
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.MerchantCode, 15, "商户代码");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.SSN, 30, "流水号");
        }
        #endregion

        public override string GetRequestUrl()
        {
            return "";
        }

        /// <summary>
        /// 重新设置SSN
        /// </summary>
        public void RestSSN()
        {
            _SSN =Payment.SSN.GetSSN();
        }
        public override IDeserializable GetDeserializer()
        {
            return new XMLSerialize();
        }
        public override string GetLog4netAppender()
        {
            return "fuyou";
        }
    }
}
