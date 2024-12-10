using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZQH.Abp.UI.Navigation;

public interface INavigationProvider
{
    Task<IReadOnlyCollection<ApplicationMenu>> GetAllAsync();
}
