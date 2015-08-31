namespace GameCheatsDBSQL
{
    partial class CheatsDBForm
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
            this.SaveCFGButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dbSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.dbSL1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dbSLok = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConStrTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CoonectDBButton = new System.Windows.Forms.Button();
            this.CFGPanel = new System.Windows.Forms.Panel();
            this.DBContentPanel = new System.Windows.Forms.Panel();
            this.BackupDBButton = new System.Windows.Forms.Button();
            this.GLabel = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.ClearBaseButton = new System.Windows.Forms.Button();
            this.BrowseSaveFileCheat = new System.Windows.Forms.Button();
            this.BrowseLoadFileCheat = new System.Windows.Forms.Button();
            this.TestLabel2 = new System.Windows.Forms.Label();
            this.TestLabel1 = new System.Windows.Forms.Label();
            this.FindDBButton = new System.Windows.Forms.Button();
            this.EditDBButton = new System.Windows.Forms.Button();
            this.DelFromDBButton = new System.Windows.Forms.Button();
            this.GameNameTB = new System.Windows.Forms.TextBox();
            this.AddToBaseButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GenreCB = new System.Windows.Forms.ComboBox();
            this.GameLB = new System.Windows.Forms.ListBox();
            this.CheatContRTB = new System.Windows.Forms.RichTextBox();
            this.BrowseCFD = new System.Windows.Forms.OpenFileDialog();
            this.BrowseSCFD = new System.Windows.Forms.SaveFileDialog();
            this.RestoreDBButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.CFGPanel.SuspendLayout();
            this.DBContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveCFGButton
            // 
            this.SaveCFGButton.Location = new System.Drawing.Point(556, 6);
            this.SaveCFGButton.Name = "SaveCFGButton";
            this.SaveCFGButton.Size = new System.Drawing.Size(135, 23);
            this.SaveCFGButton.TabIndex = 0;
            this.SaveCFGButton.Text = "Сохранить наст-ки";
            this.SaveCFGButton.UseVisualStyleBackColor = true;
            this.SaveCFGButton.Click += new System.EventHandler(this.SaveCFGButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbSL,
            this.dbSL1,
            this.dbSLok});
            this.statusStrip1.Location = new System.Drawing.Point(0, 514);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(862, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dbSL
            // 
            this.dbSL.Name = "dbSL";
            this.dbSL.Size = new System.Drawing.Size(95, 17);
            this.dbSL.Text = "Загруженная БД:";
            // 
            // dbSL1
            // 
            this.dbSL1.Name = "dbSL1";
            this.dbSL1.Size = new System.Drawing.Size(11, 17);
            this.dbSL1.Text = "-";
            // 
            // dbSLok
            // 
            this.dbSLok.Name = "dbSLok";
            this.dbSLok.Size = new System.Drawing.Size(25, 17);
            this.dbSLok.Text = ":fail";
            // 
            // ConStrTB
            // 
            this.ConStrTB.Location = new System.Drawing.Point(131, 8);
            this.ConStrTB.Name = "ConStrTB";
            this.ConStrTB.Size = new System.Drawing.Size(422, 22);
            this.ConStrTB.TabIndex = 2;
            this.ConStrTB.TextChanged += new System.EventHandler(this.ConStrTB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Строка подключения";
            // 
            // CoonectDBButton
            // 
            this.CoonectDBButton.Location = new System.Drawing.Point(716, 16);
            this.CoonectDBButton.Name = "CoonectDBButton";
            this.CoonectDBButton.Size = new System.Drawing.Size(135, 23);
            this.CoonectDBButton.TabIndex = 4;
            this.CoonectDBButton.Text = "Соединиться с БД";
            this.CoonectDBButton.UseVisualStyleBackColor = true;
            this.CoonectDBButton.Click += new System.EventHandler(this.CoonectDBButton_Click);
            // 
            // CFGPanel
            // 
            this.CFGPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CFGPanel.Controls.Add(this.label1);
            this.CFGPanel.Controls.Add(this.ConStrTB);
            this.CFGPanel.Controls.Add(this.SaveCFGButton);
            this.CFGPanel.Enabled = false;
            this.CFGPanel.Location = new System.Drawing.Point(12, 9);
            this.CFGPanel.Name = "CFGPanel";
            this.CFGPanel.Size = new System.Drawing.Size(699, 35);
            this.CFGPanel.TabIndex = 5;
            // 
            // DBContentPanel
            // 
            this.DBContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DBContentPanel.Controls.Add(this.RestoreDBButton);
            this.DBContentPanel.Controls.Add(this.BackupDBButton);
            this.DBContentPanel.Controls.Add(this.GLabel);
            this.DBContentPanel.Controls.Add(this.Label5);
            this.DBContentPanel.Controls.Add(this.ClearBaseButton);
            this.DBContentPanel.Controls.Add(this.BrowseSaveFileCheat);
            this.DBContentPanel.Controls.Add(this.BrowseLoadFileCheat);
            this.DBContentPanel.Controls.Add(this.TestLabel2);
            this.DBContentPanel.Controls.Add(this.TestLabel1);
            this.DBContentPanel.Controls.Add(this.FindDBButton);
            this.DBContentPanel.Controls.Add(this.EditDBButton);
            this.DBContentPanel.Controls.Add(this.DelFromDBButton);
            this.DBContentPanel.Controls.Add(this.GameNameTB);
            this.DBContentPanel.Controls.Add(this.AddToBaseButton);
            this.DBContentPanel.Controls.Add(this.label4);
            this.DBContentPanel.Controls.Add(this.label3);
            this.DBContentPanel.Controls.Add(this.label2);
            this.DBContentPanel.Controls.Add(this.GenreCB);
            this.DBContentPanel.Controls.Add(this.GameLB);
            this.DBContentPanel.Controls.Add(this.CheatContRTB);
            this.DBContentPanel.Enabled = false;
            this.DBContentPanel.Location = new System.Drawing.Point(12, 50);
            this.DBContentPanel.Name = "DBContentPanel";
            this.DBContentPanel.Size = new System.Drawing.Size(839, 450);
            this.DBContentPanel.TabIndex = 7;
            // 
            // BackupDBButton
            // 
            this.BackupDBButton.Location = new System.Drawing.Point(622, 420);
            this.BackupDBButton.Name = "BackupDBButton";
            this.BackupDBButton.Size = new System.Drawing.Size(84, 23);
            this.BackupDBButton.TabIndex = 18;
            this.BackupDBButton.Text = "Бэкапим DB";
            this.BackupDBButton.UseVisualStyleBackColor = true;
            this.BackupDBButton.Click += new System.EventHandler(this.BackupDBButton_Click);
            // 
            // GLabel
            // 
            this.GLabel.AutoSize = true;
            this.GLabel.Location = new System.Drawing.Point(61, 395);
            this.GLabel.Name = "GLabel";
            this.GLabel.Size = new System.Drawing.Size(38, 13);
            this.GLabel.TabIndex = 17;
            this.GLabel.Text = "Жанр";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(16, 394);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(41, 13);
            this.Label5.TabIndex = 16;
            this.Label5.Text = "Жанр:";
            // 
            // ClearBaseButton
            // 
            this.ClearBaseButton.Location = new System.Drawing.Point(712, 420);
            this.ClearBaseButton.Name = "ClearBaseButton";
            this.ClearBaseButton.Size = new System.Drawing.Size(120, 23);
            this.ClearBaseButton.TabIndex = 15;
            this.ClearBaseButton.Text = "Очистить базу";
            this.ClearBaseButton.UseVisualStyleBackColor = true;
            this.ClearBaseButton.Click += new System.EventHandler(this.ClearBaseButton_Click);
            // 
            // BrowseSaveFileCheat
            // 
            this.BrowseSaveFileCheat.Location = new System.Drawing.Point(415, 420);
            this.BrowseSaveFileCheat.Name = "BrowseSaveFileCheat";
            this.BrowseSaveFileCheat.Size = new System.Drawing.Size(200, 23);
            this.BrowseSaveFileCheat.TabIndex = 14;
            this.BrowseSaveFileCheat.Text = "Сохраняем cheat file(CTRL+S)";
            this.BrowseSaveFileCheat.UseVisualStyleBackColor = true;
            this.BrowseSaveFileCheat.Click += new System.EventHandler(this.BrowseSaveFileCheat_Click);
            // 
            // BrowseLoadFileCheat
            // 
            this.BrowseLoadFileCheat.Location = new System.Drawing.Point(192, 420);
            this.BrowseLoadFileCheat.Name = "BrowseLoadFileCheat";
            this.BrowseLoadFileCheat.Size = new System.Drawing.Size(213, 23);
            this.BrowseLoadFileCheat.TabIndex = 13;
            this.BrowseLoadFileCheat.Text = "Привязать cheat file...(CTRL+L)";
            this.BrowseLoadFileCheat.UseVisualStyleBackColor = true;
            this.BrowseLoadFileCheat.Click += new System.EventHandler(this.BrowseFileCheat_Click);
            // 
            // TestLabel2
            // 
            this.TestLabel2.AutoSize = true;
            this.TestLabel2.Location = new System.Drawing.Point(256, 394);
            this.TestLabel2.Name = "TestLabel2";
            this.TestLabel2.Size = new System.Drawing.Size(23, 13);
            this.TestLabel2.TabIndex = 12;
            this.TestLabel2.Text = "----";
            // 
            // TestLabel1
            // 
            this.TestLabel1.AutoSize = true;
            this.TestLabel1.Location = new System.Drawing.Point(146, 395);
            this.TestLabel1.Name = "TestLabel1";
            this.TestLabel1.Size = new System.Drawing.Size(115, 13);
            this.TestLabel1.TabIndex = 11;
            this.TestLabel1.Text = "Привязанный файл:";
            // 
            // FindDBButton
            // 
            this.FindDBButton.Location = new System.Drawing.Point(11, 360);
            this.FindDBButton.Name = "FindDBButton";
            this.FindDBButton.Size = new System.Drawing.Size(120, 23);
            this.FindDBButton.TabIndex = 10;
            this.FindDBButton.Text = "Найти игру";
            this.FindDBButton.UseVisualStyleBackColor = true;
            this.FindDBButton.Click += new System.EventHandler(this.FindDBButton_Click);
            // 
            // EditDBButton
            // 
            this.EditDBButton.Location = new System.Drawing.Point(11, 331);
            this.EditDBButton.Name = "EditDBButton";
            this.EditDBButton.Size = new System.Drawing.Size(120, 23);
            this.EditDBButton.TabIndex = 9;
            this.EditDBButton.Text = "Поправить cheat";
            this.EditDBButton.UseVisualStyleBackColor = true;
            this.EditDBButton.Click += new System.EventHandler(this.EditDBButton_Click);
            // 
            // DelFromDBButton
            // 
            this.DelFromDBButton.Location = new System.Drawing.Point(11, 302);
            this.DelFromDBButton.Name = "DelFromDBButton";
            this.DelFromDBButton.Size = new System.Drawing.Size(120, 23);
            this.DelFromDBButton.TabIndex = 8;
            this.DelFromDBButton.Text = "Удалить игру";
            this.DelFromDBButton.UseVisualStyleBackColor = true;
            this.DelFromDBButton.Click += new System.EventHandler(this.DelFromDBButton_Click);
            // 
            // GameNameTB
            // 
            this.GameNameTB.Location = new System.Drawing.Point(48, 274);
            this.GameNameTB.Name = "GameNameTB";
            this.GameNameTB.Size = new System.Drawing.Size(83, 22);
            this.GameNameTB.TabIndex = 7;
            this.GameNameTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameNameTB_KeyDown);
            // 
            // AddToBaseButton
            // 
            this.AddToBaseButton.Location = new System.Drawing.Point(16, 420);
            this.AddToBaseButton.Name = "AddToBaseButton";
            this.AddToBaseButton.Size = new System.Drawing.Size(170, 23);
            this.AddToBaseButton.TabIndex = 6;
            this.AddToBaseButton.Text = "Добавить игру(CTRL+A)";
            this.AddToBaseButton.UseVisualStyleBackColor = true;
            this.AddToBaseButton.Click += new System.EventHandler(this.AddToBaseButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Игра";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Жанр игр";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cheats для выбранной игры";
            // 
            // GenreCB
            // 
            this.GenreCB.FormattingEnabled = true;
            this.GenreCB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GenreCB.Location = new System.Drawing.Point(10, 23);
            this.GenreCB.Name = "GenreCB";
            this.GenreCB.Size = new System.Drawing.Size(121, 21);
            this.GenreCB.TabIndex = 2;
            this.GenreCB.SelectedIndexChanged += new System.EventHandler(this.GenreCB_SelectedIndexChanged);
            // 
            // GameLB
            // 
            this.GameLB.FormattingEnabled = true;
            this.GameLB.Location = new System.Drawing.Point(11, 69);
            this.GameLB.Name = "GameLB";
            this.GameLB.Size = new System.Drawing.Size(120, 199);
            this.GameLB.Sorted = true;
            this.GameLB.TabIndex = 1;
            this.GameLB.SelectedIndexChanged += new System.EventHandler(this.GameLB_SelectedIndexChanged);
            // 
            // CheatContRTB
            // 
            this.CheatContRTB.AcceptsTab = true;
            this.CheatContRTB.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheatContRTB.Location = new System.Drawing.Point(143, 23);
            this.CheatContRTB.Name = "CheatContRTB";
            this.CheatContRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.CheatContRTB.Size = new System.Drawing.Size(689, 368);
            this.CheatContRTB.TabIndex = 0;
            this.CheatContRTB.Text = "";
            this.CheatContRTB.WordWrap = false;
            this.CheatContRTB.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.CheatContRTB_LinkClicked);
            // 
            // BrowseCFD
            // 
            this.BrowseCFD.Filter = "|*.*|*.txt|";
            this.BrowseCFD.FilterIndex = 2;
            // 
            // BrowseSCFD
            // 
            this.BrowseSCFD.DefaultExt = "txt";
            this.BrowseSCFD.Filter = "|*.*|*.txt|";
            this.BrowseSCFD.FilterIndex = 2;
            this.BrowseSCFD.FileOk += new System.ComponentModel.CancelEventHandler(this.BrowseSCFD_FileOk);
            // 
            // RestoreDBButton
            // 
            this.RestoreDBButton.Location = new System.Drawing.Point(622, 394);
            this.RestoreDBButton.Name = "RestoreDBButton";
            this.RestoreDBButton.Size = new System.Drawing.Size(84, 23);
            this.RestoreDBButton.TabIndex = 19;
            this.RestoreDBButton.Text = "Восcтань DB!";
            this.RestoreDBButton.UseVisualStyleBackColor = true;
            this.RestoreDBButton.Click += new System.EventHandler(this.RestoreDBButton_Click);
            // 
            // CheatsDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(862, 536);
            this.Controls.Add(this.DBContentPanel);
            this.Controls.Add(this.CFGPanel);
            this.Controls.Add(this.CoonectDBButton);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "CheatsDBForm";
            this.Text = "Game cheats DB";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CheatsDBForm_FormClosed);
            this.Load += new System.EventHandler(this.CheatsDBForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheatsDBForm_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.CFGPanel.ResumeLayout(false);
            this.CFGPanel.PerformLayout();
            this.DBContentPanel.ResumeLayout(false);
            this.DBContentPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveCFGButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel dbSL;
        private System.Windows.Forms.ToolStripStatusLabel dbSL1;
        private System.Windows.Forms.ToolStripStatusLabel dbSLok;
        private System.Windows.Forms.TextBox ConStrTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CoonectDBButton;
        private System.Windows.Forms.Panel CFGPanel;
        private System.Windows.Forms.Panel DBContentPanel;
        private System.Windows.Forms.ComboBox GenreCB;
        private System.Windows.Forms.ListBox GameLB;
        private System.Windows.Forms.RichTextBox CheatContRTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DelFromDBButton;
        private System.Windows.Forms.TextBox GameNameTB;
        private System.Windows.Forms.Button AddToBaseButton;
        private System.Windows.Forms.Button FindDBButton;
        private System.Windows.Forms.Button EditDBButton;
        private System.Windows.Forms.Label TestLabel1;
        private System.Windows.Forms.Button BrowseLoadFileCheat;
        private System.Windows.Forms.OpenFileDialog BrowseCFD;
        private System.Windows.Forms.Button BrowseSaveFileCheat;
        private System.Windows.Forms.SaveFileDialog BrowseSCFD;
        private System.Windows.Forms.Button ClearBaseButton;
        private System.Windows.Forms.Label TestLabel2;
        private System.Windows.Forms.Label GLabel;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Button BackupDBButton;
        private System.Windows.Forms.Button RestoreDBButton;
    }
}