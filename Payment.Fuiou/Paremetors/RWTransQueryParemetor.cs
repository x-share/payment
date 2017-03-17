using Payment.Fuiou.Fuyou;
using System;
using System.Collections.Generic;

namespace Payment.Fuiou.Paremetors
{

    /// <summary>
    /// 22.充值提现查询接口
    /// </summary>
    public class RWTransQueryParemetor : FuiouParemetor
    {

        /// <summary>
        /// 交易类型
        /// PW11:充值 PWTX:提现
        /// </summary>
        [Paremetor("busi_tp")]
        public string TransType { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        [Paremetor("start_time")]
        public string BeginTime { get; set; }
        /// <summary>
        /// end_time
        /// </summary>
        [Paremetor("end_time")]
        public string EndTime { get; set; }

        string _user = "";
        /// <summary>
        /// 用户
        /// </summary>
        [Paremetor("cust_no")]
        public string User { get { return _user; } set { _user = value; } }

        string _trasState = "";
        /// <summary>
        /// 交易状态
        /// 1 交易成功、2 交易失败
        /// </summary>
        [Paremetor("txn_st")]
        public string TransState { get { return _trasState; } set { _trasState = value; } }
        /// <summary>
        /// 页码
        /// 大于零的整数；默认为1;
        /// </summary>
        [Paremetor("page_no")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页条数
        /// [10,100]之间整数; 默认值:10;最大值:100;
        /// </summary>
        [Paremetor("page_size")]
        public int PageSize { get; set; }


        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.QUERYCZTX.Action"];
        }

        /// <summary>
        /// 格式化日期
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DATE(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 字段
        /// </summary>
        /// <returns></returns>
        protected override string[] GetDataFields()
        {
            return new string[] { "busi_tp", "cust_no", "end_time", "mchnt_cd", "mchnt_txn_ssn", "page_no", "page_size", "start_time", "txn_st", "signature" };
        }
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.TransType, 4, "交易类型");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.BeginTime, 19, "起始时间");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.EndTime, 19, "截止时间");
        }
    }
}

