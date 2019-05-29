﻿namespace draw_shapes
{
    partial class FrmMain
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
            this.pnlDrawingArea = new System.Windows.Forms.PictureBox();
            this.btnSirialize = new System.Windows.Forms.Button();
            this.btnDesirialized = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.gbShapes = new System.Windows.Forms.GroupBox();
            this.pnlShapes = new System.Windows.Forms.Panel();
            this.gbUserShapes = new System.Windows.Forms.GroupBox();
            this.pnlUserShapes = new System.Windows.Forms.Panel();
            this.btnCreateShape = new System.Windows.Forms.Button();
            this.btnDeleteUserFigure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDrawingArea)).BeginInit();
            this.gbShapes.SuspendLayout();
            this.gbUserShapes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDrawingArea
            // 
            this.pnlDrawingArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDrawingArea.BackColor = System.Drawing.Color.White;
            this.pnlDrawingArea.Location = new System.Drawing.Point(12, 12);
            this.pnlDrawingArea.Name = "pnlDrawingArea";
            this.pnlDrawingArea.Size = new System.Drawing.Size(912, 676);
            this.pnlDrawingArea.TabIndex = 8;
            this.pnlDrawingArea.TabStop = false;
            this.pnlDrawingArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlDrawingArea_MouseDown);
            this.pnlDrawingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlDrawingArea_MouseMove);
            this.pnlDrawingArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlDrawingArea_MouseUp);
            // 
            // btnSirialize
            // 
            this.btnSirialize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSirialize.Location = new System.Drawing.Point(936, 532);
            this.btnSirialize.Name = "btnSirialize";
            this.btnSirialize.Size = new System.Drawing.Size(160, 44);
            this.btnSirialize.TabIndex = 9;
            this.btnSirialize.Text = "Serealize";
            this.btnSirialize.UseVisualStyleBackColor = true;
            this.btnSirialize.Click += new System.EventHandler(this.BtnSerealize_Click);
            // 
            // btnDesirialized
            // 
            this.btnDesirialized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesirialized.Location = new System.Drawing.Point(936, 582);
            this.btnDesirialized.Name = "btnDesirialized";
            this.btnDesirialized.Size = new System.Drawing.Size(160, 44);
            this.btnDesirialized.TabIndex = 10;
            this.btnDesirialized.Text = "Desirialize";
            this.btnDesirialized.UseVisualStyleBackColor = true;
            this.btnDesirialized.Click += new System.EventHandler(this.BtnDesirialized_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(936, 632);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(160, 44);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // gbShapes
            // 
            this.gbShapes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbShapes.Controls.Add(this.pnlShapes);
            this.gbShapes.Location = new System.Drawing.Point(930, 12);
            this.gbShapes.Name = "gbShapes";
            this.gbShapes.Size = new System.Drawing.Size(172, 514);
            this.gbShapes.TabIndex = 0;
            this.gbShapes.TabStop = false;
            this.gbShapes.Text = "Shapes";
            // 
            // pnlShapes
            // 
            this.pnlShapes.AutoScroll = true;
            this.pnlShapes.Location = new System.Drawing.Point(6, 25);
            this.pnlShapes.Name = "pnlShapes";
            this.pnlShapes.Size = new System.Drawing.Size(160, 483);
            this.pnlShapes.TabIndex = 0;
            // 
            // gbUserShapes
            // 
            this.gbUserShapes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUserShapes.Controls.Add(this.pnlUserShapes);
            this.gbUserShapes.Location = new System.Drawing.Point(1108, 12);
            this.gbUserShapes.Name = "gbUserShapes";
            this.gbUserShapes.Size = new System.Drawing.Size(175, 514);
            this.gbUserShapes.TabIndex = 12;
            this.gbUserShapes.TabStop = false;
            this.gbUserShapes.Text = "User Shapes";
            // 
            // pnlUserShapes
            // 
            this.pnlUserShapes.AutoScroll = true;
            this.pnlUserShapes.Location = new System.Drawing.Point(6, 25);
            this.pnlUserShapes.Name = "pnlUserShapes";
            this.pnlUserShapes.Size = new System.Drawing.Size(161, 483);
            this.pnlUserShapes.TabIndex = 0;
            // 
            // btnCreateShape
            // 
            this.btnCreateShape.Location = new System.Drawing.Point(1108, 532);
            this.btnCreateShape.Name = "btnCreateShape";
            this.btnCreateShape.Size = new System.Drawing.Size(167, 44);
            this.btnCreateShape.TabIndex = 13;
            this.btnCreateShape.Text = "Create Shape";
            this.btnCreateShape.UseVisualStyleBackColor = true;
            this.btnCreateShape.Click += new System.EventHandler(this.BtnCreateShape_Click);
            // 
            // btnDeleteUserFigure
            // 
            this.btnDeleteUserFigure.Location = new System.Drawing.Point(1108, 582);
            this.btnDeleteUserFigure.Name = "btnDeleteUserFigure";
            this.btnDeleteUserFigure.Size = new System.Drawing.Size(167, 44);
            this.btnDeleteUserFigure.TabIndex = 0;
            this.btnDeleteUserFigure.Text = "Delete User Figure";
            this.btnDeleteUserFigure.UseVisualStyleBackColor = true;
            this.btnDeleteUserFigure.Click += new System.EventHandler(this.BtnDeleteUserFigure_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1287, 699);
            this.Controls.Add(this.btnDeleteUserFigure);
            this.Controls.Add(this.btnCreateShape);
            this.Controls.Add(this.gbUserShapes);
            this.Controls.Add(this.gbShapes);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDesirialized);
            this.Controls.Add(this.btnSirialize);
            this.Controls.Add(this.pnlDrawingArea);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shapes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDrawingArea)).EndInit();
            this.gbShapes.ResumeLayout(false);
            this.gbUserShapes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pnlDrawingArea;
        private System.Windows.Forms.Button btnSirialize;
        private System.Windows.Forms.Button btnDesirialized;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gbShapes;
        private System.Windows.Forms.Panel pnlShapes;
        private System.Windows.Forms.GroupBox gbUserShapes;
        private System.Windows.Forms.Panel pnlUserShapes;
        private System.Windows.Forms.Button btnCreateShape;
        private System.Windows.Forms.Button btnDeleteUserFigure;
    }
}

