namespace Payment
{
    public class Provider : IProvider
    {
        public TResult Process<TResult>(AbsAccount ainfo) where TResult : AbsResult, new()
        {
            return  Process<AbsAccount, TResult>(ainfo);
        }

        public TResult Process<TParametor, TResult>(TParametor info)
            where TParametor : AbsAccount
            where TResult : AbsResult, new()
        {
            return Http.HttpProvider.GetProcesser(info.GetDeserializer(), info.GetLog4netAppender()).Request<TResult>(info as BaseParemetor);
        }
    }
}
