using System;

namespace Academits.DargeevAleksandr.MinesweeperModel
{
    [Serializable]
    public class Score
    {
        public GameSettings.DifficultyLevels Level { get; }
        public int Result { get; }
        public string Name { get; }
        public DateTime Date { get; }

        public Score(GameSettings.DifficultyLevels level, string name, int result)
        {
            Level = level;
            Name = name;
            Result = result;
            Date = DateTime.Now;
        }
    }
}
