namespace WindowsInfos
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
            this.RB = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TempListBox = new System.Windows.Forms.ListBox();
            this.GTButton = new System.Windows.Forms.Button();
            this.HDDTempTB = new System.Windows.Forms.RichTextBox();
            this.TestTB = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RB
            // 
            this.RB.Location = new System.Drawing.Point(12, 22);
            this.RB.Name = "RB";
            this.RB.Size = new System.Drawing.Size(312, 179);
            this.RB.TabIndex = 0;
            this.RB.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Информация о сети";
            // 
            // TempListBox
            // 
            this.TempListBox.FormattingEnabled = true;
            this.TempListBox.Location = new System.Drawing.Point(15, 237);
            this.TempListBox.Name = "TempListBox";
            this.TempListBox.Size = new System.Drawing.Size(149, 95);
            this.TempListBox.TabIndex = 2;
            // 
            // GTButton
            // 
            this.GTButton.Location = new System.Drawing.Point(194, 339);
            this.GTButton.Name = "GTButton";
            this.GTButton.Size = new System.Drawing.Size(120, 27);
            this.GTButton.TabIndex = 3;
            this.GTButton.Text = "Get info";
            this.GTButton.UseVisualStyleBackColor = true;
            this.GTButton.Click += new System.EventHandler(this.GTButton_Click);
            // 
            // HDDTempTB
            // 
            this.HDDTempTB.Location = new System.Drawing.Point(170, 237);
            this.HDDTempTB.Name = "HDDTempTB";
            this.HDDTempTB.Size = new System.Drawing.Size(154, 96);
            this.HDDTempTB.TabIndex = 4;
            this.HDDTempTB.Text = "";
            // 
            // TestTB
            // 
            this.TestTB.Location = new System.Drawing.Point(12, 372);
            this.TestTB.Name = "TestTB";
            this.TestTB.Size = new System.Drawing.Size(319, 74);
            this.TestTB.TabIndex = 5;
            this.TestTB.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Температура  CPUs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Температура HDDs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Информация о ресурсах";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 447);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TestTB);
            this.Controls.Add(this.HDDTempTB);
            this.Controls.Add(this.GTButton);
            this.Controls.Add(this.TempListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RB);
            this.Name = "Form1";
            this.Text = "WinInfo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox TempListBox;
        private System.Windows.Forms.Button GTButton;
        private System.Windows.Forms.RichTextBox HDDTempTB;
        private System.Windows.Forms.RichTextBox TestTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;



    }
}

