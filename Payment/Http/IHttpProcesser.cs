namespace Payment.Http
{
    public interface IHttpProcesser
    {
        T Request<T>(BaseParemetor fyParemetor) where T : class;
        T Request<T>(System.Collections.Generic.IDictionary<string, string> data, string url) where T : class;
        T Request<T>(System.Collections.Generic.SortedDictionary<string, string> data, string url) where T : class;
    }
}
