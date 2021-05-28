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
    public partial class Description : Form
    {
        String descitpion { get; set; }
        public Description(string description)
        {
            InitializeComponent();
            this.descitpion = descitpion;
        }

        public void Draw(Graphics g)
        {
            Pen p = new Pen(Color.FromArgb(0,0,0), 0) ;
            Rectangle r = new Rectangle(new Point(Width, Height), new Size(Width-5, Height-5));

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawRectangle(p, r);

            g.DrawString(this.descitpion, new Font("Times New Roman", 10, FontStyle.Bold), Brushes.Black, r, stringFormat);
        }

        private void Description_Load(object sender, EventArgs e)
        {

        }

        private void textBoxDescription_Click(object sender, EventArgs e)
        {

        }
    }
}
