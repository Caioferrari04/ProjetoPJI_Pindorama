using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class cat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Jogos de ação", "Ação" },
                    { 2, "Jogos de aventura", "Aventura" },
                    { 3, "Jogos indie", "Indie" },
                    { 4, "Jogos multiplayer", "Multiplayer" },
                    { 5, "Jogos singleplayer", "Singleplayer" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "DataLancamento", "Descricao", "Desenvolvedor", "DistribuidoraId", "IsFree", "LinkBanner", "LinkLogo", "LinkVideo", "Nome", "Preco", "Publisher", "compras" },
                values: new object[,]
                {
                    { 18, new DateTime(2013, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neverwinter is a free, action MMORPG based on the acclaimed Dungeons & Dragons fantasy roleplaying game. Epic stories, action combat and classic roleplaying await those heroes courageous enough to enter the fantastic world of Neverwinter!", "Cryptic Studios", null, true, "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_Neverwinter_CrypticStudios_S1_2560x1440-907eede12f841fa505e7bccaf0dc48ce", "https://cdn.cloudflare.steamstatic.com/steam/apps/109600/header.jpg?t=1632935549", "https://cdn.cloudflare.steamstatic.com/steam/apps/256853712/movie_max_vp9.webm?t=1632934786", "Neverwinter", 0.0, "Perfect World Entertainment", 0 },
                    { 17, new DateTime(2012, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warface is a contemporary MMO first person shooter with millions of fans around the world. It offers intense PvP modes, compelling PvE missions and raids that you can challenge with five diverse classes and a colossal customizable arsenal.", "MY.GAMES", null, true, "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_Warface_AllodsTeam_S1_2560x1440-bf3c5da7b0239523117b1ff2bba16dc9", "https://cdn.cloudflare.steamstatic.com/steam/apps/291480/header.jpg?t=1628351873", "https://cdn.cloudflare.steamstatic.com/steam/apps/256845617/movie_max_vp9.webm?t=1628195334", "Warface", 0.0, "MY.GAMES", 0 },
                    { 16, new DateTime(2013, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "You are an Exile, struggling to survive on the dark continent of Wraeclast, as you fight to earn power that will allow you to exact your revenge against those who wronged you. Created by hardcore gamers, Path of Exile is an online Action RPG set in a dark fantasy world.", "Grinding Gears Games", null, true, "https://cdn2.unrealengine.com/egs-pathofexile-grindinggeargames-s1-2560x1440-c9ae0f080546.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/238960/header.jpg?t=1627066053", "https://cdn.cloudflare.steamstatic.com/steam/apps/256844005/movie_max_vp9.webm?t=1627066029", "Path of Exile", 0.0, "Grinding Gears Games", 0 },
                    { 15, new DateTime(2018, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "War Robots is an online third-person 6v6 PvP shooter—we’re talking dozens of combat robots, hundreds of weapons combinations, and heated clan battles.", "Pixonic", null, true, "https://imag.malavida.com/mvimgbig/download-fs/walking-war-robots-17300-1.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/767560/header.jpg?t=1629810914", "https://cdn.cloudflare.steamstatic.com/steam/apps/256843182/movie_max_vp9.webm?t=1626428692", "War Robots", 0.0, "Pixonic", 0 },
                    { 14, new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "World of Warplanes is an aerial combat MMO action game set in the Golden Age of military aviation. Throwing players into a never-ending battle for dominance of the skies, the game allows aircraft enthusiasts to pursue full-scale careers as virtual pilots, earning their wings in intense 12-vs-12 battles where supremacy in the air depends on not only a fast trigger finger, but also coordinated teamwork.", "Wargaming Group Limited", null, true, "https://i.pinimg.com/originals/71/1c/e3/711ce3d86f82f993c45c0c639324135a.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/790710/header.jpg?t=1592572910", "https://cdn.cloudflare.steamstatic.com/steam/apps/256724984/movie_max.webm?t=1536746492", "World of Warplanes", 0.0, "Wargaming Group Limited", 0 },
                    { 13, new DateTime(2013, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Every day, millions of players worldwide enter battle as one of over a hundred Dota heroes. And no matter if it's their 10th hour of play or 1,000th, there's always something new to discover. With regular updates that ensure a constant evolution of gameplay, features, and heroes, Dota 2 has taken on a life of its own.", "Valve", null, true, "https://s2.glbimg.com/-q8MvinX_0xiDazd60GdPbioyH0=/1200x/smart/filters:cover():strip_icc()/i.s3.glbimg.com/v1/AUTH_08fbf48bc0524877943fe86e43087e7a/internal_photos/bs/2019/l/Q/L8uEtSTYmy8JwFegBjiw/images-8-.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/570/header.jpg?t=1633452025", "https://cdn.cloudflare.steamstatic.com/steam/apps/2028243/movie_max.webm?t=1599609286", "Dota 2", 0.0, "Valve", 0 },
                    { 12, new DateTime(2021, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Explore a thrilling, open-world MMO filled with danger and opportunity where you'll forge a new destiny on the supernatural island of Aeternum.", "Amazon Games", null, false, "https://s2.glbimg.com/zPvvYfY_ATa1yMArOwf_9MW97c0=/1200x/smart/filters:cover():strip_icc()/i.s3.glbimg.com/v1/AUTH_08fbf48bc0524877943fe86e43087e7a/internal_photos/bs/2021/5/H/jSobTRTBScuiqf472Psg/keyartmask-3840.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/1063730/header.jpg?t=1632842444", "https://cdn.cloudflare.steamstatic.com/steam/apps/256853212/movie_max_vp9.webm?t=1632842438", "New World", 75.489999999999995, "Amazon Games", 0 },
                    { 11, new DateTime(2016, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Battlefield™ 1 takes you back to The Great War, WW1, where new technology and worldwide conflict changed the face of warfare forever.", "DICE", null, false, "https://i.ytimg.com/vi/PhE1db18ZK0/maxresdefault.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/1238840/header.jpg?t=1633006806", "https://cdn.cloudflare.steamstatic.com/steam/apps/256795873/movie_max_vp9.webm?t=1597019302", "Battlefield 1 ™", 23.879999999999999, "Eletronic Arts", 0 },
                    { 10, new DateTime(2020, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Half-Life: Alyx is Valve’s VR return to the Half-Life series. It’s the story of an impossible fight against a vicious alien race known as the Combine, set between the events of Half-Life and Half-Life 2. Playing as Alyx Vance, you are humanity’s only chance for survival.", "Valve", null, false, "https://i.ytimg.com/vi/LTLotwKpLgk/maxresdefault.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/546560/header.jpg?t=1631826157", "https://cdn.cloudflare.steamstatic.com/steam/apps/256767815/movie_max.webm?t=1583175736", "Half-Life: Alyx", 109.98999999999999, "Valve", 0 },
                    { 8, new DateTime(2017, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "NieR: Automata tells the story of androids 2B, 9S and A2 and their battle to reclaim the machine-driven dystopia overrun by powerful machines.", "Square Enix", null, false, "https://compass-ssl.xbox.com/assets/10/15/1015045a-5c87-4837-9cc4-0ae2944d4b87.jpg?n=Nier-Automata_GLP-Page-Hero-1084_1920x1080.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/524220/header.jpg?t=1624266255", "https://cdn.cloudflare.steamstatic.com/steam/apps/256743980/movie_max.webm?t=1551200563", "NieR:Automata™", 53.5, "Square Enix", 0 },
                    { 19, new DateTime(2013, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "War Thunder is the most comprehensive free-to-play, cross-platform, MMO military game dedicated to aviation, armoured vehicles, and naval craft, from the early 20th century to the most advanced modern combat units. Join now and take part in major battles on land, in the air, and at sea.", "Gaijin Entertainment", null, true, "https://pbs.twimg.com/media/E_6Z_GvUYAgyDua.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/236390/header.jpg?t=1631265978", "https://cdn.cloudflare.steamstatic.com/steam/apps/256850482/movie_max_vp9.webm?t=1631009347", "War Thunder", 0.0, "Gaijin Distribution KFT", 0 },
                    { 7, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Northgard is a strategy game based on Norse mythology in which you control a clan of Vikings vying for the control of a mysterious newfound continent.", "Shiro games", null, false, "https://cdn2.unrealengine.com/egs-northgard-shirogames-g1a-00-1920x1080-315584a1b3b7.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/466560/header.jpg?t=1630575354", "https://cdn.cloudflare.steamstatic.com/steam/apps/256668473/movie_max.webm?t=1507541937", "Northgard", 23.190000000000001, "Shiro games", 0 },
                    { 6, new DateTime(2020, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apex Legends is the award-winning, free-to-play Hero shooter from Respawn Entertainment. Master an ever-growing roster of legendary characters with powerful abilities and experience strategic squad play and innovative gameplay in the next evolution of Hero Shooter and Battle Royale.", "Respawn Entertainment", null, true, "https://sm.ign.com/t/ign_br/screenshot/default/apex-legends-lendas_6emk.1200.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/1172470/header.jpg?t=1629219806", "https://cdn.cloudflare.steamstatic.com/steam/apps/256844400/movie_max_vp9.webm?t=1627392787", "Apex Legends™", 0.0, "Electronic Arts", 0 },
                    { 5, new DateTime(2013, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warframe is a cooperative free-to-play third person online action game set in an evolving sci-fi world.", "Digital Extremes", null, true, "https://www.oficinadanet.com.br/imagens/post/35877/warframe-capa.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/230410/header.jpg?t=1633371015", "https://cdn.cloudflare.steamstatic.com/steam/apps/256841818/movie_max_vp9.webm?t=1625588620", "Warframe", 0.0, "Digital Extremes", 0 },
                    { 4, new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Destiny 2 is an action MMO with a single evolving world that you and your friends can join anytime, anywhere, absolutely free.", "Bungie", null, true, "http://guiadecompras.casasbahia.com.br/imagens/2017/12/Destiny-2-Official-Reveal-Art.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/1085660/header.jpg?t=1631638993", "https://cdn.cloudflare.steamstatic.com/steam/apps/256826687/movie_max_vp9.webm?t=1629824123", "Destiny 2", 0.0, "Bungie", 0 },
                    { 3, new DateTime(2017, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Build a world for wildlife in Planet Zoo. From the developers of Planet Coaster and Zoo Tycoon comes the ultimate zoo sim. Construct detailed habitats, manage your zoo, and meet authentic living animals who think, feel and explore the world you create around them.", "Frontier Developments", null, false, "https://cdn-ext.fanatical.com/production/product/1280x720/35d6f92d-19d0-4458-9f1b-fc83063942c8.jpeg", "https://cdn.cloudflare.steamstatic.com/steam/apps/703080/header_alt_assets_1.jpg?t=1633429959", "https://cdn.cloudflare.steamstatic.com/steam/apps/256766382/movie_max.webm?t=1572955356", "Planet Zoo", 40.0, "Frontier Developments", 0 },
                    { 2, new DateTime(2020, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winner of over 80 awards, Control is a visually stunning third-person action-adventure that will keep you on the edge of your seat.", "Remedy Entertainment", null, false, "https://cdn-ext.fanatical.com/production/product/1280x720/3de44d6e-17ff-4260-be3f-86d15647f03e.jpeg", "https://cdn.cloudflare.steamstatic.com/steam/apps/870780/header.jpg?t=1629966003", "https://cdn.cloudflare.steamstatic.com/steam/apps/256795524/movie_max_vp9.webm?t=1599146533", "Control Ultimate Edition", 51.600000000000001, "505 Games", 0 },
                    { 1, new DateTime(2012, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Counter-Strike: Global Offensive (CS: GO) expands upon the team-based action gameplay that it pioneered when it was launched 19 years ago. CS: GO features new maps, characters, weapons, and game modes, and delivers updated versions of the classic CS content (de_dust2, etc.).", "Valve", null, true, "https://arenaesports.com.br/wp-content/uploads/2018/07/Counter-Strike-Global-Offensive-requisistos-m%C3%ADnimos.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/730/header.jpg?t=1631908705", "https://cdn.cloudflare.steamstatic.com/steam/apps/81958/movie_max.webm?t=1554409259", "Counter-Strike: Global Offensive", 0.0, "Valve", 0 },
                    { 9, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Battlefield™ 2042 is a first-person shooter that marks the return to the iconic all-out warfare of the franchise. In a near-future world transformed by disorder, adapt and overcome dynamically-changing battlegrounds with the help of your squad and a cutting-edge arsenal.", "DICE", null, false, "https://cdn2.unrealengine.com/egs-battlefield2042ultimateedition-dice-editions-g1a-00-1920x1080-15347ba44398.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/1517290/header.jpg?t=1633525745", "https://cdn.cloudflare.steamstatic.com/steam/apps/256844239/movie_max_vp9.webm?t=1627310563", "Battlefield™ 2042", 249.0, "Eletronic Arts", 0 },
                    { 20, new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comemore 25 anos do PES com o eFootball PES 2021 Season Update* - disponível por um preço especial de aniversário!", "Konami Digital Entertainment", null, false, "https://img.konami.com/wepes/2021/s/img/order/homescreen_pes2021.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/1259970/header.jpg?t=1618425524", "https://cdn.cloudflare.steamstatic.com/steam/apps/256808957/movie480_vp9.webm?t=1605059321", "eFootball PES 2021 SEASON UPDATE", 99.900000000000006, "Konami Digital Entertainment", 0 }
                });

            migrationBuilder.InsertData(
                table: "Imagens",
                columns: new[] { "Id", "GameId", "LinkImagem" },
                values: new object[] { 1, 1, "https://cdn.cloudflare.steamstatic.com/steam/apps/730/ss_34090867f1a02b6c17652ba9043e3f622ed985a9.600x338.jpg?t=1631908705" });

            migrationBuilder.InsertData(
                table: "Imagens",
                columns: new[] { "Id", "GameId", "LinkImagem" },
                values: new object[] { 2, 1, "https://cdn.cloudflare.steamstatic.com/steam/apps/730/ss_d196d945c6170e9cadaf67a6dea675bd5fa7a046.600x338.jpg?t=1631908705" });

            migrationBuilder.InsertData(
                table: "Imagens",
                columns: new[] { "Id", "GameId", "LinkImagem" },
                values: new object[] { 3, 1, "https://cdn.cloudflare.steamstatic.com/steam/apps/730/ss_2b9e362287b509bb3864fa7bad654fe1fda0f7ed.600x338.jpg?t=1631908705" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Imagens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
