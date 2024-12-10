using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.Account;

public interface IMyClaimAppService : IApplicationService
{
    Task ChangeAvatarAsync(ChangeAvatarInput input);
}
