#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/ZQH.MicroService.Product.HttpApi.Host/ZQH.MicroService.Product.HttpApi.Host.csproj", "services/ZQH.MicroService.Product.HttpApi.Host/"]
COPY ["modules/auditing/ZQH.Abp.AuditLogging.Elasticsearch/ZQH.Abp.AuditLogging.Elasticsearch.csproj", "modules/auditing/ZQH.Abp.AuditLogging.Elasticsearch/"]
COPY ["modules/elasticsearch/ZQH.Abp.Elasticsearch/ZQH.Abp.Elasticsearch.csproj", "modules/elasticsearch/ZQH.Abp.Elasticsearch/"]
COPY ["modules/auditing/ZQH.Abp.AuditLogging/ZQH.Abp.AuditLogging.csproj", "modules/auditing/ZQH.Abp.AuditLogging/"]
COPY ["modules/authorization/ZQH.Abp.Authorization.OrganizationUnits/ZQH.Abp.Authorization.OrganizationUnits.csproj", "modules/authorization/ZQH.Abp.Authorization.OrganizationUnits/"]
COPY ["modules/common/ZQH.Abp.AspNetCore.HttpOverrides/ZQH.Abp.AspNetCore.HttpOverrides.csproj", "modules/common/ZQH.Abp.AspNetCore.HttpOverrides/"]
COPY ["modules/common/ZQH.Abp.Data.DbMigrator/ZQH.Abp.Data.DbMigrator.csproj", "modules/common/ZQH.Abp.Data.DbMigrator/"]
COPY ["modules/common/ZQH.Abp.ExceptionHandling.Emailing/ZQH.Abp.ExceptionHandling.Emailing.csproj", "modules/common/ZQH.Abp.ExceptionHandling.Emailing/"]
COPY ["modules/common/ZQH.Abp.ExceptionHandling/ZQH.Abp.ExceptionHandling.csproj", "modules/common/ZQH.Abp.ExceptionHandling/"]
COPY ["modules/common/ZQH.Abp.Http.Client.Wrapper/ZQH.Abp.Http.Client.Wrapper.csproj", "modules/common/ZQH.Abp.Http.Client.Wrapper/"]
COPY ["modules/common/ZQH.Abp.Wrapper/ZQH.Abp.Wrapper.csproj", "modules/common/ZQH.Abp.Wrapper/"]
COPY ["modules/identity/ZQH.Abp.Identity.EntityFrameworkCore/ZQH.Abp.Identity.EntityFrameworkCore.csproj", "modules/identity/ZQH.Abp.Identity.EntityFrameworkCore/"]
COPY ["modules/identity/ZQH.Abp.Identity.Domain/ZQH.Abp.Identity.Domain.csproj", "modules/identity/ZQH.Abp.Identity.Domain/"]
COPY ["modules/identity/ZQH.Abp.Identity.Domain.Shared/ZQH.Abp.Identity.Domain.Shared.csproj", "modules/identity/ZQH.Abp.Identity.Domain.Shared/"]
COPY ["modules/localization/ZQH.Abp.AspNetCore.Mvc.Localization/ZQH.Abp.AspNetCore.Mvc.Localization.csproj", "modules/localization/ZQH.Abp.AspNetCore.Mvc.Localization/"]
COPY ["modules/localization/ZQH.Abp.Localization.CultureMap/ZQH.Abp.Localization.CultureMap.csproj", "modules/localization/ZQH.Abp.Localization.CultureMap/"]
COPY ["modules/logging/ZQH.Abp.Serilog.Enrichers.Application/ZQH.Abp.Serilog.Enrichers.Application.csproj", "modules/logging/ZQH.Abp.Serilog.Enrichers.Application/"]
COPY ["modules/logging/ZQH.Abp.Serilog.Enrichers.UniqueId/ZQH.Abp.Serilog.Enrichers.UniqueId.csproj", "modules/logging/ZQH.Abp.Serilog.Enrichers.UniqueId/"]
COPY ["modules/common/ZQH.Abp.IdGenerator/ZQH.Abp.IdGenerator.csproj", "modules/common/ZQH.Abp.IdGenerator/"]
COPY ["modules/lt/ZQH.Abp.LocalizationManagement.EntityFrameworkCore/ZQH.Abp.LocalizationManagement.EntityFrameworkCore.csproj", "modules/lt/ZQH.Abp.LocalizationManagement.EntityFrameworkCore/"]
COPY ["modules/lt/ZQH.Abp.LocalizationManagement.Domain/ZQH.Abp.LocalizationManagement.Domain.csproj", "modules/lt/ZQH.Abp.LocalizationManagement.Domain/"]
COPY ["modules/localization/ZQH.Abp.Localization.Persistence/ZQH.Abp.Localization.Persistence.csproj", "modules/localization/ZQH.Abp.Localization.Persistence/"]
COPY ["modules/lt/ZQH.Abp.LocalizationManagement.Domain.Shared/ZQH.Abp.LocalizationManagement.Domain.Shared.csproj", "modules/lt/ZQH.Abp.LocalizationManagement.Domain.Shared/"]
COPY ["modules/mvc/ZQH.Abp.AspNetCore.Mvc.Wrapper/ZQH.Abp.AspNetCore.Mvc.Wrapper.csproj", "modules/mvc/ZQH.Abp.AspNetCore.Mvc.Wrapper/"]
COPY ["modules/product/ProductManagement.Application/ProductManagement.Application.csproj", "modules/product/ProductManagement.Application/"]
COPY ["modules/product/ProductManagement.Application.Contracts/ProductManagement.Application.Contracts.csproj", "modules/product/ProductManagement.Application.Contracts/"]
COPY ["modules/product/ProductManagement.Domain.Shared/ProductManagement.Domain.Shared.csproj", "modules/product/ProductManagement.Domain.Shared/"]
COPY ["modules/product/ProductManagement.Domain/ProductManagement.Domain.csproj", "modules/product/ProductManagement.Domain/"]
COPY ["modules/product/ProductManagement.EntityFrameworkCore/ProductManagement.EntityFrameworkCore.csproj", "modules/product/ProductManagement.EntityFrameworkCore/"]
COPY ["modules/product/ProductManagement.HttpApi/ProductManagement.HttpApi.csproj", "modules/product/ProductManagement.HttpApi/"]
COPY ["modules/product/ProductManagement.HttpApi.Client/ProductManagement.HttpApi.Client.csproj", "modules/product/ProductManagement.HttpApi.Client/"]
COPY ["modules/saas/ZQH.Abp.Saas.EntityFrameworkCore/ZQH.Abp.Saas.EntityFrameworkCore.csproj", "modules/saas/ZQH.Abp.Saas.EntityFrameworkCore/"]
COPY ["modules/saas/ZQH.Abp.Saas.Domain/ZQH.Abp.Saas.Domain.csproj", "modules/saas/ZQH.Abp.Saas.Domain/"]
COPY ["modules/tenants/ZQH.Abp.MultiTenancy.Editions/ZQH.Abp.MultiTenancy.Editions.csproj", "modules/tenants/ZQH.Abp.MultiTenancy.Editions/"]
COPY ["modules/tenants/ZQH.Abp.MultiTenancy/ZQH.Abp.MultiTenancy.csproj", "modules/tenants/ZQH.Abp.MultiTenancy/"]
COPY ["modules/saas/ZQH.Abp.Saas.Domain.Shared/ZQH.Abp.Saas.Domain.Shared.csproj", "modules/saas/ZQH.Abp.Saas.Domain.Shared/"]
RUN dotnet restore "services/ZQH.MicroService.Product.HttpApi.Host/ZQH.MicroService.Product.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/ZQH.MicroService.Product.HttpApi.Host"
RUN dotnet build "ZQH.MicroService.Product.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZQH.MicroService.Product.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZQH.MicroService.Product.HttpApi.Host.dll"]