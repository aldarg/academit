using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Academits.DargeevAleksandr
{
    [Serializable]
    internal class Score
    {
        public Dictionary<GameSettings.DifficultyLevels, List<int>> Scores;

        public Score()
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (Stream stream =
                    new FileStream("scores.sav", FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    var test = (Score) formatter.Deserialize(stream);
                    Scores = test.Scores;
                }
            }
            catch (Exception)
            {
                Scores = new Dictionary<GameSettings.DifficultyLevels, List<int>>();
            }
        }

        public void AddScore(GameSettings.DifficultyLevels level, int time)
        {
            if (!Scores.ContainsKey(level))
            {
                Scores.Add(level, new List<int>());
            }

            Scores[level].Add(time);
        }

        public void SaveScore()
        {
            var formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("scores.sav", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, this);
            }
        }
    }
}
