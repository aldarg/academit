namespace Academits.DargeevAleksandr.MinesweeperGUI
{
    partial class HighscoreForm
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
            this.levelsList = new System.Windows.Forms.ListView();
            this.scores = new System.Windows.Forms.GroupBox();
            this.dateOutput = new System.Windows.Forms.Label();
            this.nameOutput = new System.Windows.Forms.Label();
            this.timeOutput = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.scores.SuspendLayout();
            this.SuspendLayout();
            // 
            // levelsList
            // 
            this.levelsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.levelsList.HideSelection = false;
            this.levelsList.Location = new System.Drawing.Point(15, 19);
            this.levelsList.Name = "levelsList";
            this.levelsList.Size = new System.Drawing.Size(249, 75);
            this.levelsList.TabIndex = 0;
            this.levelsList.UseCompatibleStateImageBehavior = false;
            this.levelsList.View = System.Windows.Forms.View.List;
            this.levelsList.ItemSelectionChanged += LevelsList_ItemSelectionChanged1;
            // 
            // scores
            // 
            this.scores.Controls.Add(this.dateOutput);
            this.scores.Controls.Add(this.nameOutput);
            this.scores.Controls.Add(this.timeOutput);
            this.scores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scores.Location = new System.Drawing.Point(281, 12);
            this.scores.Name = "scores";
            this.scores.Size = new System.Drawing.Size(390, 146);
            this.scores.TabIndex = 1;
            this.scores.TabStop = false;
            this.scores.Text = "Лучшие результаты";
            // 
            // dateOutput
            // 
            this.dateOutput.AutoSize = true;
            this.dateOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateOutput.Location = new System.Drawing.Point(268, 30);
            this.dateOutput.Name = "dateOutput";
            this.dateOutput.Size = new System.Drawing.Size(41, 20);
            this.dateOutput.TabIndex = 2;
            this.dateOutput.Text = "date";
            this.dateOutput.Visible = false;
            // 
            // nameOutput
            // 
            this.nameOutput.AutoSize = true;
            this.nameOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameOutput.Location = new System.Drawing.Point(110, 30);
            this.nameOutput.Name = "nameOutput";
            this.nameOutput.Size = new System.Drawing.Size(49, 20);
            this.nameOutput.TabIndex = 1;
            this.nameOutput.Text = "name";
            this.nameOutput.Visible = false;
            // 
            // timeOutput
            // 
            this.timeOutput.AutoSize = true;
            this.timeOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeOutput.Location = new System.Drawing.Point(6, 30);
            this.timeOutput.Name = "timeOutput";
            this.timeOutput.Size = new System.Drawing.Size(48, 20);
            this.timeOutput.TabIndex = 0;
            this.timeOutput.Text = "result";
            this.timeOutput.Visible = false;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okButton.Location = new System.Drawing.Point(395, 178);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(110, 40);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Закрыть";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetButton.Location = new System.Drawing.Point(542, 178);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(110, 40);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Сбросить";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // HighscoreForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 239);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.scores);
            this.Controls.Add(this.levelsList);
            this.Name = "HighscoreForm";
            this.Text = "Таблица результатов";
            this.scores.ResumeLayout(false);
            this.scores.PerformLayout();
            this.ResumeLayout(false);

        }

        private void LevelsList_ItemSelectionChanged1(object sender, System.Windows.Forms.ListViewItemSelectionChangedEventArgs e)
        {
            FillResults(e.Item.Text);
        }

        #endregion

        private System.Windows.Forms.ListView levelsList;
        private System.Windows.Forms.GroupBox scores;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label timeOutput;
        private System.Windows.Forms.Label dateOutput;
        private System.Windows.Forms.Label nameOutput;
    }
}