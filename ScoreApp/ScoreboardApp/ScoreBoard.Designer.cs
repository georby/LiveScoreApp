namespace ScoreApp
{
    partial class ScoreBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreBoard));
            this.gridScoreBoard = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridScoreBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // gridScoreBoard
            // 
            this.gridScoreBoard.AllowUserToAddRows = false;
            this.gridScoreBoard.AllowUserToDeleteRows = false;
            this.gridScoreBoard.AllowUserToOrderColumns = true;
            this.gridScoreBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridScoreBoard.Location = new System.Drawing.Point(90, 90);
            this.gridScoreBoard.Name = "gridScoreBoard";
            this.gridScoreBoard.ReadOnly = true;
            this.gridScoreBoard.RowHeadersWidth = 51;
            this.gridScoreBoard.RowTemplate.Height = 24;
            this.gridScoreBoard.Size = new System.Drawing.Size(800, 600);
            this.gridScoreBoard.TabIndex = 0;
            // 
            // ScoreBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 703);
            this.Controls.Add(this.gridScoreBoard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScoreBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Score Board";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScoreBoard_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridScoreBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridScoreBoard;
    }
}

