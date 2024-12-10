using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ZQH.Abp.OpenApi.Authorization
{
    public interface IOpenApiAuthorizationService
    {
        Task<bool> AuthorizeAsync(HttpContext httpContext);
    }
}
