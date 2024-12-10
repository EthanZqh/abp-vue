
using Microsoft.AspNetCore.Mvc;
using ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Data;
using ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Entities;
using ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Models;
using ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Models.PurchaseModels;

namespace ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Controllers;
//[ApiController]
//[Route("api/webhooks")]
//public class WebhookController(OnboardingDbContext dbContext) : Controller
//{
//    [HttpPost("run-task")]
//    public async Task<IActionResult> RunTask(WebhookEvent webhookEvent)
//    {
//        var payload = webhookEvent.Payload;
//        var taskPayload = payload.TaskPayload;
//        var employee = taskPayload.Employee;

//        var task = new OnboardingTask
//        {
//            ProcessId = payload.WorkflowInstanceId,
//            ExternalId = payload.TaskId,
//            Name = payload.TaskName,
//            Description = taskPayload.Description,
//            EmployeeEmail = employee.Email,
//            EmployeeName = employee.Name,
//            //CreatedAt = DateTimeOffset.Now
//            CreatedAt = DateTime.Now,
//            Roles = taskPayload.Role,
//            Users = "user1"
//        };

//        await dbContext.Tasks.AddAsync(task);
//        await dbContext.SaveChangesAsync();

//        return Ok();
//    }
//    [HttpPost("run-task2")]
//    public async Task<IActionResult> RunTask(WebhookEvent1 webhookEvent)
//    {
//        var payload = webhookEvent.Payload;
//        var taskPayload = payload.TaskPayload;
//        var purchase = taskPayload.Purchase;

//        var task = new PurchaseTask
//        {
//            ProcessId = payload.WorkflowInstanceId,
//            ExternalId = payload.TaskId,
//            Name = payload.TaskName,
//            Description = taskPayload.Description,
//            EmployeeDeptName = purchase.Dept,
//            EmployeeName = purchase.Name,
//            PurchaseName = purchase.PurchaseName,
//            CreatedAt = DateTime.Now
//        };

//        await dbContext.PurchaseTaskTasks.AddAsync(task);
//        await dbContext.SaveChangesAsync();
//        Console.WriteLine("adsfafdsfasdfsafdsafdd");

//        return Ok();
//    }
//    //[HttpPost("run-purchase-task")]
//    //public async Task<IActionResult> RunPurchaseTask(PurchaseWebhookEvent webhookEvent)
//    //{
//    //    var payload = webhookEvent.Payload;
//    //    var purchasetaskPayload = payload.PurchaseTaskPayload;
//    //    var purchase = purchasetaskPayload.Purchase;

//    //    var task = new PurchaseTask
//    //    {
//    //        ProcessId = payload.WorkflowInstanceId,
//    //        ExternalId = payload.TaskId,
//    //        Name = payload.TaskName,
//    //        Description = purchasetaskPayload.Description,
//    //        EmployeeDeptName = purchase.Dept,
//    //        EmployeeName = purchase.Name,
//    //        PurchaseName = purchase.PurchaseName,
//    //        //CreatedAt = DateTimeOffset.Now
//    //        CreatedAt = DateTime.Now
//    //    };

//    //    await dbContext.PurchaseTasks.AddAsync(task);
//    //    await dbContext.SaveChangesAsync();

//    //    return Ok();
//    //}
//    //[HttpPost("run-task")]
//    //public async Task<IActionResult> RunTask1(WebhookEvent webhookEvent)
//    //{
//    //var payload = webhookEvent.Payload;
//    //var taskPayload = payload.TaskPayload;
//    //var purchase = taskPayload.Purchase;

//    //var task = new PurchaseTask
//    //{
//    //    ProcessId = payload.WorkflowInstanceId,
//    //    ExternalId = payload.TaskId,
//    //    Name = payload.TaskName,
//    //    Description = taskPayload.Description,
//    //    EmployeeDeptName = purchase.Dept,
//    //    EmployeeName = purchase.Name,
//    //    PurchaseName = purchase.PurchaseName,
//    //    CreatedAt = DateTime.Now
//    //};

//    //await dbContext.PurchaseTaskTasks.AddAsync(task);
//    //await dbContext.SaveChangesAsync();
//    //    Console.WriteLine("bbbbbbbbbbbbbbbbbbbbbbbbbbb");

//    //    return Ok();
//    //}
//}
