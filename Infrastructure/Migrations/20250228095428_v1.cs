using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "ACCOM_FACILITY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "ACCOM_USER_ROLE_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "ACCOM_USER_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "CONFIG_NOTI_STAY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "CONTRACT_NUMBER_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "DM_QUOC_TICH_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "GOVERNING_BODY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "NOTI_STAY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "NOTIFICATION_STAY_CUSTOMER_ACCOM_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "REASON_STAY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "REGIS_ACCOM_FACILITY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "REGIS_ACCOM_REPRESENTATIVE_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "REGIS_GOVERNING_BODY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "SCALE_TYPE_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "SEQ_DM_CHUC_VU_ID",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "SEQ_HOTEL_CONFIG",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateSequence(
                name: "SHR_CONTRACT_TYPE_SEQUENCE",
                schema: "DB_TEST_DEV");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "DB_TEST_DEV",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "DB_TEST_DEV",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoLists",
                schema: "DB_TEST_DEV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Title = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Colour_Code = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "DB_TEST_DEV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RoleId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "DB_TEST_DEV",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "DB_TEST_DEV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "DB_TEST_DEV",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "DB_TEST_DEV",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "DB_TEST_DEV",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "DB_TEST_DEV",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    RoleId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "DB_TEST_DEV",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "DB_TEST_DEV",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "DB_TEST_DEV",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "DB_TEST_DEV",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                schema: "DB_TEST_DEV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ListId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Note = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Priority = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Reminder = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Done = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoLists_ListId",
                        column: x => x.ListId,
                        principalSchema: "DB_TEST_DEV",
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "DB_TEST_DEV",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "DB_TEST_DEV",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "\"NormalizedName\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "DB_TEST_DEV",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "DB_TEST_DEV",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "DB_TEST_DEV",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "DB_TEST_DEV",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "DB_TEST_DEV",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "\"NormalizedUserName\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ListId",
                schema: "DB_TEST_DEV",
                table: "TodoItems",
                column: "ListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropTable(
                name: "TodoItems",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropTable(
                name: "TodoLists",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "ACCOM_FACILITY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "ACCOM_USER_ROLE_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "ACCOM_USER_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "CONFIG_NOTI_STAY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "CONTRACT_NUMBER_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "DM_QUOC_TICH_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "GOVERNING_BODY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "NOTI_STAY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "NOTIFICATION_STAY_CUSTOMER_ACCOM_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "REASON_STAY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "REGIS_ACCOM_FACILITY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "REGIS_ACCOM_REPRESENTATIVE_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "REGIS_GOVERNING_BODY_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "SCALE_TYPE_SEQ",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "SEQ_DM_CHUC_VU_ID",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "SEQ_HOTEL_CONFIG",
                schema: "DB_TEST_DEV");

            migrationBuilder.DropSequence(
                name: "SHR_CONTRACT_TYPE_SEQUENCE",
                schema: "DB_TEST_DEV");
        }
    }
}
