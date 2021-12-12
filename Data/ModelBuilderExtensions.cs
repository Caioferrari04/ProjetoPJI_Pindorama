using Microsoft.EntityFrameworkCore;
using Pindorama.Models;
using System;
using System.Collections.Generic;

namespace QuizApi.Repositories.Context {
    public static class ModelBuilderExtensions {
        public static void Seed(this ModelBuilder modelBuilder){
            Random rand = new Random();

            modelBuilder.Entity<Categoria>()
            #region Lista de categorias a serem adicionadas
                .HasData(new List<Categoria> {
                    new Categoria
                    {
                        Id = 1,
                        Nome = "Ação",
                        Descricao = "Jogos de ação",
                    },
                    new Categoria
                    {
                        Id = 2,
                        Nome = "Aventura",
                        Descricao = "Jogos de aventura",
                    },
                    new Categoria
                    {
                        Id = 3,
                        Nome = "Indie",
                        Descricao = "Jogos indie",
                    },
                    new Categoria
                    {
                        Id = 4,
                        Nome = "Multiplayer",
                        Descricao = "Jogos multiplayer",
                    },
                    new Categoria
                    {
                        Id = 5,
                        Nome = "Singleplayer",
                        Descricao = "Jogos singleplayer",
                    }
                });
            #endregion
            
            modelBuilder.Entity<Game>()
            #region Lista de games a serem adicionados
                .HasData(new List<Game> {
                    new Game //1
                    {
                        Id = 1,
                        Nome = "Counter-Strike: Global Offensive",
                        Descricao = "Counter-Strike: Global Offensive (CS: GO) expands upon the team-based action gameplay that it pioneered when it was launched 19 years ago. CS: GO features new maps, characters, weapons, and game modes, and delivers updated versions of the classic CS content (de_dust2, etc.).",
                        Preco = 0.0,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/730/header.jpg?t=1631908705",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/81958/movie_max.webm?t=1554409259",
                        Desenvolvedor = "Valve",
                        Publisher = "Valve",
                        IsFree = true,
                        DataLancamento = new DateTime(2012,8,21),
                        LinkBanner = "https://arenaesports.com.br/wp-content/uploads/2018/07/Counter-Strike-Global-Offensive-requisistos-m%C3%ADnimos.jpg"
                    },
                    new Game //2
                    {
                        Id = 2,
                        Nome = "Control Ultimate Edition",
                        Descricao = "Winner of over 80 awards, Control is a visually stunning third-person action-adventure that will keep you on the edge of your seat.",
                        Preco = 51.6,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/870780/header.jpg?t=1629966003",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256795524/movie_max_vp9.webm?t=1599146533",
                        Desenvolvedor = "Remedy Entertainment",
                        Publisher = "505 Games",
                        DataLancamento = new DateTime(2020, 8, 27),
                        LinkBanner = "https://cdn-ext.fanatical.com/production/product/1280x720/3de44d6e-17ff-4260-be3f-86d15647f03e.jpeg"
                    },
                    new Game //3
                    {
                        Id = 3,
                        Nome = "Planet Zoo",
                        Descricao = "Build a world for wildlife in Planet Zoo. From the developers of Planet Coaster and Zoo Tycoon comes the ultimate zoo sim. Construct detailed habitats, manage your zoo, and meet authentic living animals who think, feel and explore the world you create around them.",
                        Preco = 40.0,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/703080/header_alt_assets_1.jpg?t=1633429959",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256766382/movie_max.webm?t=1572955356",
                        Desenvolvedor = "Frontier Developments",
                        Publisher = "Frontier Developments",
                        DataLancamento = new DateTime(2017, 11, 5),
                        LinkBanner = "https://cdn-ext.fanatical.com/production/product/1280x720/35d6f92d-19d0-4458-9f1b-fc83063942c8.jpeg"
                    },
                    new Game //4
                    {
                        Id = 4,
                        Nome = "Destiny 2",
                        Descricao = "Destiny 2 is an action MMO with a single evolving world that you and your friends can join anytime, anywhere, absolutely free.",
                        Preco = 0.0,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/1085660/header.jpg?t=1631638993",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256826687/movie_max_vp9.webm?t=1629824123",
                        Desenvolvedor = "Bungie",
                        Publisher = "Bungie",
                        IsFree = true,
                        DataLancamento = new DateTime(2019, 10, 1),
                        LinkBanner = "http://guiadecompras.casasbahia.com.br/imagens/2017/12/Destiny-2-Official-Reveal-Art.jpg"
                    },
                    new Game //5
                    {
                        Id = 5,
                        Nome = "Warframe",
                        Descricao = $"Warframe is a cooperative free-to-play third person online action game set in an evolving sci-fi world.",
                        Preco = 0.0,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/230410/header.jpg?t=1633371015",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256841818/movie_max_vp9.webm?t=1625588620",
                        Desenvolvedor = "Digital Extremes",
                        Publisher = "Digital Extremes",
                        IsFree = true,
                        DataLancamento = new DateTime(2013, 3, 25),
                        LinkBanner = "https://www.oficinadanet.com.br/imagens/post/35877/warframe-capa.jpg"
                    },
                    new Game //6
                    {
                        Id = 6,
                        Nome = "Apex Legends™",
                        Descricao = $"Apex Legends is the award-winning, free-to-play Hero shooter from Respawn Entertainment. Master an ever-growing roster of legendary characters with powerful abilities and experience strategic squad play and innovative gameplay in the next evolution of Hero Shooter and Battle Royale.",
                        Preco = 0.0,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/1172470/header.jpg?t=1629219806",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256844400/movie_max_vp9.webm?t=1627392787",
                        Desenvolvedor = "Respawn Entertainment",
                        Publisher = "Electronic Arts",
                        IsFree = true,
                        DataLancamento = new DateTime(2020, 11, 5),
                        LinkBanner = "https://sm.ign.com/t/ign_br/screenshot/default/apex-legends-lendas_6emk.1200.jpg"
                    },
                    new Game //7
                    {
                        Id = 7,
                        Nome = "Northgard",
                        Descricao = $"Northgard is a strategy game based on Norse mythology in which you control a clan of Vikings vying for the control of a mysterious newfound continent.",
                        Preco = 23.19,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/466560/header.jpg?t=1630575354",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256668473/movie_max.webm?t=1507541937",
                        Desenvolvedor = "Shiro games", 
                        Publisher = "Shiro games",
                        DataLancamento = new DateTime(2018, 3, 7),
                        LinkBanner = "https://cdn2.unrealengine.com/egs-northgard-shirogames-g1a-00-1920x1080-315584a1b3b7.jpg"
                    },
                    new Game //8
                    {
                        Id = 8,
                        Nome = "NieR:Automata™",
                        Descricao = "NieR: Automata tells the story of androids 2B, 9S and A2 and their battle to reclaim the machine-driven dystopia overrun by powerful machines.",
                        Preco = 53.5,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/524220/header.jpg?t=1624266255",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256743980/movie_max.webm?t=1551200563",
                        Desenvolvedor = "Square Enix",
                        Publisher = "Square Enix",
                        DataLancamento = new DateTime(2017, 3, 17),
                        LinkBanner = "https://compass-ssl.xbox.com/assets/10/15/1015045a-5c87-4837-9cc4-0ae2944d4b87.jpg?n=Nier-Automata_GLP-Page-Hero-1084_1920x1080.jpg"
                    },
                    new Game //9
                    {
                        Id = 9,
                        Nome = "Battlefield™ 2042",
                        Descricao = "Battlefield™ 2042 is a first-person shooter that marks the return to the iconic all-out warfare of the franchise. In a near-future world transformed by disorder, adapt and overcome dynamically-changing battlegrounds with the help of your squad and a cutting-edge arsenal.",
                        Preco = 249.00,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/1517290/header.jpg?t=1633525745",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256844239/movie_max_vp9.webm?t=1627310563",
                        Desenvolvedor = "DICE",
                        Publisher = "Eletronic Arts",
                        DataLancamento = new DateTime(2021, 11, 19),
                        LinkBanner = "https://cdn2.unrealengine.com/egs-battlefield2042ultimateedition-dice-editions-g1a-00-1920x1080-15347ba44398.jpg"
                    },
                    new Game //10
                    {
                        Id = 10,
                        Nome = "Half-Life: Alyx",
                        Descricao = "Half-Life: Alyx is Valve’s VR return to the Half-Life series. It’s the story of an impossible fight against a vicious alien race known as the Combine, set between the events of Half-Life and Half-Life 2. Playing as Alyx Vance, you are humanity’s only chance for survival.",
                        Preco = 109.99,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/546560/header.jpg?t=1631826157",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256767815/movie_max.webm?t=1583175736",
                        Desenvolvedor = "Valve",
                        Publisher = "Valve",
                        DataLancamento = new DateTime(2020, 3, 23),
                        LinkBanner = "https://i.ytimg.com/vi/LTLotwKpLgk/maxresdefault.jpg"
                    },
                    new Game //11
                    {
                        Id = 11,
                        Nome = "Battlefield 1 ™",
                        Descricao = "Battlefield™ 1 takes you back to The Great War, WW1, where new technology and worldwide conflict changed the face of warfare forever.",
                        Preco = 23.88,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/1238840/header.jpg?t=1633006806",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256795873/movie_max_vp9.webm?t=1597019302",
                        Desenvolvedor = "DICE",
                        Publisher = "Eletronic Arts",
                        DataLancamento = new DateTime(2016, 10, 20),
                        LinkBanner = "https://i.ytimg.com/vi/PhE1db18ZK0/maxresdefault.jpg"
                    },
                    new Game //12
                    {
                        Id = 12,
                        Nome = "New World",
                        Descricao = "Explore a thrilling, open-world MMO filled with danger and opportunity where you'll forge a new destiny on the supernatural island of Aeternum.",
                        Preco = 75.49,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/1063730/header.jpg?t=1632842444",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256853212/movie_max_vp9.webm?t=1632842438",
                        Desenvolvedor = "Amazon Games",
                        Publisher = "Amazon Games",
                        DataLancamento = new DateTime(2021, 9, 28),
                        LinkBanner = "https://s2.glbimg.com/zPvvYfY_ATa1yMArOwf_9MW97c0=/1200x/smart/filters:cover():strip_icc()/i.s3.glbimg.com/v1/AUTH_08fbf48bc0524877943fe86e43087e7a/internal_photos/bs/2021/5/H/jSobTRTBScuiqf472Psg/keyartmask-3840.jpg"
                    },
                    new Game //13
                    {
                        Id = 13,
                        Nome = "Dota 2",
                        Descricao = "Every day, millions of players worldwide enter battle as one of over a hundred Dota heroes. And no matter if it's their 10th hour of play or 1,000th, there's always something new to discover. With regular updates that ensure a constant evolution of gameplay, features, and heroes, Dota 2 has taken on a life of its own.",
                        Preco = 0.0,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/570/header.jpg?t=1633452025",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/2028243/movie_max.webm?t=1599609286",
                        Desenvolvedor = "Valve",
                        Publisher = "Valve",
                        IsFree = true,
                        DataLancamento = new DateTime(2013, 7, 9),
                        LinkBanner = "https://s2.glbimg.com/-q8MvinX_0xiDazd60GdPbioyH0=/1200x/smart/filters:cover():strip_icc()/i.s3.glbimg.com/v1/AUTH_08fbf48bc0524877943fe86e43087e7a/internal_photos/bs/2019/l/Q/L8uEtSTYmy8JwFegBjiw/images-8-.jpg"
                    },
                    new Game //14
                    {
                        Id = 14,
                        Nome = "World of Warplanes",
                        Descricao = "World of Warplanes is an aerial combat MMO action game set in the Golden Age of military aviation. Throwing players into a never-ending battle for dominance of the skies, the game allows aircraft enthusiasts to pursue full-scale careers as virtual pilots, earning their wings in intense 12-vs-12 battles where supremacy in the air depends on not only a fast trigger finger, but also coordinated teamwork.",
                        Preco = 0.0,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/790710/header.jpg?t=1592572910",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256724984/movie_max.webm?t=1536746492",
                        Desenvolvedor = "Wargaming Group Limited",
                        Publisher = "Wargaming Group Limited",
                        IsFree = true,
                        DataLancamento = new DateTime(2018, 9, 12),
                        LinkBanner = "https://i.pinimg.com/originals/71/1c/e3/711ce3d86f82f993c45c0c639324135a.jpg"
                    },
                    new Game //15
                    {
                        Id = 15,
                        Nome = "War Robots",
                        Descricao = "War Robots is an online third-person 6v6 PvP shooter—we’re talking dozens of combat robots, hundreds of weapons combinations, and heated clan battles.",
                        Preco = 0.0,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/767560/header.jpg?t=1629810914",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256843182/movie_max_vp9.webm?t=1626428692",
                        Desenvolvedor = "Pixonic",
                        Publisher = "Pixonic",
                        IsFree = true,
                        DataLancamento = new DateTime(2018, 4, 5),
                        LinkBanner = "https://imag.malavida.com/mvimgbig/download-fs/walking-war-robots-17300-1.jpg"
                    },
                    new Game //16
                    {
                        Id = 16,
                        Nome = "Path of Exile",
                        Descricao = "You are an Exile, struggling to survive on the dark continent of Wraeclast, as you fight to earn power that will allow you to exact your revenge against those who wronged you. Created by hardcore gamers, Path of Exile is an online Action RPG set in a dark fantasy world.",
                        Preco = 0.0,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/238960/header.jpg?t=1627066053",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256844005/movie_max_vp9.webm?t=1627066029",
                        Desenvolvedor = "Grinding Gears Games",
                        Publisher = "Grinding Gears Games",
                        IsFree = true,
                        DataLancamento = new DateTime(2013, 10, 23),
                        LinkBanner = "https://cdn2.unrealengine.com/egs-pathofexile-grindinggeargames-s1-2560x1440-c9ae0f080546.jpg"
                    },
                    new Game //17
                    {
                        Id = 17,
                        Nome = "Warface",
                        Descricao = "Warface is a contemporary MMO first person shooter with millions of fans around the world. It offers intense PvP modes, compelling PvE missions and raids that you can challenge with five diverse classes and a colossal customizable arsenal.",
                        Preco = 0.0,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/291480/header.jpg?t=1628351873",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256845617/movie_max_vp9.webm?t=1628195334",
                        Desenvolvedor = "MY.GAMES",
                        Publisher = "MY.GAMES",
                        IsFree = true,
                        DataLancamento = new DateTime(2012, 4, 12),
                        LinkBanner = "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_Warface_AllodsTeam_S1_2560x1440-bf3c5da7b0239523117b1ff2bba16dc9"
                    },
                    new Game //18
                    {
                        Id = 18,
                        Nome = "Neverwinter",
                        Descricao = "Neverwinter is a free, action MMORPG based on the acclaimed Dungeons & Dragons fantasy roleplaying game. Epic stories, action combat and classic roleplaying await those heroes courageous enough to enter the fantastic world of Neverwinter!",
                        Preco = 0.0,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/109600/header.jpg?t=1632935549",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256853712/movie_max_vp9.webm?t=1632934786",
                        Desenvolvedor = "Cryptic Studios",
                        Publisher = "Perfect World Entertainment",
                        IsFree = true,
                        DataLancamento = new DateTime(2013, 12, 5),
                        LinkBanner = "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_Neverwinter_CrypticStudios_S1_2560x1440-907eede12f841fa505e7bccaf0dc48ce"
                    },
                    new Game //19
                    {
                        Id = 19,
                        Nome = "War Thunder",
                        Descricao = "War Thunder is the most comprehensive free-to-play, cross-platform, MMO military game dedicated to aviation, armoured vehicles, and naval craft, from the early 20th century to the most advanced modern combat units. Join now and take part in major battles on land, in the air, and at sea.",
                        Preco = 0.0,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/236390/header.jpg?t=1631265978",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256850482/movie_max_vp9.webm?t=1631009347",
                        Desenvolvedor = "Gaijin Entertainment",
                        Publisher = "Gaijin Distribution KFT",
                        IsFree = true,
                        DataLancamento = new DateTime(2013, 8, 15),
                        LinkBanner = "https://pbs.twimg.com/media/E_6Z_GvUYAgyDua.jpg"
                    },
                    new Game //20
                    {
                        Id = 20,
                        Nome = "eFootball PES 2021 SEASON UPDATE",
                        Descricao = "Comemore 25 anos do PES com o eFootball PES 2021 Season Update* - disponível por um preço especial de aniversário!",
                        Preco = 99.9,
                        LinkLogo = "https://cdn.cloudflare.steamstatic.com/steam/apps/1259970/header.jpg?t=1618425524",
                        LinkVideo = "https://cdn.cloudflare.steamstatic.com/steam/apps/256808957/movie480_vp9.webm?t=1605059321",
                        Desenvolvedor = "Konami Digital Entertainment",
                        Publisher = "Konami Digital Entertainment",
                        DataLancamento = new DateTime(2020, 9, 15),
                        LinkBanner = "https://img.konami.com/wepes/2021/s/img/order/homescreen_pes2021.jpg"
                    }
                });
            #endregion

            modelBuilder.Entity<Imagem>()
            #region Lista de imagens a serem adicionadas
                .HasData(new List<Imagem> {
                    new Imagem {
                        Id = 1,
                        GameId = 1,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/730/ss_34090867f1a02b6c17652ba9043e3f622ed985a9.600x338.jpg?t=1631908705"
                    },
                    new Imagem {
                        Id = 2,
                        GameId = 1,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/730/ss_d196d945c6170e9cadaf67a6dea675bd5fa7a046.600x338.jpg?t=1631908705"
                    },
                    new Imagem {
                        Id = 3,
                        GameId = 1,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/730/ss_2b9e362287b509bb3864fa7bad654fe1fda0f7ed.600x338.jpg?t=1631908705"
                    },
                    new Imagem {
                        Id = 4,
                        GameId = 2,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/870780/ss_8376498631b089e52fb5c75ffe119e0de5e6aed1.600x338.jpg?t=1636733774"
                    },
                    new Imagem {
                        Id = 5,
                        GameId = 2,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/870780/ss_165fb4ca28f4db79b878e8c56ba6502e782c0bb2.600x338.jpg?t=1636733774"
                    },
                    new Imagem {
                        Id = 6,
                        GameId = 2,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/870780/ss_06b7e4baac0ac7f2ecfcc8d3198f707339c6296f.600x338.jpg?t=1636733774"
                    },
                     new Imagem {
                        Id = 7,
                        GameId = 3,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/703080/ss_fac76f23b1b655dd0459db1a443bc8adb02e4279.600x338.jpg?t=1639154253"
                    },
                     new Imagem {
                        Id = 8,
                        GameId = 3,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/703080/ss_c57319ad1fcc446a6a241b279a8477f7b741cd76.600x338.jpg?t=1639154253"
                    },
                     new Imagem {
                        Id = 9,
                        GameId = 3,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/703080/ss_5fe82516d6b1d42399dfded9fb86d6249c9d05cd.600x338.jpg?t=1639154253"
                    },
                     new Imagem {
                        Id = 10,
                        GameId = 4,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1085660/ss_7fcc82f468fcf8278c7ffa95cebf949bfc6845fc.600x338.jpg?t=1638897108"
                    },
                     new Imagem {
                        Id = 11,
                        GameId = 4,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1085660/ss_01fdd090ed1dd70112ce2c6d6fc208df0a008ac7.600x338.jpg?t=1638897108"
                    },
                     new Imagem {
                        Id = 12,
                        GameId = 4,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1085660/ss_c142f5078ace9f5e2eb2c80aa3bf768e156b4ee9.600x338.jpg?t=1638897108"
                    },
                     new Imagem {
                        Id = 13,
                        GameId = 5,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/230410/ss_2d79448091149a8cc790b62e7422615a011d015a.600x338.jpg?t=1638285467"
                    },
                     new Imagem {
                        Id = 14,
                        GameId = 5,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/230410/ss_ead77e7b45f8dcfcf54d7a061745e7c99383bfc3.600x338.jpg?t=1638285467"
                    },
                     new Imagem {
                        Id = 15,
                        GameId = 5,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/230410/ss_a3bddbc994e6b3ca465ffb0e8c38bdb0525ca7d2.600x338.jpg?t=1638285467"
                    },
                     new Imagem {
                        Id = 16,
                        GameId = 6,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1172470/ss_8731a6552dce7c9e9e6da79d6e42f62c4dcb835d.600x338.jpg?t=1638900075"
                    },
                     new Imagem {
                        Id = 17,
                        GameId = 6,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1172470/ss_1512fa5b0c252aac80b7011e2e332d45116053ca.600x338.jpg?t=1638900075"
                    },
                     new Imagem {
                        Id = 18,
                        GameId = 6,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1172470/ss_e2f6718c84031f0cbe6ce380559359833679c27b.600x338.jpg?t=1638900075"
                    },
                     new Imagem {
                        Id = 19,
                        GameId = 7,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/466560/ss_97fe21d69fd7a6346bac022eca6959a1ed26cb7d.600x338.jpg?t=1635494563"
                    },
                     new Imagem {
                        Id = 20,
                        GameId = 7,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/466560/ss_3de44ce0617567838caae8bed5ddb9eb52f0feb8.600x338.jpg?t=1635494563"
                    },
                     new Imagem {
                        Id = 21,
                        GameId = 7,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/466560/ss_33ef40a942043fd97e6c0a52cf758134db9e3985.600x338.jpg?t=1635494563"
                    },
                     new Imagem {
                        Id = 22,
                        GameId = 8,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/524220/ss_8b29f7e1ce9a8b9313dc3eb50dbe76a4cf94eef9.600x338.jpg?t=1624266255"
                    },
                     new Imagem {
                        Id = 23,
                        GameId = 8,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/524220/ss_e926e3b5d440b4f244525745c7100edc2d717b85.600x338.jpg?t=1624266255"
                    },
                     new Imagem {
                        Id = 24,
                        GameId = 8,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/524220/ss_d0314b4c134329a483b5e43af951f60274abc66b.600x338.jpg?t=1624266255"
                    },
                     new Imagem {
                        Id = 25,
                        GameId = 9,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1517290/ss_731b9a3f02ab15c517b9c42c3cbe9a71866be4d4.600x338.jpg?t=1639065984"
                    },
                     new Imagem {
                        Id = 26,
                        GameId = 9,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1517290/ss_9ddf67a6ebb471b99f9d139ab4420bba1cb25b50.600x338.jpg?t=1639065984"
                    },
                     new Imagem {
                        Id = 27,
                        GameId = 9,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1517290/ss_075b303b59a5e9a0ae6c0fff78839116e6f75848.600x338.jpg?t=1639065984"
                    },
                     new Imagem {
                        Id = 28,
                        GameId = 10,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/546560/ss_d61365e93f20ceb5a94a1e5b2811cf504cbfa303.600x338.jpg?t=1635876995"
                    },
                     new Imagem {
                        Id = 29,
                        GameId = 10,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/546560/ss_70fce3236bf252d3814f793744f648cbe35164e4.600x338.jpg?t=1635876995"
                    },
                     new Imagem {
                        Id = 30,
                        GameId = 10,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/546560/ss_0360004603a7861cf6781d5449e641f916f1ee07.600x338.jpg?t=1635876995"
                    },
                     new Imagem {
                        Id = 31,
                        GameId = 11,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1238840/ss_b914b0daf3c46d908d403bdec2881cf2b8d34915.600x338.jpg?t=1633006806"
                    },
                     new Imagem {
                        Id = 32,
                        GameId = 11,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1238840/ss_432fba694d3dfdab325ddf83cbb355545a4554c6.600x338.jpg?t=1633006806"
                    },
                     new Imagem {
                        Id = 33,
                        GameId = 11,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1238840/ss_2aac0cbea68f0ac82154ca627e2e991fc65c9ede.600x338.jpg?t=1633006806"
                    },
                     new Imagem {
                        Id = 34,
                        GameId = 12,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1063730/ss_32b377faf983064af7638e858e1bfa7c845c9e2f.600x338.jpg?t=1637255211"
                    },
                     new Imagem {
                        Id = 35,
                        GameId = 12,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1063730/ss_84bc9909c2dfc8ec0d4ff84fd072b35785332fdc.600x338.jpg?t=1637255211"
                    },
                     new Imagem {
                        Id = 36,
                        GameId = 12,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1063730/ss_ceeb983fca848dc3ec1ce88efcbf85cce6f00489.600x338.jpg?t=1637255211"
                    },
                     new Imagem {
                        Id = 37,
                        GameId = 13,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/570/ss_86d675fdc73ba10462abb8f5ece7791c5047072c.600x338.jpg?t=1635466719"
                    },
                     new Imagem {
                        Id = 38,
                        GameId = 13,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/570/ss_27b6345f22243bd6b885cc64c5cda74e4bd9c3e8.600x338.jpg?t=1635466719"
                    },
                     new Imagem {
                        Id = 39,
                        GameId = 13,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/570/ss_e0a92f15a6631a8186df79182d0fe28b5e37d8cb.600x338.jpg?t=1635466719"
                    },
                     new Imagem {
                        Id = 40,
                        GameId = 14,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/790710/ss_f92678cc1967a70f441be2816cdbde719678edd9.600x338.jpg?t=1635932497"
                    },
                     new Imagem {
                        Id = 41,
                        GameId = 14,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/790710/ss_f3bbaf14a952779d700663954be180fbc490748a.600x338.jpg?t=1635932497"
                    },
                     new Imagem {
                        Id = 42,
                        GameId = 14,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/790710/ss_6a6b54e02fe5016b6027d1e35d28a4776e8f5287.600x338.jpg?t=1635932497"
                    },
                     new Imagem {
                        Id = 43,
                        GameId = 15,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/767560/ss_a1428f997d3eafe171fc578ed2f83093c14ec88c.600x338.jpg?t=1638264226"
                    },
                     new Imagem {
                        Id = 44,
                        GameId = 15,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/767560/ss_1352d9effbd99f47dc64e046eb54588188d7b10d.600x338.jpg?t=1638264226"
                    },
                     new Imagem {
                        Id = 45,
                        GameId = 15,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/767560/ss_f7e2c410a823139e4206d42760cf907e10b1c9f5.600x338.jpg?t=1638264226"
                    },
                     new Imagem {
                        Id = 46,
                        GameId = 16,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/238960/ss_984ea348b3c7d9495ad177b1c7530a3cb7e6ff0f.600x338.jpg?t=1635819685"
                    },
                     new Imagem {
                        Id = 47,
                        GameId = 16,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/238960/ss_40fa77890c74dd962fd665fa17440cc87003456e.600x338.jpg?t=1635819685"
                    },
                     new Imagem {
                        Id = 48,
                        GameId = 16,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/238960/ss_f50b319eb3cd8c88acb2cc0359359d656ae06624.600x338.jpg?t=1635819685"
                    },
                     new Imagem {
                        Id = 49,
                        GameId = 17,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/291480/ss_f4ffe6c0f8a9c14c1dac007f31c51d7a240f0262.600x338.jpg?t=1639068783"
                    },
                     new Imagem {
                        Id = 50,
                        GameId = 17,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/291480/ss_6fef3cf98354f3b592a49a5d82e4de3be0ab8074.600x338.jpg?t=1639068783"
                    },
                     new Imagem {
                        Id = 51,
                        GameId = 17,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/291480/ss_61215b055625fae5aed3356a0aeab8b19deee925.600x338.jpg?t=1639068783"
                    },
                     new Imagem {
                        Id = 52,
                        GameId = 18,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/109600/ss_4cebfb468c713e5126c95479c30866fff975bfaf.600x338.jpg?t=1636736301"
                    },
                     new Imagem {
                        Id = 53,
                        GameId = 19,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/109600/ss_a704890424b434a66d93bd73af1a3e616cca834a.600x338.jpg?t=1636736301"
                    },
                     new Imagem {
                        Id = 54,
                        GameId = 19,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/109600/ss_f7c2a3639d782aec69c6d8d075177de7fe291441.600x338.jpg?t=1636736301"
                    },
                     new Imagem {
                        Id = 55,
                        GameId = 19,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/109600/ss_95fa23b07c9bca7ba1cf6941cf169c3df822b6bd.600x338.jpg?t=1636736301"
                    },
                     new Imagem {
                        Id = 56,
                        GameId = 20,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1259970/ss_05b5733f8fc79533ffe773dfb628c1995d10af00.600x338.jpg?t=1639008061"
                    },
                     new Imagem {
                        Id = 57,
                        GameId = 20,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1259970/ss_0e814100dc3fca73e76a1c592316ed9285a374a6.600x338.jpg?t=1639008061"
                    },
                     new Imagem {
                        Id = 58,
                        GameId = 20,
                        LinkImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1259970/ss_99261ae7af4f339269a9628a522a1d443b8f126b.600x338.jpg?t=1639008061"
                    }
                });
            #endregion
        }
    }
}