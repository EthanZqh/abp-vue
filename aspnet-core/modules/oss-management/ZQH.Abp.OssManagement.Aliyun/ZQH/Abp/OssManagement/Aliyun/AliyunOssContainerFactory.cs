﻿using ZQH.Abp.BlobStoring.Aliyun;
using Volo.Abp.MultiTenancy;

namespace ZQH.Abp.OssManagement.Aliyun;

public class AliyunOssContainerFactory : IOssContainerFactory
{
    protected ICurrentTenant CurrentTenant { get; }
    protected IOssClientFactory OssClientFactory { get; }

    public AliyunOssContainerFactory(
        ICurrentTenant currentTenant,
        IOssClientFactory ossClientFactory)
    {
        CurrentTenant = currentTenant;
        OssClientFactory = ossClientFactory;
    }

    public IOssContainer Create()
    {
        return new AliyunOssContainer(
            CurrentTenant,
            OssClientFactory);
    }
}
