using System.Windows.Forms;

namespace Academits.DargeevAleksandr.MinesweeperGUI
{
    public partial class EndHighscoredGameForm : Form
    {
        public EndHighscoredGameForm()
        {
            InitializeComponent();
        }

        public string ShowInput(int time)
        {
            recordMessage.Text = $"Вы выиграли с результатом {time} секунд и попали в таблицу рекордов!";
            var dialogResult = ShowDialog();

            return dialogResult == DialogResult.OK ? nameInput.Text : string.Empty;
        }
    }
}
