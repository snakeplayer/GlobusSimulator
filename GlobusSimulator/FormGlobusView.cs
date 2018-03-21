/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 21.02.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : FormGlobusView.cs
 * Class desc. : Reprensents a globus store - main view
 */
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
        /// <summary>
        /// Initializes a new instance of the <see cref="FormGlobusView"/> class.
        /// </summary>
        public FormGlobusView()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember(nameof(DoubleBuffered), System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, this.pnlGlobusShop, new object[] { true }); // Enable the double buffer on the panel
        }
        #endregion

        #region Methods
        /// <summary>
        /// Handles the Click event of the BtnStartStop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnStartStop_Click(object sender, System.EventArgs e)
        {
            this.GlobusShop.Simulate((int)this.nudNbOfSlowHumans.Value, (int)this.nudNbOfMediumHumans.Value, (int)this.nudNbOfFastHumans.Value, this.chkAutoAddHumans.Checked, (int)nudHumansPerMinute.Value);
        }

        /// <summary>
        /// Handles the Click event of the BtnOpenEditor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnOpenEditor_Click(object sender, System.EventArgs e)
        {
            FormGlobusEditor editor = new FormGlobusEditor();
            if (editor.ShowDialog() == DialogResult.OK)
            {
                this.GlobusShop = new GlobusShop(editor.GlobusShopEditor, this);
                this.btnStartStop.Enabled = true;
            }
        }
        #endregion

        /// <summary>
        /// Handles the Paint event of the PnlGlobusShop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PnlGlobusShop_Paint(object sender, PaintEventArgs e)
        {
            this.GlobusShop.StoreSections.ForEach(ss => { e.Graphics.DrawRectangle(new Pen(ss.Color), ss.Shape); e.Graphics.FillRectangle(new SolidBrush(ss.Color), ss.Shape); });
            this.GlobusShop.Checkouts.ForEach(c =>
            {
                e.Graphics.DrawRectangle(new Pen(c.Color), c.Shape);
                e.Graphics.FillRectangle(new SolidBrush(c.Color), c.Shape);
                StringFormat sf = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                e.Graphics.DrawString($"{c.NumberOfHumans}/{c.MaxNumberOfHumans}", this.Font, Brushes.White, c.Shape, sf);

            });

            this.GlobusShop.Humans.ForEach(h => { e.Graphics.DrawRectangle(new Pen(h.Type.Color), h.Shape); e.Graphics.FillRectangle(new SolidBrush(h.Type.Color), h.Shape); });
        }

        /// <summary>
        /// Notifies this instance.
        /// </summary>
        public void Notify()
        {
            try
            {
                this.pnlGlobusShop.Invalidate(); // Force the panel to be repaint
                this.Invoke((MethodInvoker)(() => { if (this.GlobusShop != null) this.btnStartStop.Text = (this.GlobusShop.IsSimulationStarted ? "Stop" : "Start"); })); // Invoke an anonymous method to modify the components because we are in a different thread
            }
            catch
            {
                // An error can be thrown when the view is being notify and the user quit the application.
            }
        }

        /// <summary>
        /// Handles the Load event of the FormGlobusView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FormGlobusView_Load(object sender, System.EventArgs e)
        {
            this.GlobusShop = new GlobusShop(this);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the ChkAutoAddHumans control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ChkAutoAddHumans_CheckedChanged(object sender, System.EventArgs e)
        {
            this.nudHumansPerMinute.Enabled = chkAutoAddHumans.Checked;
        }
    }
}
