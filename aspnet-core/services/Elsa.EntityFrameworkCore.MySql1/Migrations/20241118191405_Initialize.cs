﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elsa.EntityFrameworkCore.MySql.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Elsa");

            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ActivityExecutionRecords",
                schema: "Elsa",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkflowInstanceId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActivityId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActivityNodeId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActivityType = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActivityTypeVersion = table.Column<int>(type: "int", nullable: false),
                    ActivityName = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    HasBookmarks = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Status = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    SerializedActivityState = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerializedActivityStateCompressionAlgorithm = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerializedException = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerializedOutputs = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerializedPayload = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerializedProperties = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityExecutionRecords", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bookmarks",
                schema: "Elsa",
                columns: table => new
                {
                    BookmarkId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActivityTypeName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hash = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkflowInstanceId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActivityInstanceId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorrelationId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    SerializedMetadata = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerializedPayload = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmarks", x => x.BookmarkId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KeyValuePairs",
                schema: "Elsa",
                columns: table => new
                {
                    Key = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerializedValue = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyValuePairs", x => x.Key);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Triggers",
                schema: "Elsa",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkflowDefinitionId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkflowDefinitionVersionId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActivityId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hash = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerializedPayload = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triggers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkflowExecutionLogRecords",
                schema: "Elsa",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkflowDefinitionId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkflowDefinitionVersionId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkflowInstanceId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkflowVersion = table.Column<int>(type: "int", nullable: false),
                    ActivityInstanceId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentActivityInstanceId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActivityId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActivityType = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActivityTypeVersion = table.Column<int>(type: "int", nullable: false),
                    ActivityName = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActivityNodeId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Timestamp = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    Sequence = table.Column<long>(type: "bigint", nullable: false),
                    EventName = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Source = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerializedActivityState = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerializedPayload = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowExecutionLogRecords", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkflowInboxMessages",
                schema: "Elsa",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActivityTypeName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hash = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkflowInstanceId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorrelationId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActivityInstanceId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    ExpiresAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    SerializedBookmarkPayload = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerializedInput = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInboxMessages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityExecutionRecord_ActivityId",
                schema: "Elsa",
                table: "ActivityExecutionRecords",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityExecutionRecord_ActivityName",
                schema: "Elsa",
                table: "ActivityExecutionRecords",
                column: "ActivityName");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityExecutionRecord_ActivityNodeId",
                schema: "Elsa",
                table: "ActivityExecutionRecords",
                column: "ActivityNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityExecutionRecord_ActivityType",
                schema: "Elsa",
                table: "ActivityExecutionRecords",
                column: "ActivityType");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityExecutionRecord_ActivityType_ActivityTypeVersion",
                schema: "Elsa",
                table: "ActivityExecutionRecords",
                columns: new[] { "ActivityType", "ActivityTypeVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityExecutionRecord_ActivityTypeVersion",
                schema: "Elsa",
                table: "ActivityExecutionRecords",
                column: "ActivityTypeVersion");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityExecutionRecord_CompletedAt",
                schema: "Elsa",
                table: "ActivityExecutionRecords",
                column: "CompletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityExecutionRecord_HasBookmarks",
                schema: "Elsa",
                table: "ActivityExecutionRecords",
                column: "HasBookmarks");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityExecutionRecord_StartedAt",
                schema: "Elsa",
                table: "ActivityExecutionRecords",
                column: "StartedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityExecutionRecord_Status",
                schema: "Elsa",
                table: "ActivityExecutionRecords",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityExecutionRecord_WorkflowInstanceId",
                schema: "Elsa",
                table: "ActivityExecutionRecords",
                column: "WorkflowInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredBookmark_ActivityInstanceId",
                schema: "Elsa",
                table: "Bookmarks",
                column: "ActivityInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredBookmark_ActivityTypeName",
                schema: "Elsa",
                table: "Bookmarks",
                column: "ActivityTypeName");

            migrationBuilder.CreateIndex(
                name: "IX_StoredBookmark_ActivityTypeName_Hash",
                schema: "Elsa",
                table: "Bookmarks",
                columns: new[] { "ActivityTypeName", "Hash" });

            migrationBuilder.CreateIndex(
                name: "IX_StoredBookmark_ActivityTypeName_Hash_WorkflowInstanceId",
                schema: "Elsa",
                table: "Bookmarks",
                columns: new[] { "ActivityTypeName", "Hash", "WorkflowInstanceId" });

            migrationBuilder.CreateIndex(
                name: "IX_StoredBookmark_CreatedAt",
                schema: "Elsa",
                table: "Bookmarks",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StoredBookmark_Hash",
                schema: "Elsa",
                table: "Bookmarks",
                column: "Hash");

            migrationBuilder.CreateIndex(
                name: "IX_StoredBookmark_WorkflowInstanceId",
                schema: "Elsa",
                table: "Bookmarks",
                column: "WorkflowInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredTrigger_Hash",
                schema: "Elsa",
                table: "Triggers",
                column: "Hash");

            migrationBuilder.CreateIndex(
                name: "IX_StoredTrigger_Name",
                schema: "Elsa",
                table: "Triggers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_StoredTrigger_WorkflowDefinitionId",
                schema: "Elsa",
                table: "Triggers",
                column: "WorkflowDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredTrigger_WorkflowDefinitionVersionId",
                schema: "Elsa",
                table: "Triggers",
                column: "WorkflowDefinitionVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_ActivityId",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_ActivityInstanceId",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "ActivityInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_ActivityName",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "ActivityName");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_ActivityNodeId",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "ActivityNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_ActivityType",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "ActivityType");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_ActivityType_ActivityTypeVersion",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                columns: new[] { "ActivityType", "ActivityTypeVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_ActivityTypeVersion",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "ActivityTypeVersion");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_EventName",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "EventName");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_ParentActivityInstanceId",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "ParentActivityInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_Sequence",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "Sequence");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_Timestamp",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_Timestamp_Sequence",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                columns: new[] { "Timestamp", "Sequence" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_WorkflowDefinitionId",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "WorkflowDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_WorkflowDefinitionVersionId",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "WorkflowDefinitionVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_WorkflowInstanceId",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "WorkflowInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionLogRecord_WorkflowVersion",
                schema: "Elsa",
                table: "WorkflowExecutionLogRecords",
                column: "WorkflowVersion");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInboxMessage_ActivityInstanceId",
                schema: "Elsa",
                table: "WorkflowInboxMessages",
                column: "ActivityInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInboxMessage_ActivityTypeName",
                schema: "Elsa",
                table: "WorkflowInboxMessages",
                column: "ActivityTypeName");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInboxMessage_CorrelationId",
                schema: "Elsa",
                table: "WorkflowInboxMessages",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInboxMessage_CreatedAt",
                schema: "Elsa",
                table: "WorkflowInboxMessages",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInboxMessage_ExpiresAt",
                schema: "Elsa",
                table: "WorkflowInboxMessages",
                column: "ExpiresAt");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInboxMessage_Hash",
                schema: "Elsa",
                table: "WorkflowInboxMessages",
                column: "Hash");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInboxMessage_WorkflowInstanceId",
                schema: "Elsa",
                table: "WorkflowInboxMessages",
                column: "WorkflowInstanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityExecutionRecords",
                schema: "Elsa");

            migrationBuilder.DropTable(
                name: "Bookmarks",
                schema: "Elsa");

            migrationBuilder.DropTable(
                name: "KeyValuePairs",
                schema: "Elsa");

            migrationBuilder.DropTable(
                name: "Triggers",
                schema: "Elsa");

            migrationBuilder.DropTable(
                name: "WorkflowExecutionLogRecords",
                schema: "Elsa");

            migrationBuilder.DropTable(
                name: "WorkflowInboxMessages",
                schema: "Elsa");
        }
    }
}
