using Payment.Fuiou.Response;

namespace Payment.Fuiou.Fuyou
{
    /// <summary>
    /// 返回结果
    /// </summary>
    public class BaseResult: AbsResult
    {
        const string sucess_code = "0000";

        /// <summary>
        /// 请求相应数据
        /// </summary>
        public FuiouResult ResponseData { get; private set; }

        /// <summary>
        /// 操作是否成功  ，当返回码为0000时成功
        /// </summary>
        public override bool IsSucess
        {
            get
            {
                return ResponseCode == sucess_code;
            }
        }

        /// <summary>
        /// 返回码 ResponseData.Plain.ResponseCode
        /// </summary>
        public override string ResponseCode
        {
            get
            {
                if (ResponseData == null || ResponseData.Plain == null || string.IsNullOrEmpty(ResponseData.Plain.ResponseCode))
                    return string.Empty;
                return ResponseData.Plain.ResponseCode;
            }
        }

        public override string Description
        {
            get
            {
                return ResponseDescription;
            }
        }
        /// <summary>
        /// 返回码描述  富有提供
        /// </summary>
        public string ResponseDescription
        {
            get
            {
                return ErroCode.FuyouDescription[ResponseCode];
            }
        }

        public override string TYPE
        {
            get
            {
                return "fuiou";
            }
        }

        private BaseResult() { }

        internal BaseResult(FuiouResult _Response) { this.ResponseData = _Response; }
    }


    internal class FyResult
    {
        public static BaseResult ToBaseResult(FuiouResult _result)
        {
            return new BaseResult(_result);
        }
    }
}
