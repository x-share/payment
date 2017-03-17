namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 代收付返回值
    /// </summary>
    public class DSFCommonResponse : AbsResult
    {
        #region Fields

        /// <summary>
        /// 响应码 
        /// </summary>
        [System.Xml.Serialization.XmlElement("ret")]
        public override string ResponseCode { get;  set; }
        /// <summary>
        /// 响应描述 
        /// </summary>
        [System.Xml.Serialization.XmlElement("memo")]
        public override string Description { get;  set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public virtual bool Result
        {
            get { return (!string.IsNullOrEmpty(ResponseCode) && ResponseCode == "000000"); }
        }

        [System.Xml.Serialization.XmlIgnore]
        public override string TYPE
        {
            get
            {
                return "fuiou";
            }
        }
        public override bool IsSucess
        {
            get
            {
                return Result;
            }

             set
            {
                var ss = value;
            }
        }

        /// <summary>
        /// 重置结果
        /// </summary>
        /// <param name="response"></param>
        internal void Reset(DSFCommonResponse response)
        {
            if (response != null)
            {
                this.Reset(response.ResponseCode, response.Description);
            }
        }
        /// <summary>
        /// 重置结果
        /// </summary>
        /// <param name="code"></param>
        /// <param name="des"></param>
        internal void Reset(string code, string des)
        {
            this.ResponseCode = code;
            this.Description = des;
        }
        #endregion
    }
}
