namespace Academits.DargeevAleksandr
{
    partial class UserInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fromGroup = new System.Windows.Forms.GroupBox();
            this.fromFahrenheit = new System.Windows.Forms.RadioButton();
            this.fromKelvin = new System.Windows.Forms.RadioButton();
            this.fromCelsius = new System.Windows.Forms.RadioButton();
            this.inputTemperature = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.convertButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toGroup = new System.Windows.Forms.GroupBox();
            this.toFahrenheit = new System.Windows.Forms.RadioButton();
            this.toKelvin = new System.Windows.Forms.RadioButton();
            this.toCelsius = new System.Windows.Forms.RadioButton();
            this.outputTemperature = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.fromGroup.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(636, 200);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 55);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(630, 137);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.fromGroup);
            this.panel1.Controls.Add(this.inputTemperature);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 131);
            this.panel1.TabIndex = 4;
            // 
            // fromGroup
            // 
            this.fromGroup.AutoSize = true;
            this.fromGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fromGroup.Controls.Add(this.fromFahrenheit);
            this.fromGroup.Controls.Add(this.fromKelvin);
            this.fromGroup.Controls.Add(this.fromCelsius);
            this.fromGroup.Location = new System.Drawing.Point(38, 13);
            this.fromGroup.Margin = new System.Windows.Forms.Padding(0);
            this.fromGroup.Name = "fromGroup";
            this.fromGroup.Size = new System.Drawing.Size(120, 56);
            this.fromGroup.TabIndex = 1;
            this.fromGroup.TabStop = false;
            // 
            // fromFahrenheit
            // 
            this.fromFahrenheit.AutoSize = true;
            this.fromFahrenheit.Location = new System.Drawing.Point(83, 20);
            this.fromFahrenheit.Name = "fromFahrenheit";
            this.fromFahrenheit.Size = new System.Drawing.Size(31, 17);
            this.fromFahrenheit.TabIndex = 2;
            this.fromFahrenheit.Text = "F";
            this.fromFahrenheit.UseVisualStyleBackColor = true;
            this.fromFahrenheit.CheckedChanged += new System.EventHandler(this.From_CheckedChanged);
            // 
            // fromKelvin
            // 
            this.fromKelvin.AutoSize = true;
            this.fromKelvin.Location = new System.Drawing.Point(45, 20);
            this.fromKelvin.Name = "fromKelvin";
            this.fromKelvin.Size = new System.Drawing.Size(32, 17);
            this.fromKelvin.TabIndex = 1;
            this.fromKelvin.Text = "K";
            this.fromKelvin.UseVisualStyleBackColor = true;
            this.fromKelvin.CheckedChanged += new System.EventHandler(this.From_CheckedChanged);
            // 
            // fromCelsius
            // 
            this.fromCelsius.AutoSize = true;
            this.fromCelsius.Checked = true;
            this.fromCelsius.Location = new System.Drawing.Point(7, 20);
            this.fromCelsius.Name = "fromCelsius";
            this.fromCelsius.Size = new System.Drawing.Size(32, 17);
            this.fromCelsius.TabIndex = 0;
            this.fromCelsius.TabStop = true;
            this.fromCelsius.Text = "C";
            this.fromCelsius.UseVisualStyleBackColor = true;
            this.fromCelsius.CheckedChanged += new System.EventHandler(this.From_CheckedChanged);
            // 
            // inputTemperature
            // 
            this.inputTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputTemperature.Location = new System.Drawing.Point(3, 72);
            this.inputTemperature.Name = "inputTemperature";
            this.inputTemperature.Size = new System.Drawing.Size(200, 56);
            this.inputTemperature.TabIndex = 0;
            this.inputTemperature.TextChanged += new System.EventHandler(this.InputTemperature_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel3.Controls.Add(this.convertButton);
            this.panel3.Location = new System.Drawing.Point(215, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 59);
            this.panel3.TabIndex = 4;
            // 
            // convertButton
            // 
            this.convertButton.Image = ((System.Drawing.Image)(resources.GetObject("convertButton.Image")));
            this.convertButton.Location = new System.Drawing.Point(59, 10);
            this.convertButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(80, 40);
            this.convertButton.TabIndex = 1;
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.toGroup);
            this.panel2.Controls.Add(this.outputTemperature);
            this.panel2.Location = new System.Drawing.Point(421, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 128);
            this.panel2.TabIndex = 5;
            // 
            // toGroup
            // 
            this.toGroup.Controls.Add(this.toFahrenheit);
            this.toGroup.Controls.Add(this.toKelvin);
            this.toGroup.Controls.Add(this.toCelsius);
            this.toGroup.Location = new System.Drawing.Point(39, 12);
            this.toGroup.Name = "toGroup";
            this.toGroup.Size = new System.Drawing.Size(124, 57);
            this.toGroup.TabIndex = 3;
            this.toGroup.TabStop = false;
            // 
            // toFahrenheit
            // 
            this.toFahrenheit.AutoSize = true;
            this.toFahrenheit.Location = new System.Drawing.Point(83, 20);
            this.toFahrenheit.Name = "toFahrenheit";
            this.toFahrenheit.Size = new System.Drawing.Size(31, 17);
            this.toFahrenheit.TabIndex = 2;
            this.toFahrenheit.Text = "F";
            this.toFahrenheit.UseVisualStyleBackColor = true;
            this.toFahrenheit.CheckedChanged += new System.EventHandler(this.To_CheckedChanged);
            // 
            // toKelvin
            // 
            this.toKelvin.AutoSize = true;
            this.toKelvin.Checked = true;
            this.toKelvin.Location = new System.Drawing.Point(45, 20);
            this.toKelvin.Name = "toKelvin";
            this.toKelvin.Size = new System.Drawing.Size(32, 17);
            this.toKelvin.TabIndex = 1;
            this.toKelvin.TabStop = true;
            this.toKelvin.Text = "K";
            this.toKelvin.UseVisualStyleBackColor = true;
            this.toKelvin.CheckedChanged += new System.EventHandler(this.To_CheckedChanged);
            // 
            // toCelsius
            // 
            this.toCelsius.AutoSize = true;
            this.toCelsius.Location = new System.Drawing.Point(7, 20);
            this.toCelsius.Name = "toCelsius";
            this.toCelsius.Size = new System.Drawing.Size(32, 17);
            this.toCelsius.TabIndex = 0;
            this.toCelsius.Text = "C";
            this.toCelsius.UseVisualStyleBackColor = true;
            this.toCelsius.CheckedChanged += new System.EventHandler(this.To_CheckedChanged);
            // 
            // outputTemperature
            // 
            this.outputTemperature.BackColor = System.Drawing.SystemColors.ControlLight;
            this.outputTemperature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.outputTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputTemperature.Location = new System.Drawing.Point(3, 72);
            this.outputTemperature.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.outputTemperature.MinimumSize = new System.Drawing.Size(200, 0);
            this.outputTemperature.Name = "outputTemperature";
            this.outputTemperature.Size = new System.Drawing.Size(200, 56);
            this.outputTemperature.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(15, 20, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите температуру:";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 200);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UserInterface";
            this.Text = "Перевод температур";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.fromGroup.ResumeLayout(false);
            this.fromGroup.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.toGroup.ResumeLayout(false);
            this.toGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox inputTemperature;
        private System.Windows.Forms.Label outputTemperature;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox fromGroup;
        private System.Windows.Forms.RadioButton fromFahrenheit;
        private System.Windows.Forms.RadioButton fromKelvin;
        private System.Windows.Forms.RadioButton fromCelsius;
        private System.Windows.Forms.GroupBox toGroup;
        private System.Windows.Forms.RadioButton toFahrenheit;
        private System.Windows.Forms.RadioButton toKelvin;
        private System.Windows.Forms.RadioButton toCelsius;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Label label1;
    }
}

