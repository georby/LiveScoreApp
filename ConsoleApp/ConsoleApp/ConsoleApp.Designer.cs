namespace ConsoleApp
{
    partial class ConsoleApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleApp));
            this.lblConsoleNumber = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtConsoleNumber = new System.Windows.Forms.TextBox();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnSendScores = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblConsoleNumber
            // 
            this.lblConsoleNumber.AutoSize = true;
            this.lblConsoleNumber.Location = new System.Drawing.Point(29, 64);
            this.lblConsoleNumber.Name = "lblConsoleNumber";
            this.lblConsoleNumber.Size = new System.Drawing.Size(113, 17);
            this.lblConsoleNumber.TabIndex = 0;
            this.lblConsoleNumber.Text = "Console Number";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(29, 105);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(45, 17);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(29, 145);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(89, 17);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.Text = "Player Name";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(29, 188);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 17);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status";
            // 
            // txtConsoleNumber
            // 
            this.txtConsoleNumber.Location = new System.Drawing.Point(191, 64);
            this.txtConsoleNumber.Name = "txtConsoleNumber";
            this.txtConsoleNumber.Size = new System.Drawing.Size(167, 22);
            this.txtConsoleNumber.TabIndex = 1;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(191, 102);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(167, 22);
            this.txtScore.TabIndex = 2;
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(191, 142);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(167, 22);
            this.txtPlayerName.TabIndex = 3;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Online",
            "Idle"});
            this.cbStatus.Location = new System.Drawing.Point(191, 179);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(167, 24);
            this.cbStatus.TabIndex = 4;
            // 
            // btnSendScores
            // 
            this.btnSendScores.Location = new System.Drawing.Point(117, 253);
            this.btnSendScores.Name = "btnSendScores";
            this.btnSendScores.Size = new System.Drawing.Size(169, 51);
            this.btnSendScores.TabIndex = 5;
            this.btnSendScores.Text = "Send Score";
            this.btnSendScores.UseVisualStyleBackColor = true;
            this.btnSendScores.Click += new System.EventHandler(this.BtnSendScores_Click);
            // 
            // ConsoleApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 344);
            this.Controls.Add(this.btnSendScores);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.txtConsoleNumber);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblConsoleNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsoleApp";
            this.Text = "Console App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsoleApp_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConsoleNumber;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtConsoleNumber;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnSendScores;
    }
}

