using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using ZQH.Abp.Onboarding.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZQH.Abp.Onboarding;
public interface IOnboardingRepository : IBasicRepository<OnboardingTask, Guid>
{
    Task<List<OnboardingTask>> GetListAsync(
    string sorting = null,
    int maxResultCount = int.MaxValue,
    int skipCount = 0,
    string filter = null,
    bool includeDetails = false,
    CancellationToken cancellationToken = default);
    Task<int> GetCountAsync(
    string filter = "",
    CancellationToken cancellationToken = default);
    Task<List<OnboardingTask>> GetPagedListAsync(
      string filter = "",
      string sorting = nameof(OnboardingTask.CreationTime),
      bool includeDetails = false,
      int skipCount = 0,
      int maxResultCount = 10,
      CancellationToken cancellationToken = default);
    Task<OnboardingTask> FindById(
    Guid id);

}
