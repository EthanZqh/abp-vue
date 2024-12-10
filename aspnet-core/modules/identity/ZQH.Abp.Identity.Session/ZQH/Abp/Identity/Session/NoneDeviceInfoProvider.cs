using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace ZQH.Abp.Identity.Session;

[Dependency(ServiceLifetime.Singleton, TryRegister = true)]
public class NoneDeviceInfoProvider : IDeviceInfoProvider
{
    public DeviceInfo DeviceInfo => new DeviceInfo("unknown", "unknown", "unknown");

    public string ClientIpAddress => "::1";
}
