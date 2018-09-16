namespace Academits.DargeevAleksandr.MinesweeperGUI
{
    partial class EndHighscoredGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.recordMessage = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recordMessage
            // 
            this.recordMessage.AutoSize = true;
            this.recordMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recordMessage.Location = new System.Drawing.Point(32, 9);
            this.recordMessage.Name = "recordMessage";
            this.recordMessage.Size = new System.Drawing.Size(440, 48);
            this.recordMessage.TabIndex = 0;
            this.recordMessage.Text = "Вы выиграли с результатом секунд и попали в таблицу рекордов!\r\n\r\nВведите свое имя" +
    ":";
            this.recordMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameInput
            // 
            this.nameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameInput.Location = new System.Drawing.Point(125, 70);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(262, 29);
            this.nameInput.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(217, 117);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // EndHighscoredGameForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 152);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.recordMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EndHighscoredGameForm";
            this.Text = "Рекорд!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label recordMessage;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Button okButton;
    }
}