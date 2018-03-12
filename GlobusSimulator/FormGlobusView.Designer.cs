namespace GlobusSimulator
{
    partial class FormGlobusView
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenEditor = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.gbxDrawingZone = new System.Windows.Forms.GroupBox();
            this.pnlGlobusShop = new System.Windows.Forms.Panel();
            this.nudNbOfSlowHumans = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAutoAddHumans = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudNbOfFastHumans = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudNbOfMediumHumans = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxDrawingZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNbOfSlowHumans)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNbOfFastHumans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNbOfMediumHumans)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenEditor
            // 
            this.btnOpenEditor.Location = new System.Drawing.Point(90, 23);
            this.btnOpenEditor.Name = "btnOpenEditor";
            this.btnOpenEditor.Size = new System.Drawing.Size(75, 72);
            this.btnOpenEditor.TabIndex = 0;
            this.btnOpenEditor.Text = "Open Editor";
            this.btnOpenEditor.UseVisualStyleBackColor = true;
            this.btnOpenEditor.Click += new System.EventHandler(this.BtnOpenEditor_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Enabled = false;
            this.btnStartStop.Location = new System.Drawing.Point(423, 23);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 72);
            this.btnStartStop.TabIndex = 7;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.BtnStartStop_Click);
            // 
            // gbxDrawingZone
            // 
            this.gbxDrawingZone.Controls.Add(this.pnlGlobusShop);
            this.gbxDrawingZone.Location = new System.Drawing.Point(12, 12);
            this.gbxDrawingZone.Name = "gbxDrawingZone";
            this.gbxDrawingZone.Size = new System.Drawing.Size(690, 402);
            this.gbxDrawingZone.TabIndex = 0;
            this.gbxDrawingZone.TabStop = false;
            this.gbxDrawingZone.Text = "My Globus";
            // 
            // pnlGlobusShop
            // 
            this.pnlGlobusShop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGlobusShop.Location = new System.Drawing.Point(7, 20);
            this.pnlGlobusShop.Name = "pnlGlobusShop";
            this.pnlGlobusShop.Size = new System.Drawing.Size(677, 376);
            this.pnlGlobusShop.TabIndex = 0;
            this.pnlGlobusShop.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlGlobusShop_Paint);
            // 
            // nudNbOfSlowHumans
            // 
            this.nudNbOfSlowHumans.Location = new System.Drawing.Point(318, 23);
            this.nudNbOfSlowHumans.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudNbOfSlowHumans.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNbOfSlowHumans.Name = "nudNbOfSlowHumans";
            this.nudNbOfSlowHumans.Size = new System.Drawing.Size(99, 20);
            this.nudNbOfSlowHumans.TabIndex = 2;
            this.nudNbOfSlowHumans.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAutoAddHumans);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudNbOfFastHumans);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudNbOfMediumHumans);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOpenEditor);
            this.groupBox1.Controls.Add(this.nudNbOfSlowHumans);
            this.groupBox1.Controls.Add(this.btnStartStop);
            this.groupBox1.Location = new System.Drawing.Point(12, 414);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            // 
            // chkAutoAddHumans
            // 
            this.chkAutoAddHumans.AutoSize = true;
            this.chkAutoAddHumans.Location = new System.Drawing.Point(504, 52);
            this.chkAutoAddHumans.Name = "chkAutoAddHumans";
            this.chkAutoAddHumans.Size = new System.Drawing.Size(112, 17);
            this.chkAutoAddHumans.TabIndex = 8;
            this.chkAutoAddHumans.Text = "Auto Add Humans";
            this.chkAutoAddHumans.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number of fast humans :";
            // 
            // nudNbOfFastHumans
            // 
            this.nudNbOfFastHumans.Location = new System.Drawing.Point(318, 75);
            this.nudNbOfFastHumans.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudNbOfFastHumans.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNbOfFastHumans.Name = "nudNbOfFastHumans";
            this.nudNbOfFastHumans.Size = new System.Drawing.Size(99, 20);
            this.nudNbOfFastHumans.TabIndex = 6;
            this.nudNbOfFastHumans.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of medium humans :";
            // 
            // nudNbOfMediumHumans
            // 
            this.nudNbOfMediumHumans.Location = new System.Drawing.Point(318, 49);
            this.nudNbOfMediumHumans.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudNbOfMediumHumans.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNbOfMediumHumans.Name = "nudNbOfMediumHumans";
            this.nudNbOfMediumHumans.Size = new System.Drawing.Size(99, 20);
            this.nudNbOfMediumHumans.TabIndex = 4;
            this.nudNbOfMediumHumans.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of slow humans :";
            // 
            // FormGlobusView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 536);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxDrawingZone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGlobusView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Globus Simulator";
            this.gbxDrawingZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudNbOfSlowHumans)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNbOfFastHumans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNbOfMediumHumans)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenEditor;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.GroupBox gbxDrawingZone;
        private System.Windows.Forms.Panel pnlGlobusShop;
        private System.Windows.Forms.NumericUpDown nudNbOfSlowHumans;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAutoAddHumans;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudNbOfFastHumans;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudNbOfMediumHumans;
    }
}

