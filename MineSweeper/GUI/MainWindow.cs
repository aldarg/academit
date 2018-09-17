using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Academits.DargeevAleksandr.MinesweeperModel;

namespace Academits.DargeevAleksandr.MinesweeperGUI
{
    public partial class MainWindow : Form, IView
    {
        private readonly Presenter _presenter;
        private readonly Dictionary<string, Image> _images;
        public int FieldHeight { get; set; }
        public int FieldWidth { get; set; }
        public int MinesTotal { get; set; }
        public ViewCellStatus[,] CellStatuses { get; set; }
        public int TimerCount => _presenter.GetTimerCount();
        public int MinesLeft { get; set; }

        private bool _mRight;
        private bool _mLeft;
        private readonly Timer _timer = new Timer();
        private readonly Size _cellSize = new Size(25, 25);
        private readonly Padding _cellPadding = new Padding(0);

        public MainWindow()
        {
            InitializeComponent();

            _images = new Dictionary<string, Image>
            {
                {"closed", Properties.Resources.closed },
                {"flag", Properties.Resources.bombflagged },
                {"bomb", Properties.Resources.bombrevealed },
                {"blank", Properties.Resources.open0 },
                {"open1", Properties.Resources.open1 },
                {"open2", Properties.Resources.open2 },
                {"open3", Properties.Resources.open3 },
                {"open4", Properties.Resources.open4 },
                {"open5", Properties.Resources.open5 },
                {"open6", Properties.Resources.open6 },
                {"open7", Properties.Resources.open7 },
                {"open8", Properties.Resources.open8 },
                {"exploded", Properties.Resources.bombexploded },
                {"missed", Properties.Resources.bombmissed},
                {"disarmed", Properties.Resources.bombdisarmed },
                {"selected", Properties.Resources.closed_selected },
                {"flag_selected", Properties.Resources.bombflagged_selected },
                {"question", Properties.Resources.bombquestion },
                {"question_selected", Properties.Resources.bombquestion_selected }
            };

            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;

            _presenter = new Presenter(this);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timerWindow.Text = TimerCount.ToString();
        }

        public void NewGame()
        {
            Width = FieldWidth * _cellSize.Width + 58;
            Height = FieldHeight * _cellSize.Height + 150;
            MinimumSize = new Size(Width, Height);

            tableLayoutPanel1.Width = Width;
            tableLayoutPanel1.Height = Height;

            minesField.Width = FieldWidth * _cellSize.Width;
            minesField.Height = FieldHeight * _cellSize.Height;
            minesField.RowCount = FieldHeight;
            minesField.ColumnCount = FieldWidth;
            minesField.Controls.Clear();

            foreach (RowStyle style in minesField.RowStyles)
            {
                style.SizeType = SizeType.AutoSize;
            }

            foreach (ColumnStyle style in minesField.ColumnStyles)
            {
                style.SizeType = SizeType.AutoSize;
            }

            _timer.Stop();
            timerWindow.Text = "0";
            minesLeftWindow.Text = MinesLeft.ToString();

            CellStatuses = new ViewCellStatus[FieldWidth, FieldHeight];

            for (var i = 0; i < FieldWidth; ++i)
            {
                for (var j = 0; j < FieldHeight; ++j)
                {
                    var button = new Button
                    {
                        Name = $"{i}; {j}",
                        Size = _cellSize,
                        Margin = _cellPadding,
                        FlatStyle = FlatStyle.Flat,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        BackgroundImage = _images["closed"],
                        TabStop = false,
                    };

                    minesField.Controls.Add(button, i, j);
                    button.MouseDown += ButtonClick;
                    button.MouseEnter += Button_MouseEnter;
                    button.MouseLeave += Button_MouseLeave;

                    CellStatuses[i, j] = ViewCellStatus.Closed;
                }
            }
        }

        public void OpenCell(int x, int y)
        {
            if (!_timer.Enabled)
            {
                _timer.Start();
            }

            _presenter.OpenCell(x, y);
        }

        public void OpenAdjacentCells(int x, int y)
        {
            _presenter.OpenAdjacentCells(x, y);
        }

        public void MarkCell(int x, int y)
        {
            _presenter.MarkCell(x, y);
        }

        public void RefreshField()
        {
            minesLeftWindow.Text = MinesLeft.ToString();

            for (var i = 0; i < FieldWidth; ++i)
            {
                for (var j = 0; j < FieldHeight; ++j)
                {
                    RefreshCell(i, j);
                }
            }
        }

        public void EndGame(bool win)
        {
            _timer.Stop();

            var result = MessageBox.Show(win ? $"Вы выиграли. Время: {TimerCount} сек! Начать сначала?" : "Вы проиграли! Начать сначала?", "Игра окончена", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                _presenter.NewGame();
            }
        }

        public string EndHighscoredGame(int time)
        {
            _timer.Stop();

            var input = new EndHighscoredGameForm();
            var name = input.ShowInput(time);

            return name;
        }

        public void AskNewGame()
        {
            var result = MessageBox.Show("Начать новую игру?", "Новая игра", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                _presenter.NewGame();
            }
        }

        public void ShowHighScore()
        {
            var highscoresForm = new HighscoreForm();
            highscoresForm.Show(_presenter);
        }

        public void Settings()
        {
            var settingsWindow = new SettingsForm();
            settingsWindow.Show(_presenter);
        }

        public void About()
        {
            const string about = "Игра Сапер (версия 1.0)";
            const string title = "О игре \"Сапер\"";
            MessageBox.Show(about, title, MessageBoxButtons.OK);
        }

        public void Exit()
        {
            Application.Exit();
        }

        private void RefreshCell(int x, int y)
        {
            Button btn;

            switch (CellStatuses[x, y])
            {
                case ViewCellStatus.Closed:
                    btn = minesField.GetControlFromPosition(x, y) as Button;
                    if (btn != null)
                    {
                        btn.BackgroundImage = _images["closed"];
                    }
                    break;
                case ViewCellStatus.Marked:
                    btn = minesField.GetControlFromPosition(x, y) as Button;
                    if (btn != null)
                    {
                        btn.BackgroundImage = _images["flag"];
                    }
                    break;
                case ViewCellStatus.Questioned:
                    btn = minesField.GetControlFromPosition(x, y) as Button;
                    if (btn != null)
                    {
                        btn.BackgroundImage = _images["question"];
                    }
                    break;
                case ViewCellStatus.Mined:
                    PutImage(x, y, _images["bomb"]);
                    break;
                case ViewCellStatus.Exploded:
                    PutImage(x, y, _images["exploded"]);
                    break;
                case ViewCellStatus.Blank:
                    PutImage(x, y, _images["blank"]);
                    break;
                case ViewCellStatus.Numbered1:
                    PutImage(x, y, _images["open1"]);
                    break;
                case ViewCellStatus.Numbered2:
                    PutImage(x, y, _images["open2"]);
                    break;
                case ViewCellStatus.Numbered3:
                    PutImage(x, y, _images["open3"]);
                    break;
                case ViewCellStatus.Numbered4:
                    PutImage(x, y, _images["open4"]);
                    break;
                case ViewCellStatus.Numbered5:
                    PutImage(x, y, _images["open5"]);
                    break;
                case ViewCellStatus.Numbered6:
                    PutImage(x, y, _images["open6"]);
                    break;
                case ViewCellStatus.Numbered7:
                    PutImage(x, y, _images["open7"]);
                    break;
                case ViewCellStatus.Numbered8:
                    PutImage(x, y, _images["open8"]);
                    break;
                case ViewCellStatus.Disarmed:
                    PutImage(x, y, _images["disarmed"]);
                    break;
                case ViewCellStatus.BadMark:
                    PutImage(x, y, _images["missed"]);
                    break;
            }
        }

        private void PutImage(int x, int y, Image image)
        {
            var control = minesField.GetControlFromPosition(x, y);

            if (control is PictureBox)
            {
                return;
            }

            minesField.Controls.Remove(minesField.GetControlFromPosition(x, y));

            var pb = new PictureBox
            {
                Image = image,
                Size = _cellSize,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Margin = _cellPadding
            };

            minesField.Controls.Add(pb, x, y);

            pb.MouseDown += Pb_MouseDown;
            pb.MouseUp += Pb_MouseUp;
        }

        private void Pb_MouseUp(object sender, MouseEventArgs click)
        {
            if (click.Button == MouseButtons.Left)
            {
                _mLeft = false;
            }
            if (click.Button == MouseButtons.Right)
            {
                _mRight = false;
            }
        }

        private void Pb_MouseDown(object sender, MouseEventArgs click)
        {
            switch (click.Button)
            {
                case MouseButtons.Left:
                    _mLeft = true;
                    break;
                case MouseButtons.Right:
                    _mRight = true;
                    break;
                case MouseButtons.Middle:
                    _mLeft = true;
                    _mRight = true;
                    break;
            }

            if (!_mLeft || !_mRight)
            {
                return;
            }

            var cell = sender as PictureBox;
            var x = minesField.GetPositionFromControl(cell).Column;
            var y = minesField.GetPositionFromControl(cell).Row;

            OpenAdjacentCells(x, y);
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (!(sender is Button btn))
            {
                throw new NullReferenceException("Вызов от несуществующей кнопки.");
            }

            var x = minesField.GetPositionFromControl(btn).Column;
            var y = minesField.GetPositionFromControl(btn).Row;

            switch (CellStatuses[x, y])
            {
                case ViewCellStatus.Closed:
                    btn.BackgroundImage = _images["closed"];
                    break;
                case ViewCellStatus.Questioned:
                    btn.BackgroundImage = _images["question"];
                    break;
                case ViewCellStatus.Marked:
                    btn.BackgroundImage = _images["flag"];
                    break;
            }
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (!(sender is Button btn))
            {
                throw new NullReferenceException("Вызов от несуществующей кнопки.");
            }

            var x = minesField.GetPositionFromControl(btn).Column;
            var y = minesField.GetPositionFromControl(btn).Row;

            switch ( CellStatuses[x, y])
            {
                case ViewCellStatus.Closed:
                    btn.BackgroundImage = _images["selected"];
                    break;
                case ViewCellStatus.Questioned:
                    btn.BackgroundImage = _images["question_selected"];
                    break;
                case ViewCellStatus.Marked:
                    btn.BackgroundImage = _images["flag_selected"];
                    break;
            }
        }

        private void ButtonClick(object sender, MouseEventArgs click)
        {
            if (!(sender is Button btn))
            {
                throw new NullReferenceException("Вызов от несуществующей кнопки.");
            }

            var x = minesField.GetPositionFromControl(btn).Column;
            var y = minesField.GetPositionFromControl(btn).Row;

            switch (click.Button)
            {
                case MouseButtons.Left:
                    if (CellStatuses[x, y] == ViewCellStatus.Questioned)
                    {
                        return;
                    }

                    OpenCell(x, y);
                    break;
                case MouseButtons.Right:
                    MarkCell(x, y);
                    break;
            }
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.NewGame();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHighScore();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About();
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Exit();
        }
    }
}
