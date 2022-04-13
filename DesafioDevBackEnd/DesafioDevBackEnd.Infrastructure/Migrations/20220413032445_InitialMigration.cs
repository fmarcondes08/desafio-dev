using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioDevBackEnd.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
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
                    { new Guid("086f2ed5-ec23-46a2-9f27-185e29a33c0c"), new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(2177), null, "Débito", "Entrada", "+", 1L, new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8109) },
                    { new Guid("6d2a5ca3-fd68-42ec-8c4b-4e615fd65525"), new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8806), null, "Boleto", "Saída", "-", 2L, new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8810) },
                    { new Guid("b7654cdb-f97b-434f-88f1-3b0620965f4b"), new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8814), null, "Financiamento", "Saída", "-", 3L, new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8815) },
                    { new Guid("6a81195c-cd3d-4f4c-ae87-1075a3eaec19"), new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8817), null, "Crédito", "Entrada", "+", 4L, new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8817) },
                    { new Guid("df6a1dc1-19d1-40a0-8df5-d89ef69c58d3"), new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8820), null, "Recebimento Empréstimo", "Entrada", "+", 5L, new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8821) },
                    { new Guid("d2ea9a29-c590-4ed0-b403-a73b6bacfce0"), new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8823), null, "Vendas", "Entrada", "+", 6L, new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8823) },
                    { new Guid("5af6be11-88df-41c8-97bb-9a9c43a95feb"), new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8825), null, "Recebimento TED", "Entrada", "+", 7L, new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8826) },
                    { new Guid("6f0f7b2d-c515-4420-be46-b0b5a9e73c67"), new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8834), null, "Recebimento DOC", "Entrada", "+", 8L, new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8835) },
                    { new Guid("3f778df6-45e7-458f-bb2f-51cb46089182"), new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8837), null, "Aluguel", "Saída", "+", 9L, new DateTime(2022, 4, 13, 0, 24, 44, 654, DateTimeKind.Local).AddTicks(8838) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId");

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
