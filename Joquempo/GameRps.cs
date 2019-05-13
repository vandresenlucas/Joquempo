using System;
using System.Collections.Generic;
using System.Linq;

namespace Joquempo
{
    public class GameRps
    {
        private static List<Tuple<string, string>> subscribers = new List<Tuple<string, string>>();
        private static List<List<Tuple<string, string>>> rounds = new List<List<Tuple<string, string>>>();
        public GameRps(List<Tuple<string, string>> _subscribers, List<List<Tuple<string, string>>> _rounds)
        {
            subscribers = _subscribers;
            rounds = _rounds;
        }      
        public void RpsTournamentWinner()
        {
            ValidateOption(subscribers);

            CreateFirstStage();

            RpsGameWinner();
        }
        public void RpsGameWinner()
        {
            var roundWinners = new List<List<Tuple<string, string>>>();

            int count = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Confrontos: ");
                Console.WriteLine();

                count++;

                if (roundWinners.Count() == 1)
                    Console.WriteLine("Final: ");
                else
                    Console.WriteLine("{0}ª Etapa: ", count);

                Console.WriteLine();
                CreateNewStage(out roundWinners);
                rounds = roundWinners;

                Console.Clear();
            } while (roundWinners.Count() != 0);

        }

        public void CreateFirstStage()
        {
            var newRound = new List<Tuple<string, string>>();

            foreach (var player in subscribers)
            {
                newRound.Add(player);

                if (newRound.Count() == 2)
                {
                    rounds.Add(newRound);
                    newRound = new List<Tuple<string, string>>();
                }
            }
        }
        
        public void CreateNewStage(out List<List<Tuple<string, string>>> roundWinners)
        {
            roundWinners = new List<List<Tuple<string, string>>>();

            Tuple<string, string> winner;

            var winners = new List<Tuple<string, string>>();

            foreach (var round in rounds)
            {
                ValidateNumberOfPlayersGame(round);
                ShowRound(round);

                winner = PlayRps(round);
                winners.Add(winner);

                Console.WriteLine();
                Console.WriteLine(string.Format("Vencedor: {0} - {1}", winner.Item1, winner.Item2));
                Console.WriteLine();

                if (winners.Count() == 2)
                {
                    roundWinners.Add(winners);
                    winners = new List<Tuple<string, string>>();
                }
            }

            Console.ReadKey();
        }
        public Tuple<string, string> PlayRps(List<Tuple<string, string>> round)
        {
            if (round[0].Item2.Equals("R"))
            {
                if (round[1].Item2.Equals("P"))
                    return round[1];
                else
                    return round[0];
            }
            else if (round[0].Item2.Equals("P"))
            {
                if (round[1].Item2.Equals("S"))
                    return round[1];
                else
                    return round[0];
            }
            else //S - Tesoura
            {
                if (round[1].Item2.Equals("R"))
                    return round[1];
                else
                    return round[0];
            }
        }
        public void ShowRound(List<Tuple<string, string>> round)
        {
            Console.WriteLine(round[0].Item1 + " - " + round[0].Item2 + " X " + round[1].Item1 + " - " + round[1].Item2);
        }

        public void ValidateNumberOfPlayersGame(List<Tuple<string, string>> round)
        {
            if (round.Count() != 2)
                throw new WrongNumberOfPlayersError("São necessários dois jogadores para poder jogar!!!");
        }

        public void ValidateOption(List<Tuple<string, string>> subscribers)
        {

            List<Tuple<string, string>> wrongPlays = (from o in subscribers
                                                      where !o.Item2.Equals("R") && !o.Item2.Equals("P") && !o.Item2.Equals("S")
                                                      select o).ToList();

            if (wrongPlays.Count() > 0)
                throw new NoSuchStrategyError();
        }

        public void ValidateNumberChampionshipPlayers(List<Tuple<string, string>> subscribers)
        {
            if (subscribers.Count() < 2)
                throw new WrongNumberOfPlayersError("Necessário ter ao menos dois jogadores para iniciar o torneio!!!");
            else if (subscribers.Count() > 2)
            {
                double log2 = Math.Log(subscribers.Count(), 2);
                int baseLog;

                if (!int.TryParse(log2.ToString(), out baseLog))
                    throw new WrongNumberOfPlayersError("A quantidade de jogadores do torneio deve ser uma potência de dois para que as chaves sejam formadas corretamente!");                  
            }
        }
    }
}
