using System;
using System.Windows.Forms;

namespace Academits.DargeevAleksandr
{
    public partial class UserInterface : Form
    {
        private RadioButton from;
        private RadioButton to;

        public UserInterface()
        {
            InitializeComponent();

            from = fromCelsius;
            to = toKelvin;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(inputTemperature.Text, out double inputValue))
            {
                MessageBox.Show("Введите число!");
                return;
            }

            if (from == null || to == null)
            {
                return;
            }

            try
            {
                Converter converter = new Converter(inputValue, from.Name, to.Name);
                outputTemperature.Text = String.Format("{0:f1}", converter.GetResult());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void From_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                return;
            }

            if (rb.Checked)
            {
                from = rb;
                outputTemperature.Text = "";
            }
        }

        private void To_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                return;
            }

            if (rb.Checked)
            {
                to = rb;
                outputTemperature.Text = "";
            }
        }

        private void InputTemperature_TextChanged(object sender, EventArgs e)
        {
            outputTemperature.Text = "";
        }
    }
}
