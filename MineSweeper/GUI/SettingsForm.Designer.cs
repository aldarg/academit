namespace Academits.DargeevAleksandr
{
    partial class SettingsForm
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
            this.levelSettings = new System.Windows.Forms.GroupBox();
            this.customSettingsGroup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.heightInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.widthInput = new System.Windows.Forms.TextBox();
            this.minesCountInput = new System.Windows.Forms.TextBox();
            this.radioButtonCustom = new System.Windows.Forms.RadioButton();
            this.radioButtonPro = new System.Windows.Forms.RadioButton();
            this.radioButtonMedium = new System.Windows.Forms.RadioButton();
            this.radioButtonNovice = new System.Windows.Forms.RadioButton();
            this.OkButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.levelSettings.SuspendLayout();
            this.customSettingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // levelSettings
            // 
            this.levelSettings.Controls.Add(this.customSettingsGroup);
            this.levelSettings.Controls.Add(this.radioButtonCustom);
            this.levelSettings.Controls.Add(this.radioButtonPro);
            this.levelSettings.Controls.Add(this.radioButtonMedium);
            this.levelSettings.Controls.Add(this.radioButtonNovice);
            this.levelSettings.Location = new System.Drawing.Point(12, 12);
            this.levelSettings.Name = "levelSettings";
            this.levelSettings.Size = new System.Drawing.Size(460, 234);
            this.levelSettings.TabIndex = 0;
            this.levelSettings.TabStop = false;
            this.levelSettings.Text = "Уровень";
            // 
            // customSettingsGroup
            // 
            this.customSettingsGroup.Controls.Add(this.label1);
            this.customSettingsGroup.Controls.Add(this.label3);
            this.customSettingsGroup.Controls.Add(this.heightInput);
            this.customSettingsGroup.Controls.Add(this.label2);
            this.customSettingsGroup.Controls.Add(this.widthInput);
            this.customSettingsGroup.Controls.Add(this.minesCountInput);
            this.customSettingsGroup.Enabled = false;
            this.customSettingsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customSettingsGroup.Location = new System.Drawing.Point(233, 56);
            this.customSettingsGroup.Name = "customSettingsGroup";
            this.customSettingsGroup.Size = new System.Drawing.Size(196, 101);
            this.customSettingsGroup.TabIndex = 10;
            this.customSettingsGroup.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "высота (9-64):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "число мин (10-668):";
            // 
            // heightInput
            // 
            this.heightInput.Location = new System.Drawing.Point(127, 13);
            this.heightInput.Name = "heightInput";
            this.heightInput.Size = new System.Drawing.Size(52, 20);
            this.heightInput.TabIndex = 4;
            this.heightInput.Text = "9";
            this.heightInput.Leave += HeightInput_Leave;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "ширина (9-30):";
            // 
            // widthInput
            // 
            this.widthInput.Location = new System.Drawing.Point(127, 44);
            this.widthInput.Name = "widthInput";
            this.widthInput.Size = new System.Drawing.Size(52, 20);
            this.widthInput.TabIndex = 5;
            this.widthInput.Text = "9";
            this.widthInput.Leave += WidthInput_Leave;
            // 
            // minesCountInput
            // 
            this.minesCountInput.Location = new System.Drawing.Point(127, 74);
            this.minesCountInput.Name = "minesCountInput";
            this.minesCountInput.Size = new System.Drawing.Size(52, 20);
            this.minesCountInput.TabIndex = 6;
            this.minesCountInput.Text = "10";
            this.minesCountInput.Leave += MinesCountInput_Leave;
            // 
            // radioButtonCustom
            // 
            this.radioButtonCustom.AutoSize = true;
            this.radioButtonCustom.Location = new System.Drawing.Point(215, 33);
            this.radioButtonCustom.Name = "radioButtonCustom";
            this.radioButtonCustom.Size = new System.Drawing.Size(109, 17);
            this.radioButtonCustom.TabIndex = 3;
            this.radioButtonCustom.Text = "Свои настройки:";
            this.radioButtonCustom.UseVisualStyleBackColor = true;
            this.radioButtonCustom.CheckedChanged += new System.EventHandler(this.RadioButtonCustom_CheckedChanged);
            // 
            // radioButtonPro
            // 
            this.radioButtonPro.AutoSize = true;
            this.radioButtonPro.Location = new System.Drawing.Point(7, 171);
            this.radioButtonPro.Name = "radioButtonPro";
            this.radioButtonPro.Size = new System.Drawing.Size(119, 43);
            this.radioButtonPro.TabIndex = 2;
            this.radioButtonPro.Text = "Профессионал\r\n99 мин\r\nполе 16 х 30 ячеек";
            this.radioButtonPro.UseVisualStyleBackColor = true;
            this.radioButtonPro.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButtonMedium
            // 
            this.radioButtonMedium.AutoSize = true;
            this.radioButtonMedium.Location = new System.Drawing.Point(7, 94);
            this.radioButtonMedium.Name = "radioButtonMedium";
            this.radioButtonMedium.Size = new System.Drawing.Size(119, 43);
            this.radioButtonMedium.TabIndex = 1;
            this.radioButtonMedium.Text = "Любитель\r\n40 мин\r\nполе 16 х 16 ячеек";
            this.radioButtonMedium.UseVisualStyleBackColor = true;
            this.radioButtonMedium.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButtonNovice
            // 
            this.radioButtonNovice.AutoSize = true;
            this.radioButtonNovice.Checked = true;
            this.radioButtonNovice.Location = new System.Drawing.Point(7, 20);
            this.radioButtonNovice.Name = "radioButtonNovice";
            this.radioButtonNovice.Size = new System.Drawing.Size(107, 43);
            this.radioButtonNovice.TabIndex = 0;
            this.radioButtonNovice.TabStop = true;
            this.radioButtonNovice.Text = "Новичок\r\n10 мин\r\nполе 9 х 9 ячеек";
            this.radioButtonNovice.UseVisualStyleBackColor = true;
            this.radioButtonNovice.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(135, 274);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "ОК";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(258, 274);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(482, 326);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.levelSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.levelSettings.ResumeLayout(false);
            this.levelSettings.PerformLayout();
            this.customSettingsGroup.ResumeLayout(false);
            this.customSettingsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox levelSettings;
        private System.Windows.Forms.RadioButton radioButtonCustom;
        private System.Windows.Forms.RadioButton radioButtonPro;
        private System.Windows.Forms.RadioButton radioButtonMedium;
        private System.Windows.Forms.RadioButton radioButtonNovice;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox minesCountInput;
        private System.Windows.Forms.TextBox widthInput;
        private System.Windows.Forms.TextBox heightInput;
        private System.Windows.Forms.GroupBox customSettingsGroup;
    }
}