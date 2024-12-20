using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using ZQH.Abp.Employees;
using ZQH.Abp.Identity.EntityFrameworkCore.Employees;
using ZQH.Platform.DataItems;
using ZQH.Platform.Datas;
using ZQH.Platform.EntityFrameworkCore;

namespace ZQH.Abp.Identity.EntityFrameworkCore;

[DependsOn(typeof(ZQH.Abp.Identity.AbpIdentityDomainModule))]
[DependsOn(typeof(Volo.Abp.Identity.EntityFrameworkCore.AbpIdentityEntityFrameworkCoreModule))]
//新增
[DependsOn(typeof(ZQH.Platform.EntityFrameworkCore.PlatformEntityFrameworkCoreModule))]
public class AbpIdentityEntityFrameworkCoreModule : AbpModule
{
    // private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<IdentityDbContext>(options =>
        {
            options.AddRepository<IdentityRole, EfCoreIdentityRoleRepository>();
            options.AddRepository<IdentityUser, EfCoreIdentityUserRepository>();
            options.AddRepository<IdentitySession, EfCoreIdentitySessionRepository>();
            options.AddRepository<OrganizationUnit, EfCoreOrganizationUnitRepository>();
        });
        //新增
        context.Services.AddAbpDbContext<EmployeeDbContext>(options =>
        {

            options.AddRepository<Employee, EfCoreEmployeeRepository>();
        });
    }

    //public override void PostConfigureServices(ServiceConfigurationContext context)
    //{
    //    OneTimeRunner.Run(() =>
    //    {
    //        ObjectExtensionManager.Instance
    //            .MapEfCoreProperty<IdentityUser, string>(
    //                ExtensionIdentityUserConsts.AvatarUrlField,
    //                (etb, prop) =>
    //                {
    //                    prop.HasMaxLength(ExtensionIdentityUserConsts.MaxAvatarUrlLength);
    //                });
    //    });
    //}
}
