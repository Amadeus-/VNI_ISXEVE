using System;
using VNI.Routines;
using VNI.Functions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EVE.ISXEVE;

namespace VNI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }
        private void UI_Load(object sender, EventArgs e)
        {
            VNI Daedalus = new VNI(this);


        }

        public void NewConsoleMessage(string input)
        {
            Console.Items.Add(DateTime.Now + " " + input);
            Console.SelectedIndex = (Console.Items.Count - 1);

        }
        public void addAnomaly(string input)
        {
            listBox1.Items.Add(input);
            listBox1.SelectedIndex = (listBox1.Items.Count - 1);
        }
        public void updateStartAndEnd(DateTime start, DateTime end)
        {
            StartTime.Text = start.ToLongTimeString();
            EndTime.Text = end.ToLongTimeString();
        }
        public void AddOccupiedAnomaly(string input)
        {
            listBox2.Items.Add(input);
            listBox2.SelectedIndex = (listBox2.Items.Count - 1);
        }
        public void ClearAnomalies()
        {
            listBox1.Items.Clear();
        }
        public void AddWarpScrambler (String Input)
        {

        }
        public void updateDroneCountLabel(int droneCount)
        {
            DroneCount.Text = droneCount.ToString();
        }
        public void updateShieldPctLabel(int ShieldPct)
        {
            ShieldPctLabel.Text = ShieldPct.ToString();
        }
        public void updateTimeAndDateLabel(DateTime pulse)
        {


            TimeAndDate.Text = pulse.ToLongTimeString();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                f_Anomalies.lastAnomaly = true;
            }
            else if (!checkBox1.Checked)
            {
                f_Anomalies.lastAnomaly = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            VNI.Eve.Toggle3DDisplay();
            

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            VNI.Eve.ToggleTextureLoading();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            VNI.Eve.ToggleUIDisplay();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
 
}
