/***********************************
 * Create Date:  2014/10/14 PM 6:03:15
 * Author     ：Aaron Yuan
 * Description: 
 * ********************************/

using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Payment.Fuiou.Response.Plain;
using Payment.Fuiou.Fuyou;

namespace Payment.Fuiou.Response
{
    /// <summary>
    /// 富友接口返回对象
    /// </summary>
    [XmlRoot("ap")]
    public class FuiouResult
    {
        [XmlElement("plain")]
        public BasicPlain Plain { get; set; }
        /// <summary>
        /// 操作结果状态
        /// 0000 - 成功
        /// 其他值表示失败
        /// </summary>
        [XmlElement("signature")]
        public string Sgnature { get; set; }
    }

    /// <summary>
    /// 富友接口返回数据基本结构
    /// </summary>
    [XmlRoot("ap")]
    public class FuiouBaseResult<TPlain> : AbsResult where TPlain : FuiouBasePlain
    {

        const string sucess_code = "0000";

        /// <summary>
        /// 操作是否成功 
        /// </summary>
        public override bool IsSucess
        {
            get
            {
                return ResponseCode == sucess_code;
            }
        }

        /// <summary>
        /// 返回码 
        /// </summary>
        public override string ResponseCode
        {
            get
            {
                if (Plain == null || string.IsNullOrEmpty(Plain.ResponseCode))
                    return string.Empty;
                return Plain.ResponseCode;
            }
        }

        /// <summary>
        /// 返回码描述  富有提供
        /// </summary>
        public override string Description
        {
            get
            {
                return ErroCode.FuyouDescription[ResponseCode];
            }
        }

        /// <summary>
        /// 数据
        /// </summary>
        [XmlElement("plain")]
        public TPlain Plain { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [XmlElement("signature")]
        public string Sgnature { get; set; }

        /// <summary>
        /// 账户类型
        /// </summary>
        public override string TYPE { get { return "fuiou"; } }
    }






    /// <summary>
    /// 富友标准返回接口
    /// </summary>
    [XmlRoot("ap")]
    public class FuiouStandardResult : FuiouBaseResult<FuiouBasePlain>
    {

    }


    //1.	开户注册             不需要修改使用标准接口 RegisterAccountParemetor
    //2.	用户信息修改         不需要实现
    #region   3.   	余额查询 QueryAccountBalanceParemetor
    /// <summary>
    /// 余额查询
    /// </summary>
    [XmlRoot("ap")]
    public class QueryAccountBalanceResult : FuiouBaseResult<QueryAccountBalancePlain>
    {

    }

    #endregion
    #region   4.	预授权 ReleasePreAuthorizationParemetor
    /// <summary>
    /// 预授权
    /// </summary>
    [XmlRoot("ap")]
    public class PreAuthorizationResult : FuiouBaseResult<PreAuthorizationPlain>
    {
    }

    #endregion
    //5.	预授权撤销           不需要修改使用标准接口 ReleasePreAuthorizationParemetor
    //6.	转账(商户与个人之间) 不需要修改使用标准接口 TransferAccountParemetor
    //7.	划拨 (个人与个人之间)不需要修改使用标准接口 DirectlyDeductedParemetor
    #region  8.	用户信息查询接口 QueryAccountInfoParemetor
    /// <summary>
    /// 用户信息查询接口
    /// </summary>
    [XmlRoot("ap")]
    public class QueryAccountInfoResult : FuiouBaseResult<QueryAccountInfoParemetorPlain>
    {

    }
    #endregion
    // 9.	用户信息修改         不需要修改使用标准接口 ModifyAccountParemetor
    // 12 	冻结                 不需要修改使用标准接口 FreezeParemetor
    #region  15.	解冻  UnFreezeParemetor
    [XmlRoot("ap")]
    public class UnFreezeResult : FuiouBaseResult<UnFreezePlain>
    {

    }
    #endregion
    #region 29 快速充值
    [XmlRoot("ap")]
    public class RechargeResult : FuiouBaseResult<RechargePlain>
    {

    }

    #endregion
    #region 30 网银充值

    [XmlRoot("ap")]
    public class RechargeSignResult : FuiouBaseResult<RechargeSignPlain>
    {

    }
    #endregion
    //WithdrawalsParemetor
    #region 31 提现
    [XmlRoot("ap")]
    public class WithdrawalsResult : FuiouBaseResult<WithdrawalsPlain>
    {

    }


    #endregion

    //20.交易查询接口
    /// <summary>
    /// 交易查询接口
    /// </summary>
    [XmlRoot("ap")]
    public class TradingQueryResult : FuiouBaseResult<TradingQueryPlain>
    {
        /// <summary>
        /// 充值提现查询接口返回的数据
        /// </summary>
        public List<TradingQueryPlainResult> Data
        {
            get
            {
                if (base.Plain != null && base.Plain.Results != null)
                    return base.Plain.Results.ResultList;
                return null;
            }
        }
    }

    #region 22.	充值提现查询接口

    /// <summary>
    /// 充值提现查询接口返回数据结构
    /// </summary>
    [XmlRoot("ap")]
    public class RWTransQueryResult : FuiouBaseResult<RWTransQueryPlain>
    {
        /// <summary>
        /// 充值提现查询接口返回的数据
        /// </summary>
        public List<RWTransQueryPlainResult> Data
        {
            get
            {
                if (base.Plain != null && base.Plain.Results != null)
                    return base.Plain.Results.Data;
                return null;
            }
        }
    }


    /// <summary>
    /// 富友标准返回接口
    /// </summary>
    [XmlRoot("ap")]
    public class ChangeCardResult : FuiouBaseResult<FuiouBasePlain2>
    {
        /// <summary>
        /// 返回码说明
        /// </summary>
        public string DescriptionCode
        {
            get
            {
                return Plain != null ? Plain.Description : "";
            }
        }
    }

    #endregion

}
