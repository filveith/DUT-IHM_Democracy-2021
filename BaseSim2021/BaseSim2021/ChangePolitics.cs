using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseSim2021
{
    public partial class ChangePolitics : Form
    {

        public int valSlider { get { return (int)politicsSlider.Value; } }
        public int valNumeric { get { return (int)politicsNumericUp.Value; } }
        public ChangePolitics(int val)
        {
            InitializeComponent();
            politicsSlider.Value = val;
            politicsNumericUp.Value = val;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void politicsSlider_Scroll(object sender, EventArgs e)
        {
            politicsNumericUp.Value = politicsSlider.Value;
        }

        private void politicsNumericUp_ValueChanged(object sender, EventArgs e)
        {
            politicsSlider.Value = (int)politicsNumericUp.Value;
        }
    }
}
