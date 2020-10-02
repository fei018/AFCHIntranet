using Microsoft.EntityFrameworkCore.Migrations;

namespace AFCHIntranet.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Elder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 5, nullable: false),
                    Sex = table.Column<string>(maxLength: 2, nullable: false),
                    Identity = table.Column<string>(maxLength: 18, nullable: false),
                    Marital = table.Column<string>(maxLength: 5, nullable: false),
                    Phone = table.Column<string>(maxLength: 11, nullable: true),
                    MinZu = table.Column<string>(maxLength: 5, nullable: true),
                    JiGuan = table.Column<string>(maxLength: 10, nullable: true),
                    IDAddress = table.Column<string>(maxLength: 40, nullable: false),
                    HomeAddress = table.Column<string>(maxLength: 40, nullable: false),
                    Faith = table.Column<string>(maxLength: 5, nullable: true),
                    Remark = table.Column<string>(maxLength: 100, nullable: true),
                    NursingGrade = table.Column<string>(maxLength: 4, nullable: false),
                    RomNumber = table.Column<string>(maxLength: 3, nullable: false),
                    LiveState = table.Column<string>(maxLength: 4, nullable: false),
                    PettyCash = table.Column<string>(maxLength: 10, nullable: true),
                    ExperienceStartDate = table.Column<string>(maxLength: 10, nullable: true),
                    ContractStartDate = table.Column<string>(maxLength: 10, nullable: true),
                    ContractTerm = table.Column<string>(nullable: true),
                    LeftDate = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Elder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ElderFamily",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 5, nullable: false),
                    Sex = table.Column<string>(maxLength: 2, nullable: false),
                    Phone = table.Column<string>(maxLength: 11, nullable: false),
                    Relationship = table.Column<string>(maxLength: 5, nullable: false),
                    Identity = table.Column<string>(maxLength: 18, nullable: false),
                    HomeAddress = table.Column<string>(maxLength: 40, nullable: false),
                    ElderIdentity = table.Column<string>(maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ElderFamily", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_LoginUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    Password = table.Column<string>(maxLength: 10, nullable: false),
                    RoleName = table.Column<string>(maxLength: 20, nullable: true),
                    LoginErrorCount = table.Column<int>(nullable: false),
                    AccountLocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_LoginUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Staff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 5, nullable: false),
                    Sex = table.Column<string>(maxLength: 2, nullable: false),
                    Identity = table.Column<string>(maxLength: 18, nullable: false),
                    Marital = table.Column<string>(maxLength: 5, nullable: false),
                    Phone = table.Column<string>(maxLength: 11, nullable: false),
                    MinZu = table.Column<string>(maxLength: 5, nullable: true),
                    JiGuan = table.Column<string>(maxLength: 10, nullable: true),
                    IDAddress = table.Column<string>(maxLength: 40, nullable: false),
                    HomeAddress = table.Column<string>(maxLength: 40, nullable: true),
                    Remark = table.Column<string>(maxLength: 100, nullable: true),
                    PositionState = table.Column<string>(maxLength: 2, nullable: false),
                    WorkStartDate = table.Column<string>(maxLength: 10, nullable: false),
                    ContractStartDate = table.Column<string>(maxLength: 10, nullable: true),
                    ContractTerm = table.Column<string>(nullable: true),
                    Education = table.Column<string>(maxLength: 3, nullable: true),
                    Skill = table.Column<string>(maxLength: 10, nullable: true),
                    RomNumber = table.Column<string>(maxLength: 3, nullable: true),
                    Department = table.Column<string>(maxLength: 3, nullable: false),
                    LeftDate = table.Column<string>(maxLength: 10, nullable: true),
                    FamilyName = table.Column<string>(maxLength: 5, nullable: false),
                    FamilyPhone = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Staff", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Elder");

            migrationBuilder.DropTable(
                name: "Tbl_ElderFamily");

            migrationBuilder.DropTable(
                name: "Tbl_LoginUser");

            migrationBuilder.DropTable(
                name: "Tbl_Staff");
        }
    }
}
