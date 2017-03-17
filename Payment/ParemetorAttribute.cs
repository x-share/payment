using System;

namespace Payment
{
    /// <summary>
    /// 第三方支付字段属性
    /// </summary>
    public class ParemetorAttribute : Attribute
    {
        public string FieldName { get; set; }
        public int Sort { get; set; }
        private ParemetorAttribute() { }
        public ParemetorAttribute(string fieldName)
        {
            this.FieldName = fieldName.Trim();
            this.Sort = 0;
        }
        public ParemetorAttribute(string fieldName, int sort)
        {
            this.FieldName = fieldName.Trim();
            this.Sort = sort;
        }
    }
}
