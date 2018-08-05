using System;
using System.Windows.Forms;

namespace Academits.DargeevAleksandr
{
    public partial class UserInterface : Form
    {
        private readonly TemperatureConverter _converter = new TemperatureConverter();

        public UserInterface()
        {
            InitializeComponent();

            fromScale.Items.AddRange(_converter.ScalesList);
            fromScale.SelectedIndex = 0;

            toScale.Items.AddRange(_converter.ScalesList);
            toScale.SelectedIndex = 1;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(inputTemperature.Text, out double inputValue))
            {
                MessageBox.Show("Введите число!");
                return;
            }

            try
            {
                outputTemperature.Text = $"{_converter.Convert(inputValue, fromScale.SelectedItem.ToString(), toScale.SelectedItem.ToString()):f1}";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void InputTemperature_TextChanged(object sender, EventArgs e)
        {
            outputTemperature.Text = "";
        }

        private void FromScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputTemperature.Text = "";
        }

        private void ToScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputTemperature.Text = "";
        }
    }
}
