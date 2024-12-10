namespace ZQH.Abp.AspNetCore.Wrapper;
public interface IHttpResponseWrapper
{
    void Wrap(HttpResponseWrapperContext context);
}
