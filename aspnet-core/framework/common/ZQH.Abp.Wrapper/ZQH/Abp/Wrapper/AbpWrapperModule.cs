using Volo.Abp.ExceptionHandling;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Wrapper;

[DependsOn(typeof(AbpExceptionHandlingModule))]
public class AbpWrapperModule: AbpModule
{

}
