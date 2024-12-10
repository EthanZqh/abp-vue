using Elsa.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.NewtonsoftJson;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ZQH.MicroService.Workflows.ElsaServer;

[DependsOn(
    //typeof(AbpSerilogEnrichersApplicationModule),
    //typeof(AbpSerilogEnrichersUniqueIdModule),
    //typeof(AbpAuditLoggingElasticsearchModule),
    //typeof(AbpAspNetCoreSerilogModule),
    //typeof(AbpBlobStoringOssManagementModule),
    //typeof(AbpElsaModule),
    //typeof(AbpElsaServerModule),
    //typeof(AbpElsaActivitiesModule),
    //typeof(AbpElsaNotificationsModule),
    //typeof(AbpEmailingExceptionHandlingModule),
    //typeof(AbpHttpClientIdentityModelWebModule),
    //typeof(AbpAspNetCoreMultiTenancyModule),
    //typeof(AbpAspNetCoreMvcLocalizationModule),
    //typeof(AbpBackgroundTasksQuartzModule),
    //typeof(AbpBackgroundTasksDistributedLockingModule),
    //typeof(AbpBackgroundTasksExceptionHandlingModule),
    //typeof(TaskManagementEntityFrameworkCoreModule),
    //typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    //typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    //typeof(AbpSettingManagementEntityFrameworkCoreModule),
    //typeof(AbpSaasEntityFrameworkCoreModule),
    //typeof(AbpLocalizationManagementEntityFrameworkCoreModule),
    //typeof(AbpEntityFrameworkCoreMySQLModule),
    //typeof(AbpElsaEntityFrameworkCoreMySqlModule),
    //typeof(AbpAuthorizationOrganizationUnitsModule),
    //typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
    //typeof(AbpTextTemplatingScribanModule),
    //typeof(AbpDataDbMigratorModule),
    //typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpAspNetCoreMvcModule),
    //typeof(AbpSwashbuckleModule),
    //typeof(AbpCAPEventBusModule),
    //typeof(AbpLocalizationCultureMapModule),
    //typeof(AbpHttpClientWrapperModule),
    //typeof(AbpAspNetCoreMvcWrapperModule),
    //typeof(AbpClaimsMappingModule),
    typeof(AbpAspNetCoreMvcNewtonsoftModule),
    //typeof(AbpAspNetCoreHttpOverridesModule),
    //typeof(AbpIdentitySessionAspNetCoreModule),
    typeof(AbpAutofacModule)
    )]

public partial class WorkflowManagementHttpApiHostModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        //PreConfigureFeature();
        //PreConfigureForwardedHeaders();
        //PreConfigureApp(configuration);
        //PreConfigureCAP(configuration);
        //PreConfigureQuartz(configuration);
        //PreConfigureElsa(context.Services, configuration);
    }


    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        ConfigureDbContext();
        //ConfigureLocalization();
        //ConfigureExceptionHandling();
        //ConfigureVirtualFileSystem();
        //ConfigureTiming(configuration);
        //ConfigureCaching(configuration);
        //ConfigureAuditing(configuration);
        //ConfigureIdentity(configuration);
        //ConfigureMultiTenancy(configuration);
        //ConfigureBackgroundTasks(configuration);
        //ConfigureSwagger(context.Services);
        //ConfigureEndpoints(context.Services);
        //ConfigureMvc(context.Services, configuration);
        ConfigureCors(context.Services, configuration);
        //ConfigureBlobStoring(context.Services, configuration);
        //ConfigureOpenTelemetry(context.Services, configuration);
        //ConfigureDistributedLock(context.Services, configuration);
        //ConfigureSecurity(context.Services, configuration, hostingEnvironment.IsDevelopment());

        //context.Services.AddRazorPages();

        context.Services.AddRazorPages(options => options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute()));
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        app.UseForwardedHeaders();
        // 本地化
        //app.UseMapRequestLocalization();
        //app.UseCorrelationId();
        //app.UseStaticFiles();
        //app.UseRouting();
        //app.UseCors(DefaultCorsPolicyName);
        //app.UseElsaFeatures();
        //app.UseAuthentication();
        //app.UseJwtTokenMiddleware();
        //app.UseMultiTenancy();
        //app.UseAbpSession();
        //app.UseDynamicClaims();
        //app.UseAuthorization();
        //app.UseSwagger();
        //app.UseAbpSwaggerUI(options =>
        //{
        //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");

        //    var configuration = context.GetConfiguration();
        //    options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
        //    options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
        //    options.OAuthScopes(configuration["AuthServer:Scopes"]);
        //});
        //app.UseAuditing();
        //app.UseAbpSerilogEnrichers();
        //app.UseConfiguredEndpoints();



        //if (!app.Environment.IsDevelopment())
        //{
        //    app.UseExceptionHandler("/Error");
        //    app.UseHsts();
        //}
        app.UseHttpsRedirection();
        app.UseBlazorFrameworkFiles();
        app.UseRouting(); // Required for SignalR.
        app.UseCors();
        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseWorkflowsApi(); // Use Elsa API endpoints.
        app.UseWorkflows(); // Use Elsa middleware to handle HTTP requests mapped to HTTP Endpoint activities.
        app.UseWorkflowsSignalRHubs(); // Optional SignalR integration. Elsa Studio uses SignalR to receive real-time updates from the server. 
        //app.MapFallbackToPage("/_Host");
        //app.MapControllers();
        //app.MapRazorPages();
        // Create a sample weather forecast API.
//        var summaries = new[]
//        {
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//        app.MapGet("/weatherforecast", () =>
//        {
//            var forecast = Enumerable.Range(1, 5).Select(index =>
//                    new WeatherForecast
//                    (
//                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                        Random.Shared.Next(-20, 55),
//                        summaries[Random.Shared.Next(summaries.Length)]
//                    ))
//                .ToArray();
//            return forecast;
//        });
//        app.Run();
    }
}
