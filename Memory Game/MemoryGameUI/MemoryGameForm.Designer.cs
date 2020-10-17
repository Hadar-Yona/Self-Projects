namespace Project1
{
    partial class MemoryGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoryGameForm));
            this.currentPlayerLabel = new System.Windows.Forms.Label();
            this.firstPlayerLabel = new System.Windows.Forms.Label();
            this.secondPlayerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // currentPlayerLabel
            // 
            resources.ApplyResources(this.currentPlayerLabel, "currentPlayerLabel");
            this.currentPlayerLabel.Name = "currentPlayerLabel";
            // 
            // firstPlayerLabel
            // 
            resources.ApplyResources(this.firstPlayerLabel, "firstPlayerLabel");
            this.firstPlayerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.firstPlayerLabel.Name = "firstPlayerLabel";
            // 
            // secondPlayerLabel
            // 
            resources.ApplyResources(this.secondPlayerLabel, "secondPlayerLabel");
            this.secondPlayerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.secondPlayerLabel.Name = "secondPlayerLabel";
            // 
            // MemoryGameForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.secondPlayerLabel);
            this.Controls.Add(this.firstPlayerLabel);
            this.Controls.Add(this.currentPlayerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MemoryGameForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label currentPlayerLabel;
        private System.Windows.Forms.Label firstPlayerLabel;
        private System.Windows.Forms.Label secondPlayerLabel;
    }
}