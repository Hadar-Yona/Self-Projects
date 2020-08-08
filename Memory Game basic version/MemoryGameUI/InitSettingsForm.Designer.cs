namespace Project1
{
    partial class InitSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitSettingsForm));
            this.firstPlayerNameLabel = new System.Windows.Forms.Label();
            this.secondPlayerNameLabel = new System.Windows.Forms.Label();
            this.firstPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.secondPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.againstFriendButton = new System.Windows.Forms.Button();
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.boardSizeButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstPlayerNameLabel
            // 
            this.firstPlayerNameLabel.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.firstPlayerNameLabel, "firstPlayerNameLabel");
            this.firstPlayerNameLabel.Name = "firstPlayerNameLabel";
            // 
            // secondPlayerNameLabel
            // 
            resources.ApplyResources(this.secondPlayerNameLabel, "secondPlayerNameLabel");
            this.secondPlayerNameLabel.Name = "secondPlayerNameLabel";
            // 
            // m_FirstPlayerNameTextBox
            // 
            resources.ApplyResources(this.firstPlayerNameTextBox, "m_FirstPlayerNameTextBox");
            this.firstPlayerNameTextBox.Name = "m_FirstPlayerNameTextBox";
            // 
            // m_SecondPlayerNameTextBox
            // 
            this.secondPlayerNameTextBox.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.secondPlayerNameTextBox, "m_SecondPlayerNameTextBox");
            this.secondPlayerNameTextBox.Name = "m_SecondPlayerNameTextBox";
            // 
            // m_AgainstFriendButton
            // 
            resources.ApplyResources(this.againstFriendButton, "m_AgainstFriendButton");
            this.againstFriendButton.Name = "m_AgainstFriendButton";
            this.againstFriendButton.UseVisualStyleBackColor = false;
            this.againstFriendButton.Click += new System.EventHandler(this.m_AgainstFriendButton_Click);
            // 
            // m_BoardSizeLable
            // 
            resources.ApplyResources(this.boardSizeLabel, "m_BoardSizeLable");
            this.boardSizeLabel.Name = "m_BoardSizeLable";
            // 
            // m_BoardSizeButton
            // 
            this.boardSizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(235)))), ((int)(((byte)(101)))));
            resources.ApplyResources(this.boardSizeButton, "m_BoardSizeButton");
            this.boardSizeButton.Name = "m_BoardSizeButton";
            this.boardSizeButton.UseVisualStyleBackColor = false;
            this.boardSizeButton.Click += new System.EventHandler(this.m_BoardSizeButton_Click);
            // 
            // m_StartButton
            // 
            resources.ApplyResources(this.startButton, "m_StartButton");
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(235)))), ((int)(((byte)(101)))));
            this.startButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.startButton.Name = "m_StartButton";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.m_StartButton_Click);
            // 
            // InitSettingsForm
            // 
            this.AcceptButton = this.startButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.firstPlayerNameLabel);
            this.Controls.Add(this.firstPlayerNameTextBox);
            this.Controls.Add(this.secondPlayerNameLabel);
            this.Controls.Add(this.secondPlayerNameTextBox);
            this.Controls.Add(this.againstFriendButton);
            this.Controls.Add(this.boardSizeLabel);
            this.Controls.Add(this.boardSizeButton);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitSettingsForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public string FirstPlayerName
        {
            get
            {
                return firstPlayerNameTextBox.Text;
            }
        }  

        public string SecondPlayerName
        {
            get
            {
                return secondPlayerNameTextBox.Text;
            }
        }

        private System.Windows.Forms.Label firstPlayerNameLabel;
        private System.Windows.Forms.Label secondPlayerNameLabel;
        private System.Windows.Forms.TextBox firstPlayerNameTextBox;
        private System.Windows.Forms.TextBox secondPlayerNameTextBox;
        private System.Windows.Forms.Button againstFriendButton;
        private System.Windows.Forms.Label boardSizeLabel;
        private int m_RowSize = 4;
        private int m_ColSize = 4;
        private System.Windows.Forms.Button boardSizeButton;
        private System.Windows.Forms.Button startButton;
        #endregion
    }
}