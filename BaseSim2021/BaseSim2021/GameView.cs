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

        private void printValues(PaintEventArgs e, List<IndexedValue> values, int x, int y, Size recSize, Color color)
        {
            int margin = 25;

            recSize = new Size(recSize.Width - margin*3, recSize.Height);

            int nbValue = values.Count();
            int baseX = x+margin;
            int baseY = y;
            int increment = 0;
            int width = 50;
            int height = 50;
            

            //Console.WriteLine(nbValue.ToString(), color.GetType().ToString());
            int nbInRow = recSize.Width / width;
            int reste = recSize.Width - nbValue * width;
            int espacementX = reste / (nbValue + 1);
            Pen pen = new Pen(color, 2);
            List<IndexedValueView> views = new List<IndexedValueView>();

            
            e.Graphics.DrawRectangle(pen, new Rectangle(new Point(x+margin, y+margin), recSize));

            y = baseY;
            x = baseX;

            foreach (IndexedValue v in values)
            {
                if (x + width + 5 >= recSize.Width)
                {
                    Console.WriteLine(color+"    To width = " + (x + width + 5) + "   over = " + recSize.Width);
                    y += width + 5;
                    increment = 0;
                    x = baseX;
                }

                

                increment++;
                x += espacementX + width;
                Console.WriteLine("x = " + x + "    y = " + y);
                //views.Add(new IndexedValueView(v, x, y + recSize.Height / 2 - height / 2, width, height, color));
                views.Add(new IndexedValueView(v, x, y + width - 15, width, height, color));
                x += width;
            }
            views.ForEach(view => view.Draw(e.Graphics));
        }

        private void getAllValues(PaintEventArgs e)
        {
            printValues(e, theWorld.Policies, 0, 0, new Size(Width, Height / 3), Color.FromName("Blue"));

            printValues(e, theWorld.Crises, 0, 25 + Height - (Height / 3) * 2, new Size(Width / 2, Height - (Height / 3)*2), Color.FromName("Red"));
            printValues(e, theWorld.Indicators, Width/2, 25 + Height - (Height / 3) * 2, new Size(Width / 2, Height - (Height / 3) * 2), Color.FromName("Green"));
            
            printValues(e, theWorld.Groups, 0, 25 + Height - (Height / 3), new Size(Width / 2, -100 + Height - (Height / 3) * 2), Color.FromName("Pink"));
            printValues(e, theWorld.Perks, Width / 2, 25 + Height - (Height / 3), new Size(Width / 2, -100 + Height - (Height / 3) * 2), Color.FromName("Orange"));
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            GameController.Interpret("suivant");
        }

    }
}
