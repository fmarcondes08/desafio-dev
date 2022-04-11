using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioDevBackEnd.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Signal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<long>(type: "bigint", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted_At = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<decimal>(type: "decimal", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Card = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted_At = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "Created_At", "Deleted_At", "Description", "Nature", "Signal", "Type", "Updated_At" },
                values: new object[,]
                {
                    { new Guid("dd70f5a9-a6f3-4684-939e-d33558db1550"), new DateTime(2022, 4, 10, 21, 54, 44, 670, DateTimeKind.Local).AddTicks(6270), null, "Débito", "Entrada", "+", 1L, new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4123) },
                    { new Guid("bb95ccac-5cd5-4872-ae1e-afa58ce7542b"), new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4816), null, "Boleto", "Saída", "-", 2L, new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4821) },
                    { new Guid("6cdb7ac0-52f1-4f11-8346-562cd6b0ea48"), new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4824), null, "Financiamento", "Saída", "-", 3L, new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4825) },
                    { new Guid("1fa0a2d6-bb96-4cac-a843-4bbe83e5ece6"), new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4827), null, "Crédito", "Entrada", "+", 4L, new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4828) },
                    { new Guid("d12fea30-27f1-4e2d-8563-f6019f96a1aa"), new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4831), null, "Recebimento Empréstimo", "Entrada", "+", 5L, new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4832) },
                    { new Guid("1d2a3d16-9e94-449f-ac41-890973457f95"), new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4834), null, "Vendas", "Entrada", "+", 6L, new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4835) },
                    { new Guid("9ffb2183-e3a3-4bf4-9af1-2e812145eb53"), new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4837), null, "Recebimento TED", "Entrada", "+", 7L, new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4837) },
                    { new Guid("2fc30eca-684d-4efa-8104-bfad420f4449"), new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4839), null, "Recebimento DOC", "Entrada", "+", 8L, new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4840) },
                    { new Guid("560a6c3e-a654-4cf1-a5c5-77383ba232f0"), new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4848), null, "Aluguel", "Saída", "+", 9L, new DateTime(2022, 4, 10, 21, 54, 44, 671, DateTimeKind.Local).AddTicks(4849) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTypes_Type",
                table: "TransactionTypes",
                column: "Type",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionTypes");
        }
    }
}
