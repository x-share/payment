using System.Collections.Generic;

namespace Payment.Unspay.UnspayExternal
{
    /// <summary>
    /// 子协议号查询接口
    /// </summary>
    public class QuerySubContractIdParemetor : UnspayParemetor
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


        public QuerySubContractIdParemetor(string cardNo, string name, string idCardNo)
        {
            CardNo = cardNo;
            Name = name;
            IdCardNo = idCardNo;
        }

        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULL(this.CardNo, "银行卡号");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.Name,30, "用户姓名");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.IdCardNo,18, "身份证号");
        }

        public override string GetRequestUrl()
        {
            return UnspayConfig.ApiAddress["YSB.URL.QuerySubContractId"];
        }

        protected override string[] GetDataFields()
        {
            return new string[] { "accountId", "name", "cardNo", "idCardNo", "mac" };
        }
    }


    /// <summary>
    /// 子协议号查询接口 结果
    /// </summary>
    public class QuerySubContractIdResult : UnspayResult
    {
        /// <summary>
        /// 子协议号， 查询失败该值不返回
        /// </summary>
        [Newtonsoft.Json.JsonProperty("subContractId")]
        public string SubContractId
        {
            get; set;
        }
    }

}
