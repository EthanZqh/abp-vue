using System.Threading.Tasks;

namespace ZQH.Abp.Cli.Commands
{
    public interface ICreateProjectService
    {
        Task CreateAsync(ProjectCreateArgs createArgs);
    }
}
