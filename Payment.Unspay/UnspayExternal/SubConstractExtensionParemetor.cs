using System;
using System.Collections.Generic;

namespace Payment.Unspay.UnspayExternal
{
    /// <summary>
    /// 子协议延期接口
    /// </summary>
    public class SubConstractExtensionParemetor : UnspayParemetor
    {
        /// <summary>
        /// 子协议开始时间 格式 yyyyMMdd，如 20150101
        /// </summary>
        [Paremetor("startDate")]
        public string StartDate { get; set; }
        /// <summary>
        /// 子协议结束时间 格式 yyyyMMdd，如 20150101
        /// </summary>
        [Paremetor("endDate")]
        public string EndDate { get; set; }
        /// <summary>
        /// 商户协议编号
        /// </summary>
        [Paremetor("contractId")]
        public string ContractId { get; set; }
        /// <summary>
        /// 子协议编号
        /// </summary>
        [Paremetor("subContractId")]
        public string SubContractId { get; set; }
        public SubConstractExtensionParemetor(DateTime startDate, DateTime endDate, string contractId, string subContractId)
        {
            this.StartDate = startDate.ToString("yyyyMMdd");
            this.EndDate = endDate.ToString("yyyyMMdd");
            this.ContractId = contractId;
            this.SubContractId = subContractId;
        }

        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULL(this.StartDate, "子协议开始时间");
            yield return VALIDATE.NOTNULL(this.EndDate, "子协议结束时间");
            yield return VALIDATE.NOTNULL(this.ContractId, "商户协议编号");
            yield return VALIDATE.NOTNULL(this.SubContractId, "子协议编号");
        }

        public override string GetRequestUrl()
        {
            return UnspayConfig.ApiAddress["YSB.URL.SubConstractExtension"];
        }

        protected override string[] GetDataFields()
        {
            return new string[] { "accountId", "contractId", "subContractId", "startDate", "endDate", "mac" };
        }
    }

    /// <summary>
    /// 子协议延期接口 结果
    /// </summary>
    public class SubConstractExtensionResult : UnspayResult
    {
       

    }
}
