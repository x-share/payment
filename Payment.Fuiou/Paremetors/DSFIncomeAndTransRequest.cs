
using Payment.Fuiou.Fuyou;

namespace Payment.Fuiou.Paremetors
{
    /// <summary>
    /// 代收然后转账 
    /// </summary>
    public class IncomeAndTransRequest
    {

        #region Fields
        /// <summary>
        /// 代收信息
        /// </summary>
        public IncomeForRequest IncomeInfo { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        internal string MerchantCode { get { return FuiouConfig.MerchantCode; } }

        /// <summary>
        /// 付款登录账户
        /// </summary>
        public string OutNo { get; set; }
        /// <summary>
        /// 收款登录账户
        /// </summary>
        public string InNo { get; set; }
        /// <summary>
        /// 转账金额以分为单位 (无小数位)
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 预授权合同号
        /// </summary>
        public string ContractNo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }

        string _ssn = "";
        /// <summary>
        /// 流水号
        /// </summary>
        public string SSN
        {
            get
            {
                if (string.IsNullOrEmpty(_ssn))
                    _ssn = Payment.SSN.GetSSN();
                return _ssn;
            }
        }
        #endregion

        #region Construction
        /// <summary>
        /// Construction
        /// </summary>
        public IncomeAndTransRequest() { }
        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="incomeInfo"></param>
        public IncomeAndTransRequest(IncomeForRequest incomeInfo) { this.IncomeInfo = incomeInfo; }
        #endregion

    }

    /// <summary>
    /// 代收然后转账返回值 错误类型
    /// </summary>
    public enum ErroType
    {
        /// <summary>
        /// 没有错误
        /// </summary>
        None = 0,
        /// <summary>
        /// 代收出错(代收异常，转账也不会成功)
        /// </summary>
        IncomeErro = 1,
        /// <summary>
        /// 代收成功，转账出错
        /// </summary>
        TransErro = 2,
    }

    /// <summary>
    /// 代收然后转账返回值
    /// </summary>
    public class IncomeAndTransResponse : DSFCommonResponse
    {
        /// <summary>
        /// 错误类型
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public ErroType ErroType { get; set; }
        /// <summary>
        /// 转账返回结果
        /// </summary>
        public string TransferResultCode { get; set; }

        public override string ResponseCode
        {
            get
            {
                return TransferResultCode;
            }

            set
            {
                var v = value;
            }
        }

        /// <summary>
        /// 转账返回结果描述
        /// </summary>
        public string TransferResultDescription
        {
            get
            {
                if (string.IsNullOrEmpty(this.TransferResultCode))
                    return "失败";
                else
                    return ErroCode.FuyouDescription[this.TransferResultCode];
            }
        }
        public override string Description
        {
            get
            {
                return TransferResultDescription;
            }

            set
            {
                var v = value;
            }
        }
        /// <summary>
        /// Construction
        /// </summary>
        public IncomeAndTransResponse() { }
        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="res"></param>
        public IncomeAndTransResponse(SingleCollectResponse res)
        {
            if (res != null)
            {
                this.Description = res.Description;
                this.ResponseCode = res.ResponseCode;
                this.ErroType = res.Result ? Paremetors.ErroType.None : Paremetors.ErroType.IncomeErro;
            }
        }
        /// <summary>
        /// 是否成功
        /// </summary>
        public override bool Result
        {
            get
            {
                if (string.IsNullOrEmpty(this.TransferResultCode))
                    this.TransferResultCode = "";
                return this.ErroType == Paremetors.ErroType.None && this.TransferResultCode == "0000";
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
                var v = value; ;
            }
        }
    }
}
