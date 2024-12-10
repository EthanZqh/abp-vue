using System.Collections;
using System.Collections.Generic;

namespace ZQH.Abp.BackgroundTasks;
public interface IJobDispatcherSelectorList : IList<JobTypeSelector>, ICollection<JobTypeSelector>, IEnumerable<JobTypeSelector>, IEnumerable
{

}
