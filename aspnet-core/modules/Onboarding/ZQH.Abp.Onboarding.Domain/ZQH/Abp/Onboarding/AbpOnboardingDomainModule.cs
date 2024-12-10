
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using ZQH.Abp.Onboarding.Localization;

namespace ZQH.Abp.Onboarding;

[DependsOn(typeof(AbpOnboardingDomainSharedModule))]
[DependsOn(typeof(AbpAutoMapperModule))]
[DependsOn(typeof(AbpDddDomainModule))]
public class AbpOnboardingDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AbpOnboardingDomainModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<AbpOnboardingDomainMappingProfile>(validate: true);
        });

        Configure<AbpDistributedEntityEventOptions>(options =>
        {
            //options.EtoMappings.Add<BackgroundJobInfo, BackgroundJobEto>(typeof(TaskManagementDomainModule));

            //options.AutoEventSelectors.Add<BackgroundJobInfo>();
        });

    }


}
