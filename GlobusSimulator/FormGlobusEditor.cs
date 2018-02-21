/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 21.02.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : FormGlobusEditor.cs
 * Class desc. : Allows to create a custom GlobusStore - view
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobusSimulator
{
    public partial class FormGlobusEditor : Form
    {
        #region Consts

        #endregion

        #region Fields

        #endregion

        #region Properties

        public GlobusShop GlobusShop { get; set; }

        #endregion

        #region Constructors

        public FormGlobusEditor()
        {
            InitializeComponent();

            Path path = new Path();
            this.GlobusShop = new GlobusShop(path);
        }

        #endregion

        #region Methods

        public void UpdateView()
        {
            // Init
            this.Refresh();
            SolidBrush myBrush;
            Graphics formGraphics;
            formGraphics = pnlDrawingZone.CreateGraphics();

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

        private void pnlDrawingZone_Click(object sender, EventArgs e)
        {
            switch (cbxObjectToDraw.Text)
            {
                case "Path":
                    this.DrawPath();
                    break;

                case "Store section":
                    this.DrawStoreSection();
                    break;

                case "Checkout":
                    this.DrawCheckout();
                    break;

                default:
                    break;
            }
        }

        public void DrawPath()
        {
            Point mousePosition = pnlDrawingZone.PointToClient(Cursor.Position);
            this.GlobusShop.Path.AddPoint(new Point(mousePosition.X, mousePosition.Y));

            this.UpdateView();
        }

        public void DrawStoreSection()
        {
            Point mousePosition = pnlDrawingZone.PointToClient(Cursor.Position);
            this.GlobusShop.StoreSections.Add(new StoreSection(mousePosition, new Size(40, 100)));

            this.UpdateView();
        }

        public void DrawCheckout()
        {
            Point mousePosition = pnlDrawingZone.PointToClient(Cursor.Position);
            this.GlobusShop.Checkouts.Add(new Checkout(mousePosition.X, mousePosition.Y, 20, 60));

            this.UpdateView();
        }

        #endregion
    }
}
