using LINGYUN.Abp.Tests;
using LINGYUN.Abp.Tests.Features;
using LINGYUN.Abp.WxPusher.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace LINGYUN.Abp.WxPusher;

[DependsOn(
        typeof(AbpWxPusherModule),
        typeof(AbpTestsBaseModule))]
public class AbpWxPusherTestModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var configurationOptions = new AbpConfigurationBuilderOptions
        {
            BasePath = @"D:\Projects\Development\Abp\WxPusher",
            EnvironmentName = "Test"
        };
        var configuration = ConfigurationHelper.BuildConfiguration(configurationOptions);

        context.Services.ReplaceConfiguration(configuration);
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<FakeFeatureOptions>(options =>
        {
            options.Map(WxPusherFeatureNames.Enable, (_) => "true");
            options.Map(WxPusherFeatureNames.Message.Enable, (_) => "true");
            options.Map(WxPusherFeatureNames.Message.SendLimit, (_) => "500");
            options.Map(WxPusherFeatureNames.Message.SendLimitInterval, (_) => "1");
        });
    }
}
