namespace VNI
{
    partial class Form1
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
            this.Console = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Console
            // 
            this.Console.FormattingEnabled = true;
            this.Console.Location = new System.Drawing.Point(24, 12);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(380, 199);
            this.Console.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 218);
            this.Controls.Add(this.Console);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Console;
    }
}

