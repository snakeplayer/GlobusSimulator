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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAndExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxObjectToDraw = new System.Windows.Forms.ComboBox();
            this.gbxDrawingZone = new System.Windows.Forms.GroupBox();
            this.pnlDrawingZone = new System.Windows.Forms.Panel();
            this.gbxTools.SuspendLayout();
            this.gbxDrawingZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxTools
            // 
            this.gbxTools.Controls.Add(this.btnCancel);
            this.gbxTools.Controls.Add(this.btnSaveAndExit);
            this.gbxTools.Controls.Add(this.btnClear);
            this.gbxTools.Controls.Add(this.label1);
            this.gbxTools.Controls.Add(this.cbxObjectToDraw);
            this.gbxTools.Location = new System.Drawing.Point(12, 420);
            this.gbxTools.Name = "gbxTools";
            this.gbxTools.Size = new System.Drawing.Size(690, 52);
            this.gbxTools.TabIndex = 0;
            this.gbxTools.TabStop = false;
            this.gbxTools.Text = "Tools";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(452, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSaveAndExit
            // 
            this.btnSaveAndExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveAndExit.Location = new System.Drawing.Point(533, 19);
            this.btnSaveAndExit.Name = "btnSaveAndExit";
            this.btnSaveAndExit.Size = new System.Drawing.Size(151, 23);
            this.btnSaveAndExit.TabIndex = 3;
            this.btnSaveAndExit.Text = "Save & Back to the shop";
            this.btnSaveAndExit.UseMnemonic = false;
            this.btnSaveAndExit.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(343, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(103, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Object to draw:";
            // 
            // cbxObjectToDraw
            // 
            this.cbxObjectToDraw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxObjectToDraw.FormattingEnabled = true;
            this.cbxObjectToDraw.Location = new System.Drawing.Point(91, 19);
            this.cbxObjectToDraw.Name = "cbxObjectToDraw";
            this.cbxObjectToDraw.Size = new System.Drawing.Size(121, 21);
            this.cbxObjectToDraw.TabIndex = 0;
            // 
            // gbxDrawingZone
            // 
            this.gbxDrawingZone.Controls.Add(this.pnlDrawingZone);
            this.gbxDrawingZone.Location = new System.Drawing.Point(12, 12);
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
            this.pnlDrawingZone.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlDrawingZone_Paint);
            this.pnlDrawingZone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PnlDrawingZone_MouseClick);
            this.pnlDrawingZone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlDrawingZone_MouseDown);
            this.pnlDrawingZone.MouseLeave += new System.EventHandler(this.PnlDrawingZone_MouseLeave);
            this.pnlDrawingZone.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlDrawingZone_MouseMove);
            // 
            // FormGlobusEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 485);
            this.Controls.Add(this.gbxDrawingZone);
            this.Controls.Add(this.gbxTools);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGlobusEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Globus Editor";
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
        private System.Windows.Forms.Button btnSaveAndExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlDrawingZone;
    }
}