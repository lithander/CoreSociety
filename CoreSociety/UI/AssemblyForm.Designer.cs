namespace CoreSociety.UI
{
    partial class AssemblyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblyForm));
            this.memoryBox = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtOpCode = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbEnergy = new System.Windows.Forms.CheckBox();
            this.coreTarget = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chargedEnergy = new System.Windows.Forms.NumericUpDown();
            this.shieldEnergy = new System.Windows.Forms.NumericUpDown();
            this.unboundEnergy = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stepBtn = new System.Windows.Forms.Button();
            this.numIP = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbAutoStep = new System.Windows.Forms.CheckBox();
            this.txtAutoRun = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.batchSize = new System.Windows.Forms.TrackBar();
            this.autoRunSpeed = new System.Windows.Forms.TrackBar();
            this.gridView = new CoreSociety.UI.GridView();
            this.label12 = new System.Windows.Forms.Label();
            this.coreRenderView = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.runClock = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.listingBox = new System.Windows.Forms.RichTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.toolbox = new System.Windows.Forms.ToolStrip();
            this.btnClearListing = new System.Windows.Forms.ToolStripButton();
            this.btnLoadListing = new System.Windows.Forms.ToolStripButton();
            this.btnSaveListing = new System.Windows.Forms.ToolStripButton();
            this.btnAssemble = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnToggleAutoUpdate = new System.Windows.Forms.ToolStripButton();
            this.btnGrid = new System.Windows.Forms.ToolStripButton();
            this.coreContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargedEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shieldEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unboundEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIP)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.batchSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoRunSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coreRenderView)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.toolbox.SuspendLayout();
            this.coreContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // memoryBox
            // 
            this.memoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoryBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(55)))));
            this.memoryBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.memoryBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoryBox.ForeColor = System.Drawing.Color.Yellow;
            this.memoryBox.Location = new System.Drawing.Point(6, 6);
            this.memoryBox.Margin = new System.Windows.Forms.Padding(6);
            this.memoryBox.Name = "memoryBox";
            this.memoryBox.ReadOnly = true;
            this.memoryBox.Size = new System.Drawing.Size(562, 198);
            this.memoryBox.TabIndex = 3;
            this.memoryBox.Text = "";
            this.memoryBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.memoryBox_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.txtOpCode);
            this.panel2.Controls.Add(this.txtAddress);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cbEnergy);
            this.panel2.Controls.Add(this.coreTarget);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.chargedEnergy);
            this.panel2.Controls.Add(this.shieldEnergy);
            this.panel2.Controls.Add(this.unboundEnergy);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.stepBtn);
            this.panel2.Controls.Add(this.numIP);
            this.panel2.Location = new System.Drawing.Point(421, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 306);
            this.panel2.TabIndex = 3;
            // 
            // txtOpCode
            // 
            this.txtOpCode.AutoSize = true;
            this.txtOpCode.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpCode.ForeColor = System.Drawing.Color.Gold;
            this.txtOpCode.Location = new System.Drawing.Point(62, 85);
            this.txtOpCode.Name = "txtOpCode";
            this.txtOpCode.Size = new System.Drawing.Size(71, 37);
            this.txtOpCode.TabIndex = 24;
            this.txtOpCode.Text = "NOP";
            // 
            // txtAddress
            // 
            this.txtAddress.AutoSize = true;
            this.txtAddress.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.Color.Gold;
            this.txtAddress.Location = new System.Drawing.Point(3, 85);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(53, 37);
            this.txtAddress.TabIndex = 23;
            this.txtAddress.Text = "00";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.SlateBlue;
            this.label10.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(0, 62);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 22);
            this.label10.TabIndex = 22;
            this.label10.Text = "Focus";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbEnergy
            // 
            this.cbEnergy.AutoSize = true;
            this.cbEnergy.BackColor = System.Drawing.Color.SlateBlue;
            this.cbEnergy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEnergy.Location = new System.Drawing.Point(4, 131);
            this.cbEnergy.Name = "cbEnergy";
            this.cbEnergy.Size = new System.Drawing.Size(12, 11);
            this.cbEnergy.TabIndex = 21;
            this.cbEnergy.UseVisualStyleBackColor = false;
            // 
            // coreTarget
            // 
            this.coreTarget.BackColor = System.Drawing.Color.Gold;
            this.coreTarget.FormattingEnabled = true;
            this.coreTarget.Location = new System.Drawing.Point(12, 273);
            this.coreTarget.Name = "coreTarget";
            this.coreTarget.Size = new System.Drawing.Size(121, 21);
            this.coreTarget.TabIndex = 20;
            this.coreTarget.SelectedIndexChanged += new System.EventHandler(this.OnCoreFocusTargetChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SlateBlue;
            this.label9.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(0, 243);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 22);
            this.label9.TabIndex = 19;
            this.label9.Text = "Target";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gold;
            this.label8.Location = new System.Drawing.Point(74, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 18);
            this.label8.TabIndex = 18;
            this.label8.Text = "Charge";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gold;
            this.label7.Location = new System.Drawing.Point(74, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 18);
            this.label7.TabIndex = 17;
            this.label7.Text = "Shield";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gold;
            this.label6.Location = new System.Drawing.Point(74, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "Energy";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chargedEnergy
            // 
            this.chargedEnergy.BackColor = System.Drawing.Color.Gold;
            this.chargedEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chargedEnergy.Hexadecimal = true;
            this.chargedEnergy.Location = new System.Drawing.Point(12, 215);
            this.chargedEnergy.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.chargedEnergy.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.chargedEnergy.Name = "chargedEnergy";
            this.chargedEnergy.Size = new System.Drawing.Size(56, 22);
            this.chargedEnergy.TabIndex = 15;
            this.chargedEnergy.ValueChanged += new System.EventHandler(this.OnChargeLevelChanged);
            // 
            // shieldEnergy
            // 
            this.shieldEnergy.BackColor = System.Drawing.Color.Gold;
            this.shieldEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shieldEnergy.Hexadecimal = true;
            this.shieldEnergy.Location = new System.Drawing.Point(12, 184);
            this.shieldEnergy.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.shieldEnergy.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.shieldEnergy.Name = "shieldEnergy";
            this.shieldEnergy.Size = new System.Drawing.Size(56, 22);
            this.shieldEnergy.TabIndex = 14;
            this.shieldEnergy.ValueChanged += new System.EventHandler(this.OnShieldEnergyChanged);
            // 
            // unboundEnergy
            // 
            this.unboundEnergy.BackColor = System.Drawing.Color.Gold;
            this.unboundEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unboundEnergy.Hexadecimal = true;
            this.unboundEnergy.Location = new System.Drawing.Point(12, 153);
            this.unboundEnergy.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.unboundEnergy.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.unboundEnergy.Name = "unboundEnergy";
            this.unboundEnergy.Size = new System.Drawing.Size(56, 22);
            this.unboundEnergy.TabIndex = 13;
            this.unboundEnergy.ValueChanged += new System.EventHandler(this.OnUnboundEnergyChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SlateBlue;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(0, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 22);
            this.label5.TabIndex = 12;
            this.label5.Text = "Energy";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SlateBlue;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Instruction";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stepBtn
            // 
            this.stepBtn.BackColor = System.Drawing.Color.Gold;
            this.stepBtn.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite;
            this.stepBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stepBtn.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepBtn.Location = new System.Drawing.Point(74, 32);
            this.stepBtn.Name = "stepBtn";
            this.stepBtn.Size = new System.Drawing.Size(56, 22);
            this.stepBtn.TabIndex = 2;
            this.stepBtn.Text = "Step";
            this.stepBtn.UseVisualStyleBackColor = false;
            this.stepBtn.Click += new System.EventHandler(this.stepBtn_Click);
            // 
            // numIP
            // 
            this.numIP.BackColor = System.Drawing.Color.Gold;
            this.numIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numIP.Hexadecimal = true;
            this.numIP.Location = new System.Drawing.Point(12, 32);
            this.numIP.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.numIP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numIP.Name = "numIP";
            this.numIP.Size = new System.Drawing.Size(56, 22);
            this.numIP.TabIndex = 0;
            this.numIP.ValueChanged += new System.EventHandler(this.OnIpValueChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.coreRenderView);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Location = new System.Drawing.Point(305, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 330);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateBlue;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(173, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Focus Core";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(55)))));
            this.panel7.Controls.Add(this.cbAutoStep);
            this.panel7.Controls.Add(this.txtAutoRun);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.batchSize);
            this.panel7.Controls.Add(this.autoRunSpeed);
            this.panel7.Controls.Add(this.gridView);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Location = new System.Drawing.Point(12, 12);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(155, 306);
            this.panel7.TabIndex = 17;
            // 
            // cbAutoStep
            // 
            this.cbAutoStep.AutoSize = true;
            this.cbAutoStep.BackColor = System.Drawing.Color.SlateBlue;
            this.cbAutoStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAutoStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutoStep.Location = new System.Drawing.Point(6, 202);
            this.cbAutoStep.Name = "cbAutoStep";
            this.cbAutoStep.Size = new System.Drawing.Size(12, 11);
            this.cbAutoStep.TabIndex = 27;
            this.cbAutoStep.UseVisualStyleBackColor = false;
            this.cbAutoStep.CheckedChanged += new System.EventHandler(this.OnAutoStepCheckedChanged);
            // 
            // txtAutoRun
            // 
            this.txtAutoRun.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutoRun.ForeColor = System.Drawing.Color.Gold;
            this.txtAutoRun.Location = new System.Drawing.Point(3, 285);
            this.txtAutoRun.Name = "txtAutoRun";
            this.txtAutoRun.Size = new System.Drawing.Size(141, 18);
            this.txtAutoRun.TabIndex = 26;
            this.txtAutoRun.Text = "Paused";
            this.txtAutoRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SlateBlue;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(0, 196);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 22);
            this.label4.TabIndex = 24;
            this.label4.Text = "Run";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // batchSize
            // 
            this.batchSize.Location = new System.Drawing.Point(3, 258);
            this.batchSize.Minimum = 1;
            this.batchSize.Name = "batchSize";
            this.batchSize.Size = new System.Drawing.Size(141, 45);
            this.batchSize.TabIndex = 25;
            this.batchSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.batchSize.Value = 1;
            this.batchSize.ValueChanged += new System.EventHandler(this.OnBatchSizeChanged);
            // 
            // autoRunSpeed
            // 
            this.autoRunSpeed.Location = new System.Drawing.Point(3, 230);
            this.autoRunSpeed.Minimum = 1;
            this.autoRunSpeed.Name = "autoRunSpeed";
            this.autoRunSpeed.Size = new System.Drawing.Size(141, 45);
            this.autoRunSpeed.TabIndex = 23;
            this.autoRunSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.autoRunSpeed.Value = 5;
            this.autoRunSpeed.ValueChanged += new System.EventHandler(this.OnRunSpeedChanged);
            // 
            // gridView
            // 
            this.gridView.CoreMargin = 3;
            this.gridView.Data = null;
            this.gridView.Location = new System.Drawing.Point(3, 38);
            this.gridView.Name = "gridView";
            this.gridView.OffsetX = 0;
            this.gridView.OffsetY = 0;
            this.gridView.Size = new System.Drawing.Size(149, 144);
            this.gridView.TabIndex = 20;
            this.gridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseClick);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.SlateBlue;
            this.label12.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(155, 22);
            this.label12.TabIndex = 13;
            this.label12.Text = "Mini-Grid";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // coreRenderView
            // 
            this.coreRenderView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coreRenderView.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.coreRenderView.Location = new System.Drawing.Point(177, 40);
            this.coreRenderView.Name = "coreRenderView";
            this.coreRenderView.Size = new System.Drawing.Size(238, 278);
            this.coreRenderView.TabIndex = 5;
            this.coreRenderView.TabStop = false;
            this.coreRenderView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnCoreRenderViewClick);
            this.coreRenderView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnRenderViewMouseMove);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.SlateBlue;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "ASM Listing";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(55)))));
            this.panel3.Controls.Add(this.memoryBox);
            this.panel3.Location = new System.Drawing.Point(305, 351);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(574, 210);
            this.panel3.TabIndex = 7;
            // 
            // runClock
            // 
            this.runClock.Tick += new System.EventHandler(this.runClock_Tick);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(55)))));
            this.panel4.Controls.Add(this.listingBox);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(12, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(284, 549);
            this.panel4.TabIndex = 9;
            // 
            // listingBox
            // 
            this.listingBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listingBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(55)))));
            this.listingBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listingBox.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listingBox.ForeColor = System.Drawing.Color.Yellow;
            this.listingBox.Location = new System.Drawing.Point(7, 61);
            this.listingBox.Name = "listingBox";
            this.listingBox.Size = new System.Drawing.Size(271, 482);
            this.listingBox.TabIndex = 11;
            this.listingBox.Text = "";
            this.listingBox.TextChanged += new System.EventHandler(this.OnListingChanged);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.toolbox);
            this.panel6.Location = new System.Drawing.Point(4, 25);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(277, 30);
            this.panel6.TabIndex = 10;
            // 
            // toolbox
            // 
            this.toolbox.BackColor = System.Drawing.Color.Gold;
            this.toolbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClearListing,
            this.btnLoadListing,
            this.btnSaveListing,
            this.btnAssemble,
            this.btnClear,
            this.btnToggleAutoUpdate,
            this.btnGrid});
            this.toolbox.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolbox.Location = new System.Drawing.Point(0, 0);
            this.toolbox.Name = "toolbox";
            this.toolbox.Size = new System.Drawing.Size(277, 23);
            this.toolbox.TabIndex = 0;
            this.toolbox.Text = "toolStrip1";
            // 
            // btnClearListing
            // 
            this.btnClearListing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClearListing.Image = ((System.Drawing.Image)(resources.GetObject("btnClearListing.Image")));
            this.btnClearListing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearListing.Name = "btnClearListing";
            this.btnClearListing.Size = new System.Drawing.Size(23, 20);
            this.btnClearListing.Text = "Clear Listing";
            this.btnClearListing.Click += new System.EventHandler(this.btnClearListing_Click);
            // 
            // btnLoadListing
            // 
            this.btnLoadListing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoadListing.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadListing.Image")));
            this.btnLoadListing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadListing.Name = "btnLoadListing";
            this.btnLoadListing.Size = new System.Drawing.Size(23, 20);
            this.btnLoadListing.Text = "Load Listing";
            this.btnLoadListing.Click += new System.EventHandler(this.btnLoadListing_Click);
            // 
            // btnSaveListing
            // 
            this.btnSaveListing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveListing.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveListing.Image")));
            this.btnSaveListing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveListing.Name = "btnSaveListing";
            this.btnSaveListing.Size = new System.Drawing.Size(23, 20);
            this.btnSaveListing.Text = "Save Listing";
            this.btnSaveListing.Click += new System.EventHandler(this.btnSaveListing_Click);
            // 
            // btnAssemble
            // 
            this.btnAssemble.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAssemble.Image = ((System.Drawing.Image)(resources.GetObject("btnAssemble.Image")));
            this.btnAssemble.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAssemble.Name = "btnAssemble";
            this.btnAssemble.Size = new System.Drawing.Size(23, 20);
            this.btnAssemble.Text = "Assemble Core";
            this.btnAssemble.Click += new System.EventHandler(this.btnAssemble_Click);
            // 
            // btnClear
            // 
            this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(23, 20);
            this.btnClear.Text = "Clear Core";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnToggleAutoUpdate
            // 
            this.btnToggleAutoUpdate.Checked = true;
            this.btnToggleAutoUpdate.CheckOnClick = true;
            this.btnToggleAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnToggleAutoUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToggleAutoUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnToggleAutoUpdate.Image")));
            this.btnToggleAutoUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToggleAutoUpdate.Name = "btnToggleAutoUpdate";
            this.btnToggleAutoUpdate.Size = new System.Drawing.Size(23, 20);
            this.btnToggleAutoUpdate.Text = "Toggle Auto Update";
            this.btnToggleAutoUpdate.ToolTipText = "Toggle Auto Update";
            this.btnToggleAutoUpdate.Click += new System.EventHandler(this.btnToggleAutoUpdate_Click);
            // 
            // btnGrid
            // 
            this.btnGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGrid.Image = ((System.Drawing.Image)(resources.GetObject("btnGrid.Image")));
            this.btnGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGrid.Name = "btnGrid";
            this.btnGrid.Size = new System.Drawing.Size(23, 20);
            this.btnGrid.Text = "Open Grid";
            this.btnGrid.Click += new System.EventHandler(this.btnGrid_Click);
            // 
            // coreContextMenu
            // 
            this.coreContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.coreContextMenu.Name = "contextMenuStrip1";
            this.coreContextMenu.Size = new System.Drawing.Size(103, 48);
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
            // AssemblyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(891, 573);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AssemblyForm";
            this.Text = "Core Assembly";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargedEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shieldEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unboundEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIP)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.batchSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoRunSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coreRenderView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.toolbox.ResumeLayout(false);
            this.toolbox.PerformLayout();
            this.coreContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox memoryBox;
        private System.Windows.Forms.NumericUpDown numIP;
        private System.Windows.Forms.Button stepBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer runClock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown shieldEnergy;
        private System.Windows.Forms.NumericUpDown unboundEnergy;
        private System.Windows.Forms.NumericUpDown chargedEnergy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox coreTarget;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ToolStrip toolbox;
        private System.Windows.Forms.ToolStripButton btnClearListing;
        private System.Windows.Forms.ToolStripButton btnLoadListing;
        private System.Windows.Forms.ToolStripButton btnSaveListing;
        private System.Windows.Forms.ToolStripButton btnAssemble;
        private System.Windows.Forms.ToolStripButton btnToggleAutoUpdate;
        private System.Windows.Forms.CheckBox cbEnergy;
        private System.Windows.Forms.ContextMenuStrip coreContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnGrid;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.RichTextBox listingBox;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox coreRenderView;
        private GridView gridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtOpCode;
        private System.Windows.Forms.Label txtAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbAutoStep;
        private System.Windows.Forms.Label txtAutoRun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar batchSize;
        private System.Windows.Forms.TrackBar autoRunSpeed;
    }
}

