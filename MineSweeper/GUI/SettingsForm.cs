using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Academits.DargeevAleksandr.MinesweeperModel;

namespace Academits.DargeevAleksandr.MinesweeperGUI
{
    public partial class SettingsForm : Form
    {
        private RadioButton _levelRb;
        private bool _isCustomSettings;
        private Presenter _presenter;

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
            _presenter = presenter;

            heightInput.Text = _presenter.GetCustomHeightLimit()[0].ToString();
            widthInput.Text = _presenter.GetCustomWidthLimit()[0].ToString();
            minesCountInput.Text = _presenter.GetCustomMinesCountLimit()[0].ToString();

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

                _presenter.NewGame(GameSettings.DifficultyLevels.Custom, customWidth, customHeight, customMinesTotal);
            }
            else
            {
                _presenter.NewGame(_settings[_levelRb.Name]);
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
                heightInput.Focus();
            }
            else
            {
                _isCustomSettings = false;
                customSettingsGroup.Enabled = false;
            }
        }

        private void Input_Leave(object sender, EventArgs e)
        {
            var tb = sender as TextBox;

            switch (tb.Name)
            {
                case "heightInput":
                    ValidateHeightInput();
                    break;
                case "widthInput":
                    ValidateWidthInput();
                    break;
                case "minesCountInput":
                    ValidateMinesCountInput();
                    break;
            }
        }

        private bool ValidateHeightInput()
        {
            var minHeight = _presenter.GetCustomHeightLimit()[0];
            var maxHeight = _presenter.GetCustomHeightLimit()[1];

            if (int.TryParse(heightInput.Text, out var customHeight) && customHeight >= minHeight && customHeight <= maxHeight)
            {
                return true;
            }

            heightInput.Focus();
            heightInput.Text = minHeight.ToString();
            MessageBox.Show($"Введите число от {minHeight} до {maxHeight}.");
            return false;
        }

        private bool ValidateWidthInput()
        {
            var minWidth = _presenter.GetCustomWidthLimit()[0];
            var maxWidth = _presenter.GetCustomWidthLimit()[1];

            if (int.TryParse(widthInput.Text, out var customWidth) && customWidth >= minWidth && customWidth <= maxWidth)
            {
                return true;
            }

            widthInput.Focus();
            widthInput.Text = minWidth.ToString();
            MessageBox.Show($"Введите число от {minWidth} до {maxWidth}.");
            return false;
        }

        private bool ValidateMinesCountInput()
        {
            var customWidth = int.Parse(widthInput.Text);
            var customHeight = int.Parse(heightInput.Text);

            var minMinesCount = _presenter.GetCustomMinesCountLimit()[0];
            var maxMinesCount = _presenter.GetCustomMinesCountLimit()[1];

            if (!int.TryParse(minesCountInput.Text, out var customMinesTotal) || customMinesTotal < minMinesCount || customMinesTotal > maxMinesCount)
            {
                minesCountInput.Focus();
                minesCountInput.Text = minMinesCount.ToString();
                MessageBox.Show($"Введите число от {minMinesCount} до {maxMinesCount}.");

                return false;
            }

            var minesCountRedandancy = _presenter.CheckCustomMinesCountRedundancy(customWidth, customHeight, customMinesTotal);

            if (customMinesTotal > minesCountRedandancy)
            {
                minesCountInput.Focus();
                minesCountInput.Text = minesCountRedandancy.ToString();
                MessageBox.Show("Слишком большое количество мин.");
                return false;
            }

            return true;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            var checkCustomInputs = ValidateHeightInput() && ValidateWidthInput() && ValidateMinesCountInput();

            if (!_isCustomSettings || checkCustomInputs)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }
    }
}
