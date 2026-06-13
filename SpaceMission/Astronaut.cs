using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceMission
{
    public class Astronaut
    {
        public string Id { get; set; }
        public Position StartPosition { get; set; }
        public int ShortestPathLength { get; set; } = int.MaxValue;
        public string[,] SolvedMap { get; set; }
        public bool IsLost { get; set; } = true;

        public Astronaut(string id, Position startPosition)
        {
            Id = id;
            StartPosition = startPosition;
        }
    }
}
