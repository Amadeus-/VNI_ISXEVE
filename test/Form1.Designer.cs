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
            this.StartTime = new System.Windows.Forms.Label();
            this.EndTime = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DroneCount = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.ShieldPctLabel2 = new System.Windows.Forms.Label();
            this.ShieldPctLabel = new System.Windows.Forms.Label();
            this.TimeAndDate = new System.Windows.Forms.Label();
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
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "End Time:";
            // 
            // StartTime
            // 
            this.StartTime.AutoSize = true;
            this.StartTime.Location = new System.Drawing.Point(98, 230);
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(70, 13);
            this.StartTime.TabIndex = 3;
            this.StartTime.Text = "Drone Target";
            // 
            // EndTime
            // 
            this.EndTime.AutoSize = true;
            this.EndTime.Location = new System.Drawing.Point(100, 252);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(69, 13);
            this.EndTime.TabIndex = 4;
            this.EndTime.Text = "Drone Status";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(410, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(143, 199);
            this.listBox1.TabIndex = 5;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(559, 12);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(143, 199);
            this.listBox2.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(206, 226);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Finish site and dock";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "# Of Drones: ";
            // 
            // DroneCount
            // 
            this.DroneCount.AutoSize = true;
            this.DroneCount.Location = new System.Drawing.Point(280, 252);
            this.DroneCount.Name = "DroneCount";
            this.DroneCount.Size = new System.Drawing.Size(13, 13);
            this.DroneCount.TabIndex = 9;
            this.DroneCount.Text = "0";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(559, 217);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(92, 17);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "3D Rendering";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(559, 240);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(139, 17);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "Toggle Texture Loading";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(559, 264);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(110, 17);
            this.checkBox4.TabIndex = 12;
            this.checkBox4.Text = "Toggle UI Display";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // ShieldPctLabel2
            // 
            this.ShieldPctLabel2.AutoSize = true;
            this.ShieldPctLabel2.Location = new System.Drawing.Point(328, 252);
            this.ShieldPctLabel2.Name = "ShieldPctLabel2";
            this.ShieldPctLabel2.Size = new System.Drawing.Size(58, 13);
            this.ShieldPctLabel2.TabIndex = 13;
            this.ShieldPctLabel2.Text = "Shield Pct:";
            this.ShieldPctLabel2.Click += new System.EventHandler(this.label4_Click);
            // 
            // ShieldPctLabel
            // 
            this.ShieldPctLabel.AutoSize = true;
            this.ShieldPctLabel.Location = new System.Drawing.Point(392, 252);
            this.ShieldPctLabel.Name = "ShieldPctLabel";
            this.ShieldPctLabel.Size = new System.Drawing.Size(35, 13);
            this.ShieldPctLabel.TabIndex = 14;
            this.ShieldPctLabel.Text = "label5";
            this.ShieldPctLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // TimeAndDate
            // 
            this.TimeAndDate.AutoSize = true;
            this.TimeAndDate.Location = new System.Drawing.Point(352, 229);
            this.TimeAndDate.Name = "TimeAndDate";
            this.TimeAndDate.Size = new System.Drawing.Size(35, 13);
            this.TimeAndDate.TabIndex = 15;
            this.TimeAndDate.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 286);
            this.Controls.Add(this.TimeAndDate);
            this.Controls.Add(this.ShieldPctLabel);
            this.Controls.Add(this.ShieldPctLabel2);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.DroneCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.EndTime);
            this.Controls.Add(this.StartTime);
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
        private System.Windows.Forms.Label StartTime;
        private System.Windows.Forms.Label EndTime;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label DroneCount;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label ShieldPctLabel2;
        private System.Windows.Forms.Label ShieldPctLabel;
        private System.Windows.Forms.Label TimeAndDate;
    }
}

