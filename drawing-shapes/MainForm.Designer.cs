namespace draw_shapes
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
            this.create = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDrawingArea)).BeginInit();
            this.gbShapes.SuspendLayout();
            this.pnlShapes.SuspendLayout();
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
            this.pnlDrawingArea.Size = new System.Drawing.Size(1078, 676);
            this.pnlDrawingArea.TabIndex = 8;
            this.pnlDrawingArea.TabStop = false;
            this.pnlDrawingArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlDrawingArea_MouseDown);
            this.pnlDrawingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlDrawingArea_MouseMove);
            this.pnlDrawingArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlDrawingArea_MouseUp);
            // 
            // btnSirialize
            // 
            this.btnSirialize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSirialize.Location = new System.Drawing.Point(1094, 543);
            this.btnSirialize.Name = "btnSirialize";
            this.btnSirialize.Size = new System.Drawing.Size(139, 44);
            this.btnSirialize.TabIndex = 9;
            this.btnSirialize.Text = "Serealize";
            this.btnSirialize.UseVisualStyleBackColor = true;
            this.btnSirialize.Click += new System.EventHandler(this.BtnSerealize_Click);
            // 
            // btnDesirialized
            // 
            this.btnDesirialized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesirialized.Location = new System.Drawing.Point(1094, 593);
            this.btnDesirialized.Name = "btnDesirialized";
            this.btnDesirialized.Size = new System.Drawing.Size(139, 44);
            this.btnDesirialized.TabIndex = 10;
            this.btnDesirialized.Text = "Desirialize";
            this.btnDesirialized.UseVisualStyleBackColor = true;
            this.btnDesirialized.Click += new System.EventHandler(this.BtnDesirialized_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(1094, 643);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(139, 44);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // gbShapes
            // 
            this.gbShapes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbShapes.Controls.Add(this.pnlShapes);
            this.gbShapes.Location = new System.Drawing.Point(1096, 12);
            this.gbShapes.Name = "gbShapes";
            this.gbShapes.Size = new System.Drawing.Size(145, 514);
            this.gbShapes.TabIndex = 0;
            this.gbShapes.TabStop = false;
            this.gbShapes.Text = "Shapes";
            // 
            // pnlShapes
            // 
            this.pnlShapes.AutoScroll = true;
            this.pnlShapes.Controls.Add(this.button2);
            this.pnlShapes.Controls.Add(this.create);
            this.pnlShapes.Location = new System.Drawing.Point(0, 25);
            this.pnlShapes.Name = "pnlShapes";
            this.pnlShapes.Size = new System.Drawing.Size(139, 483);
            this.pnlShapes.TabIndex = 0;
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(6, 390);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(130, 35);
            this.create.TabIndex = 12;
            this.create.Text = "dra";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 431);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 49);
            this.button2.TabIndex = 13;
            this.button2.Text = "create";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1245, 699);
            this.Controls.Add(this.gbShapes);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDesirialized);
            this.Controls.Add(this.btnSirialize);
            this.Controls.Add(this.pnlDrawingArea);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shapes";
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDrawingArea)).EndInit();
            this.gbShapes.ResumeLayout(false);
            this.pnlShapes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pnlDrawingArea;
        private System.Windows.Forms.Button btnSirialize;
        private System.Windows.Forms.Button btnDesirialized;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gbShapes;
        private System.Windows.Forms.Panel pnlShapes;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button button2;
    }
}

