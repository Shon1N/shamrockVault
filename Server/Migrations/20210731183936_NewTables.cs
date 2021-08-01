using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ShamrockVault.Server.Migrations
{
    public partial class NewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageType",
                columns: table => new
                {
                    MessageTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MessageTypeName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageType", x => x.MessageTypeId);
                });

            migrationBuilder.CreateTable(
            name: "Message",
            columns: table => new
            {
                MessageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                MessageText = table.Column<string>(type: "nvarchar(1024)", maxLength: 256, nullable: true),
                MessageTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                MessageName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                MessageLocation = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                CreationTime = table.Column<DateTime>(type: "datetime", nullable: false),
                MessageLifeInSeconds = table.Column<int>(type: "int", nullable: false),
                MessageReceiptCount = table.Column<int>(type: "int", nullable: false),
                UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Message", x => x.MessageId);
                table.ForeignKey(
                    name: "FK_Message_MessageTypeId",
                    column: x => x.MessageTypeId,
                    principalTable: "MessageType",
                    principalColumn: "MessageTypeId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Message_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
            });

            migrationBuilder.CreateTable(
            name: "MessageReceipt",
            columns: table => new
            {
                MessageReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                MessageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                MessageReceived = table.Column<bool>(type: "bit", nullable: false),
                UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MessageReceipt", x => x.MessageId);
                table.ForeignKey(
                   name: "FK_MessageReceipt_MessageId",
                   column: x => x.MessageId,
                   principalTable: "Message",
                   principalColumn: "MessageId",
                   onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_MessageReceipt_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
