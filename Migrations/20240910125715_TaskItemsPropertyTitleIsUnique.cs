using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListMvc.Migrations
{
    /// <inheritdoc />
    public partial class TaskItemsPropertyTitleIsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_Title",
                table: "TaskItems",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaskItems_Title",
                table: "TaskItems");
        }
    }
}
