using System;
using System.Windows.Forms;

namespace Academits.DargeevAleksandr
{
    public partial class UserInterface : Form
    {
        private TemperatureConverter converter = new TemperatureConverter();

        public UserInterface()
        {
            InitializeComponent();

            fromScale.Items.AddRange(converter.ScalesList.ToArray());
            fromScale.SelectedIndex = 0;

            toScale.Items.AddRange(converter.ScalesList.ToArray());
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
                outputTemperature.Text = String.Format("{0:f1}", converter.Convert(inputValue, fromScale.SelectedItem.ToString(), toScale.SelectedItem.ToString()));
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
