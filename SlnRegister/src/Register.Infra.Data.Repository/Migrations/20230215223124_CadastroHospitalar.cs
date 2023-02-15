using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Register.Infra.Data.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CadastroHospitalar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionId = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    MRNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CRM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Critical" },
                    { 2, "Serious" },
                    { 3, "Fair" },
                    { 4, "Good" },
                    { 5, "Undetermined" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "BirthDate", "CPF", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "123.456.789-12", 2, "Maria Clara de Souza" },
                    { 2, new DateTime(2000, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "789.456.123-78", 1, "Paulo Moreira" },
                    { 3, new DateTime(2000, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "753.159.456-58", 2, "Rafaella Rodrigues da Silva" },
                    { 4, new DateTime(2000, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "951.357.321-56", 1, "João de Oliveira" },
                    { 5, new DateTime(2000, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "741.852.963-37", 2, "Clara Maria Moretti" },
                    { 6, new DateTime(2000, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "963.852.741-15", 1, "Ricardo Alves de Souza" },
                    { 7, new DateTime(2000, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "248.862.176-49", 2, "Helena Muller" },
                    { 8, new DateTime(2000, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "154.268.729-16", 1, "Gabriel Bugmann Vanzuita" },
                    { 9, new DateTime(2000, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "217.369.252-98", 2, "Laura Elena Fisher" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pediatric" },
                    { 2, "Cardiology" },
                    { 3, "Dermatology" },
                    { 4, "Gastroenterology" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "District", "Number", "PersonId", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Blumenau", "SC", "123", 1, "89012-412", "Rua Curitiba" },
                    { 2, "Blumenau", "SC", "453", 2, "89051-260", "Rua Pedro Francisco Cordeiro" },
                    { 3, "Blumenau", "SC", "1963", 3, "89051-170", "Rua Caiena" },
                    { 4, "Blumenau", "SC", "2587", 4, "89046-636", "Rua Áustria" },
                    { 5, "Blumenau", "SC", "8746", 5, "89027-351", "Rua Bruno Hort" },
                    { 6, "Blumenau", "SC", "7895", 6, "89022-275", "Rua Turvo" },
                    { 7, "Blumenau", "SC", "753", 7, "89095-510", "Rua Otto Manzke" },
                    { 8, "Blumenau", "SC", "951", 8, "89057-496", "Rua Augusto Setter" },
                    { 9, "Blumenau", "SC", "852", 9, "89095-525", "Rua Três Primos" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CNPJ", "CRM", "PersonId", "SpecialtyId" },
                values: new object[,]
                {
                    { 1, "12.234.567/0001-89", "CRM/SP 123456", 4, 4 },
                    { 2, "56.741.963/0001-42", "CRM/SC 456983", 5, 1 },
                    { 3, "89.466.123/0001-26", "CRM/RS 123147", 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "ConditionId", "MRNumber", "PersonId" },
                values: new object[,]
                {
                    { 1, 3, 1, 1 },
                    { 2, 3, 2, 2 },
                    { 3, 1, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonId",
                table: "Address",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PersonId",
                table: "Doctors",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ConditionId",
                table: "Patients",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PersonId",
                table: "Patients",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
