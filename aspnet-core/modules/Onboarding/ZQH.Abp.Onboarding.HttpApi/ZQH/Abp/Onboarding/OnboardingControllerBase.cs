
using Volo.Abp.AspNetCore.Mvc;
using ZQH.Abp.Onboarding.Localization;


namespace ZQH.Abp.Onboarding;

public abstract class OnboardingControllerBase : AbpControllerBase
{
    protected OnboardingControllerBase()
    {
        LocalizationResource = typeof(AbpOnboardingResource);
    }
}
