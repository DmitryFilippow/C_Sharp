namespace WindowsChat
{
    partial class LocalChatForm
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
            this.ChatBox = new System.Windows.Forms.RichTextBox();
            this.Message = new System.Windows.Forms.RichTextBox();
            this.SendMsgButton = new System.Windows.Forms.Button();
            this.IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(-1, 37);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.Size = new System.Drawing.Size(441, 182);
            this.ChatBox.TabIndex = 1;
            this.ChatBox.Text = "";
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(-1, 225);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(441, 102);
            this.Message.TabIndex = 2;
            this.Message.Text = "";
            this.Message.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Message_KeyPress);
            // 
            // SendMsgButton
            // 
            this.SendMsgButton.Location = new System.Drawing.Point(313, 8);
            this.SendMsgButton.Name = "SendMsgButton";
            this.SendMsgButton.Size = new System.Drawing.Size(127, 23);
            this.SendMsgButton.TabIndex = 3;
            this.SendMsgButton.Text = "Отправить(Enter)";
            this.SendMsgButton.UseVisualStyleBackColor = true;
            this.SendMsgButton.Click += new System.EventHandler(this.SendMsgButton_Click);
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(34, 10);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(273, 22);
            this.IP.TabIndex = 4;
            this.IP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP";
            // 
            // LocalChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 331);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.SendMsgButton);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.ChatBox);
            this.Name = "LocalChatForm";
            this.Text = "Local chat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LocalChatForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public  System.Windows.Forms.RichTextBox ChatBox;
        public  System.Windows.Forms.RichTextBox Message;
        public System.Windows.Forms.Button SendMsgButton;
        public System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Label label1;
    }
}

