using System.Threading.Tasks;

namespace ZQH.Abp.Localization.Persistence;

public interface IStaticLocalizationSaver
{
    Task SaveAsync();
}
