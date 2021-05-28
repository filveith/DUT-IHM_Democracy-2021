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
    public partial class GameView : Form
    {
        private readonly WorldState theWorld;
        /// <summary>
        /// The constructor for the main window
        /// </summary>
        public GameView(WorldState world)
        {
            InitializeComponent();
            theWorld = world;
        }
        /// <summary>
        /// Method called by the controler whenever some text should be displayed
        /// </summary>
        /// <param name="s"></param>
        public void WriteLine(string s)
        {
            List<string> strs = s.Split('\n').ToList();
            strs.ForEach(str=>outputListBox.Items.Add(str));
            if (outputListBox.Items.Count > 0)
            {
                outputListBox.SelectedIndex = outputListBox.Items.Count - 1;
            }
            outputListBox.Refresh();
        }
        /// <summary>
        /// Method called by the controler whenever a confirmation should be asked
        /// </summary>
        /// <returns>Yes iff confirmed</returns>
        public bool ConfirmDialog()
        {
            string message = "Confirmer ?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            return MessageBox.Show(message, "", buttons) == DialogResult.Yes;
        }
        #region Event handling
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                e.SuppressKeyPress = true; // Or beep.
                GameController.Interpret(inputTextBox.Text);
            }
        }

        private void GameView_Paint(object sender, PaintEventArgs e)
        {
            getAllValues(e);
            //theWorld.Perks.ForEach(v => new IndexedValueView(v, Width / 2, Height / 2, Width / 4, Height / 4).Draw(e.Graphics));
            //theWorld.Taxes.ForEach(v => new IndexedValueView(v, 20, 20, Width / 4, Height / 4).Draw(e.Graphics));
            diffLabel.Text = "Difficulté : " + theWorld.TheDifficulty;
            turnLabel.Text = "Tour " + theWorld.Turns;
            moneyLabel.Text = "Trésor : " + theWorld.Money + " pièces d'or";
            gloryLabel.Text = "Gloire : " + theWorld.Glory;
            nextButton.Visible = true;
        }
        #endregion

        List<IndexedValueView> views = new List<IndexedValueView>();

        private void printValues(PaintEventArgs e, List<IndexedValue> values, int x, int y, Size recSize, Color color, Color contourColor)
        {
           
            //Console.WriteLine(color + "    x = " + x + "   y = " + y + "   recW = " + recSize.Width);

            int margin = 25;

            recSize = new Size(recSize.Width - margin*3, recSize.Height);

            int nbValue = values.Count();
            
            int increment = 0;
            int width = 50;
            int height = 50;
            

            //Console.WriteLine(nbValue.ToString(), color.GetType().ToString());
            int nbInRow = recSize.Width / width;
            int reste = recSize.Width - nbValue * width;
            int espacementX = reste / (nbValue + 1);
            Pen pen = new Pen(contourColor, 4);
            

            int baseX = x + espacementX;
            int baseY = y;

            int maxRecPos = recSize.Width + x;

            //e.Graphics.DrawRectangle(pen, new Rectangle(new Point(x+margin, y+margin), recSize));
            e.Graphics.FillRectangle(new SolidBrush(color), new Rectangle(new Point(x + margin, y + margin), recSize));
            e.Graphics.DrawRectangle(pen, new Rectangle(new Point(x + margin, y + margin), recSize));

            int xInRec = 0;

            y = baseY;
            x = baseX;


            //Console.WriteLine("BEFORE    x = " + x + "   y = " + y + "   recMaxPos = " + maxRecPos);

            foreach (IndexedValue v in values)
            {
                if (xInRec + width * 2 + 5 >= recSize.Width || x + width * 2 + 5 >= maxRecPos)
                {
                    //Console.WriteLine(color+"    To width = " + (x + width + 5) + "   over = " + recSize.Width + "    xInRec = " + xInRec);
                    y += width + 5;
                    increment = 0;
                    x = baseX;
                    xInRec = 0;
                }

                increment++;
                x += espacementX + width;
                xInRec += espacementX + width;
                Console.WriteLine("x = " + x + "    y = " + y + "    xInRec = " + xInRec);
                //views.Add(new IndexedValueView(v, x, y + recSize.Height / 2 - height / 2, width, height, color));
                views.Add(new IndexedValueView(v, x, y + width - 15, width, height, contourColor));
                x += width;
            }
            views.ForEach(view => view.Draw(e.Graphics));
        }

        private void getAllValues(PaintEventArgs e)
        {
            views.Clear();
            printValues(e, theWorld.Policies, 0, 0, new Size(Width, Height / 3 - 25), Color.FromArgb(90,112,219), Color.FromArgb(64,79,156));

            printValues(e, theWorld.Perks, 0, Height - (Height / 3) * 2, new Size(Width / 2, Height - (Height / 3)*2), Color.FromArgb(247, 55, 45), Color.FromArgb(184,41,33));

            printValues(e, theWorld.Indicators, Width/2, Height - (Height / 3) * 2 , new Size(Width / 2, Height - (Height / 3) * 2), Color.FromArgb(54,128,55), Color.FromArgb(39,112,53));
            
            printValues(e, theWorld.Groups, 0, 25 +Height - (Height / 3), new Size(Width / 2, -100 + Height - (Height / 3) * 2), Color.FromName("Pink"), Color.FromName("HotPink"));

            printValues(e, theWorld.Crises, Width / 2, 25 + Height - (Height / 3), new Size(Width / 2, -100 + Height - (Height / 3) * 2), Color.FromArgb(230,157,31), Color.FromArgb(184,125,24));
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            GameController.Interpret("suivant");
        }

        private void GameView_MouseDown(object sender, MouseEventArgs e)
        {
            IndexedValueView selection = Selection(e.Location);

            Console.WriteLine(selection.Value.Type);

            if (e.Button == MouseButtons.Left && selection != null)
            {
                
                if (selection.Value.Type.ToString().Equals("Policy"))
                {
                    
                    ChangePolitics changePolitics = new ChangePolitics(selection.Value.Value);

                    if (changePolitics.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        String changes = selection.Value.Name + " " + changePolitics.valNumeric;
                        GameController.ApplyPolicyChanges(changes); //changes the value of the selected policy
                    }
                } else
                {
                    MessageBox.Show(selection.Value.Description, "Message", MessageBoxButtons.OK);
                }
                
            }
        }
        private IndexedValueView Selection(Point p)
        {
            /*foreach(IndexedValueView c in views)
            {
                if (c != null) Console.WriteLine("x = "+c.Position.X + "   y = " + c.Position.Y + "   val = " + c.Value.Name);
            }*/
            return views.FirstOrDefault(c => c.Contient(p));
        }
    }
}