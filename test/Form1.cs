using System;
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
        public void updateDroneTargetLabel(Entity droneTarget)
        {
            if(droneTarget != null)
            {
             
              DroneTarget.Text = droneTarget.Name;
            }
            
        }
    }
 
}
