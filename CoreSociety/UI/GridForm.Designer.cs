namespace CoreSociety.UI
{
    partial class GridForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridForm));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnStartPause = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnMission = new System.Windows.Forms.ToolStripButton();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEnergy = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtEnergyPerTick = new System.Windows.Forms.Label();
            this.txtTicksPerSecond = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.batchSize = new System.Windows.Forms.TrackBar();
            this.autoRunSpeed = new System.Windows.Forms.TrackBar();
            this.gridContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runClock = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.gridView = new CoreSociety.UI.GridView();
            this.deckView = new CoreSociety.UI.DeckView();
            this.mainToolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.batchSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoRunSpeed)).BeginInit();
            this.gridContextMenu.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.BackColor = System.Drawing.Color.Gold;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.btnSave,
            this.btnStartPause,
            this.btnStop,
            this.btnMission});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(695, 25);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "mainToolStrip";
            // 
            // btnLoad
            // 
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(23, 22);
            this.btnLoad.Text = "Load Grid Layout";
            this.btnLoad.ToolTipText = "Load Grid Layout";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Save Grid Layout";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStartPause
            // 
            this.btnStartPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStartPause.Image = ((System.Drawing.Image)(resources.GetObject("btnStartPause.Image")));
            this.btnStartPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartPause.Name = "btnStartPause";
            this.btnStartPause.Size = new System.Drawing.Size(23, 22);
            this.btnStartPause.Text = "Start/Pause";
            this.btnStartPause.ToolTipText = "Start/Pause";
            this.btnStartPause.Click += new System.EventHandler(this.btnStartPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(23, 22);
            this.btnStop.Text = "Stop";
            this.btnStop.ToolTipText = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnMission
            // 
            this.btnMission.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMission.Image = global::CoreSociety.Properties.Resources.HelpIcon;
            this.btnMission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMission.Name = "btnMission";
            this.btnMission.Size = new System.Drawing.Size(23, 22);
            this.btnMission.Text = "Mission";
            this.btnMission.Click += new System.EventHandler(this.btnMission_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.SlateBlue;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 22);
            this.label5.TabIndex = 13;
            this.label5.Text = "Grid Power";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.txtEnergy);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(163, 596);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 71);
            this.panel1.TabIndex = 1;
            // 
            // txtEnergy
            // 
            this.txtEnergy.AutoSize = true;
            this.txtEnergy.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnergy.ForeColor = System.Drawing.Color.Gold;
            this.txtEnergy.Location = new System.Drawing.Point(3, 25);
            this.txtEnergy.Name = "txtEnergy";
            this.txtEnergy.Size = new System.Drawing.Size(143, 37);
            this.txtEnergy.TabIndex = 14;
            this.txtEnergy.Text = "0000000";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.txtScore);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(315, 596);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(113, 71);
            this.panel2.TabIndex = 14;
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.ForeColor = System.Drawing.Color.Gold;
            this.txtScore.Location = new System.Drawing.Point(3, 25);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(107, 37);
            this.txtScore.TabIndex = 15;
            this.txtScore.Text = "00000";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.SlateBlue;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "Score";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(55)))));
            this.panel3.Controls.Add(this.deckView);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(434, 596);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(249, 71);
            this.panel3.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SlateBlue;
            this.label6.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(3);
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(22, 71);
            this.label6.TabIndex = 13;
            this.label6.Text = "DECK";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(55)))));
            this.panel4.Controls.Add(this.txtEnergyPerTick);
            this.panel4.Controls.Add(this.txtTicksPerSecond);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.batchSize);
            this.panel4.Controls.Add(this.autoRunSpeed);
            this.panel4.Location = new System.Drawing.Point(11, 596);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(146, 71);
            this.panel4.TabIndex = 16;
            // 
            // txtEnergyPerTick
            // 
            this.txtEnergyPerTick.AutoSize = true;
            this.txtEnergyPerTick.BackColor = System.Drawing.Color.Transparent;
            this.txtEnergyPerTick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtEnergyPerTick.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnergyPerTick.ForeColor = System.Drawing.Color.Gold;
            this.txtEnergyPerTick.Location = new System.Drawing.Point(101, 48);
            this.txtEnergyPerTick.Name = "txtEnergyPerTick";
            this.txtEnergyPerTick.Size = new System.Drawing.Size(28, 14);
            this.txtEnergyPerTick.TabIndex = 20;
            this.txtEnergyPerTick.Text = "E:1";
            this.txtEnergyPerTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTicksPerSecond
            // 
            this.txtTicksPerSecond.AutoSize = true;
            this.txtTicksPerSecond.BackColor = System.Drawing.Color.Transparent;
            this.txtTicksPerSecond.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtTicksPerSecond.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTicksPerSecond.ForeColor = System.Drawing.Color.Gold;
            this.txtTicksPerSecond.Location = new System.Drawing.Point(101, 25);
            this.txtTicksPerSecond.Name = "txtTicksPerSecond";
            this.txtTicksPerSecond.Size = new System.Drawing.Size(35, 14);
            this.txtTicksPerSecond.TabIndex = 19;
            this.txtTicksPerSecond.Text = "T:30";
            this.txtTicksPerSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.SlateBlue;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 22);
            this.label7.TabIndex = 13;
            this.label7.Text = "Speed";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // batchSize
            // 
            this.batchSize.Location = new System.Drawing.Point(0, 48);
            this.batchSize.Maximum = 15;
            this.batchSize.Minimum = 1;
            this.batchSize.Name = "batchSize";
            this.batchSize.Size = new System.Drawing.Size(104, 45);
            this.batchSize.TabIndex = 18;
            this.batchSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.batchSize.Value = 1;
            this.batchSize.Scroll += new System.EventHandler(this.batchSize_Scroll);
            // 
            // autoRunSpeed
            // 
            this.autoRunSpeed.Location = new System.Drawing.Point(0, 23);
            this.autoRunSpeed.Maximum = 30;
            this.autoRunSpeed.Minimum = 3;
            this.autoRunSpeed.Name = "autoRunSpeed";
            this.autoRunSpeed.Size = new System.Drawing.Size(104, 45);
            this.autoRunSpeed.SmallChange = 3;
            this.autoRunSpeed.TabIndex = 17;
            this.autoRunSpeed.TickFrequency = 3;
            this.autoRunSpeed.Value = 30;
            this.autoRunSpeed.ValueChanged += new System.EventHandler(this.autoRunSpeed_ValueChanged);
            // 
            // gridContextMenu
            // 
            this.gridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.deckToolStripMenuItem});
            this.gridContextMenu.Name = "gridContextMenu";
            this.gridContextMenu.Size = new System.Drawing.Size(103, 92);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // deckToolStripMenuItem
            // 
            this.deckToolStripMenuItem.Name = "deckToolStripMenuItem";
            this.deckToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.deckToolStripMenuItem.Text = "Deck";
            // 
            // runClock
            // 
            this.runClock.Enabled = true;
            this.runClock.Interval = 33;
            this.runClock.Tick += new System.EventHandler(this.runClock_Tick);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.SlateBlue;
            this.panel5.Controls.Add(this.gridView);
            this.panel5.Location = new System.Drawing.Point(11, 39);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(672, 551);
            this.panel5.TabIndex = 18;
            // 
            // gridView
            // 
            this.gridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(55)))));
            this.gridView.CoreMargin = 4;
            this.gridView.Data = null;
            this.gridView.Location = new System.Drawing.Point(6, 6);
            this.gridView.Name = "gridView";
            this.gridView.OffsetX = 0;
            this.gridView.OffsetY = 0;
            this.gridView.Size = new System.Drawing.Size(660, 539);
            this.gridView.TabIndex = 17;
            this.gridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseClick);
            this.gridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseDown);
            this.gridView.MouseLeave += new System.EventHandler(this.gridView_MouseLeave);
            this.gridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseMove);
            this.gridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseUp);
            // 
            // deckView
            // 
            this.deckView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deckView.CoreMargin = 3;
            this.deckView.Data = null;
            this.deckView.Location = new System.Drawing.Point(29, 4);
            this.deckView.Name = "deckView";
            this.deckView.OffsetX = 0;
            this.deckView.Size = new System.Drawing.Size(214, 64);
            this.deckView.TabIndex = 14;
            this.deckView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.deckView_MouseClick);
            // 
            // GridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(695, 679);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GridForm";
            this.Text = "Core Grid";
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.batchSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoRunSpeed)).EndInit();
            this.gridContextMenu.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtEnergy;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton btnStartPause;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtTicksPerSecond;
        private System.Windows.Forms.TrackBar batchSize;
        private System.Windows.Forms.TrackBar autoRunSpeed;
        private System.Windows.Forms.Label txtEnergyPerTick;
        private GridView gridView;
        private System.Windows.Forms.ContextMenuStrip gridContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.Timer runClock;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.Panel panel5;
        private DeckView deckView;
        private System.Windows.Forms.ToolStripMenuItem deckToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnMission;
    }
}