using System;
using System.Collections.Generic;
using System.Linq;

namespace Academits.DargeevAleksandr.MinesweeperModel
{
    internal class Field
    {
        public bool IsFilled { get; set; }
        public FieldCell[,] Cells { get; }

        public int MinesCount { get; }
        public int Width { get; }
        public int Height { get; }

        public int ClosedCells { get; set; }
        public int GoodMarks { get; set; }

        public DateTime BeginTime { get; set; }

        public Field(GameSettings settings)
        {
            Width = settings.FieldWidth;
            Height = settings.FieldHeight;
            MinesCount = settings.FieldMinesTotal;

            ClosedCells = Height * Width;
            GoodMarks = 0;
            IsFilled = false;

            Cells = new FieldCell[Width, Height];

            for (var i = 0; i < Width; ++i)
            {
                for (var j = 0; j < Height; ++j)
                {
                    Cells[i, j] = new FieldCell
                    {
                        X = i,
                        Y = j
                    };
                }
            }
        }

        public void PutMines(int x, int y)
        {
            var randomizer = new Random();

            for (var i = 1; i <= MinesCount; ++i)
            {
                int j;
                int k;

                do
                {
                    j = randomizer.Next(0, Width);
                    k = randomizer.Next(0, Height);
                } while ((j >= x - 1 && j <= x + 1 && k >= y - 1 && k <= y + 1) || Cells[j, k].IsMined);

                Cells[j, k].IsMined = true;
            }

            IsFilled = true;
        }

        public void PutNumbers()
        {
            for (var i = 0; i < Width; ++i)
            {
                for (var j = 0; j < Height; ++j)
                {
                    if (!Cells[i, j].IsMined)
                    {
                        Cells[i, j].AdjacentBombsCount = CountAdjacentMines(i, j);
                    }
                }
            }
        }

        public List<FieldCell> GetAdjacentCells(int x, int y)
        {
            var result = new List<FieldCell>();

            for (var i = -1; i <= 1; ++i)
            {
                for (var j = -1; j <= 1; ++j)
                {
                    if (x + i < 0 || x + i >= Width || y + j < 0 || y + j >= Height)
                    {
                        continue;
                    }

                    result.Add(Cells[x + i, y + j]);
                }
            }

            return result;
        }

        private int CountAdjacentMines(int x, int y)
        {
            var result = GetAdjacentCells(x, y)
                .Count(p => p.IsMined);

            return result;
        }
    }
}
