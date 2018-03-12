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
        #region Fields

        private GlobusShopEditor _globusShopEditor;

        #endregion

        #region Properties
        public GlobusShopEditor GlobusShopEditor { get => _globusShopEditor; private set => _globusShopEditor = value ?? new GlobusShopEditor(); }
        private bool IsDrawingObject { get; set; }
        private Point ObjectStartPoint { get; set; }
        private bool IsDrawingPath { get; set; }
        public Point MouseLocation { get; set; }

        #endregion

        #region Constructors

        public FormGlobusEditor()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember(nameof(DoubleBuffered), BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlDrawingZone, new object[] { true });
            this.cbxObjectToDraw.DataSource = Enum.GetValues(typeof(DrawableObject));
            this.GlobusShopEditor = new GlobusShopEditor();
        }

        #endregion

        #region Methods

        public void UpdateView()
        {
            this.pnlDrawingZone.Invalidate();
        }

        #endregion

        private void PnlDrawingZone_MouseClick(object sender, MouseEventArgs e)
        {
            switch ((DrawableObject)cbxObjectToDraw.SelectedItem)
            {
                // StoreSection
                case DrawableObject.StoreSection:
                    this.CreateObject(DrawableObject.StoreSection, e);
                    break;
                // Checkout
                case DrawableObject.Checkout:
                    this.CreateObject(DrawableObject.Checkout, e);
                    break;
                // Path
                case DrawableObject.Path:
                    if (e.Button == MouseButtons.Left)
                    {
                        this.IsDrawingPath = !this.IsDrawingPath;
                        if (this.IsDrawingPath)
                        {
                            this.GlobusShopEditor.RemovePath();
                        }
                        else
                        {
                            this.GlobusShopEditor.AddPointToPath(e.Location);
                        }
                    }
                    else
                    {
                        this.GlobusShopEditor.RemovePath();
                    }
                    break;
            }
            this.UpdateView();
        }

        private void PnlDrawingZone_MouseMove(object sender, MouseEventArgs e)
        {
            this.MouseLocation = e.Location;

            if (this.IsDrawingPath)
            {
                this.GlobusShopEditor.AddPointToPath(this.MouseLocation);
            }
            this.UpdateView();
        }

        private void PnlDrawingZone_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush myBrush;

            this.GlobusShopEditor.Path.Points.ForEach(p => { myBrush = new SolidBrush(Color.Red); e.Graphics.FillEllipse(myBrush, new Rectangle(p, new Size(10, 10))); });
            this.GlobusShopEditor.StoreSections.ForEach(s => { myBrush = new SolidBrush(s.Color); e.Graphics.FillRectangle(myBrush, s.Shape); });
            this.GlobusShopEditor.Checkouts.ForEach(c => { myBrush = new SolidBrush(c.Color); e.Graphics.FillRectangle(myBrush, c.Shape); });

            // StoreSection & Checkout
            if (this.IsDrawingObject)
            {
                Size size = new Size(this.MouseLocation.X - this.ObjectStartPoint.X, this.MouseLocation.Y - this.ObjectStartPoint.Y);
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(this.ObjectStartPoint, size));
            }
        }

        private void PnlDrawingZone_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void PnlDrawingZone_MouseLeave(object sender, EventArgs e)
        {
            this.IsDrawingObject = false;
        }

        private void CreateObject(DrawableObject drawableObject, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.IsDrawingObject = !this.IsDrawingObject;
                if (this.IsDrawingObject)
                {
                    this.ObjectStartPoint = this.MouseLocation;
                }
                else
                {
                    Size size = new Size(this.MouseLocation.X - this.ObjectStartPoint.X, this.MouseLocation.Y - this.ObjectStartPoint.Y);

                    switch (drawableObject)
                    {
                        case DrawableObject.StoreSection:
                            this.GlobusShopEditor.AddStoreSection(this.ObjectStartPoint, size);
                            break;
                        case DrawableObject.Checkout:
                            this.GlobusShopEditor.AddCheckout(this.ObjectStartPoint, size);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                switch (drawableObject)
                {
                    case DrawableObject.StoreSection:
                        this.GlobusShopEditor.RemoveStoreSection(this.MouseLocation);
                        break;
                    case DrawableObject.Checkout:
                        this.GlobusShopEditor.RemoveCheckout(this.MouseLocation);
                        break;
                    default:
                        break;
                }
                
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.GlobusShopEditor.RemoveStoreSections();
            this.GlobusShopEditor.RemoveCheckouts();
            this.GlobusShopEditor.RemovePath();
            this.UpdateView();
        }
    }
}
