using System;
using System.CodeDom;
using System.Linq;
using System.Collections.Generic;

namespace Academits.DargeevAleksandr.MinesweeperModel
{
    public class Presenter
    {
        private Field _field;
        private readonly IView _view;
        private readonly Highscores _highscores;
        private GameSettings _settings = new GameSettings(GameSettings.DifficultyLevels.Novice);

        public Presenter(IView view)
        {
            _field = new Field(_settings);
            _highscores = new Highscores();
            _view = view;

            _view.FieldHeight = _field.Height;
            _view.FieldWidth = _field.Width;
            _view.MinesTotal = _field.MinesCount;
            _view.MinesLeft = _field.MinesCount;

            _view.NewGame();
        }

        public void NewGame(GameSettings.DifficultyLevels level = GameSettings.DifficultyLevels.Current)
        {
            if (level != GameSettings.DifficultyLevels.Current)
            {
                _settings = new GameSettings(level);
            }

            _field = new Field(_settings);

            _view.FieldHeight = _field.Height;
            _view.FieldWidth = _field.Width;
            _view.MinesTotal = _field.MinesCount;
            _view.MinesLeft = _field.MinesCount;

            _view.NewGame();
        }

        public void NewGame(GameSettings.DifficultyLevels level, int width, int height, int minesTotal)
        {
            _settings = new GameSettings(level, width, height, minesTotal);
            _field = new Field(_settings);

            _view.FieldHeight = _field.Height;
            _view.FieldWidth = _field.Width;
            _view.MinesTotal = _field.MinesCount;
            _view.MinesLeft = _field.MinesCount;

            _view.NewGame();
        }

        public void OpenCell(int x, int y)
        {
            _field.Cells[x, y].IsOpened = true;
            --_field.ClosedCells;

            if (!_field.IsFilled)
            {
                _field.PutMines(x, y);
                _field.PutNumbers();
                _field.BeginTime = DateTime.Now;
            }

            if (_field.Cells[x, y].IsMined)
            {
                _view.CellStatuses[x, y] = ViewCellStatus.Exploded;
                EndGame(false);
            }
            else if (_field.Cells[x, y].AdjacentBombsCount == 0)
            {
                OpenBlankCells(x, y);
            }
            else
            {
                OpenNumberedCell(x, y);
            }

            _view.RefreshField();

            CheckEndGame();
        }

        private void OpenBlankCells(int x, int y)
        {
            _view.CellStatuses[x, y] = ViewCellStatus.Blank;

            foreach (var cell in _field.GetAdjacentCells(x, y))
            {
                if (cell.IsOpened)
                {
                    continue;
                }

                cell.IsOpened = true;
                --_field.ClosedCells;

                if (cell.AdjacentBombsCount == 0)
                {
                    OpenBlankCells(cell.X, cell.Y);
                }

                if (cell.AdjacentBombsCount > 0)
                {
                    OpenNumberedCell(cell.X, cell.Y);
                }
            }
        }

        private void OpenNumberedCell(int x, int y)
        {
            switch (_field.Cells[x, y].AdjacentBombsCount)
            {
                case 1:
                    _view.CellStatuses[x, y] = ViewCellStatus.Numbered1;
                    break;
                case 2:
                    _view.CellStatuses[x, y] = ViewCellStatus.Numbered2;
                    break;
                case 3:
                    _view.CellStatuses[x, y] = ViewCellStatus.Numbered3;
                    break;
                case 4:
                    _view.CellStatuses[x, y] = ViewCellStatus.Numbered4;
                    break;
                case 5:
                    _view.CellStatuses[x, y] = ViewCellStatus.Numbered5;
                    break;
                case 6:
                    _view.CellStatuses[x, y] = ViewCellStatus.Numbered6;
                    break;
                case 7:
                    _view.CellStatuses[x, y] = ViewCellStatus.Numbered7;
                    break;
                case 8:
                    _view.CellStatuses[x, y] = ViewCellStatus.Numbered8;
                    break;
            }
        }

        public void OpenAdjacentCells(int x, int y)
        {
            var badMarksCount = 0;
            var marksCount = 0;
            var cellsExploded = new List<FieldCell>();
            var badMarks = new List<FieldCell>();

            foreach (var cell in _field.GetAdjacentCells(x, y))
            {
                if (cell.IsOpened)
                {
                    continue;
                }

                if (cell.IsMarked)
                {
                    ++marksCount;
                }

                if (cell.IsMarked && !cell.IsMined)
                {
                    badMarks.Add(cell);
                    ++badMarksCount;
                }

                if (!cell.IsMarked && cell.IsMined)
                {
                    cellsExploded.Add(cell);
                }
            }

            if (marksCount != _field.Cells[x, y].AdjacentBombsCount)
            {
                return;
            }

            if (badMarksCount == 0)
            {
                foreach (var cell in _field.GetAdjacentCells(x, y))
                {
                    if (!cell.IsOpened && !cell.IsMarked)
                    {
                        OpenCell(cell.X, cell.Y);
                    }
                }
            }
            else
            {
                foreach (var cell in cellsExploded)
                {
                    cell.IsOpened = true;
                    _view.CellStatuses[cell.X, cell.Y] = ViewCellStatus.Exploded;
                }
                foreach (var cell in badMarks)
                {
                    cell.IsOpened = true;
                    _view.CellStatuses[cell.X, cell.Y] = ViewCellStatus.BadMark;
                }

                EndGame(false);
            }
        }

        public void MarkCell(int x, int y)
        {
            if (_field.Cells[x, y].IsMarked)
            {
                _field.Cells[x, y].IsMarked = false;
                _view.CellStatuses[x, y] = ViewCellStatus.Questioned;
                ++_view.MinesLeft;

                if (_field.Cells[x, y].IsMined)
                {
                    --_field.GoodMarks;
                }
            }
            else
            {
                if (_view.CellStatuses[x, y] == ViewCellStatus.Questioned)
                {
                    _view.CellStatuses[x, y] = ViewCellStatus.Closed;
                }
                else
                {
                    _field.Cells[x, y].IsMarked = true;
                    _view.CellStatuses[x, y] = ViewCellStatus.Marked;
                    --_view.MinesLeft;

                    if (_field.Cells[x, y].IsMined)
                    {
                        ++_field.GoodMarks;
                    }
                }
            }

            _view.RefreshField();
        }

        private void CheckEndGame()
        {
            if (_field.ClosedCells == _field.MinesCount)
            {
                EndGame(true);
            }
        }

        private void EndGame(bool win)
        {
            var time = GetTimerCount();
            OpenAllCells();

            if (win && _highscores.CheckResult(_settings.DifficultyLevel, GetTimerCount()))
            {
                var name = _view.EndHighscoredGame(time);
                _highscores.AddResult(_settings.DifficultyLevel, name, time);
                _highscores.SaveScore();

                _view.AskNewGame();
            }
            else
            {
                _view.EndGame(win);
            }
        }

        private void OpenAllCells()
        {
            foreach (var cell in _field.Cells)
            {
                if (cell.IsOpened)
                {
                    continue;
                }

                if (cell.IsMined)
                {
                    if (cell.IsMarked)
                    {
                        _view.CellStatuses[cell.X, cell.Y] = ViewCellStatus.Disarmed;
                    }
                    else
                    {
                        _view.CellStatuses[cell.X, cell.Y] = ViewCellStatus.Mined;
                    }
                }
                else if (cell.AdjacentBombsCount == 0)
                {
                    _view.CellStatuses[cell.X, cell.Y] = ViewCellStatus.Blank;
                }
                else
                {
                    OpenNumberedCell(cell.X, cell.Y);
                }
            }

            _view.RefreshField();
        }

        public Dictionary<GameSettings.DifficultyLevels, List<Score>> GetHighScore()
        {
            var highscore = _highscores.GetHighscores();
            var result = new Dictionary<GameSettings.DifficultyLevels, List<Score>>();

            var levels = highscore.Select(x => x.Level).Distinct().ToList();
            foreach (var level in levels)
            {
                var levelResults = highscore.Where(x => x.Level == level).OrderBy(x => x.Result).ToList();
                result.Add(level, levelResults);
            }

            return result;
        }

        public void ResetHighScore()
        {
            _highscores.Reset();
            _highscores.SaveScore();
        }

        public int[] GetCustomWidthLimit()
        {
            var minWidth = _settings.LimitCustomSettings["minWidth"];
            var maxWidth = _settings.LimitCustomSettings["maxWidth"];

            return new[] { minWidth, maxWidth };
        }

        public int[] GetCustomHeightLimit()
        {
            var minHeight = _settings.LimitCustomSettings["minHeight"];
            var maxHeight = _settings.LimitCustomSettings["maxHeight"];

            return new[] { minHeight, maxHeight };
        }

        public int[] GetCustomMinesCountLimit()
        {
            var minMinesCount = _settings.LimitCustomSettings["minMinesCount"];
            var maxMinesCount = _settings.LimitCustomSettings["maxMinesCount"];

            return new[] { minMinesCount, maxMinesCount };
        }

        public int CheckCustomMinesCountRedundancy(int widthInput, int heightInput, int minesInput)
        {
            var maxMinesCount = (widthInput - 1) * (heightInput - 1);

            if (minesInput < maxMinesCount)
            {
                return minesInput;
            }

            return maxMinesCount - 1;
        }

        public int GetTimerCount()
        {
            return (int)DateTime.Now.Subtract(_field.BeginTime).TotalSeconds;
        }
    }
}
