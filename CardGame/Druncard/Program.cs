// See https://aka.ms/new-console-template for more information

using CardGameDrunkard;

List<Player> listPlayers = new List<Player>();
listPlayers.Add(new Player("Appolon"));
listPlayers.Add(new Player("Germes"));
listPlayers.Add(new Player("Aphina"));
listPlayers.Add(new Player("Diana"));
listPlayers.Add(new Player("Zevs"));

Random random = new Random();
Game game = new Game(listPlayers, random);

game.Start();

Console.WriteLine("\nEnd Game");


