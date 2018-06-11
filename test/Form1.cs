using System;
using VNI.Routines;
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
            Console.Items.Add(input);
            Console.SelectedIndex = (Console.Items.Count - 1);
        }
        public void addAnomaly(string input)
        {
            listBox1.Items.Add(input);
            listBox1.SelectedIndex = (listBox1.Items.Count - 1);
        }
        public void AddWarpScrambler (String Input)
        {

        }
        public void updateDroneTargetLabel()
        {
            if (r_TravelToAnomaly.initComplete != null)
            {

                DroneTarget.Text = r_TravelToAnomaly.initComplete.ToString();
            }

        }
        public void updateDroneTargetLabel(Entity droneTarget)
        {
            if(droneTarget != null)
            {

                DroneTarget.Text = r_TravelToAnomaly.initComplete.ToString();
            }
            
        }
    }
 
}
