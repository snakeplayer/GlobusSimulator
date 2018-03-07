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
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace GlobusSimulator
{
    public partial class FormGlobusEditor : Form
    {
        #region Consts

        #endregion

        #region Fields
        private GlobusShop _globusShop;
        #endregion

        #region Properties
        private GlobusShop GlobusShop { get => _globusShop; set => _globusShop = value ?? new GlobusShop(); }
        private bool IsDrawingPath { get; set; }
        #endregion

        #region Constructors

        public FormGlobusEditor()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember(nameof(DoubleBuffered), BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlDrawingZone, new object[] { true });
            this.cbxObjectToDraw.DataSource = Enum.GetValues(typeof(DrawableObject));
            this.GlobusShop = new GlobusShop();
        }

        #endregion

        #region Methods

        public void UpdateView()
        {
            // Init
            this.pnlDrawingZone.Invalidate();
        }

        #endregion

        private void PnlDrawingZone_MouseClick(object sender, MouseEventArgs e)
        {
            switch ((DrawableObject)cbxObjectToDraw.SelectedItem)
            {
                case DrawableObject.Path:
                    this.IsDrawingPath = !this.IsDrawingPath && e.Button == MouseButtons.Right;
                    this.GlobusShop.AddPointToPath(e.Location);
                    break;
                case DrawableObject.StoreSection:
                    this.GlobusShop.AddStoreSection(e.Location);
                    break;
                case DrawableObject.Checkout:
                   // this.GlobusShop.AddCheckout(new Checkout());
                    break;
            }
        }

        private void PnlDrawingZone_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsDrawingPath)
            {
                this.GlobusShop.AddPointToPath(e.Location);
                this.UpdateView();
            }
        }

        private void PnlDrawingZone_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush myBrush;

            this.GlobusShop.Humans.ForEach(h => { myBrush = new SolidBrush(h.Color); e.Graphics.FillEllipse(myBrush, h.Shape); });
            this.GlobusShop.Path.Points.ForEach(p => { myBrush = new SolidBrush(Color.Red); e.Graphics.FillEllipse(myBrush, new Rectangle(p, new Size(10, 10))); });
            this.GlobusShop.StoreSections.ForEach(s => { myBrush = new SolidBrush(s.Color); e.Graphics.FillRectangle(myBrush, s.Shape); });
            this.GlobusShop.Checkouts.ForEach(c => { myBrush = new SolidBrush(c.Color); e.Graphics.FillRectangle(myBrush, c.Shape); });
        }

        private void PnlDrawingZone_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
