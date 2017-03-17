/***********************************
 * Create Date: 2015/11/16 17:16:57
 * Author     ：赵赫昂
 * Description: 
 * ********************************/

using Payment.Fuiou.Fuyou;
using System;
using System.Collections.Generic;

namespace Payment.Fuiou.Paremetors
{

    /// <summary>
    /// 业务查询
    /// </summary>
    public class TradingQueryParemetor : FuiouParemetor
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumBusinessType">交易类型</param>
        /// <param name="strTradingSSN">交易流水</param>
        /// <param name="strCustomerNo">交易用户</param>
        /// <param name="strRemark"></param>
        /// <param name="strPageNo"></param>
        /// <param name="strPageSize"></param>
        /// <param name="strStartDay">开始时间 8位 yyyymmdd</param>
        /// <param name="strEndDay">结束时间</param>
        /// <param name="enumTradingState">交易状态  "" 默认值 1 交易成功 2 交易失败</param>
        public TradingQueryParemetor(
            TradingQueryBusinessTypeEnum enumBusinessType,
            string strTradingSSN,
            string strCustomerNo,
            string strRemark = "",
            string strPageNo = "1",
            string strPageSize = "10",
            string strStartDay = "",
            string strEndDay = "",
            TradingQueryTradingState enumTradingState = TradingQueryTradingState.All
            )
        {
            this.BusinessType = enumBusinessType.ToString();
            this.StartDay = string.IsNullOrEmpty(strStartDay) ? DateTime.Now.ToString("yyyyMMdd") : strStartDay;
            this.EndDay = string.IsNullOrEmpty(strEndDay) ? DateTime.Now.ToString("yyyyMMdd") : strEndDay;
            this.TradingSSN = strTradingSSN;
            this.CustomerNo = strCustomerNo;
            this.Remark = strRemark;
            this.TradingState = enumTradingState == TradingQueryTradingState.All ? "" : ((Int32)enumTradingState).ToString();
            this.PageNo = strPageNo;
            this.PageSize = strPageSize;

        }

       

        /// <summary>
        /// 交易类型
        ///PWPC 转账
        ///PW13 预授权
        ///PWCF 预授权撤销
        ///PW03 划拨
        ///PW14 转账冻结
        ///PW15 划拨冻结
        ///PWDJ 冻结
        ///PWJD 解冻
        ///PW19 冻结付款到冻结
        /// </summary>
        [Paremetor("busi_tp")]
        public string BusinessType{ get; set; }
      

        /// <summary>
        /// 起始时间 20120901
        /// </summary>
        [Paremetor("start_day")]
        public string StartDay { get; set; }

        /// <summary>
        /// 截止时间20120901 起止时间不能跨月
        /// </summary>
        [Paremetor("end_day")]
        public string EndDay { get; set; }

        /// <summary>
        /// 交易流水
        /// </summary>
        [Paremetor("txn_ssn")]
        public string TradingSSN { get; set; }

        /// <summary>
        /// 交易用户
        /// </summary>
        [Paremetor("cust_no")]
        public string CustomerNo { get; set; }

        /// <summary>
        /// 交易状态  "" 默认值 1 交易成功 2 交易失败
        /// </summary>
        [Paremetor("txn_st")]
        public string TradingState { get; set; }

        /// <summary>
        /// 交易备注
        /// </summary>
        [Paremetor("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        [Paremetor("page_no")]
        public string PageNo { get; set; }


        /// <summary>
        /// 每页条数 [10,100]之间整数
        /// </summary>
        [Paremetor("page_size")]
        public string PageSize { get; set; }


        /// <summary>
        /// 字段
        /// </summary>
        /// <returns></returns>
        protected override string[] GetDataFields()
        {
            //busi_tp+"|"+cust_no+"|"+end_day+"|"+mchnt_cd+"|"+mchnt_txn_ssn+"|"+page_no+"|"+page_size+"|"+remark+"|"+start_day+"|"+txn_ssn+"|"+txn_st
            return new string[] { "busi_tp", "cust_no", "end_day", "mchnt_cd", "mchnt_txn_ssn", "page_no", "page_size", "remark", "start_day", "txn_ssn", "txn_st", "signature" };
      
        }

        /// <summary>
        /// 获取访问的路径 
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.QueryTxn.Action"];
        }
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.BusinessType, 4, "交易类型");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.StartDay, 8, "起始时间");
            yield return VALIDATE.CANNULLANDLIMITLENGTH(this.EndDay, 8, "截止时间");
            
        }
    }
}
