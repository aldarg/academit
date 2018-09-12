using System.Linq;
using System.Collections.Generic;

namespace Academits.DargeevAleksandr
{
    public enum ViewCellStatus
    {
        Closed,
        Blank,
        Numbered1,
        Numbered2,
        Numbered3,
        Numbered4,
        Numbered5,
        Numbered6,
        Numbered7,
        Numbered8,
        Mined,
        Marked,
        Exploded,
        BadMark,
        Disarmed
    }

    public class Presenter
    {
        private Field _field;
        private readonly IView _view;
        private readonly Score _scores;
        private GameSettings _settings = new GameSettings(GameSettings.DifficultyLevels.Novice);

        public Presenter(IView view)
        {
            _field = new Field(_settings);
            _scores = new Score();
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
                _view.CellStatuses[x, y] = ViewCellStatus.Closed;
                ++_view.MinesLeft;

                if (_field.Cells[x, y].IsMined)
                {
                    --_field.GoodMarks;
                }
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
            if (win)
            {
                _scores.AddScore(_settings.DifficultyLevel, _view.TimerCount);
                _scores.SaveScore();
            }

            OpenAllCells();
            _view.EndGame(win);
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

        public Dictionary<GameSettings.DifficultyLevels, int> GetHighScores()
        {
            var result = new Dictionary<GameSettings.DifficultyLevels, int>();

            foreach (var level in _scores.Scores.Keys)
            {
                result.Add(level, _scores.Scores[level].Min());
            }

            return result;
        }

        public void ResetHighscores()
        {
            _scores.Scores.Clear();
            _scores.SaveScore();
        }
    }
}
