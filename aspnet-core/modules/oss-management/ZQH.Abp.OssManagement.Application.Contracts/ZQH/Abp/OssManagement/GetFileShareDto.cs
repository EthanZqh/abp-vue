﻿using System.IO;

namespace ZQH.Abp.OssManagement;

public class GetFileShareDto
{
    public string Name { get; set; }
    public Stream Content { get; set; }
    public GetFileShareDto(
        string name,
        Stream content = null)
    {
        Name = name;
        Content = content ?? Stream.Null;
    }
}
