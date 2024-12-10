﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ZQH.Abp.LocalizationManagement.EntityFrameworkCore;

[ConnectionStringName(LocalizationDbProperties.ConnectionStringName)]
public interface ILocalizationDbContext : IEfCoreDbContext
{
    DbSet<Resource> Resources { get; }
    DbSet<Language> Languages { get; }
    DbSet<Text> Texts { get; }
}
