using System.Collections.Generic;

namespace ZQH.Abp.UI.Navigation;

public interface INavigationDefinitionManager
{
    IReadOnlyList<NavigationDefinition> GetAll();
}
