namespace ZQH.Abp.UI.Navigation;

public interface INavigationDefinitionContext
{
    void Add(params NavigationDefinition[] definitions);
}
