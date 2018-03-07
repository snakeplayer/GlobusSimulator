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
            this.pnlDrawingZone = new System.Windows.Forms.Panel();
            this.nudNbOfHumans = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxDrawingZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNbOfHumans)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenEditor
            // 
            this.btnOpenEditor.Location = new System.Drawing.Point(15, 18);
            this.btnOpenEditor.Name = "btnOpenEditor";
            this.btnOpenEditor.Size = new System.Drawing.Size(75, 23);
            this.btnOpenEditor.TabIndex = 0;
            this.btnOpenEditor.Text = "Open Editor";
            this.btnOpenEditor.UseVisualStyleBackColor = true;
            this.btnOpenEditor.Click += new System.EventHandler(this.BtnOpenEditor_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(310, 20);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.BtnStartStop_Click);
            // 
            // gbxDrawingZone
            // 
            this.gbxDrawingZone.Controls.Add(this.pnlDrawingZone);
            this.gbxDrawingZone.Location = new System.Drawing.Point(12, 12);
            this.gbxDrawingZone.Name = "gbxDrawingZone";
            this.gbxDrawingZone.Size = new System.Drawing.Size(690, 402);
            this.gbxDrawingZone.TabIndex = 4;
            this.gbxDrawingZone.TabStop = false;
            this.gbxDrawingZone.Text = "My Globus";
            // 
            // pnlDrawingZone
            // 
            this.pnlDrawingZone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDrawingZone.Location = new System.Drawing.Point(7, 20);
            this.pnlDrawingZone.Name = "pnlDrawingZone";
            this.pnlDrawingZone.Size = new System.Drawing.Size(677, 376);
            this.pnlDrawingZone.TabIndex = 0;
            // 
            // nudNbOfHumans
            // 
            this.nudNbOfHumans.Location = new System.Drawing.Point(204, 21);
            this.nudNbOfHumans.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudNbOfHumans.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNbOfHumans.Name = "nudNbOfHumans";
            this.nudNbOfHumans.Size = new System.Drawing.Size(99, 20);
            this.nudNbOfHumans.TabIndex = 5;
            this.nudNbOfHumans.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOpenEditor);
            this.groupBox1.Controls.Add(this.nudNbOfHumans);
            this.groupBox1.Controls.Add(this.btnStartStop);
            this.groupBox1.Location = new System.Drawing.Point(12, 414);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 53);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Number of humans :";
            // 
            // FormGlobusView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 479);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxDrawingZone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGlobusView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Globus Simulator";
            this.gbxDrawingZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudNbOfHumans)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenEditor;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.GroupBox gbxDrawingZone;
        private System.Windows.Forms.Panel pnlDrawingZone;
        private System.Windows.Forms.NumericUpDown nudNbOfHumans;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}

