namespace Game
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class GameSave
    {
        public List<int> completedLevels = new List<int>();
        public Dictionary<int, int> bestScore = new Dictionary<int, int>();
    }
}