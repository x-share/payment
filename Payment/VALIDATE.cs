using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Payment
{
    /// <summary>
    /// 验证结构体
    /// </summary>
    public class VALIDATE
    {
        /// <summary>
        /// 验证结果
        /// </summary>
        public bool ISOK { get; private set; }
        /// <summary>
        /// 错误提示
        /// </summary>
        public string MESS { get; private set; }
        /// <summary>
        /// 字段
        /// </summary>
        public string FIELD { get; private set; }

        private VALIDATE() { }
        private VALIDATE(bool isok) { this.ISOK = isok; }
        private VALIDATE(string field) { this.FIELD = field; }

        /// <summary>
        /// 不能为空且长度不能超过指定长度
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static VALIDATE NOTNULLANDLIMITLENGTH(string value, int maxLength, string fieldName)
        {
            var vali = new VALIDATE(fieldName);

            vali.ISOK = true;
            if (string.IsNullOrEmpty(value))
            {
                vali.ISOK = false;
                vali.MESS = string.Format("字段[{0}]不能为空", fieldName);
            }
            if (value.Length > maxLength)
            {
                vali.ISOK = false;
                vali.MESS = string.Format("字段[{0}]长度超过最大长度" + maxLength.ToString(), fieldName);
            }
            return vali;
        }

        /// <summary>
        /// 可以为空且长度不能超过指定长度
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static VALIDATE CANNULLANDLIMITLENGTH(string value, int maxLength, string fieldName)
        {
            var vali = new VALIDATE(fieldName);
            vali.ISOK = true;
            if (!string.IsNullOrEmpty(value))
                if (value.Length > maxLength)
                {
                    vali.ISOK = false;
                    vali.MESS = string.Format("字段[{0}]长度超过最大长度" + maxLength.ToString(), fieldName);
                }
            return vali;
        }

        /// <summary>
        /// 正确的验证结果
        /// </summary>
        /// <returns></returns>
        public static VALIDATE OKRES()
        {
            return new VALIDATE(true);
        }

        /// <summary>
        /// 不能为空
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static VALIDATE NOTNULL(string value, string fieldName)
        {
            var vali = new VALIDATE(fieldName);

            vali.ISOK = true;
            if (string.IsNullOrEmpty(value))
            {
                vali.ISOK = false;
                vali.MESS = string.Format("字段[{0}]不能为空", fieldName);
            }
            return vali;
        }


        /// <summary>
        /// 区间数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static VALIDATE ISSection(decimal minValue, decimal maxValue, decimal value, string fieldName)
        {
            var vali = new VALIDATE(fieldName.ToString());

            vali.ISOK = true;
            if (!(value < minValue || value > maxValue))
            {
                vali.ISOK = false;
                vali.MESS = string.Format("字段[{0}]小于{1}或大于{2}", fieldName, minValue, maxValue);
            }
            return vali;
        }

        /// <summary>
        /// 自定义错误
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static VALIDATE CustomerError(string fieldName, string fieldError)
        {
            var vali = new VALIDATE(fieldName);
            vali.ISOK = false;
            vali.MESS = fieldError;
            return vali;
        }

        /// <summary>
        /// 是否为空,如果不为空,是否是数字,数字长度必须为一定范围值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <param name="isNull">true 可以为空 false 不能为空</param>
        /// <param name="isNumber">true 只能为数字 false 可不为数字</param>
        /// <param name="maxLength">不为空最大长度</param>
        /// <param name="minLength">不为空最小长度</param>
        /// <returns></returns>
        public static VALIDATE ORNULLANDNUMBER(string value, string fieldName, bool isNull = true, bool isNumber = true, int maxLength = 8000, int minLength = 0)
        {
            VALIDATE val = new VALIDATE(fieldName);
            val.ISOK = true;

            if (!string.IsNullOrEmpty(value))
            {
                //return Regex.IsMatch(value, @"^[+-]?\d*$");
                bool isOk = Regex.IsMatch(value, @"^\d*$");
                if (isOk)
                {
                    if (value.Length > maxLength || value.Length < minLength)
                    {
                        val.ISOK = false;
                        val.MESS = string.Format("{0}:{1}", fieldName, "长度不能大于：" + maxLength + "且不能小于：" + minLength);
                    }
                }
                else
                {
                    if (!isNumber)
                    {
                        if (value.Length > maxLength || value.Length < minLength)
                        {
                            val.ISOK = false;
                            val.MESS = string.Format("{0}:{1}", fieldName, "长度不能大于：" + maxLength + "且不能小于：" + minLength);
                        }
                    }
                    else 
                    {
                        val.ISOK = false;
                        val.MESS = string.Format("{0}:{1}", fieldName, "不为数字");
                    }
                }
            }
            else
            {
                if (!isNull)
                {
                    val.ISOK = false;
                    val.MESS = string.Format("{0}:{1}", fieldName, "不能为空");
                }
            }
            return val;
        }
    }


    /// <summary>
    /// 验证中心
    /// </summary>
    public class VALIDATE_CONTROLLER
    {

        List<VALIDATE> erro = new List<VALIDATE>();

        /// <summary>
        /// 添加验证
        /// </summary>
        /// <param name="vali"></param>
        public void ADD_VALIDATE(VALIDATE vali)
        {
            erro.Add(vali);
        }

        /// <summary>
        /// 添加验证
        /// </summary>
        /// <param name="vali"></param>
        public void ADDRANGE_VALIDATE(params VALIDATE[] vali)
        {
            if (vali == null || vali.Count() <= 0) return;
            erro.AddRange(vali);
        }

        /// <summary>
        /// 是否有错误
        /// </summary>
        /// <returns></returns>
        public bool HASERRO()
        {
            return erro.Where(p => p.ISOK == false).FirstOrDefault() != null;
        }

        /// <summary>
        /// 第一个错误
        /// </summary>
        /// <returns></returns>
        public VALIDATE FIRSTERRO()
        {
            return erro.Where(p => p.ISOK == false).FirstOrDefault();
        }

        /// <summary>
        /// 所所有错误
        /// </summary>
        /// <returns></returns>
        public List<VALIDATE> ERROS()
        {
            return erro.Where(p => p.ISOK == false).ToList();
        }


    }
}
