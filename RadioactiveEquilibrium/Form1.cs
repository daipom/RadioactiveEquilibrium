using RadioactiveEquilibrium.Element;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioactiveEquilibrium
{
    public partial class Form1 : Form
    {
        private ulong timeDeltaSec = 100;
        private ulong timeProgressed = 0;

        private Uranium uranium;
        private Thorium thorium;
        private Radium radium;

        public Form1()
        {
            InitializeComponent();

            radium = new Radium(null);
            thorium = new Thorium(radium);
            uranium = new Uranium(thorium, 100000000);

            comboBox1.SelectedIndex = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeProgressed += timeDeltaSec;

            UpdateElement();

            var sum = radium.Ammount + thorium.Ammount + uranium.Ammount;
            progressBar1.Maximum = (int)sum;
            progressBar2.Maximum = (int)sum;
            progressBar3.Maximum = (int)sum;
            
            UpdateDisplay();
        }

        private void UpdateElement()
        {
            uranium.Update(timeDeltaSec);
            thorium.Update(timeDeltaSec);
            radium.Update(timeDeltaSec);
        }

        private void UpdateDisplay()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label1.Text = $"{timeProgressed} sec";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label1.Text = $"{timeProgressed/BaseElement.DAY_TO_SEC} day";
            }
            else
            {
                label1.Text = $"{timeProgressed/BaseElement.YEAR_TO_SEC} year";
            }

            progressBar1.Value = (int)uranium.Ammount;
            label2.Text = $"{uranium.Ammount}";
            progressBar3.Value = (int)thorium.Ammount;
            label3.Text = $"{thorium.Ammount}";
            progressBar2.Value = (int)radium.Ammount;
            label4.Text = $"{radium.Ammount}";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateTimeDeltaSec();
        }

        private void UpdateTimeDeltaSec()
        {
            var result = (ulong)numericUpDown1.Value;
            if (comboBox1.SelectedIndex == 1)
            {
                result = result * BaseElement.DAY_TO_SEC;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                result = result * BaseElement.YEAR_TO_SEC;
            }
            timeDeltaSec = result;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTimeDeltaSec();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                timer1.Enabled = true;
                button1.Text = "Stop";
            }
            else
            {
                timer1.Enabled = false;
                button1.Text = "Start";
            }
        }
    }
}
