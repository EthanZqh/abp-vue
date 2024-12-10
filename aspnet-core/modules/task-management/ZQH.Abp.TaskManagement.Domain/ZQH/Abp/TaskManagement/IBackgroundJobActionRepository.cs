using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ZQH.Abp.TaskManagement;

public interface IBackgroundJobActionRepository : IRepository<BackgroundJobAction, Guid>
{
    Task<List<BackgroundJobAction>> GetListAsync(
        string jobId,
        bool? isEnabled = null,
        CancellationToken cancellationToken = default);
}
