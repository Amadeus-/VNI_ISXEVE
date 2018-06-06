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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DroneTarget = new System.Windows.Forms.Label();
            this.DroneStatus = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Drone Target";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Drone Status:";
            // 
            // DroneTarget
            // 
            this.DroneTarget.AutoSize = true;
            this.DroneTarget.Location = new System.Drawing.Point(98, 230);
            this.DroneTarget.Name = "DroneTarget";
            this.DroneTarget.Size = new System.Drawing.Size(70, 13);
            this.DroneTarget.TabIndex = 3;
            this.DroneTarget.Text = "Drone Target";
            // 
            // DroneStatus
            // 
            this.DroneStatus.AutoSize = true;
            this.DroneStatus.Location = new System.Drawing.Point(100, 252);
            this.DroneStatus.Name = "DroneStatus";
            this.DroneStatus.Size = new System.Drawing.Size(69, 13);
            this.DroneStatus.TabIndex = 4;
            this.DroneStatus.Text = "Drone Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 302);
            this.Controls.Add(this.DroneStatus);
            this.Controls.Add(this.DroneTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Console);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Console;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DroneTarget;
        private System.Windows.Forms.Label DroneStatus;
    }
}

