/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 21.02.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : FormGlobusView.cs
 * Class desc. : Reprensents a globus store - main view
 */
using System;
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
        private GlobusShop GlobusShop { get; set; }
        #endregion

        #region Constructors
        public FormGlobusView()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember(nameof(DoubleBuffered), System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, this.pnlGlobusShop, new object[] { true });
        }
        #endregion

        #region Methods
        private void BtnStartStop_Click(object sender, System.EventArgs e)
        {
            this.GlobusShop.Simulate((int)this.nudNbOfSlowHumans.Value, (int)this.nudNbOfMediumHumans.Value, (int)this.nudNbOfFastHumans.Value);
        }

        private void BtnOpenEditor_Click(object sender, System.EventArgs e)
        {
            FormGlobusEditor editor = new FormGlobusEditor();
            if (editor.ShowDialog() == DialogResult.OK)
            {
                //this.GlobusShop = new GlobusShop(editor.GlobusEditor);
            }
        }
        #endregion

        private void PnlGlobusShop_Paint(object sender, PaintEventArgs e)
        {
            this.GlobusShop.StoreSections.ForEach(ss => { e.Graphics.DrawRectangle(new Pen(ss.Color), ss.Shape); e.Graphics.FillRectangle(new SolidBrush(ss.Color), ss.Shape); });
            this.GlobusShop.Checkouts.FindAll(c => c.IsOpened).ForEach(c => { e.Graphics.DrawRectangle(new Pen(c.Color), c.Shape); e.Graphics.FillRectangle(new SolidBrush(c.Color), c.Shape); });
            this.GlobusShop.Humans.ForEach(h => { e.Graphics.DrawRectangle(new Pen(h.Color), h.Shape); e.Graphics.FillRectangle(new SolidBrush(h.Color), h.Shape); });
        }

        public void Notify()
        {
            this.pnlGlobusShop.Invalidate();
        }
    }
}
