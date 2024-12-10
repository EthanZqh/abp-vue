using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ZQH.Abp.Onboarding.EntityFrameworkCore;

public class OnboardingModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
{
    public OnboardingModelBuilderConfigurationOptions(
       [NotNull] string tablePrefix = "",
       [CanBeNull] string schema = null)
       : base(
           tablePrefix,
           schema)
    {

    }
}
