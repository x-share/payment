using System;
using System.Collections.Generic;

namespace Payment.Unspay.UnspayExternal
{
    /// <summary>
    /// 子协议录入接口
    /// </summary>
    public class SignSimpleSubContractParemetor : UnspayParemetor
    {

        /// <summary>
        /// 银行卡号
        /// </summary>
        [Paremetor("cardNo")]
        public string CardNo { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [Paremetor("name")]
        public string Name { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [Paremetor("idCardNo")]
        public string IdCardNo { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Paremetor("phoneNo")]
        public string PhoneNo { get; set; }
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
        /// 扣款频率 1：每年； 2：每月； 3：每日
        /// </summary>
        [Paremetor("cycle")]
        public string Cycle { get; set; }
        /// <summary>
        /// 扣款次数限制 
        /// </summary>
        [Paremetor("triesLimit")]
        public string TriesLimit { get; set; }
        /// <summary>
        /// 商户协议编号 
        /// </summary>
        [Paremetor("contractId")]
        public string ContractId { get; set; }
        public SignSimpleSubContractParemetor(string cardNo, string name, string idCardNo, string phoneNo, DateTime startDate, DateTime endDate, string cycle, string triesLimit, string contractId)
        {
            this.CardNo = cardNo;
            this.Name = name;
            this.IdCardNo = idCardNo;
            this.PhoneNo = phoneNo;
            this.StartDate = startDate.ToString("yyyyMMdd");
            this.EndDate = endDate.ToString("yyyyMMdd");
            this.Cycle = cycle;
            this.TriesLimit = triesLimit;
            this.ContractId = contractId;
        }

        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULL(this.CardNo, "银行卡号");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.Name, 32, "用户姓名");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.IdCardNo, 18, "身份证号");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.PhoneNo, 11, "手机号");
            yield return VALIDATE.NOTNULL(this.StartDate, "子协议开始时间");
            yield return VALIDATE.NOTNULL(this.EndDate, "子协议结束时间");
            yield return VALIDATE.CANNULLANDLIMITLENGTH(this.Cycle, 10, " 扣款频率");
            yield return VALIDATE.CANNULLANDLIMITLENGTH(this.TriesLimit, 10, " 扣款次数限制");
            yield return VALIDATE.NOTNULL(this.ContractId, " 商户协议编号");
        }

        public override string GetRequestUrl()
        {
            return UnspayConfig.ApiAddress["YSB.URL.SignSimpleSubContract"];
        }

        protected override string[] GetDataFields()
        {
            return new string[] { "accountId", "contractId", "name", "phoneNo",
                "cardNo", "idCardNo", "startDate","endDate" ,"cycle","triesLimit","mac"};
        }

    }

    /// <summary>
    /// 子协议录入接口 返回结果
    /// </summary>
    public class SignSimpleSubContractResult : UnspayResult
    {
        /// <summary>
        /// 子协议号， 失败时该字段不返回
        /// </summary>
        [Newtonsoft.Json.JsonProperty("subContractId")]
        public string SubContractId
        {
            get; set;
        }
    }

}
