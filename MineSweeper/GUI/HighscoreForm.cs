using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Academits.DargeevAleksandr.MinesweeperModel;

namespace Academits.DargeevAleksandr.MinesweeperGUI
{
    public partial class HighscoreForm : Form
    {
        private Presenter _presenter;

        public HighscoreForm()
        {
            InitializeComponent();
        }

        public void Show(Presenter presenter)
        {
            _presenter = presenter;

            var highscores = presenter.GetHighScore();

            if (highscores.Count == 0)
            {
                Controls.Remove(levelsList);
                Controls.Remove(scores);
                Controls.Remove(resetButton);

                scoresLabel.Text = "Таблица результатов пока пустая.";
                scoresLabel.Location = new Point(9, 40);

                Width = 300;
                Height = 200;

                okButton.Location = new Point(100, 100);
            }
            else
            {
                foreach (var level in highscores.Keys)
                {
                    var item = new ListViewItem { Text = level.ToString() };
                    levelsList.Items.Add(item);
                }

                levelsList.Items[0].Selected = true;
                levelsList.Select();
            }

            ShowDialog();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            _presenter.ResetHighScore();

            levelsList.Items.Clear();
            scores.Controls.Clear();
        }

        private void FillResults(string levelName)
        {
            var level = (GameSettings.DifficultyLevels)Enum.Parse(typeof(GameSettings.DifficultyLevels), levelName);

            timeOutput.Visible = true;
            nameOutput.Visible = true;
            dateOutput.Visible = true;

            var levelScores = _presenter.GetHighScore()[level];
            var timeResult = new StringBuilder();
            var nameResult = new StringBuilder();
            var dateResult = new StringBuilder();

            foreach (var score in levelScores)
            {
                timeResult.Append(score.Result).Append(" сек").AppendLine();
                nameResult.Append(score.Name).AppendLine();
                dateResult.Append(score.Date.ToString("dd-MM-yyyy")).AppendLine();
            }

            timeOutput.Text = timeResult.ToString();
            nameOutput.Text = nameResult.ToString();
            dateOutput.Text = dateResult.ToString();
        }
    }
}
