using System;

namespace ZQH.Platform.Datas;

public class DataCreateDto : DataCreateOrUpdateDto
{
    public Guid? ParentId { get; set; }
}
