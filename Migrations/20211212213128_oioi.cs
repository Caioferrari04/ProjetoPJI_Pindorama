using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class oioi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Imagens",
                columns: new[] { "Id", "GameId", "LinkImagem" },
                values: new object[,]
                {
                    { 4, 2, "https://cdn.cloudflare.steamstatic.com/steam/apps/870780/ss_8376498631b089e52fb5c75ffe119e0de5e6aed1.600x338.jpg?t=1636733774" },
                    { 33, 11, "https://cdn.cloudflare.steamstatic.com/steam/apps/1238840/ss_2aac0cbea68f0ac82154ca627e2e991fc65c9ede.600x338.jpg?t=1633006806" },
                    { 34, 12, "https://cdn.cloudflare.steamstatic.com/steam/apps/1063730/ss_32b377faf983064af7638e858e1bfa7c845c9e2f.600x338.jpg?t=1637255211" },
                    { 35, 12, "https://cdn.cloudflare.steamstatic.com/steam/apps/1063730/ss_84bc9909c2dfc8ec0d4ff84fd072b35785332fdc.600x338.jpg?t=1637255211" },
                    { 36, 12, "https://cdn.cloudflare.steamstatic.com/steam/apps/1063730/ss_ceeb983fca848dc3ec1ce88efcbf85cce6f00489.600x338.jpg?t=1637255211" },
                    { 37, 13, "https://cdn.cloudflare.steamstatic.com/steam/apps/570/ss_86d675fdc73ba10462abb8f5ece7791c5047072c.600x338.jpg?t=1635466719" },
                    { 38, 13, "https://cdn.cloudflare.steamstatic.com/steam/apps/570/ss_27b6345f22243bd6b885cc64c5cda74e4bd9c3e8.600x338.jpg?t=1635466719" },
                    { 39, 13, "https://cdn.cloudflare.steamstatic.com/steam/apps/570/ss_e0a92f15a6631a8186df79182d0fe28b5e37d8cb.600x338.jpg?t=1635466719" },
                    { 40, 14, "https://cdn.cloudflare.steamstatic.com/steam/apps/790710/ss_f92678cc1967a70f441be2816cdbde719678edd9.600x338.jpg?t=1635932497" },
                    { 41, 14, "https://cdn.cloudflare.steamstatic.com/steam/apps/790710/ss_f3bbaf14a952779d700663954be180fbc490748a.600x338.jpg?t=1635932497" },
                    { 42, 14, "https://cdn.cloudflare.steamstatic.com/steam/apps/790710/ss_6a6b54e02fe5016b6027d1e35d28a4776e8f5287.600x338.jpg?t=1635932497" },
                    { 43, 15, "https://cdn.cloudflare.steamstatic.com/steam/apps/767560/ss_a1428f997d3eafe171fc578ed2f83093c14ec88c.600x338.jpg?t=1638264226" },
                    { 32, 11, "https://cdn.cloudflare.steamstatic.com/steam/apps/1238840/ss_432fba694d3dfdab325ddf83cbb355545a4554c6.600x338.jpg?t=1633006806" },
                    { 44, 15, "https://cdn.cloudflare.steamstatic.com/steam/apps/767560/ss_1352d9effbd99f47dc64e046eb54588188d7b10d.600x338.jpg?t=1638264226" },
                    { 46, 16, "https://cdn.cloudflare.steamstatic.com/steam/apps/238960/ss_984ea348b3c7d9495ad177b1c7530a3cb7e6ff0f.600x338.jpg?t=1635819685" },
                    { 47, 16, "https://cdn.cloudflare.steamstatic.com/steam/apps/238960/ss_40fa77890c74dd962fd665fa17440cc87003456e.600x338.jpg?t=1635819685" },
                    { 48, 16, "https://cdn.cloudflare.steamstatic.com/steam/apps/238960/ss_f50b319eb3cd8c88acb2cc0359359d656ae06624.600x338.jpg?t=1635819685" },
                    { 49, 17, "https://cdn.cloudflare.steamstatic.com/steam/apps/291480/ss_f4ffe6c0f8a9c14c1dac007f31c51d7a240f0262.600x338.jpg?t=1639068783" },
                    { 50, 17, "https://cdn.cloudflare.steamstatic.com/steam/apps/291480/ss_6fef3cf98354f3b592a49a5d82e4de3be0ab8074.600x338.jpg?t=1639068783" },
                    { 51, 17, "https://cdn.cloudflare.steamstatic.com/steam/apps/291480/ss_61215b055625fae5aed3356a0aeab8b19deee925.600x338.jpg?t=1639068783" },
                    { 52, 18, "https://cdn.cloudflare.steamstatic.com/steam/apps/109600/ss_4cebfb468c713e5126c95479c30866fff975bfaf.600x338.jpg?t=1636736301" },
                    { 53, 19, "https://cdn.cloudflare.steamstatic.com/steam/apps/109600/ss_a704890424b434a66d93bd73af1a3e616cca834a.600x338.jpg?t=1636736301" },
                    { 54, 19, "https://cdn.cloudflare.steamstatic.com/steam/apps/109600/ss_f7c2a3639d782aec69c6d8d075177de7fe291441.600x338.jpg?t=1636736301" },
                    { 55, 19, "https://cdn.cloudflare.steamstatic.com/steam/apps/109600/ss_95fa23b07c9bca7ba1cf6941cf169c3df822b6bd.600x338.jpg?t=1636736301" },
                    { 56, 20, "https://cdn.cloudflare.steamstatic.com/steam/apps/1259970/ss_05b5733f8fc79533ffe773dfb628c1995d10af00.600x338.jpg?t=1639008061" },
                    { 45, 15, "https://cdn.cloudflare.steamstatic.com/steam/apps/767560/ss_f7e2c410a823139e4206d42760cf907e10b1c9f5.600x338.jpg?t=1638264226" },
                    { 57, 20, "https://cdn.cloudflare.steamstatic.com/steam/apps/1259970/ss_0e814100dc3fca73e76a1c592316ed9285a374a6.600x338.jpg?t=1639008061" },
                    { 31, 11, "https://cdn.cloudflare.steamstatic.com/steam/apps/1238840/ss_b914b0daf3c46d908d403bdec2881cf2b8d34915.600x338.jpg?t=1633006806" },
                    { 29, 10, "https://cdn.cloudflare.steamstatic.com/steam/apps/546560/ss_70fce3236bf252d3814f793744f648cbe35164e4.600x338.jpg?t=1635876995" },
                    { 5, 2, "https://cdn.cloudflare.steamstatic.com/steam/apps/870780/ss_165fb4ca28f4db79b878e8c56ba6502e782c0bb2.600x338.jpg?t=1636733774" },
                    { 6, 2, "https://cdn.cloudflare.steamstatic.com/steam/apps/870780/ss_06b7e4baac0ac7f2ecfcc8d3198f707339c6296f.600x338.jpg?t=1636733774" },
                    { 7, 3, "https://cdn.cloudflare.steamstatic.com/steam/apps/703080/ss_fac76f23b1b655dd0459db1a443bc8adb02e4279.600x338.jpg?t=1639154253" },
                    { 8, 3, "https://cdn.cloudflare.steamstatic.com/steam/apps/703080/ss_c57319ad1fcc446a6a241b279a8477f7b741cd76.600x338.jpg?t=1639154253" },
                    { 9, 3, "https://cdn.cloudflare.steamstatic.com/steam/apps/703080/ss_5fe82516d6b1d42399dfded9fb86d6249c9d05cd.600x338.jpg?t=1639154253" },
                    { 10, 4, "https://cdn.cloudflare.steamstatic.com/steam/apps/1085660/ss_7fcc82f468fcf8278c7ffa95cebf949bfc6845fc.600x338.jpg?t=1638897108" },
                    { 11, 4, "https://cdn.cloudflare.steamstatic.com/steam/apps/1085660/ss_01fdd090ed1dd70112ce2c6d6fc208df0a008ac7.600x338.jpg?t=1638897108" },
                    { 12, 4, "https://cdn.cloudflare.steamstatic.com/steam/apps/1085660/ss_c142f5078ace9f5e2eb2c80aa3bf768e156b4ee9.600x338.jpg?t=1638897108" },
                    { 13, 5, "https://cdn.cloudflare.steamstatic.com/steam/apps/230410/ss_2d79448091149a8cc790b62e7422615a011d015a.600x338.jpg?t=1638285467" },
                    { 14, 5, "https://cdn.cloudflare.steamstatic.com/steam/apps/230410/ss_ead77e7b45f8dcfcf54d7a061745e7c99383bfc3.600x338.jpg?t=1638285467" },
                    { 15, 5, "https://cdn.cloudflare.steamstatic.com/steam/apps/230410/ss_a3bddbc994e6b3ca465ffb0e8c38bdb0525ca7d2.600x338.jpg?t=1638285467" },
                    { 30, 10, "https://cdn.cloudflare.steamstatic.com/steam/apps/546560/ss_0360004603a7861cf6781d5449e641f916f1ee07.600x338.jpg?t=1635876995" },
                    { 16, 6, "https://cdn.cloudflare.steamstatic.com/steam/apps/1172470/ss_8731a6552dce7c9e9e6da79d6e42f62c4dcb835d.600x338.jpg?t=1638900075" }
                });

            migrationBuilder.InsertData(
                table: "Imagens",
                columns: new[] { "Id", "GameId", "LinkImagem" },
                values: new object[,]
                {
                    { 18, 6, "https://cdn.cloudflare.steamstatic.com/steam/apps/1172470/ss_e2f6718c84031f0cbe6ce380559359833679c27b.600x338.jpg?t=1638900075" },
                    { 19, 7, "https://cdn.cloudflare.steamstatic.com/steam/apps/466560/ss_97fe21d69fd7a6346bac022eca6959a1ed26cb7d.600x338.jpg?t=1635494563" },
                    { 20, 7, "https://cdn.cloudflare.steamstatic.com/steam/apps/466560/ss_3de44ce0617567838caae8bed5ddb9eb52f0feb8.600x338.jpg?t=1635494563" },
                    { 21, 7, "https://cdn.cloudflare.steamstatic.com/steam/apps/466560/ss_33ef40a942043fd97e6c0a52cf758134db9e3985.600x338.jpg?t=1635494563" },
                    { 22, 8, "https://cdn.cloudflare.steamstatic.com/steam/apps/524220/ss_8b29f7e1ce9a8b9313dc3eb50dbe76a4cf94eef9.600x338.jpg?t=1624266255" },
                    { 23, 8, "https://cdn.cloudflare.steamstatic.com/steam/apps/524220/ss_e926e3b5d440b4f244525745c7100edc2d717b85.600x338.jpg?t=1624266255" },
                    { 24, 8, "https://cdn.cloudflare.steamstatic.com/steam/apps/524220/ss_d0314b4c134329a483b5e43af951f60274abc66b.600x338.jpg?t=1624266255" },
                    { 25, 9, "https://cdn.cloudflare.steamstatic.com/steam/apps/1517290/ss_731b9a3f02ab15c517b9c42c3cbe9a71866be4d4.600x338.jpg?t=1639065984" },
                    { 26, 9, "https://cdn.cloudflare.steamstatic.com/steam/apps/1517290/ss_9ddf67a6ebb471b99f9d139ab4420bba1cb25b50.600x338.jpg?t=1639065984" },
                    { 27, 9, "https://cdn.cloudflare.steamstatic.com/steam/apps/1517290/ss_075b303b59a5e9a0ae6c0fff78839116e6f75848.600x338.jpg?t=1639065984" },
                    { 28, 10, "https://cdn.cloudflare.steamstatic.com/steam/apps/546560/ss_d61365e93f20ceb5a94a1e5b2811cf504cbfa303.600x338.jpg?t=1635876995" },
                    { 17, 6, "https://cdn.cloudflare.steamstatic.com/steam/apps/1172470/ss_1512fa5b0c252aac80b7011e2e332d45116053ca.600x338.jpg?t=1638900075" },
                    { 58, 20, "https://cdn.cloudflare.steamstatic.com/steam/apps/1259970/ss_99261ae7af4f339269a9628a522a1d443b8f126b.600x338.jpg?t=1639008061" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 58);
        }
    }
}
