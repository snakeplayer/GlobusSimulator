/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 21.02.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : FormGlobusView.cs
 * Class desc. : Reprensents a globus store - main view
 */
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GlobusSimulator
{
    public partial class FormGlobusView : Form
    {
        #region Consts

        #endregion

        #region Fields

        #endregion

        #region Properties

        public GlobusShop GlobusShop { get; set; }

        #endregion

        #region Constructors

        public FormGlobusView()
        {
            InitializeComponent();

            // Points
            List<Point> points = new List<Point>();
            points.Add(new Point(90, 80));
            points.Add(new Point(90, 220));
            points.Add(new Point(170, 220));
            points.Add(new Point(170, 80));
            points.Add(new Point(250, 80));
            points.Add(new Point(250, 220));

            // Path
            Path path = new Path(points);

            // GlobusShop
            this.GlobusShop = new GlobusShop(path);

            // StoreSections
            this.GlobusShop.StoreSections.Add(new StoreSection(110, 100, 40, 100));
            this.GlobusShop.StoreSections.Add(new StoreSection(190, 100, 40, 100));
            this.GlobusShop.StoreSections.Add(new StoreSection(270, 100, 40, 100));

            // Checkouts
            this.GlobusShop.Checkouts.Add(new Checkout(110, 300, 20, 80));
            this.GlobusShop.Checkouts.Add(new Checkout(150, 300, 20, 80));
            this.GlobusShop.Checkouts.Add(new Checkout(190, 300, 20, 80));
        }

        #endregion

        #region Methods

        public void UpdateView()
        {
            // Init
            this.Refresh();
            SolidBrush myBrush;
            Graphics formGraphics;
            formGraphics = this.CreateGraphics();

            // Humans drawing
            foreach (Human h in this.GlobusShop.Humans)
            {
                myBrush = new SolidBrush(h.Color);
                formGraphics.FillEllipse(myBrush, h.Shape);
            }

            // Checkouts drawing
            foreach (Point p in this.GlobusShop.Path.Points)
            {
                myBrush = new SolidBrush(Color.Red);
                formGraphics.FillEllipse(myBrush, new Rectangle(p, new Size(10, 10)));
            }

            // StoreSections drawing
            foreach (StoreSection s in this.GlobusShop.StoreSections)
            {
                myBrush = new SolidBrush(s.Color);
                formGraphics.FillRectangle(myBrush, s.Shape);
            }

            // Checkouts drawing
            foreach (Checkout c in this.GlobusShop.Checkouts)
            {
                myBrush = new SolidBrush(c.Color);
                formGraphics.FillRectangle(myBrush, c.Shape);
            }

            // Dispose
            formGraphics.Dispose();
        }

        #endregion

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.UpdateView();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            // Add Humans
            this.GlobusShop.Humans.Add(new Human(this.GlobusShop.Path.Points[0], Color.Green, 1000, this.GlobusShop));
            this.UpdateView();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            // Move Humans
            int index = -1;
            foreach (Human h in this.GlobusShop.Humans)
            {
                for (int i = 0; i < this.GlobusShop.Path.Points.Count; i++)
                {
                    if (h.Shape.Location == this.GlobusShop.Path.Points[i])
                    {
                        index = i;
                    }
                }

                // If the Human is not at the end of the Path
                if (index < this.GlobusShop.Path.Points.Count - 1)
                {
                    h.Shape = new Rectangle(this.GlobusShop.Path.Points[index + 1], h.Shape.Size);
                }
                else // If the Human is at the end of the Path, move it to a Checkout
                {
                    // TODO
                }
            }

            this.UpdateView();
        }
    }
}
