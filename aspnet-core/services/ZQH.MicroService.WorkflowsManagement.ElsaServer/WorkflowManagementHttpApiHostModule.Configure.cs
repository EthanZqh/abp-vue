using Microsoft.AspNetCore.Cors;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Threading;

namespace ZQH.MicroService.Workflows.ElsaServer;

public partial class WorkflowManagementHttpApiHostModule
{
    public static string ApplicationName { get; set; } = "WorkflowService";
    private const string DefaultCorsPolicyName = "Default";
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    private void ConfigureDbContext()
    {
        // 配置Ef
        Configure<AbpDbContextOptions>(options =>
        {
            //options.UseMySQL();
            options.UseSqlServer();
        });
    }

    private void ConfigureCors(IServiceCollection services, IConfiguration configuration)
    {
        //services.AddCors(options =>
        //{
        //    options.AddPolicy(DefaultCorsPolicyName, builder =>
        //    {
        //        builder
        //            .WithOrigins(
        //                configuration["App:CorsOrigins"]
        //                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
        //                    .Select(o => o.RemovePostFix("/"))
        //                    .ToArray()
        //            )
        //            .WithAbpExposedHeaders()
        //            .WithAbpWrapExposedHeaders()
        //            .SetIsOriginAllowedToAllowWildcardSubdomains()
        //            .AllowAnyHeader()
        //            .AllowAnyMethod()
        //            .AllowCredentials();
        //    });
        //});

        services.AddCors(cors => cors
    .AddDefaultPolicy(policy => policy
        .AllowAnyOrigin() // For demo purposes only. Use a specific origin instead.
        .AllowAnyHeader()
        .AllowAnyMethod()
        //.WithExposedHeaders("x-elsa-workflow-instance-id"))); // Required for Elsa Studio in order to support running workflows from the designer. Alternatively, you can use the `*` wildcard to expose all headers.
        .WithExposedHeaders())); // Required for Elsa Studio in order to support running workflows from the designer. Alternatively, you can use the `*` wildcard to expose all headers.
    }


}
