using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventUber.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameToLowercase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Topics",
                newName: "topics");

            migrationBuilder.RenameTable(
                name: "Tenants",
                newName: "tenants");

            migrationBuilder.RenameTable(
                name: "Subscriptions",
                newName: "subscriptions");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "events");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "topics",
                newName: "tenantid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "topics",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "topics",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "topics",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "topics",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tenants",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "tenants",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tenants",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "subscriptions",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "subscriptions",
                newName: "topicid");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "subscriptions",
                newName: "tenantid");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "subscriptions",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "subscriptions",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "subscriptions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "events",
                newName: "topicid");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "events",
                newName: "tenantid");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "events",
                newName: "data");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "events",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "events",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_topics",
                table: "topics",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tenants",
                table: "tenants",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_subscriptions",
                table: "subscriptions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_events",
                table: "events",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_topics_tenantid",
                table: "topics",
                column: "tenantid");

            migrationBuilder.CreateIndex(
                name: "ix_subscriptions_tenantid",
                table: "subscriptions",
                column: "tenantid");

            migrationBuilder.CreateIndex(
                name: "ix_subscriptions_topicid",
                table: "subscriptions",
                column: "topicid");

            migrationBuilder.CreateIndex(
                name: "ix_events_tenantid",
                table: "events",
                column: "tenantid");

            migrationBuilder.CreateIndex(
                name: "ix_events_topicid",
                table: "events",
                column: "topicid");

            migrationBuilder.AddForeignKey(
                name: "fk_events_tenants_tenantid",
                table: "events",
                column: "tenantid",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_events_topics_topicid",
                table: "events",
                column: "topicid",
                principalTable: "topics",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_subscriptions_tenants_tenantid",
                table: "subscriptions",
                column: "tenantid",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_subscriptions_topics_topicid",
                table: "subscriptions",
                column: "topicid",
                principalTable: "topics",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_topics_tenants_tenantid",
                table: "topics",
                column: "tenantid",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_events_tenants_tenantid",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "fk_events_topics_topicid",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "fk_subscriptions_tenants_tenantid",
                table: "subscriptions");

            migrationBuilder.DropForeignKey(
                name: "fk_subscriptions_topics_topicid",
                table: "subscriptions");

            migrationBuilder.DropForeignKey(
                name: "fk_topics_tenants_tenantid",
                table: "topics");

            migrationBuilder.DropPrimaryKey(
                name: "pk_topics",
                table: "topics");

            migrationBuilder.DropIndex(
                name: "ix_topics_tenantid",
                table: "topics");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tenants",
                table: "tenants");

            migrationBuilder.DropPrimaryKey(
                name: "pk_subscriptions",
                table: "subscriptions");

            migrationBuilder.DropIndex(
                name: "ix_subscriptions_tenantid",
                table: "subscriptions");

            migrationBuilder.DropIndex(
                name: "ix_subscriptions_topicid",
                table: "subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_events",
                table: "events");

            migrationBuilder.DropIndex(
                name: "ix_events_tenantid",
                table: "events");

            migrationBuilder.DropIndex(
                name: "ix_events_topicid",
                table: "events");

            migrationBuilder.RenameTable(
                name: "topics",
                newName: "Topics");

            migrationBuilder.RenameTable(
                name: "tenants",
                newName: "Tenants");

            migrationBuilder.RenameTable(
                name: "subscriptions",
                newName: "Subscriptions");

            migrationBuilder.RenameTable(
                name: "events",
                newName: "Events");

            migrationBuilder.RenameColumn(
                name: "tenantid",
                table: "Topics",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Topics",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Topics",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Topics",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Topics",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Tenants",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Tenants",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tenants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Subscriptions",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "topicid",
                table: "Subscriptions",
                newName: "TopicId");

            migrationBuilder.RenameColumn(
                name: "tenantid",
                table: "Subscriptions",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "Subscriptions",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Subscriptions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Subscriptions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "topicid",
                table: "Events",
                newName: "TopicId");

            migrationBuilder.RenameColumn(
                name: "tenantid",
                table: "Events",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "data",
                table: "Events",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Events",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Events",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");
        }
    }
}
