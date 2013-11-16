namespace TerrariaDedicatedServerGUI
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.msTop = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStartServer = new System.Windows.Forms.ToolStripMenuItem();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.tsslIpAdress = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslServerValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.flpSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.lblServerPath = new System.Windows.Forms.Label();
            this.tbServerPath = new System.Windows.Forms.TextBox();
            this.btnServerPath = new System.Windows.Forms.Button();
            this.btnSearchServer = new System.Windows.Forms.Button();
            this.lblWorldPath = new System.Windows.Forms.Label();
            this.tbWorldPath = new System.Windows.Forms.TextBox();
            this.btnMapPath = new System.Windows.Forms.Button();
            this.btnSearchMap = new System.Windows.Forms.Button();
            this.chbAutoCreate = new System.Windows.Forms.CheckBox();
            this.cbAutoCreate = new System.Windows.Forms.ComboBox();
            this.lblWorldName = new System.Windows.Forms.Label();
            this.tbAutoCreateName = new System.Windows.Forms.TextBox();
            this.lblConfig = new System.Windows.Forms.Label();
            this.tbConfig = new System.Windows.Forms.TextBox();
            this.lblBanlist = new System.Windows.Forms.Label();
            this.tbBanlist = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblMaxPlayer = new System.Windows.Forms.Label();
            this.tbMaxPlayer = new System.Windows.Forms.TextBox();
            this.chbSecure = new System.Windows.Forms.CheckBox();
            this.chbUpnp = new System.Windows.Forms.CheckBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cbLangauge = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cbPriority = new System.Windows.Forms.ComboBox();
            this.lblNpcStream = new System.Windows.Forms.Label();
            this.tbNpcStream = new System.Windows.Forms.TextBox();
            this.chbAutoShutDown = new System.Windows.Forms.CheckBox();
            this.tpMotd = new System.Windows.Forms.TabPage();
            this.flpMotd = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMotd = new System.Windows.Forms.Label();
            this.tbMotd = new System.Windows.Forms.TextBox();
            this.tpWorlds = new System.Windows.Forms.TabPage();
            this.lbMaps = new System.Windows.Forms.ListBox();
            this.tbConsole = new System.Windows.Forms.TabPage();
            this.lblExampleAdmin = new System.Windows.Forms.Label();
            this.chbUserInteract = new System.Windows.Forms.CheckBox();
            this.btnCommandSave = new System.Windows.Forms.Button();
            this.tbAdmin = new System.Windows.Forms.TextBox();
            this.chbAdmin = new System.Windows.Forms.CheckBox();
            this.btnCommandExit = new System.Windows.Forms.Button();
            this.btnCommandExitNoS = new System.Windows.Forms.Button();
            this.btnChatText = new System.Windows.Forms.Button();
            this.tbCommandChat = new System.Windows.Forms.TextBox();
            this.cbConsole = new System.Windows.Forms.ComboBox();
            this.btnCommand = new System.Windows.Forms.Button();
            this.btnCommandText = new System.Windows.Forms.Button();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.lbController = new System.Windows.Forms.ListBox();
            this.tpBannlist = new System.Windows.Forms.TabPage();
            this.msTop.SuspendLayout();
            this.ssBottom.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.flpSettings.SuspendLayout();
            this.tpMotd.SuspendLayout();
            this.flpMotd.SuspendLayout();
            this.tpWorlds.SuspendLayout();
            this.tbConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // msTop
            // 
            this.msTop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiStartServer});
            this.msTop.Location = new System.Drawing.Point(0, 0);
            this.msTop.Name = "msTop";
            this.msTop.Size = new System.Drawing.Size(784, 25);
            this.msTop.TabIndex = 0;
            this.msTop.Text = "msTop";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave,
            this.tsmiLoad,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(39, 21);
            this.tsmiFile.Text = "&File";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(105, 22);
            this.tsmiSave.Text = "&Save";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiLoad
            // 
            this.tsmiLoad.Name = "tsmiLoad";
            this.tsmiLoad.Size = new System.Drawing.Size(105, 22);
            this.tsmiLoad.Text = "&Load";
            this.tsmiLoad.Click += new System.EventHandler(this.tsmiLoad_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(105, 22);
            this.tsmiExit.Text = "&Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiStartServer
            // 
            this.tsmiStartServer.Name = "tsmiStartServer";
            this.tsmiStartServer.Size = new System.Drawing.Size(47, 21);
            this.tsmiStartServer.Text = "&Start";
            this.tsmiStartServer.Click += new System.EventHandler(this.tsmiStartServer_Click);
            // 
            // ssBottom
            // 
            this.ssBottom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslIpAdress,
            this.tsslServerValue});
            this.ssBottom.Location = new System.Drawing.Point(0, 535);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(784, 26);
            this.ssBottom.TabIndex = 1;
            this.ssBottom.Text = "statusStrip1";
            // 
            // tsslIpAdress
            // 
            this.tsslIpAdress.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslIpAdress.Name = "tsslIpAdress";
            this.tsslIpAdress.Size = new System.Drawing.Size(77, 21);
            this.tsslIpAdress.Text = "unknown IP";
            // 
            // tsslServerValue
            // 
            this.tsslServerValue.Name = "tsslServerValue";
            this.tsslServerValue.Size = new System.Drawing.Size(85, 21);
            this.tsslServerValue.Text = "Server offline";
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpSettings);
            this.tcMain.Controls.Add(this.tpMotd);
            this.tcMain.Controls.Add(this.tpWorlds);
            this.tcMain.Controls.Add(this.tbConsole);
            this.tcMain.Controls.Add(this.tpBannlist);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.ItemSize = new System.Drawing.Size(100, 20);
            this.tcMain.Location = new System.Drawing.Point(0, 25);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(784, 510);
            this.tcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcMain.TabIndex = 2;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.flpSettings);
            this.tpSettings.Location = new System.Drawing.Point(4, 24);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(776, 482);
            this.tpSettings.TabIndex = 0;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // flpSettings
            // 
            this.flpSettings.AutoScroll = true;
            this.flpSettings.Controls.Add(this.lblServerPath);
            this.flpSettings.Controls.Add(this.tbServerPath);
            this.flpSettings.Controls.Add(this.btnServerPath);
            this.flpSettings.Controls.Add(this.btnSearchServer);
            this.flpSettings.Controls.Add(this.lblWorldPath);
            this.flpSettings.Controls.Add(this.tbWorldPath);
            this.flpSettings.Controls.Add(this.btnMapPath);
            this.flpSettings.Controls.Add(this.btnSearchMap);
            this.flpSettings.Controls.Add(this.chbAutoCreate);
            this.flpSettings.Controls.Add(this.cbAutoCreate);
            this.flpSettings.Controls.Add(this.lblWorldName);
            this.flpSettings.Controls.Add(this.tbAutoCreateName);
            this.flpSettings.Controls.Add(this.lblConfig);
            this.flpSettings.Controls.Add(this.tbConfig);
            this.flpSettings.Controls.Add(this.lblBanlist);
            this.flpSettings.Controls.Add(this.tbBanlist);
            this.flpSettings.Controls.Add(this.lblPort);
            this.flpSettings.Controls.Add(this.tbPort);
            this.flpSettings.Controls.Add(this.lblPassword);
            this.flpSettings.Controls.Add(this.tbPassword);
            this.flpSettings.Controls.Add(this.lblMaxPlayer);
            this.flpSettings.Controls.Add(this.tbMaxPlayer);
            this.flpSettings.Controls.Add(this.chbSecure);
            this.flpSettings.Controls.Add(this.chbUpnp);
            this.flpSettings.Controls.Add(this.lblLanguage);
            this.flpSettings.Controls.Add(this.cbLangauge);
            this.flpSettings.Controls.Add(this.lblPriority);
            this.flpSettings.Controls.Add(this.cbPriority);
            this.flpSettings.Controls.Add(this.lblNpcStream);
            this.flpSettings.Controls.Add(this.tbNpcStream);
            this.flpSettings.Controls.Add(this.chbAutoShutDown);
            this.flpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSettings.Location = new System.Drawing.Point(3, 3);
            this.flpSettings.Name = "flpSettings";
            this.flpSettings.Size = new System.Drawing.Size(770, 476);
            this.flpSettings.TabIndex = 0;
            // 
            // lblServerPath
            // 
            this.lblServerPath.AutoSize = true;
            this.flpSettings.SetFlowBreak(this.lblServerPath, true);
            this.lblServerPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerPath.Location = new System.Drawing.Point(3, 9);
            this.lblServerPath.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.lblServerPath.Name = "lblServerPath";
            this.lblServerPath.Size = new System.Drawing.Size(81, 16);
            this.lblServerPath.TabIndex = 0;
            this.lblServerPath.Text = "Server Path:";
            // 
            // tbServerPath
            // 
            this.tbServerPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbServerPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbServerPath.Location = new System.Drawing.Point(3, 28);
            this.tbServerPath.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbServerPath.Name = "tbServerPath";
            this.tbServerPath.Size = new System.Drawing.Size(500, 22);
            this.tbServerPath.TabIndex = 1;
            // 
            // btnServerPath
            // 
            this.btnServerPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServerPath.Location = new System.Drawing.Point(509, 28);
            this.btnServerPath.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnServerPath.Name = "btnServerPath";
            this.btnServerPath.Size = new System.Drawing.Size(75, 23);
            this.btnServerPath.TabIndex = 2;
            this.btnServerPath.Text = "Choose";
            this.btnServerPath.UseVisualStyleBackColor = true;
            this.btnServerPath.Click += new System.EventHandler(this.btnServerPath_Click);
            // 
            // btnSearchServer
            // 
            this.btnSearchServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flpSettings.SetFlowBreak(this.btnSearchServer, true);
            this.btnSearchServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchServer.Location = new System.Drawing.Point(590, 28);
            this.btnSearchServer.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnSearchServer.Name = "btnSearchServer";
            this.btnSearchServer.Size = new System.Drawing.Size(75, 23);
            this.btnSearchServer.TabIndex = 13;
            this.btnSearchServer.Text = "Search";
            this.btnSearchServer.UseVisualStyleBackColor = true;
            this.btnSearchServer.Click += new System.EventHandler(this.btnSearchServer_Click);
            // 
            // lblWorldPath
            // 
            this.lblWorldPath.AutoSize = true;
            this.flpSettings.SetFlowBreak(this.lblWorldPath, true);
            this.lblWorldPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorldPath.Location = new System.Drawing.Point(3, 63);
            this.lblWorldPath.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.lblWorldPath.Name = "lblWorldPath";
            this.lblWorldPath.Size = new System.Drawing.Size(77, 16);
            this.lblWorldPath.TabIndex = 16;
            this.lblWorldPath.Text = "World Path:";
            // 
            // tbWorldPath
            // 
            this.tbWorldPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbWorldPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWorldPath.Location = new System.Drawing.Point(3, 82);
            this.tbWorldPath.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbWorldPath.Name = "tbWorldPath";
            this.tbWorldPath.Size = new System.Drawing.Size(500, 22);
            this.tbWorldPath.TabIndex = 17;
            this.tbWorldPath.Tag = "worldpath";
            // 
            // btnMapPath
            // 
            this.btnMapPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMapPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMapPath.Location = new System.Drawing.Point(509, 82);
            this.btnMapPath.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnMapPath.Name = "btnMapPath";
            this.btnMapPath.Size = new System.Drawing.Size(75, 23);
            this.btnMapPath.TabIndex = 18;
            this.btnMapPath.Text = "Choose";
            this.btnMapPath.UseVisualStyleBackColor = true;
            this.btnMapPath.Click += new System.EventHandler(this.btnMapPath_Click);
            // 
            // btnSearchMap
            // 
            this.btnSearchMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flpSettings.SetFlowBreak(this.btnSearchMap, true);
            this.btnSearchMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchMap.Location = new System.Drawing.Point(590, 82);
            this.btnSearchMap.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnSearchMap.Name = "btnSearchMap";
            this.btnSearchMap.Size = new System.Drawing.Size(75, 23);
            this.btnSearchMap.TabIndex = 19;
            this.btnSearchMap.Text = "Search";
            this.btnSearchMap.UseVisualStyleBackColor = true;
            this.btnSearchMap.Click += new System.EventHandler(this.btnSearchMap_Click);
            // 
            // chbAutoCreate
            // 
            this.chbAutoCreate.AutoSize = true;
            this.chbAutoCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flpSettings.SetFlowBreak(this.chbAutoCreate, true);
            this.chbAutoCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAutoCreate.Location = new System.Drawing.Point(3, 117);
            this.chbAutoCreate.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.chbAutoCreate.Name = "chbAutoCreate";
            this.chbAutoCreate.Size = new System.Drawing.Size(288, 20);
            this.chbAutoCreate.TabIndex = 26;
            this.chbAutoCreate.Tag = "autocreate";
            this.chbAutoCreate.Text = "Auto Create Map (1:small, 2:medium, 3:large)";
            this.chbAutoCreate.UseVisualStyleBackColor = true;
            // 
            // cbAutoCreate
            // 
            this.flpSettings.SetFlowBreak(this.cbAutoCreate, true);
            this.cbAutoCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutoCreate.FormattingEnabled = true;
            this.cbAutoCreate.Items.AddRange(new object[] {
            "1 - small",
            "2 - medium",
            "3 - large"});
            this.cbAutoCreate.Location = new System.Drawing.Point(3, 143);
            this.cbAutoCreate.Name = "cbAutoCreate";
            this.cbAutoCreate.Size = new System.Drawing.Size(150, 24);
            this.cbAutoCreate.TabIndex = 27;
            this.cbAutoCreate.Tag = "lang";
            // 
            // lblWorldName
            // 
            this.lblWorldName.AutoSize = true;
            this.flpSettings.SetFlowBreak(this.lblWorldName, true);
            this.lblWorldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorldName.Location = new System.Drawing.Point(3, 179);
            this.lblWorldName.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.lblWorldName.Name = "lblWorldName";
            this.lblWorldName.Size = new System.Drawing.Size(181, 16);
            this.lblWorldName.TabIndex = 22;
            this.lblWorldName.Text = "World Name (for Autocreate):";
            // 
            // tbAutoCreateName
            // 
            this.tbAutoCreateName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSettings.SetFlowBreak(this.tbAutoCreateName, true);
            this.tbAutoCreateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAutoCreateName.Location = new System.Drawing.Point(3, 198);
            this.tbAutoCreateName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbAutoCreateName.Name = "tbAutoCreateName";
            this.tbAutoCreateName.Size = new System.Drawing.Size(300, 22);
            this.tbAutoCreateName.TabIndex = 23;
            this.tbAutoCreateName.Tag = "worldname";
            this.tbAutoCreateName.Text = "World";
            // 
            // lblConfig
            // 
            this.lblConfig.AutoSize = true;
            this.flpSettings.SetFlowBreak(this.lblConfig, true);
            this.lblConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfig.Location = new System.Drawing.Point(3, 235);
            this.lblConfig.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(232, 16);
            this.lblConfig.TabIndex = 3;
            this.lblConfig.Text = "Config Name (default serverconfig.txt):";
            // 
            // tbConfig
            // 
            this.tbConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSettings.SetFlowBreak(this.tbConfig, true);
            this.tbConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfig.Location = new System.Drawing.Point(3, 254);
            this.tbConfig.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbConfig.Name = "tbConfig";
            this.tbConfig.Size = new System.Drawing.Size(300, 22);
            this.tbConfig.TabIndex = 4;
            this.tbConfig.Tag = "config";
            this.tbConfig.Text = "serverconfig.txt";
            // 
            // lblBanlist
            // 
            this.lblBanlist.AutoSize = true;
            this.flpSettings.SetFlowBreak(this.lblBanlist, true);
            this.lblBanlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanlist.Location = new System.Drawing.Point(3, 291);
            this.lblBanlist.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.lblBanlist.Name = "lblBanlist";
            this.lblBanlist.Size = new System.Drawing.Size(159, 16);
            this.lblBanlist.TabIndex = 14;
            this.lblBanlist.Tag = "";
            this.lblBanlist.Text = "Banlist (default banlist.txt):";
            // 
            // tbBanlist
            // 
            this.tbBanlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSettings.SetFlowBreak(this.tbBanlist, true);
            this.tbBanlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBanlist.Location = new System.Drawing.Point(3, 310);
            this.tbBanlist.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbBanlist.Name = "tbBanlist";
            this.tbBanlist.Size = new System.Drawing.Size(300, 22);
            this.tbBanlist.TabIndex = 15;
            this.tbBanlist.Tag = "banlist";
            this.tbBanlist.Text = "banlist.txt";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.flpSettings.SetFlowBreak(this.lblPort, true);
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(3, 347);
            this.lblPort.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(160, 16);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "Server Port (default 7777):";
            // 
            // tbPort
            // 
            this.tbPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSettings.SetFlowBreak(this.tbPort, true);
            this.tbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPort.Location = new System.Drawing.Point(3, 366);
            this.tbPort.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbPort.MaxLength = 6;
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(50, 22);
            this.tbPort.TabIndex = 6;
            this.tbPort.Tag = "port";
            this.tbPort.Text = "7777";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.flpSettings.SetFlowBreak(this.lblPassword, true);
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(3, 403);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(198, 16);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Server Password (default none):";
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSettings.SetFlowBreak(this.tbPassword, true);
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(3, 422);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbPassword.MaxLength = 6;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(300, 22);
            this.tbPassword.TabIndex = 8;
            this.tbPassword.Tag = "password";
            // 
            // lblMaxPlayer
            // 
            this.lblMaxPlayer.AutoSize = true;
            this.flpSettings.SetFlowBreak(this.lblMaxPlayer, true);
            this.lblMaxPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxPlayer.Location = new System.Drawing.Point(3, 459);
            this.lblMaxPlayer.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.lblMaxPlayer.Name = "lblMaxPlayer";
            this.lblMaxPlayer.Size = new System.Drawing.Size(198, 16);
            this.lblMaxPlayer.TabIndex = 9;
            this.lblMaxPlayer.Text = "Max Player (default 8 - max 255):";
            // 
            // tbMaxPlayer
            // 
            this.tbMaxPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSettings.SetFlowBreak(this.tbMaxPlayer, true);
            this.tbMaxPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaxPlayer.Location = new System.Drawing.Point(3, 478);
            this.tbMaxPlayer.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbMaxPlayer.MaxLength = 3;
            this.tbMaxPlayer.Name = "tbMaxPlayer";
            this.tbMaxPlayer.Size = new System.Drawing.Size(50, 22);
            this.tbMaxPlayer.TabIndex = 10;
            this.tbMaxPlayer.Tag = "maxplayers";
            this.tbMaxPlayer.Text = "8";
            // 
            // chbSecure
            // 
            this.chbSecure.AutoSize = true;
            this.chbSecure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flpSettings.SetFlowBreak(this.chbSecure, true);
            this.chbSecure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSecure.Location = new System.Drawing.Point(3, 519);
            this.chbSecure.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.chbSecure.Name = "chbSecure";
            this.chbSecure.Size = new System.Drawing.Size(170, 20);
            this.chbSecure.TabIndex = 11;
            this.chbSecure.Tag = "secure";
            this.chbSecure.Text = "addition cheat protection";
            this.chbSecure.UseVisualStyleBackColor = true;
            // 
            // chbUpnp
            // 
            this.chbUpnp.AutoSize = true;
            this.chbUpnp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flpSettings.SetFlowBreak(this.chbUpnp, true);
            this.chbUpnp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbUpnp.Location = new System.Drawing.Point(3, 545);
            this.chbUpnp.Name = "chbUpnp";
            this.chbUpnp.Size = new System.Drawing.Size(228, 20);
            this.chbUpnp.TabIndex = 12;
            this.chbUpnp.Tag = "upnp";
            this.chbUpnp.Text = "disables automatic port forwarding";
            this.chbUpnp.UseVisualStyleBackColor = true;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.flpSettings.SetFlowBreak(this.lblLanguage, true);
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.Location = new System.Drawing.Point(3, 579);
            this.lblLanguage.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(374, 16);
            this.lblLanguage.TabIndex = 20;
            this.lblLanguage.Text = "Language (1:English, 2:German, 3:Italian, 4:French, 5:Spanish):";
            // 
            // cbLangauge
            // 
            this.flpSettings.SetFlowBreak(this.cbLangauge, true);
            this.cbLangauge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLangauge.FormattingEnabled = true;
            this.cbLangauge.Items.AddRange(new object[] {
            "1 - English",
            "2 - German",
            "3 - Italien",
            "4 - French",
            "5 - Spanish"});
            this.cbLangauge.Location = new System.Drawing.Point(3, 603);
            this.cbLangauge.Name = "cbLangauge";
            this.cbLangauge.Size = new System.Drawing.Size(150, 24);
            this.cbLangauge.TabIndex = 21;
            this.cbLangauge.Tag = "lang";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.flpSettings.SetFlowBreak(this.lblPriority, true);
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(3, 639);
            this.lblPriority.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(466, 16);
            this.lblPriority.TabIndex = 24;
            this.lblPriority.Text = "Priority (0:Realtime, 1:High, 2:AboveNormal, 3:Normal, 4:BelowNormal, 5:Idle):";
            // 
            // cbPriority
            // 
            this.flpSettings.SetFlowBreak(this.cbPriority, true);
            this.cbPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Items.AddRange(new object[] {
            "0 - Realtime",
            "1 - High",
            "2 - AboveNormal",
            "3 - Normal",
            "4 - BelowNormal",
            "5 - Idle"});
            this.cbPriority.Location = new System.Drawing.Point(3, 663);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(150, 24);
            this.cbPriority.TabIndex = 25;
            this.cbPriority.Tag = "priority";
            // 
            // lblNpcStream
            // 
            this.lblNpcStream.AutoSize = true;
            this.flpSettings.SetFlowBreak(this.lblNpcStream, true);
            this.lblNpcStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNpcStream.Location = new System.Drawing.Point(3, 699);
            this.lblNpcStream.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.lblNpcStream.Name = "lblNpcStream";
            this.lblNpcStream.Size = new System.Drawing.Size(191, 16);
            this.lblNpcStream.TabIndex = 28;
            this.lblNpcStream.Tag = "";
            this.lblNpcStream.Text = "Npc Stream (default 60 - 0 = off)";
            // 
            // tbNpcStream
            // 
            this.tbNpcStream.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSettings.SetFlowBreak(this.tbNpcStream, true);
            this.tbNpcStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNpcStream.Location = new System.Drawing.Point(3, 718);
            this.tbNpcStream.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbNpcStream.MaxLength = 3;
            this.tbNpcStream.Name = "tbNpcStream";
            this.tbNpcStream.Size = new System.Drawing.Size(50, 22);
            this.tbNpcStream.TabIndex = 29;
            this.tbNpcStream.Tag = "npcstream";
            this.tbNpcStream.Text = "60";
            // 
            // chbAutoShutDown
            // 
            this.chbAutoShutDown.AutoSize = true;
            this.chbAutoShutDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flpSettings.SetFlowBreak(this.chbAutoShutDown, true);
            this.chbAutoShutDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAutoShutDown.Location = new System.Drawing.Point(3, 747);
            this.chbAutoShutDown.Name = "chbAutoShutDown";
            this.chbAutoShutDown.Size = new System.Drawing.Size(112, 20);
            this.chbAutoShutDown.TabIndex = 30;
            this.chbAutoShutDown.Tag = "autoshutdown";
            this.chbAutoShutDown.Text = "Auto Shutdown";
            this.chbAutoShutDown.UseVisualStyleBackColor = true;
            // 
            // tpMotd
            // 
            this.tpMotd.Controls.Add(this.flpMotd);
            this.tpMotd.Location = new System.Drawing.Point(4, 24);
            this.tpMotd.Name = "tpMotd";
            this.tpMotd.Size = new System.Drawing.Size(776, 482);
            this.tpMotd.TabIndex = 1;
            this.tpMotd.Text = "Motd";
            this.tpMotd.UseVisualStyleBackColor = true;
            // 
            // flpMotd
            // 
            this.flpMotd.Controls.Add(this.lblMotd);
            this.flpMotd.Controls.Add(this.tbMotd);
            this.flpMotd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMotd.Location = new System.Drawing.Point(0, 0);
            this.flpMotd.Name = "flpMotd";
            this.flpMotd.Size = new System.Drawing.Size(776, 482);
            this.flpMotd.TabIndex = 0;
            // 
            // lblMotd
            // 
            this.lblMotd.AutoSize = true;
            this.flpMotd.SetFlowBreak(this.lblMotd, true);
            this.lblMotd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotd.Location = new System.Drawing.Point(3, 9);
            this.lblMotd.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.lblMotd.Name = "lblMotd";
            this.lblMotd.Size = new System.Drawing.Size(129, 16);
            this.lblMotd.TabIndex = 1;
            this.lblMotd.Text = "Message of the day:";
            // 
            // tbMotd
            // 
            this.tbMotd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMotd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMotd.Location = new System.Drawing.Point(3, 28);
            this.tbMotd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbMotd.Name = "tbMotd";
            this.tbMotd.Size = new System.Drawing.Size(765, 22);
            this.tbMotd.TabIndex = 2;
            this.tbMotd.Tag = "motd";
            this.tbMotd.Text = "Please dont cut the purple trees! type time for Server Time! Type dawn, noon, dus" +
    "k, midnight to change time (by default off). Type playing to show online Players" +
    ". Type motd for this Message.";
            // 
            // tpWorlds
            // 
            this.tpWorlds.Controls.Add(this.lbMaps);
            this.tpWorlds.Location = new System.Drawing.Point(4, 24);
            this.tpWorlds.Name = "tpWorlds";
            this.tpWorlds.Size = new System.Drawing.Size(776, 482);
            this.tpWorlds.TabIndex = 2;
            this.tpWorlds.Text = "Worlds";
            this.tpWorlds.UseVisualStyleBackColor = true;
            // 
            // lbMaps
            // 
            this.lbMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMaps.FormattingEnabled = true;
            this.lbMaps.Location = new System.Drawing.Point(0, 0);
            this.lbMaps.Name = "lbMaps";
            this.lbMaps.Size = new System.Drawing.Size(776, 482);
            this.lbMaps.TabIndex = 0;
            // 
            // tbConsole
            // 
            this.tbConsole.Controls.Add(this.lblExampleAdmin);
            this.tbConsole.Controls.Add(this.chbUserInteract);
            this.tbConsole.Controls.Add(this.btnCommandSave);
            this.tbConsole.Controls.Add(this.tbAdmin);
            this.tbConsole.Controls.Add(this.chbAdmin);
            this.tbConsole.Controls.Add(this.btnCommandExit);
            this.tbConsole.Controls.Add(this.btnCommandExitNoS);
            this.tbConsole.Controls.Add(this.btnChatText);
            this.tbConsole.Controls.Add(this.tbCommandChat);
            this.tbConsole.Controls.Add(this.cbConsole);
            this.tbConsole.Controls.Add(this.btnCommand);
            this.tbConsole.Controls.Add(this.btnCommandText);
            this.tbConsole.Controls.Add(this.tbCommand);
            this.tbConsole.Controls.Add(this.lbController);
            this.tbConsole.Location = new System.Drawing.Point(4, 24);
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(776, 482);
            this.tbConsole.TabIndex = 3;
            this.tbConsole.Text = "Console";
            this.tbConsole.UseVisualStyleBackColor = true;
            // 
            // lblExampleAdmin
            // 
            this.lblExampleAdmin.AutoSize = true;
            this.lblExampleAdmin.Location = new System.Drawing.Point(251, 452);
            this.lblExampleAdmin.Name = "lblExampleAdmin";
            this.lblExampleAdmin.Size = new System.Drawing.Size(177, 26);
            this.lblExampleAdmin.TabIndex = 13;
            this.lblExampleAdmin.Text = "Example: /noon as Admin command\r\n                 noon as non Admin";
            // 
            // chbUserInteract
            // 
            this.chbUserInteract.AutoSize = true;
            this.chbUserInteract.Location = new System.Drawing.Point(254, 373);
            this.chbUserInteract.Margin = new System.Windows.Forms.Padding(2);
            this.chbUserInteract.Name = "chbUserInteract";
            this.chbUserInteract.Size = new System.Drawing.Size(134, 17);
            this.chbUserInteract.TabIndex = 12;
            this.chbUserInteract.Text = "User can change Time";
            this.chbUserInteract.UseVisualStyleBackColor = true;
            this.chbUserInteract.CheckedChanged += new System.EventHandler(this.chbUserTime_CheckedChanged);
            // 
            // btnCommandSave
            // 
            this.btnCommandSave.Location = new System.Drawing.Point(3, 374);
            this.btnCommandSave.Name = "btnCommandSave";
            this.btnCommandSave.Size = new System.Drawing.Size(131, 23);
            this.btnCommandSave.TabIndex = 11;
            this.btnCommandSave.Text = "Send Save Command";
            this.btnCommandSave.UseVisualStyleBackColor = true;
            this.btnCommandSave.Click += new System.EventHandler(this.btnCommandSave_Click);
            // 
            // tbAdmin
            // 
            this.tbAdmin.Location = new System.Drawing.Point(254, 429);
            this.tbAdmin.Name = "tbAdmin";
            this.tbAdmin.Size = new System.Drawing.Size(160, 20);
            this.tbAdmin.TabIndex = 10;
            this.tbAdmin.TextChanged += new System.EventHandler(this.tbAdmin_TextChanged);
            // 
            // chbAdmin
            // 
            this.chbAdmin.AutoSize = true;
            this.chbAdmin.Location = new System.Drawing.Point(254, 394);
            this.chbAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.chbAdmin.Name = "chbAdmin";
            this.chbAdmin.Size = new System.Drawing.Size(163, 30);
            this.chbAdmin.TabIndex = 9;
            this.chbAdmin.Text = "Allow Admin Chat Commands\r\nAdmin Name:";
            this.chbAdmin.UseVisualStyleBackColor = true;
            this.chbAdmin.CheckedChanged += new System.EventHandler(this.chbAdmin_CheckedChanged);
            // 
            // btnCommandExit
            // 
            this.btnCommandExit.Location = new System.Drawing.Point(3, 432);
            this.btnCommandExit.Name = "btnCommandExit";
            this.btnCommandExit.Size = new System.Drawing.Size(131, 23);
            this.btnCommandExit.TabIndex = 8;
            this.btnCommandExit.Text = "Send Save and Exit";
            this.btnCommandExit.UseVisualStyleBackColor = true;
            this.btnCommandExit.Click += new System.EventHandler(this.btnCommandExit_Click);
            // 
            // btnCommandExitNoS
            // 
            this.btnCommandExitNoS.Location = new System.Drawing.Point(3, 403);
            this.btnCommandExitNoS.Name = "btnCommandExitNoS";
            this.btnCommandExitNoS.Size = new System.Drawing.Size(131, 23);
            this.btnCommandExitNoS.TabIndex = 7;
            this.btnCommandExitNoS.Text = "Send Exit NoSave";
            this.btnCommandExitNoS.UseVisualStyleBackColor = true;
            this.btnCommandExitNoS.Click += new System.EventHandler(this.btnCommandExitNoS_Click);
            // 
            // btnChatText
            // 
            this.btnChatText.Location = new System.Drawing.Point(642, 432);
            this.btnChatText.Name = "btnChatText";
            this.btnChatText.Size = new System.Drawing.Size(131, 23);
            this.btnChatText.TabIndex = 6;
            this.btnChatText.Text = "Send Chat Message";
            this.btnChatText.UseVisualStyleBackColor = true;
            this.btnChatText.Click += new System.EventHandler(this.btnChatText_Click);
            // 
            // tbCommandChat
            // 
            this.tbCommandChat.Location = new System.Drawing.Point(448, 434);
            this.tbCommandChat.Name = "tbCommandChat";
            this.tbCommandChat.Size = new System.Drawing.Size(188, 20);
            this.tbCommandChat.TabIndex = 5;
            this.tbCommandChat.Text = "Hello World!";
            // 
            // cbConsole
            // 
            this.cbConsole.FormattingEnabled = true;
            this.cbConsole.Items.AddRange(new object[] {
            "help",
            "playing",
            "time",
            "motd",
            "dawn",
            "noon",
            "dusk",
            "midnight",
            "settle"});
            this.cbConsole.Location = new System.Drawing.Point(522, 403);
            this.cbConsole.Name = "cbConsole";
            this.cbConsole.Size = new System.Drawing.Size(114, 21);
            this.cbConsole.TabIndex = 4;
            // 
            // btnCommand
            // 
            this.btnCommand.Location = new System.Drawing.Point(642, 403);
            this.btnCommand.Name = "btnCommand";
            this.btnCommand.Size = new System.Drawing.Size(131, 23);
            this.btnCommand.TabIndex = 3;
            this.btnCommand.Text = "Send Selected Command";
            this.btnCommand.UseVisualStyleBackColor = true;
            this.btnCommand.Click += new System.EventHandler(this.btnCommand_Click);
            // 
            // btnCommandText
            // 
            this.btnCommandText.Location = new System.Drawing.Point(642, 374);
            this.btnCommandText.Name = "btnCommandText";
            this.btnCommandText.Size = new System.Drawing.Size(131, 23);
            this.btnCommandText.TabIndex = 2;
            this.btnCommandText.Text = "Send Command Text";
            this.btnCommandText.UseVisualStyleBackColor = true;
            this.btnCommandText.Click += new System.EventHandler(this.btnCommandText_Click);
            // 
            // tbCommand
            // 
            this.tbCommand.Location = new System.Drawing.Point(522, 376);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(114, 20);
            this.tbCommand.TabIndex = 1;
            // 
            // lbController
            // 
            this.lbController.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbController.FormattingEnabled = true;
            this.lbController.Location = new System.Drawing.Point(0, 0);
            this.lbController.Name = "lbController";
            this.lbController.Size = new System.Drawing.Size(776, 368);
            this.lbController.TabIndex = 0;
            // 
            // tpBannlist
            // 
            this.tpBannlist.Location = new System.Drawing.Point(4, 24);
            this.tpBannlist.Name = "tpBannlist";
            this.tpBannlist.Size = new System.Drawing.Size(776, 482);
            this.tpBannlist.TabIndex = 4;
            this.tpBannlist.Text = "Bannlist";
            this.tpBannlist.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.ssBottom);
            this.Controls.Add(this.msTop);
            this.MainMenuStrip = this.msTop;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terraria Dedicated Server Gui v";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msTop.ResumeLayout(false);
            this.msTop.PerformLayout();
            this.ssBottom.ResumeLayout(false);
            this.ssBottom.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.flpSettings.ResumeLayout(false);
            this.flpSettings.PerformLayout();
            this.tpMotd.ResumeLayout(false);
            this.flpMotd.ResumeLayout(false);
            this.flpMotd.PerformLayout();
            this.tpWorlds.ResumeLayout(false);
            this.tbConsole.ResumeLayout(false);
            this.tbConsole.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msTop;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.FlowLayoutPanel flpSettings;
        private System.Windows.Forms.Label lblServerPath;
        private System.Windows.Forms.TextBox tbServerPath;
        private System.Windows.Forms.Button btnServerPath;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.TextBox tbConfig;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnSearchServer;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblMaxPlayer;
        private System.Windows.Forms.TextBox tbMaxPlayer;
        private System.Windows.Forms.CheckBox chbSecure;
        private System.Windows.Forms.CheckBox chbUpnp;
        private System.Windows.Forms.Label lblWorldPath;
        private System.Windows.Forms.TextBox tbWorldPath;
        private System.Windows.Forms.Button btnMapPath;
        private System.Windows.Forms.Button btnSearchMap;
        private System.Windows.Forms.Label lblBanlist;
        private System.Windows.Forms.TextBox tbBanlist;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cbLangauge;
        private System.Windows.Forms.Label lblWorldName;
        private System.Windows.Forms.TextBox tbAutoCreateName;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox cbPriority;
        private System.Windows.Forms.TabPage tpMotd;
        private System.Windows.Forms.FlowLayoutPanel flpMotd;
        private System.Windows.Forms.Label lblMotd;
        private System.Windows.Forms.TextBox tbMotd;
        private System.Windows.Forms.CheckBox chbAutoCreate;
        private System.Windows.Forms.ComboBox cbAutoCreate;
        private System.Windows.Forms.Label lblNpcStream;
        private System.Windows.Forms.TextBox tbNpcStream;
        private System.Windows.Forms.ToolStripStatusLabel tsslIpAdress;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoad;
        private System.Windows.Forms.TabPage tpWorlds;
        private System.Windows.Forms.CheckBox chbAutoShutDown;
        private System.Windows.Forms.ListBox lbMaps;
        private System.Windows.Forms.TabPage tbConsole;
        private System.Windows.Forms.ToolStripMenuItem tsmiStartServer;
        private System.Windows.Forms.ListBox lbController;
        private System.Windows.Forms.Button btnCommandText;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.ComboBox cbConsole;
        private System.Windows.Forms.Button btnCommand;
        private System.Windows.Forms.ToolStripStatusLabel tsslServerValue;
        private System.Windows.Forms.TabPage tpBannlist;
        private System.Windows.Forms.Button btnCommandExit;
        private System.Windows.Forms.Button btnCommandExitNoS;
        private System.Windows.Forms.Button btnChatText;
        private System.Windows.Forms.TextBox tbCommandChat;
        private System.Windows.Forms.TextBox tbAdmin;
        private System.Windows.Forms.CheckBox chbAdmin;
        private System.Windows.Forms.Button btnCommandSave;
        private System.Windows.Forms.CheckBox chbUserInteract;
        private System.Windows.Forms.Label lblExampleAdmin;
    }
}

