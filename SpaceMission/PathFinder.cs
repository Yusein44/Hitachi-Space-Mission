using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceMission
{
    public class PathFinder
    {
        private int[] dRow = { -1, 1, 0, 0 };
        private int[] dCol = { 0, 0, -1, 1 };

        public void CalculatePath(Astronaut astronaut, Position target, string[,] originalMap, int M, int N)
        {
            astronaut.SolvedMap = new string[M, N];
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    astronaut.SolvedMap[i, j] = originalMap[i, j];
                }
            }

            Queue<(Position pos, List<Position> path)> queue = new Queue<(Position, List<Position>)>();
            bool[,] visited = new bool[M, N];

            queue.Enqueue((astronaut.StartPosition, new List<Position>()));
            visited[astronaut.StartPosition.Row, astronaut.StartPosition.Col] = true;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Position currPos = current.pos;
                List<Position> currPath = current.path;

                if (currPos.Row == target.Row && currPos.Col == target.Col)
                {
                    astronaut.ShortestPathLength = currPath.Count;
                    astronaut.IsLost = false;

                    foreach (var p in currPath)
                    {
                        if (originalMap[p.Row, p.Col] != "F" && originalMap[p.Row, p.Col] != astronaut.Id)
                        {
                            astronaut.SolvedMap[p.Row, p.Col] = "*";
                        }
                    }
                    return;
                }

                for (int i = 0; i < 4; i++)
                {
                    int newRow = currPos.Row + dRow[i];
                    int newCol = currPos.Col + dCol[i];

                    if (newRow >= 0 && newRow < M && newCol >= 0 && newCol < N)
                    {
                        string cell = originalMap[newRow, newCol];
                        if (!visited[newRow, newCol] && cell != "X")
                        {
                            visited[newRow, newCol] = true;

                            List<Position> newPath = new List<Position>(currPath);
                            newPath.Add(new Position(newRow, newCol));

                            queue.Enqueue((new Position(newRow, newCol), newPath));
                        }
                    }
                }
            }
        }
    }
}
