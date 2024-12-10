using Volo.Abp.Data;

namespace ZQH.Abp.Onboarding;

public class AbpOnboardingDbProperties
{
    public static string DbTablePrefix { get; set; } = "Cus";

    public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

    public const string ConnectionStringName = "Default";
}
