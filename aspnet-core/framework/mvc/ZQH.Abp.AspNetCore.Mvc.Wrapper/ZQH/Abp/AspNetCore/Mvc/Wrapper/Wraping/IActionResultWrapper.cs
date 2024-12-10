using Microsoft.AspNetCore.Mvc.Filters;

namespace ZQH.Abp.AspNetCore.Mvc.Wrapper.Wraping;

public interface IActionResultWrapper
{
    void Wrap(FilterContext context);
}
