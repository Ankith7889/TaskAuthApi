using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskAuthApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskItemEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "TaskItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_AppUserId",
                table: "TaskItems",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_AspNetUsers_AppUserId",
                table: "TaskItems",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_AspNetUsers_AppUserId",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_AppUserId",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "TaskItems");
        }
    }
}
