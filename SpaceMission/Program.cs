using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceMission
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Map rows: ");
            int M = int.Parse(Console.ReadLine());

            Console.Write("Map columns: ");
            int N = int.Parse(Console.ReadLine());

            Console.WriteLine("Cosmic map:");
            string[,] cosmicMap = new string[M, N];
            Position spaceStation = null;

            List<Astronaut> astronauts = new List<Astronaut>();

            for (int i = 0; i < M; i++)
            {
                string[] rowElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < N; j++)
                {
                    string currentSymbol = rowElements[j];
                    cosmicMap[i, j] = currentSymbol;

                    if (currentSymbol == "F")
                    {
                        spaceStation = new Position(i, j);
                    }
                    else if (currentSymbol.StartsWith("S"))
                    {
                        astronauts.Add(new Astronaut(currentSymbol, new Position(i, j)));
                    }
                }
            }

            Console.WriteLine($"\n--- Данните са заредени! Намерени астронавти: {astronauts.Count} ---");
            PathFinder pathFinder = new PathFinder();

            foreach (var astro in astronauts)
            {
                pathFinder.CalculatePath(astro, spaceStation, cosmicMap, M, N);
            }

            Console.WriteLine("\n================ MISSION RESULTS ================\n");

            var lostAstronauts = astronauts.Where(a => a.IsLost).ToList();
            foreach (var astro in lostAstronauts)
            {
                Console.WriteLine($"Mission failed - Astronaut {astro.Id} lost in space!");
            }

            var savedAstronauts = astronauts.Where(a => !a.IsLost).OrderBy(a => a.ShortestPathLength).ToList();

            foreach (var astro in savedAstronauts)
            {
                Console.WriteLine($"Astronaut {astro.Id} - Shortest path: {astro.ShortestPathLength} steps");

                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write(astro.SolvedMap[i, j] + " ");
                    }
                    Console.WriteLine(); 
                }
                Console.WriteLine(); 
            }

        }
    }
}