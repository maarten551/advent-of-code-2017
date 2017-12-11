using System;
using System.Collections.Generic;

namespace Console_Application
{
    public class HexMazeSolver
    {
        private readonly Dictionary<string, (int, int)> movementManipulationPerDirection = new Dictionary<string, (int, int)>();
        
        private int xPosition;
        private int yPosition;

        public HexMazeSolver()
        {
            movementManipulationPerDirection.Add("n", (2, 0));
            movementManipulationPerDirection.Add("ne", (1, 1));
            movementManipulationPerDirection.Add("se", (-1, 1));
            movementManipulationPerDirection.Add("s", (-2, 0));
            movementManipulationPerDirection.Add("sw", (-1, -1));
            movementManipulationPerDirection.Add("nw", (1, -1));
        }

        public void AddStep(string step)
        {
            if (!movementManipulationPerDirection.ContainsKey(step))
                throw new Exception($"step '{step}' is not recongized");

            (int, int) positionManipulation = movementManipulationPerDirection[step];

            xPosition += positionManipulation.Item1;
            yPosition += positionManipulation.Item2;
        }

        public int AmountOfStepsBack()
        {
            return (Math.Abs(xPosition) + Math.Abs(yPosition)) / 2;
        }
    }
}