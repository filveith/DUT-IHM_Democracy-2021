using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BaseSim2021
{
    class IndexedValueView
    {
        public IndexedValue Value { get; set; }
        public Point Position { get; set; }
        public Size Taille { get; set; }
        public int Epaisseur { get; set; } = 1;
        public Color Couleur { get; set; } = Color.FromName("Green");
        public String Texte { get; set; } = "";

        //public Point Centre
        //{
            //get
            //{
            //    return new Point(Position.X + Taille.Width / 2,
              //                   Position.Y + Taille.Height / 2);
          //  }
        //}

        public IndexedValueView(IndexedValue value_, int x, int y, int sx, int sy, Color c)
        {
            Value = value_;
            Position = new Point(x, y);
            Taille = new Size(sx, sy);
            Couleur = c;
        }

        public void Draw(Graphics g)
        {
            Pen p = new Pen(Couleur, Epaisseur);
            
            Rectangle r = new Rectangle(this.Position, Taille);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            //stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawRectangle(p, r);
            g.FillRectangle(new SolidBrush(Color.FromName("White")), r);

            g.DrawString(Value.Type.ToString(), new Font("Times New Roman", 10, FontStyle.Bold), Brushes.Black, r, stringFormat);

            g.DrawString(Value.Name, new Font("Times New Roman", 8, FontStyle.Bold), Brushes.Black, new Point(this.Position.X + 25, this.Position.Y + 11), stringFormat);

            g.DrawString(Value.MinValue.ToString() + "   " + Value.Value.ToString() + "   " + Value.MaxValue.ToString(), new Font("Times New Roman", 6, FontStyle.Bold), Brushes.Black, new Point(this.Position.X + 25, this.Position.Y + 26), stringFormat);


        }

        public bool Contient(Point p)
        {
            Rectangle r = new Rectangle(Position, Taille);
            return r.Contains(p);
        }

        public Point Deplace(Point p)
        {
            int x = p.X;
            int y = p.Y;
            return new Point(x, y);
        }

        public void DessineSouris(Graphics g, Point posM)
        {
            g.DrawLine(Pens.Blue, Position, posM);
        }
    }
}
