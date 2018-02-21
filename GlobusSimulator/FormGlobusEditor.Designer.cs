namespace GlobusSimulator
{
    partial class FormGlobusEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxTools = new System.Windows.Forms.GroupBox();
            this.gbxDrawingZone = new System.Windows.Forms.GroupBox();
            this.pnlDrawingZone = new System.Windows.Forms.Panel();
            this.cbxObjectToDraw = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxTools.SuspendLayout();
            this.gbxDrawingZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxTools
            // 
            this.gbxTools.Controls.Add(this.label1);
            this.gbxTools.Controls.Add(this.cbxObjectToDraw);
            this.gbxTools.Location = new System.Drawing.Point(13, 13);
            this.gbxTools.Name = "gbxTools";
            this.gbxTools.Size = new System.Drawing.Size(690, 105);
            this.gbxTools.TabIndex = 0;
            this.gbxTools.TabStop = false;
            this.gbxTools.Text = "Tools";
            // 
            // gbxDrawingZone
            // 
            this.gbxDrawingZone.Controls.Add(this.pnlDrawingZone);
            this.gbxDrawingZone.Location = new System.Drawing.Point(13, 125);
            this.gbxDrawingZone.Name = "gbxDrawingZone";
            this.gbxDrawingZone.Size = new System.Drawing.Size(690, 402);
            this.gbxDrawingZone.TabIndex = 1;
            this.gbxDrawingZone.TabStop = false;
            this.gbxDrawingZone.Text = "Drawing zone";
            // 
            // pnlDrawingZone
            // 
            this.pnlDrawingZone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDrawingZone.Location = new System.Drawing.Point(7, 20);
            this.pnlDrawingZone.Name = "pnlDrawingZone";
            this.pnlDrawingZone.Size = new System.Drawing.Size(677, 376);
            this.pnlDrawingZone.TabIndex = 0;
            this.pnlDrawingZone.Click += new System.EventHandler(this.pnlDrawingZone_Click);
            // 
            // cbxObjectToDraw
            // 
            this.cbxObjectToDraw.FormattingEnabled = true;
            this.cbxObjectToDraw.Items.AddRange(new object[] {
            "Path",
            "Store section",
            "Checkout"});
            this.cbxObjectToDraw.Location = new System.Drawing.Point(91, 19);
            this.cbxObjectToDraw.Name = "cbxObjectToDraw";
            this.cbxObjectToDraw.Size = new System.Drawing.Size(121, 21);
            this.cbxObjectToDraw.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Object to draw:";
            // 
            // FormGlobusEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 539);
            this.Controls.Add(this.gbxDrawingZone);
            this.Controls.Add(this.gbxTools);
            this.Name = "FormGlobusEditor";
            this.Text = "FormGlobusEditor";
            this.gbxTools.ResumeLayout(false);
            this.gbxTools.PerformLayout();
            this.gbxDrawingZone.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxTools;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxObjectToDraw;
        private System.Windows.Forms.GroupBox gbxDrawingZone;
        private System.Windows.Forms.Panel pnlDrawingZone;
    }
}