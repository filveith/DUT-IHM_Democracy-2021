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

            g.DrawRectangle(p, r);

            g.DrawString(Value.Type.ToString(), new Font("Times New Roman", 10, FontStyle.Bold), Brushes.Black, this.Position);

            g.DrawString(Value.Name, new Font("Times New Roman", 8, FontStyle.Bold), Brushes.Black, new Point(this.Position.X, this.Position.Y+11));

            g.DrawString(Value.Value.ToString(), new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new Point(this.Position.X+20, this.Position.Y + 20));

            g.DrawString(Value.MinValue.ToString(), new Font("Times New Roman", 6, FontStyle.Bold), Brushes.Black, new Point(this.Position.X, this.Position.Y + 20));

            g.DrawString(Value.MaxValue.ToString(), new Font("Times New Roman", 6, FontStyle.Bold), Brushes.Black, new Point(this.Position.X+40, this.Position.Y + 20));

        }

        public bool Contient(Point p)
        {
            Rectangle r = new Rectangle(new Point(Position.X - Taille.Width / 2, Position.Y - Taille.Height / 2), Taille);
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
