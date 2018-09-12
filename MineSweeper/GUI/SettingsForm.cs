using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Academits.DargeevAleksandr
{
    public partial class SettingsForm : Form
    {
        private RadioButton _levelRb;
        private bool _isCustomSettings;

        private readonly Dictionary<string, GameSettings.DifficultyLevels> _settings = new Dictionary<string, GameSettings.DifficultyLevels>
        {
            {"radioButtonNovice", GameSettings.DifficultyLevels.Novice },
            {"radioButtonMedium", GameSettings.DifficultyLevels.Medium },
            {"radioButtonPro", GameSettings.DifficultyLevels.Professional }
        };

        public SettingsForm()
        {
            InitializeComponent();
        }

        public void Show(Presenter presenter)
        {
            var resultCode = ShowDialog();

            if (resultCode != DialogResult.OK)
            {
                return;
            }

            if (_isCustomSettings)
            {
                var customWidth = int.Parse(widthInput.Text);
                var customHeight = int.Parse(heightInput.Text);
                var customMinesTotal = int.Parse(minesCountInput.Text);

                presenter.NewGame(GameSettings.DifficultyLevels.Custom, customWidth, customHeight, customMinesTotal);
            }
            else
            {
                presenter.NewGame(_settings[_levelRb.Name]);
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is RadioButton rb))
            {
                return;
            }

            if (rb.Checked)
            {
                _levelRb = rb;
            }
        }

        private void RadioButtonCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is RadioButton rb))
            {
                return;
            }

            if (rb.Checked)
            {
                _levelRb = rb;
                _isCustomSettings = true;
                customSettingsGroup.Enabled = true;
            }
            else
            {
                _isCustomSettings = false;
                customSettingsGroup.Enabled = false;
            }
        }

        private void HeightInput_Leave(object sender, EventArgs e)
        {
            var tb = sender as TextBox;

            if (!int.TryParse(tb.Text, out int result) || result < 9 || result > 64)
            {
                tb.Focus();
                tb.Text = "9";
                MessageBox.Show("Введите число от 9 до 64.");
            }
        }

        private void WidthInput_Leave(object sender, EventArgs e)
        {
            var tb = sender as TextBox;

            if (!int.TryParse(tb.Text, out int result) || result < 9 || result > 30)
            {
                tb.Focus();
                tb.Text = "10";
                MessageBox.Show("Введите число от 9 до 30.");
            }
        }

        private void MinesCountInput_Leave(object sender, EventArgs e)
        {
            var tb = sender as TextBox;

            if (!int.TryParse(tb.Text, out int result) || result < 10 || result > 668)
            {
                tb.Focus();
                tb.Text = "9";
                MessageBox.Show("Введите число от 10 до 668.");
            }
        }
    }
}
