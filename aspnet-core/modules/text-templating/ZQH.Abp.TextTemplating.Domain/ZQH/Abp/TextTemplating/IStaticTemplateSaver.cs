using System.Threading.Tasks;

namespace ZQH.Abp.TextTemplating;
public interface IStaticTemplateSaver
{
    Task SaveDefinitionTemplateAsync();

    Task SaveTemplateContentAsync();
}
