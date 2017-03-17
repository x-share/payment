namespace Payment
{
    public interface IProvider
    {
        TResult Process<TResult>(AbsAccount ainfo) where TResult : AbsResult, new();
        TResult Process<TParametor, TResult>(TParametor info)
            where TParametor : AbsAccount
            where TResult : AbsResult, new();
    }
}
