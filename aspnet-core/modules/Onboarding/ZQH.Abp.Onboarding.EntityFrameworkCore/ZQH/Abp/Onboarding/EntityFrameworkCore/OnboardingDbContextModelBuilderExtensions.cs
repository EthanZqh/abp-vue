using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using ZQH.Abp.Onboarding;
using ZQH.Abp.Onboarding.Entities;
using ZQH.Abp.Onboarding.EntityFrameworkCore;

namespace ZQH.Platform.EntityFrameworkCore;

public static class OnboardingDbContextModelBuilderExtensions
{
    public static void ConfigureOnboarding(
       this ModelBuilder builder,
       Action<OnboardingModelBuilderConfigurationOptions> optionsAction = null)
    {
        Check.NotNull(builder, nameof(builder));

        var options = new OnboardingModelBuilderConfigurationOptions(
            AbpOnboardingDbProperties.DbTablePrefix,
            AbpOnboardingDbProperties.DbSchema
        );

        optionsAction?.Invoke(options);

        builder.Entity<OnboardingTask>(b =>
        {
            b.ToTable(options.TablePrefix + "OnboardingTasks", options.Schema);

            //b.Property(p => p.Framework)
            //    .HasMaxLength(LayoutConsts.MaxFrameworkLength)
            //    .HasColumnName(nameof(Layout.Framework))
            //    .IsRequired();

            b.ConfigureByConvention();
        });

    }



}
