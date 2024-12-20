using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.Identity.Dto.EmployeeDto;
public class EmployeeGetByPagedDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
