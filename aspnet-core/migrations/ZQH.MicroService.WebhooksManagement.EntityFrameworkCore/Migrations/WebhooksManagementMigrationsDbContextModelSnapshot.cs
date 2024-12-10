﻿// <auto-generated />
using System;
using ZQH.MicroService.WebhooksManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore;

#nullable disable

namespace ZQH.MicroService.WebhooksManagement.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(WebhooksManagementMigrationsDbContext))]
    partial class WebhooksManagementMigrationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.MySql)
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LINGYUN.Abp.WebhooksManagement.WebhookDefinitionRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("longtext")
                        .HasColumnName("ExtraProperties");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("RequiredFeatures")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("GroupName");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("AbpWebhooksWebhooks", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WebhooksManagement.WebhookEventRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<string>("Data")
                        .HasMaxLength(2147483647)
                        .HasColumnType("longtext")
                        .HasColumnName("Data");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DeletionTime");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)");

                    b.Property<string>("WebhookName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("WebhookName");

                    b.HasKey("Id");

                    b.ToTable("AbpWebhooksEvents", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WebhooksManagement.WebhookGroupDefinitionRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("longtext")
                        .HasColumnName("ExtraProperties");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("AbpWebhooksWebhookGroups", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WebhooksManagement.WebhookSendRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<string>("RequestHeaders")
                        .HasMaxLength(2147483647)
                        .HasColumnType("longtext")
                        .HasColumnName("RequestHeaders");

                    b.Property<string>("Response")
                        .HasMaxLength(2147483647)
                        .HasColumnType("longtext")
                        .HasColumnName("Response");

                    b.Property<string>("ResponseHeaders")
                        .HasMaxLength(2147483647)
                        .HasColumnType("longtext")
                        .HasColumnName("ResponseHeaders");

                    b.Property<int?>("ResponseStatusCode")
                        .HasColumnType("int");

                    b.Property<bool>("SendExactSameData")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("WebhookEventId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("WebhookSubscriptionId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("WebhookEventId");

                    b.ToTable("AbpWebhooksSendAttempts", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WebhooksManagement.WebhookSubscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CreatorId");

                    b.Property<string>("Description")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("Description");

                    b.Property<string>("Headers")
                        .HasMaxLength(2147483647)
                        .HasColumnType("longtext")
                        .HasColumnName("Headers");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Secret")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("Secret");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("TimeoutDuration")
                        .HasColumnType("int");

                    b.Property<string>("WebhookUri")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("WebhookUri");

                    b.Property<string>("Webhooks")
                        .HasMaxLength(2147483647)
                        .HasColumnType("longtext")
                        .HasColumnName("Webhooks");

                    b.HasKey("Id");

                    b.ToTable("AbpWebhooksSubscriptions", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WebhooksManagement.WebhookSendRecord", b =>
                {
                    b.HasOne("LINGYUN.Abp.WebhooksManagement.WebhookEventRecord", "WebhookEvent")
                        .WithOne()
                        .HasForeignKey("LINGYUN.Abp.WebhooksManagement.WebhookSendRecord", "WebhookEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WebhookEvent");
                });
#pragma warning restore 612, 618
        }
    }
}
