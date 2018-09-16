using System;
using System.Collections.Generic;

namespace Academits.DargeevAleksandr.MinesweeperModel
{
    public class GameSettings
    {
        public enum DifficultyLevels
        {
            Novice,
            Medium,
            Professional,
            Custom,
            Current
        }

        public Dictionary<DifficultyLevels, int[]> Settings = new Dictionary<DifficultyLevels, int[]>
        {
            {DifficultyLevels.Novice, new[] { 9, 9, 10 } },
            {DifficultyLevels.Medium, new[] { 16, 16, 40 } },
            {DifficultyLevels.Professional, new[] { 30, 16, 99 } },
        };

        public Dictionary<string, int> LimitCustomSettings = new Dictionary<string, int>()
        {
            {"minWidth", 9},
            {"maxWidth", 30 },
            {"minHeight", 9 },
            {"maxHeight", 64 },
            {"minMinesCount", 10 },
            {"maxMinesCount", 668 }
        };

        public DifficultyLevels DifficultyLevel { get; }
        public int FieldWidth { get; }
        public int FieldHeight { get; }
        public int FieldMinesTotal { get; }

        public GameSettings(DifficultyLevels level)
        {
            if (level == DifficultyLevels.Custom)
            {
                throw  new ArgumentOutOfRangeException("Передан уровень Custom без дополнительных параметров.");
            }

            DifficultyLevel = level;
            FieldWidth = Settings[level][0];
            FieldHeight= Settings[level][1];
            FieldMinesTotal = Settings[level][2];
        }

        public GameSettings(DifficultyLevels customLevel, int width, int height, int minesTotal)
        {
            DifficultyLevel = customLevel;
            FieldWidth = width;
            FieldHeight = height;
            FieldMinesTotal = minesTotal;
        }
    }
}
