using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectMapping;
using ZQH.Abp.Onboarding;
using ZQH.Abp.Onboarding.Definitions.Dto;
using ZQH.Abp.Onboarding.Models;
using ZQH.Abp.Onboarding.Services;
using ZQH.Abp.Onboarding.Localization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ZQH.Abp.Onboarding.Entities;

namespace ZQH.Abp.Onboarding;
public class OnboardingAppService : OnboardingApplicationServiceBase, IOnboardingAppService
{
    protected IOnboardingRepository OnboardingRepository { get; }
    protected ElsaClient OlsaClient { get; }

    public OnboardingAppService(
        IOnboardingRepository onboardingRepository, ElsaClient elsaClient)
    {
        OnboardingRepository = onboardingRepository;
        OlsaClient = elsaClient;
        LocalizationResource = typeof(AbpOnboardingResource);
    }


    public async Task<ListResultDto<OnboardingTaskDto>> GetListAsync(OnboardingGetListInput input)
    {
        var count = await OnboardingRepository.GetCountAsync(input.Filter);

        var list = await OnboardingRepository.GetPagedListAsync(
            input.Filter, input.Sorting,
            false, input.SkipCount, input.MaxResultCount);
        return new PagedResultDto<OnboardingTaskDto>(
        count,
            ObjectMapper.Map<List<OnboardingTask>, List<OnboardingTaskDto>>(list)
        );
    }

    public async virtual Task<OnboardingTaskDto> CreateAsync(WebhookEvent webhookEvent)
    {
        Console.WriteLine("aaaaaaaaaaaaaaaaaaaaa");
        var payload = webhookEvent.Payload;
        var taskPayload = payload.TaskPayload;
        var employee = taskPayload.Employee;

        var task = new OnboardingTask
        {
            ProcessId = payload.WorkflowInstanceId,
            ExternalId = payload.TaskId,
            Name = payload.TaskName,
            Description = taskPayload.Description,
            EmployeeEmail = employee.Email,
            EmployeeName = employee.Name,
            //CreatedAt = DateTimeOffset.Now
            CreatedAt = DateTime.Now,
            Roles = taskPayload.Role,
            Users = "user1"
        };

        //await dbContext.Tasks.AddAsync(task);
        //await dbContext.SaveChangesAsync();

        //return Ok();

        //var data = await DataRepository.FindByNameAsync(input.Name);
        //if (data != null)
        //{
        //    throw new UserFriendlyException(L["DuplicateData", input.Name]);
        //}

        //string code = string.Empty;
        //var children = await DataRepository.GetChildrenAsync(input.ParentId);
        //if (children.Any())
        //{
        //    var lastChildren = children.OrderBy(x => x.Code).FirstOrDefault();
        //    code = CodeNumberGenerator.CalculateNextCode(lastChildren.Code);
        //}
        //else
        //{
        //    var parentData = input.ParentId != null
        //    ? await DataRepository.GetAsync(input.ParentId.Value)
        //    : null;

        //    code = CodeNumberGenerator.AppendCode(parentData?.Code, CodeNumberGenerator.CreateCode(1));
        //}

        //data = new Data(
        //    GuidGenerator.Create(),
        //    input.Name,
        //    code,
        //    input.DisplayName,
        //    input.Description,
        //    input.ParentId,
        //    CurrentTenant.Id
        //    );

        task = await OnboardingRepository.InsertAsync(task);
        await CurrentUnitOfWork.SaveChangesAsync();

        return ObjectMapper.Map<OnboardingTask, OnboardingTaskDto>(task);




    }

    public async Task<OnboardingTaskDto> CompleteTaskAsync(Guid taskId,CancellationToken cancellationToken)
    {
        var task = await OnboardingRepository.FindById(taskId);

        if (task == null)
            return null;

        await OlsaClient.ReportTaskCompletedAsync(task.ExternalId, cancellationToken: cancellationToken);

        task.IsCompleted = true;
        //task.CompletedAt = DateTimeOffset.Now;
        task.CompletedAt = DateTime.Now;

        task = await OnboardingRepository.UpdateAsync(task);
        await CurrentUnitOfWork.SaveChangesAsync();

        return ObjectMapper.Map<OnboardingTask, OnboardingTaskDto>(task);
    }
}
