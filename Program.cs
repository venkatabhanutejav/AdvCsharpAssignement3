using Core.Interfaces;
using Infrastructure;
using System.Reflection.Metadata;

namespace PredatorPreySim
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool waitingToStart = true;
            while(waitingToStart)
            {
                Console.WriteLine("Enter Start to start the game");
                if(Console.ReadLine()?.ToLower() == "start")
                {
                    waitingToStart = false;
                }
            }

            StartGame(20, 20);
        }

        static void StartGame(int x, int y)
        {
            Console.Clear();
            Console.WriteLine("Enter Stop to stop the game");
            Console.WriteLine();

            var gameService = CreateService();
            gameService.StartGame(20, 20, 100, 5);

            string input = string.Empty;
            while (gameService.IsGameOver == false && input.ToLower() != "stop")
            {
                input = Console.ReadLine() ?? string.Empty;
                gameService.NextIteration();
            }
        }

        static IGameService CreateService()
        {
            var gameboardService = new GameBoardService();
            var creatureSErvice = new CreatureService(gameboardService);
            var gameService = new GameService(gameboardService, creatureSErvice);

            return gameService;
        }
    }
}