using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using ZQH.Abp.Onboarding.Localization;


namespace ZQH.Abp.Onboarding;
public abstract class OnboardingApplicationServiceBase : ApplicationService
{
    protected OnboardingApplicationServiceBase()
    {
        ObjectMapperContext = typeof(AbpOnboardingApplicationModule);
        LocalizationResource = typeof(AbpOnboardingResource);

    }
}
