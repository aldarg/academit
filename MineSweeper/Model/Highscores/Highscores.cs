using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Academits.DargeevAleksandr.MinesweeperModel
{
    [Serializable]
    internal class Highscores
    {
        private readonly List<Score> _highscores;
        private const int TopResultsCount = 5;

        public Highscores()
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (Stream stream = new FileStream("highscores.sav", FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    var test = (Highscores) formatter.Deserialize(stream);
                    _highscores = test._highscores;
                }
            }
            catch (Exception)
            {
                _highscores = new List<Score>();
            }
        }

        public bool CheckResult(GameSettings.DifficultyLevels level, int time)
        {
            var levelScores = _highscores
                .Where(x => x.Level == level)
                .OrderByDescending(x => x.Result)
                .ToList();

            if (levelScores.Count < TopResultsCount)
            {
                return true;
            }

            var maxScore = levelScores.First();

            return time < maxScore.Result;
        }

        public void AddResult(GameSettings.DifficultyLevels level, string name, int time)
        {
            var newScore = new Score(level, name, time);

            var scoreToRemove = _highscores
                .Where(x => x.Level == level)
                .OrderBy(x => x.Result)
                .Skip(TopResultsCount - 1)
                .ToList();

            if (scoreToRemove.Any())
            {
                _highscores.Remove(scoreToRemove.First());
            }

            _highscores.Add(newScore);
        }

        public List<Score> GetHighscores()
        {
            return _highscores;
        }

        public void SaveScore()
        {
            var formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("highscores.sav", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, this);
            }
        }

        public void Reset()
        {
            _highscores.Clear();
        }
    }
}
