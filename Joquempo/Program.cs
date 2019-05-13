using System;
using System.Collections.Generic;
using System.Linq;

namespace Joquempo
{
    class Program
    {
        static List<Tuple<string, string>> subscribers;
        static List<List<Tuple<string, string>>> rounds;
        static void Main(string[] args)
        {
            var players = new Player();

            rounds = new List<List<Tuple<string, string>>>();

            subscribers = players.Subscription();

            var gameRps = new GameRps(subscribers, rounds);

            gameRps.ValidateNumberChampionshipPlayers(subscribers);

            Console.WriteLine("Campeonato de Jóquempô!!");
            Console.WriteLine();
            Console.ReadKey();           

            Console.WriteLine("Competidores: ");
            Console.WriteLine();

            foreach (var player in subscribers)               
                Console.WriteLine(player.Item1 + " - " + player.Item2);

            Console.ReadKey();

            gameRps.RpsTournamentWinner();
        }                     
    }
}
