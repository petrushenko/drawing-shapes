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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.languageSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.russianSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.englishSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.themeSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.daySubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.nightSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDrawingArea)).BeginInit();
            this.gbShapes.SuspendLayout();
            this.gbUserShapes.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDrawingArea
            // 
            resources.ApplyResources(this.pnlDrawingArea, "pnlDrawingArea");
            this.pnlDrawingArea.BackColor = System.Drawing.Color.White;
            this.pnlDrawingArea.Name = "pnlDrawingArea";
            this.pnlDrawingArea.TabStop = false;
            this.pnlDrawingArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlDrawingArea_MouseDown);
            this.pnlDrawingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlDrawingArea_MouseMove);
            this.pnlDrawingArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlDrawingArea_MouseUp);
            // 
            // btnSirialize
            // 
            resources.ApplyResources(this.btnSirialize, "btnSirialize");
            this.btnSirialize.Name = "btnSirialize";
            this.btnSirialize.UseVisualStyleBackColor = true;
            this.btnSirialize.Click += new System.EventHandler(this.BtnSerealize_Click);
            // 
            // btnDesirialized
            // 
            resources.ApplyResources(this.btnDesirialized, "btnDesirialized");
            this.btnDesirialized.Name = "btnDesirialized";
            this.btnDesirialized.UseVisualStyleBackColor = true;
            this.btnDesirialized.Click += new System.EventHandler(this.BtnDesirialized_Click);
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // gbShapes
            // 
            resources.ApplyResources(this.gbShapes, "gbShapes");
            this.gbShapes.Controls.Add(this.pnlShapes);
            this.gbShapes.Name = "gbShapes";
            this.gbShapes.TabStop = false;
            // 
            // pnlShapes
            // 
            resources.ApplyResources(this.pnlShapes, "pnlShapes");
            this.pnlShapes.Name = "pnlShapes";
            // 
            // gbUserShapes
            // 
            resources.ApplyResources(this.gbUserShapes, "gbUserShapes");
            this.gbUserShapes.Controls.Add(this.pnlUserShapes);
            this.gbUserShapes.Name = "gbUserShapes";
            this.gbUserShapes.TabStop = false;
            // 
            // pnlUserShapes
            // 
            resources.ApplyResources(this.pnlUserShapes, "pnlUserShapes");
            this.pnlUserShapes.Name = "pnlUserShapes";
            // 
            // btnCreateShape
            // 
            resources.ApplyResources(this.btnCreateShape, "btnCreateShape");
            this.btnCreateShape.Name = "btnCreateShape";
            this.btnCreateShape.UseVisualStyleBackColor = true;
            this.btnCreateShape.Click += new System.EventHandler(this.BtnCreateShape_Click);
            // 
            // btnDeleteUserFigure
            // 
            resources.ApplyResources(this.btnDeleteUserFigure, "btnDeleteUserFigure");
            this.btnDeleteUserFigure.Name = "btnDeleteUserFigure";
            this.btnDeleteUserFigure.UseVisualStyleBackColor = true;
            this.btnDeleteUserFigure.Click += new System.EventHandler(this.BtnDeleteUserFigure_Click);
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewMenu});
            resources.ApplyResources(this.menu, "menu");
            this.menu.Name = "menu";
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageSubMenu,
            this.themeSubMenu});
            this.viewMenu.Name = "viewMenu";
            resources.ApplyResources(this.viewMenu, "viewMenu");
            // 
            // languageSubMenu
            // 
            this.languageSubMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.russianSubMenu,
            this.englishSubMenu});
            this.languageSubMenu.Name = "languageSubMenu";
            resources.ApplyResources(this.languageSubMenu, "languageSubMenu");
            // 
            // russianSubMenu
            // 
            this.russianSubMenu.Name = "russianSubMenu";
            resources.ApplyResources(this.russianSubMenu, "russianSubMenu");
            this.russianSubMenu.Click += new System.EventHandler(this.RussianToolStripMenuItem_Click);
            // 
            // englishSubMenu
            // 
            this.englishSubMenu.Name = "englishSubMenu";
            resources.ApplyResources(this.englishSubMenu, "englishSubMenu");
            this.englishSubMenu.Click += new System.EventHandler(this.EnglishToolStripMenuItem_Click);
            // 
            // themeSubMenu
            // 
            this.themeSubMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.daySubMenu,
            this.nightSubMenu});
            this.themeSubMenu.Name = "themeSubMenu";
            resources.ApplyResources(this.themeSubMenu, "themeSubMenu");
            // 
            // daySubMenu
            // 
            this.daySubMenu.Name = "daySubMenu";
            resources.ApplyResources(this.daySubMenu, "daySubMenu");
            this.daySubMenu.Click += new System.EventHandler(this.DayToolStripMenuItem_Click);
            // 
            // nightSubMenu
            // 
            this.nightSubMenu.Name = "nightSubMenu";
            resources.ApplyResources(this.nightSubMenu, "nightSubMenu");
            this.nightSubMenu.Click += new System.EventHandler(this.NightToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnDeleteUserFigure);
            this.Controls.Add(this.gbUserShapes);
            this.Controls.Add(this.btnCreateShape);
            this.Controls.Add(this.btnSirialize);
            this.Controls.Add(this.gbShapes);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDesirialized);
            this.Controls.Add(this.pnlDrawingArea);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menu;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDrawingArea)).EndInit();
            this.gbShapes.ResumeLayout(false);
            this.gbUserShapes.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem languageSubMenu;
        private System.Windows.Forms.ToolStripMenuItem russianSubMenu;
        private System.Windows.Forms.ToolStripMenuItem englishSubMenu;
        private System.Windows.Forms.ToolStripMenuItem themeSubMenu;
        private System.Windows.Forms.ToolStripMenuItem daySubMenu;
        private System.Windows.Forms.ToolStripMenuItem nightSubMenu;
    }
}

