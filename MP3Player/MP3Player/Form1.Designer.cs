namespace MP3Player
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlayButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LoopCB = new System.Windows.Forms.CheckBox();
            this.PauseButton = new System.Windows.Forms.Button();
            this.UpVolButton = new System.Windows.Forms.Button();
            this.DwnVolButton = new System.Windows.Forms.Button();
            this.VolLabel = new System.Windows.Forms.Label();
            this.PlrPanel = new System.Windows.Forms.Panel();
            this.PlrPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(17, 42);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(179, 42);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(274, 3);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(265, 22);
            this.textBox1.TabIndex = 3;
            // 
            // LoopCB
            // 
            this.LoopCB.AutoSize = true;
            this.LoopCB.Location = new System.Drawing.Point(269, 46);
            this.LoopCB.Name = "LoopCB";
            this.LoopCB.Size = new System.Drawing.Size(80, 17);
            this.LoopCB.TabIndex = 4;
            this.LoopCB.Text = "Loop track";
            this.LoopCB.UseVisualStyleBackColor = true;
            this.LoopCB.CheckedChanged += new System.EventHandler(this.LoopCB_CheckedChanged);
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(98, 42);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(75, 23);
            this.PauseButton.TabIndex = 5;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // UpVolButton
            // 
            this.UpVolButton.Location = new System.Drawing.Point(355, 3);
            this.UpVolButton.Name = "UpVolButton";
            this.UpVolButton.Size = new System.Drawing.Size(57, 23);
            this.UpVolButton.TabIndex = 6;
            this.UpVolButton.Text = "UpVol";
            this.UpVolButton.UseVisualStyleBackColor = true;
            this.UpVolButton.Click += new System.EventHandler(this.UpVolButton_Click);
            // 
            // DwnVolButton
            // 
            this.DwnVolButton.Location = new System.Drawing.Point(355, 54);
            this.DwnVolButton.Name = "DwnVolButton";
            this.DwnVolButton.Size = new System.Drawing.Size(57, 23);
            this.DwnVolButton.TabIndex = 7;
            this.DwnVolButton.Text = "DwnVol";
            this.DwnVolButton.UseVisualStyleBackColor = true;
            this.DwnVolButton.Click += new System.EventHandler(this.DwnVolButton_Click);
            // 
            // VolLabel
            // 
            this.VolLabel.AutoSize = true;
            this.VolLabel.Location = new System.Drawing.Point(371, 33);
            this.VolLabel.Name = "VolLabel";
            this.VolLabel.Size = new System.Drawing.Size(28, 13);
            this.VolLabel.TabIndex = 8;
            this.VolLabel.Text = "50%";
            // 
            // PlrPanel
            // 
            this.PlrPanel.Controls.Add(this.PlayButton);
            this.PlrPanel.Controls.Add(this.LoopCB);
            this.PlrPanel.Controls.Add(this.textBox1);
            this.PlrPanel.Controls.Add(this.PauseButton);
            this.PlrPanel.Controls.Add(this.BrowseButton);
            this.PlrPanel.Controls.Add(this.StopButton);
            this.PlrPanel.Controls.Add(this.UpVolButton);
            this.PlrPanel.Controls.Add(this.VolLabel);
            this.PlrPanel.Controls.Add(this.DwnVolButton);
            this.PlrPanel.Location = new System.Drawing.Point(3, 2);
            this.PlrPanel.Name = "PlrPanel";
            this.PlrPanel.Size = new System.Drawing.Size(419, 81);
            this.PlrPanel.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 84);
            this.Controls.Add(this.PlrPanel);
            this.Name = "Form1";
            this.Text = "MP3 Player";
            this.PlrPanel.ResumeLayout(false);
            this.PlrPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox LoopCB;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button UpVolButton;
        private System.Windows.Forms.Button DwnVolButton;
        private System.Windows.Forms.Label VolLabel;
        private System.Windows.Forms.Panel PlrPanel;
    }
}

