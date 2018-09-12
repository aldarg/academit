namespace Academits.DargeevAleksandr
{
    public interface IView
    {
        int FieldHeight { get; set; }
        int FieldWidth { get; set; }
        int MinesTotal { get; set; }
        int TimerCount { get; }
        int MinesLeft { get; set; }
        ViewCellStatus[,] CellStatuses { get; }

        void NewGame();
        void OpenCell(int x, int y);
        void OpenAdjacentCells(int x, int y);
        void MarkCell(int x, int y);
        void RefreshField();
        void EndGame(bool win);
        void ShowHighscores();
        void Settings();
        void About();
        void Exit();
    }
}
