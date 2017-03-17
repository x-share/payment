namespace Payment
{
    /// <summary>
    /// 付款异常类型
    /// </summary>
    public enum PayErrorType
    {
        /// <summary>
        /// 无异常
        /// </summary>
        None = 0,
        /// <summary>
        /// 网络异常
        /// </summary>
        NetException = 1001,
        /// <summary>
        /// 类型转换
        /// </summary>
        TypeConvertException = 1002,
        /// <summary>
        /// 未实现的第三方支付操作
        /// </summary>
        UnrealizedPaymentException = 1003,
        /// <summary>
        /// 其它异常
        /// </summary>
        OtherException = 1004,
        /// <summary>
        /// 禁用的接口
        /// </summary>
        DisableApi = 1005,
        /// <summary>
        /// 验签失败
        /// </summary>
        VerifyException = 1006,
        /// <summary>
        /// 提交服务器成功，需要查询验证交易结果
        /// </summary>
        NeedQuery = 1007
    }
}
