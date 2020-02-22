using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetCoreXunit.Migrations
{
    public partial class new_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "value_property",
                columns: table => new
                {
                    value_property_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    group = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    value_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_value_property", x => x.value_property_id);
                    table.ForeignKey(
                        name: "fk_value_property_value_value_id",
                        column: x => x.value_id,
                        principalTable: "value",
                        principalColumn: "value_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_value_property_value_id",
                table: "value_property",
                column: "value_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "value_property");
        }
    }
}
