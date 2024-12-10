using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ProductManagement
{
    public class ProductGetByPagedInputDto: PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
