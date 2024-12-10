using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;
using ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Data;
using ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Entities;

namespace ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Controllers;

//[ApiController]
//[Route("api/onboarding")]
//public class OnboardingController(OnboardingDbContext dbContext, ElsaClient elsaClient) : ApplicationService
//{
//    //public IActionResult Index()
//    //{
//    //    return View();
//    //}
//    //public async Task<IActionResult> Index(CancellationToken cancellationToken)
//    //{
//    //    var tasks = await dbContext.Tasks.Where(x => !x.IsCompleted).ToListAsync(cancellationToken: cancellationToken);
//    //    var model = new IndexViewModel(tasks);
//    //    return View(model);
//    //}
//    [HttpGet]
//    public async virtual Task<PagedResultDto<OnboardingTaskDto>> GetListAsync(OnboardingGetListInput input, CancellationToken cancellationToken)
//    {
//        var tasks = await dbContext.Tasks.Where(x => !x.IsCompleted).ToListAsync(cancellationToken: cancellationToken);

//        //var count = await TenantRepository.GetCountAsync(input.Filter);
//        var count = 2;
//        //var list = await TenantRepository.GetListAsync(
//        //    input.Sorting,
//        //    input.MaxResultCount,
//        //    input.SkipCount,
//        //    input.Filter
//        //);

//        return new PagedResultDto<OnboardingTaskDto>(
//        count,
//            ObjectMapper.Map<List<OnboardingTask>, List<OnboardingTaskDto>>(tasks)
//        );


//        //return await DataAppService.GetListAsync(input);
//    }

//}
