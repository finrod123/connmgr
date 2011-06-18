namespace connmgr
{
    partial class ConnectionManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionManagerForm));
            this.connNameLabel = new System.Windows.Forms.Label();
            this.conUserNameLabel = new System.Windows.Forms.Label();
            this.connPasswordLabel = new System.Windows.Forms.Label();
            this.conName = new System.Windows.Forms.TextBox();
            this.connUsername = new System.Windows.Forms.TextBox();
            this.credentialsGroupBox = new System.Windows.Forms.GroupBox();
            this.connPassword = new System.Windows.Forms.MaskedTextBox();
            this.osAuthenticate = new System.Windows.Forms.CheckBox();
            this.namingMethodType = new System.Windows.Forms.ComboBox();
            this.namingMethodTypeLabel = new System.Windows.Forms.Label();
            this.DBAPrivileges = new System.Windows.Forms.ComboBox();
            this.DBAPrivilegesLabel = new System.Windows.Forms.Label();
            this.stornoB = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.okB = new System.Windows.Forms.Button();
            this.connOptions = new System.Windows.Forms.TabControl();
            this.connOptionsBasic = new System.Windows.Forms.TabPage();
            this.connOptionsBox = new System.Windows.Forms.GroupBox();
            this.connectionDescriptionBox = new System.Windows.Forms.GroupBox();
            this.directNamingBox = new System.Windows.Forms.GroupBox();
            this.host = new System.Windows.Forms.ComboBox();
            this.serverType = new System.Windows.Forms.ComboBox();
            this.port = new System.Windows.Forms.NumericUpDown();
            this.sid = new System.Windows.Forms.TextBox();
            this.instanceName = new System.Windows.Forms.TextBox();
            this.serviceName = new System.Windows.Forms.TextBox();
            this.sidB = new System.Windows.Forms.RadioButton();
            this.serviceNameB = new System.Windows.Forms.RadioButton();
            this.serverTypeLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.instanceNameLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.tnsNamingBox = new System.Windows.Forms.GroupBox();
            this.tnsName = new System.Windows.Forms.ComboBox();
            this.tnsSid = new System.Windows.Forms.TextBox();
            this.tnsInstanceName = new System.Windows.Forms.TextBox();
            this.tnsServer = new System.Windows.Forms.TextBox();
            this.tnsServiceName = new System.Windows.Forms.TextBox();
            this.tnsSidB = new System.Windows.Forms.RadioButton();
            this.tnsServiceNameB = new System.Windows.Forms.RadioButton();
            this.tnsServerTypeLabel = new System.Windows.Forms.Label();
            this.tnsPortLabel = new System.Windows.Forms.Label();
            this.tnsInstanceNameLabel = new System.Windows.Forms.Label();
            this.tnsServerLabel = new System.Windows.Forms.Label();
            this.tnsNameLabel = new System.Windows.Forms.Label();
            this.ldapNamingBox = new System.Windows.Forms.GroupBox();
            this.ldapServiceName = new System.Windows.Forms.TextBox();
            this.ldapContext = new System.Windows.Forms.TextBox();
            this.ldapServiceNameLabel = new System.Windows.Forms.Label();
            this.ldapContextLabel = new System.Windows.Forms.Label();
            this.ldapServerLabel = new System.Windows.Forms.Label();
            this.ldapServer = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.advancedConnOptions = new System.Windows.Forms.PropertyGrid();
            this.connmgrNabidka = new System.Windows.Forms.ToolStrip();
            this.prevConnB = new System.Windows.Forms.ToolStripButton();
            this.nextConnB = new System.Windows.Forms.ToolStripButton();
            this.connList = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newConnB = new System.Windows.Forms.ToolStripButton();
            this.saveConnB = new System.Windows.Forms.ToolStripButton();
            this.deleteConnB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.testConnB = new System.Windows.Forms.ToolStripButton();
            this.connB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.importConnB = new System.Windows.Forms.ToolStripSplitButton();
            this.exportConnB = new System.Windows.Forms.ToolStripSplitButton();
            this.vybranéSpojeníToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.všechnaSpojeníToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tnsServerType = new System.Windows.Forms.TextBox();
            this.tnsPort = new System.Windows.Forms.TextBox();
            this.credentialsGroupBox.SuspendLayout();
            this.connOptions.SuspendLayout();
            this.connOptionsBasic.SuspendLayout();
            this.connOptionsBox.SuspendLayout();
            this.connectionDescriptionBox.SuspendLayout();
            this.directNamingBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.port)).BeginInit();
            this.tnsNamingBox.SuspendLayout();
            this.ldapNamingBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.connmgrNabidka.SuspendLayout();
            this.SuspendLayout();
            // 
            // connNameLabel
            // 
            this.connNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.connNameLabel.AutoSize = true;
            this.connNameLabel.Location = new System.Drawing.Point(6, 26);
            this.connNameLabel.Name = "connNameLabel";
            this.connNameLabel.Size = new System.Drawing.Size(86, 13);
            this.connNameLabel.TabIndex = 0;
            this.connNameLabel.Text = "Název připojení:";
            // 
            // conUserNameLabel
            // 
            this.conUserNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.conUserNameLabel.AutoSize = true;
            this.conUserNameLabel.Location = new System.Drawing.Point(6, 55);
            this.conUserNameLabel.Name = "conUserNameLabel";
            this.conUserNameLabel.Size = new System.Drawing.Size(96, 13);
            this.conUserNameLabel.TabIndex = 0;
            this.conUserNameLabel.Text = "Uživatelské jméno:";
            // 
            // connPasswordLabel
            // 
            this.connPasswordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.connPasswordLabel.AutoSize = true;
            this.connPasswordLabel.Location = new System.Drawing.Point(6, 87);
            this.connPasswordLabel.Name = "connPasswordLabel";
            this.connPasswordLabel.Size = new System.Drawing.Size(37, 13);
            this.connPasswordLabel.TabIndex = 0;
            this.connPasswordLabel.Text = "Heslo:";
            // 
            // conName
            // 
            this.conName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.conName.Location = new System.Drawing.Point(108, 23);
            this.conName.Name = "conName";
            this.conName.Size = new System.Drawing.Size(460, 20);
            this.conName.TabIndex = 1;
            // 
            // connUsername
            // 
            this.connUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.connUsername.Location = new System.Drawing.Point(108, 52);
            this.connUsername.Name = "connUsername";
            this.connUsername.Size = new System.Drawing.Size(291, 20);
            this.connUsername.TabIndex = 1;
            // 
            // credentialsGroupBox
            // 
            this.credentialsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.credentialsGroupBox.Controls.Add(this.connPassword);
            this.credentialsGroupBox.Controls.Add(this.connNameLabel);
            this.credentialsGroupBox.Controls.Add(this.connUsername);
            this.credentialsGroupBox.Controls.Add(this.conUserNameLabel);
            this.credentialsGroupBox.Controls.Add(this.connPasswordLabel);
            this.credentialsGroupBox.Controls.Add(this.conName);
            this.credentialsGroupBox.Location = new System.Drawing.Point(12, 28);
            this.credentialsGroupBox.Name = "credentialsGroupBox";
            this.credentialsGroupBox.Size = new System.Drawing.Size(574, 134);
            this.credentialsGroupBox.TabIndex = 2;
            this.credentialsGroupBox.TabStop = false;
            this.credentialsGroupBox.Text = "Základní údaje";
            // 
            // connPassword
            // 
            this.connPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.connPassword.Location = new System.Drawing.Point(108, 84);
            this.connPassword.Name = "connPassword";
            this.connPassword.Size = new System.Drawing.Size(291, 20);
            this.connPassword.TabIndex = 2;
            this.connPassword.UseSystemPasswordChar = true;
            // 
            // osAuthenticate
            // 
            this.osAuthenticate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.osAuthenticate.AutoSize = true;
            this.osAuthenticate.Location = new System.Drawing.Point(15, 91);
            this.osAuthenticate.Name = "osAuthenticate";
            this.osAuthenticate.Size = new System.Drawing.Size(99, 17);
            this.osAuthenticate.TabIndex = 3;
            this.osAuthenticate.Text = "OS autentizace";
            this.osAuthenticate.UseVisualStyleBackColor = true;
            // 
            // namingMethodType
            // 
            this.namingMethodType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.namingMethodType.FormattingEnabled = true;
            this.namingMethodType.Location = new System.Drawing.Point(139, 55);
            this.namingMethodType.Name = "namingMethodType";
            this.namingMethodType.Size = new System.Drawing.Size(144, 21);
            this.namingMethodType.TabIndex = 4;
            // 
            // namingMethodTypeLabel
            // 
            this.namingMethodTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.namingMethodTypeLabel.AutoSize = true;
            this.namingMethodTypeLabel.Location = new System.Drawing.Point(12, 58);
            this.namingMethodTypeLabel.Name = "namingMethodTypeLabel";
            this.namingMethodTypeLabel.Size = new System.Drawing.Size(121, 13);
            this.namingMethodTypeLabel.TabIndex = 5;
            this.namingMethodTypeLabel.Text = "Typ pojmenování zdroje";
            // 
            // DBAPrivileges
            // 
            this.DBAPrivileges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DBAPrivileges.FormattingEnabled = true;
            this.DBAPrivileges.Location = new System.Drawing.Point(139, 23);
            this.DBAPrivileges.Name = "DBAPrivileges";
            this.DBAPrivileges.Size = new System.Drawing.Size(144, 21);
            this.DBAPrivileges.TabIndex = 4;
            // 
            // DBAPrivilegesLabel
            // 
            this.DBAPrivilegesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DBAPrivilegesLabel.AutoSize = true;
            this.DBAPrivilegesLabel.Location = new System.Drawing.Point(12, 26);
            this.DBAPrivilegesLabel.Name = "DBAPrivilegesLabel";
            this.DBAPrivilegesLabel.Size = new System.Drawing.Size(123, 13);
            this.DBAPrivilegesLabel.TabIndex = 5;
            this.DBAPrivilegesLabel.Text = "Zvláštní DBA oprávnění";
            // 
            // stornoB
            // 
            this.stornoB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stornoB.Location = new System.Drawing.Point(501, 759);
            this.stornoB.Name = "stornoB";
            this.stornoB.Size = new System.Drawing.Size(76, 23);
            this.stornoB.TabIndex = 6;
            this.stornoB.Text = "Storno";
            this.stornoB.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(-78, 318);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "button1";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // okB
            // 
            this.okB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okB.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okB.Location = new System.Drawing.Point(420, 759);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(76, 23);
            this.okB.TabIndex = 6;
            this.okB.Text = "OK";
            this.okB.UseVisualStyleBackColor = true;
            // 
            // connOptions
            // 
            this.connOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.connOptions.Controls.Add(this.connOptionsBasic);
            this.connOptions.Controls.Add(this.tabPage2);
            this.connOptions.Location = new System.Drawing.Point(13, 168);
            this.connOptions.Name = "connOptions";
            this.connOptions.SelectedIndex = 0;
            this.connOptions.Size = new System.Drawing.Size(570, 585);
            this.connOptions.TabIndex = 7;
            // 
            // connOptionsBasic
            // 
            this.connOptionsBasic.Controls.Add(this.connOptionsBox);
            this.connOptionsBasic.Controls.Add(this.connectionDescriptionBox);
            this.connOptionsBasic.Location = new System.Drawing.Point(4, 22);
            this.connOptionsBasic.Name = "connOptionsBasic";
            this.connOptionsBasic.Padding = new System.Windows.Forms.Padding(3);
            this.connOptionsBasic.Size = new System.Drawing.Size(562, 559);
            this.connOptionsBasic.TabIndex = 0;
            this.connOptionsBasic.Text = "Základní nastavení";
            this.connOptionsBasic.UseVisualStyleBackColor = true;
            // 
            // connOptionsBox
            // 
            this.connOptionsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.connOptionsBox.Controls.Add(this.osAuthenticate);
            this.connOptionsBox.Controls.Add(this.DBAPrivilegesLabel);
            this.connOptionsBox.Controls.Add(this.DBAPrivileges);
            this.connOptionsBox.Controls.Add(this.namingMethodType);
            this.connOptionsBox.Controls.Add(this.namingMethodTypeLabel);
            this.connOptionsBox.Location = new System.Drawing.Point(6, 6);
            this.connOptionsBox.Name = "connOptionsBox";
            this.connOptionsBox.Size = new System.Drawing.Size(289, 128);
            this.connOptionsBox.TabIndex = 6;
            this.connOptionsBox.TabStop = false;
            this.connOptionsBox.Text = "Nastavení";
            // 
            // connectionDescriptionBox
            // 
            this.connectionDescriptionBox.Controls.Add(this.tnsNamingBox);
            this.connectionDescriptionBox.Controls.Add(this.ldapNamingBox);
            this.connectionDescriptionBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.connectionDescriptionBox.Location = new System.Drawing.Point(3, 140);
            this.connectionDescriptionBox.Name = "connectionDescriptionBox";
            this.connectionDescriptionBox.Size = new System.Drawing.Size(556, 416);
            this.connectionDescriptionBox.TabIndex = 6;
            this.connectionDescriptionBox.TabStop = false;
            this.connectionDescriptionBox.Text = "Pojmenování zdroje";
            // 
            // directNamingBox
            // 
            this.directNamingBox.Controls.Add(this.host);
            this.directNamingBox.Controls.Add(this.serverType);
            this.directNamingBox.Controls.Add(this.port);
            this.directNamingBox.Controls.Add(this.sid);
            this.directNamingBox.Controls.Add(this.instanceName);
            this.directNamingBox.Controls.Add(this.serviceName);
            this.directNamingBox.Controls.Add(this.sidB);
            this.directNamingBox.Controls.Add(this.serviceNameB);
            this.directNamingBox.Controls.Add(this.serverTypeLabel);
            this.directNamingBox.Controls.Add(this.portLabel);
            this.directNamingBox.Controls.Add(this.instanceNameLabel);
            this.directNamingBox.Controls.Add(this.hostLabel);
            this.directNamingBox.Location = new System.Drawing.Point(25, 284);
            this.directNamingBox.Name = "directNamingBox";
            this.directNamingBox.Size = new System.Drawing.Size(550, 87);
            this.directNamingBox.TabIndex = 2;
            this.directNamingBox.TabStop = false;
            this.directNamingBox.Text = "Přímé zadání údajů";
            // 
            // host
            // 
            this.host.FormattingEnabled = true;
            this.host.Location = new System.Drawing.Point(103, 25);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(172, 21);
            this.host.TabIndex = 7;
            // 
            // serverType
            // 
            this.serverType.FormattingEnabled = true;
            this.serverType.Location = new System.Drawing.Point(103, 200);
            this.serverType.Name = "serverType";
            this.serverType.Size = new System.Drawing.Size(135, 21);
            this.serverType.TabIndex = 6;
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(103, 49);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(70, 20);
            this.port.TabIndex = 5;
            // 
            // sid
            // 
            this.sid.Location = new System.Drawing.Point(103, 156);
            this.sid.Name = "sid";
            this.sid.Size = new System.Drawing.Size(172, 20);
            this.sid.TabIndex = 4;
            // 
            // instanceName
            // 
            this.instanceName.Location = new System.Drawing.Point(103, 111);
            this.instanceName.Name = "instanceName";
            this.instanceName.Size = new System.Drawing.Size(172, 20);
            this.instanceName.TabIndex = 3;
            // 
            // serviceName
            // 
            this.serviceName.Location = new System.Drawing.Point(103, 85);
            this.serviceName.Name = "serviceName";
            this.serviceName.Size = new System.Drawing.Size(172, 20);
            this.serviceName.TabIndex = 2;
            // 
            // sidB
            // 
            this.sidB.AutoSize = true;
            this.sidB.Location = new System.Drawing.Point(9, 157);
            this.sidB.Name = "sidB";
            this.sidB.Size = new System.Drawing.Size(43, 17);
            this.sidB.TabIndex = 1;
            this.sidB.TabStop = true;
            this.sidB.Text = "SID";
            this.sidB.UseVisualStyleBackColor = true;
            // 
            // serviceNameB
            // 
            this.serviceNameB.AutoSize = true;
            this.serviceNameB.Location = new System.Drawing.Point(9, 86);
            this.serviceNameB.Name = "serviceNameB";
            this.serviceNameB.Size = new System.Drawing.Size(88, 17);
            this.serviceNameB.TabIndex = 1;
            this.serviceNameB.TabStop = true;
            this.serviceNameB.Text = "Název služby";
            this.serviceNameB.UseVisualStyleBackColor = true;
            // 
            // serverTypeLabel
            // 
            this.serverTypeLabel.AutoSize = true;
            this.serverTypeLabel.Location = new System.Drawing.Point(6, 203);
            this.serverTypeLabel.Name = "serverTypeLabel";
            this.serverTypeLabel.Size = new System.Drawing.Size(66, 13);
            this.serverTypeLabel.TabIndex = 0;
            this.serverTypeLabel.Text = "Typ serveru:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(6, 51);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "Port:";
            // 
            // instanceNameLabel
            // 
            this.instanceNameLabel.AutoSize = true;
            this.instanceNameLabel.Location = new System.Drawing.Point(30, 114);
            this.instanceNameLabel.Name = "instanceNameLabel";
            this.instanceNameLabel.Size = new System.Drawing.Size(51, 13);
            this.instanceNameLabel.TabIndex = 0;
            this.instanceNameLabel.Text = "Instance:";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(6, 25);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(41, 13);
            this.hostLabel.TabIndex = 0;
            this.hostLabel.Text = "Server:";
            // 
            // tnsNamingBox
            // 
            this.tnsNamingBox.Controls.Add(this.directNamingBox);
            this.tnsNamingBox.Controls.Add(this.tnsPort);
            this.tnsNamingBox.Controls.Add(this.tnsServerType);
            this.tnsNamingBox.Controls.Add(this.tnsName);
            this.tnsNamingBox.Controls.Add(this.tnsSid);
            this.tnsNamingBox.Controls.Add(this.tnsInstanceName);
            this.tnsNamingBox.Controls.Add(this.tnsServer);
            this.tnsNamingBox.Controls.Add(this.tnsServiceName);
            this.tnsNamingBox.Controls.Add(this.tnsSidB);
            this.tnsNamingBox.Controls.Add(this.tnsServiceNameB);
            this.tnsNamingBox.Controls.Add(this.tnsServerTypeLabel);
            this.tnsNamingBox.Controls.Add(this.tnsPortLabel);
            this.tnsNamingBox.Controls.Add(this.tnsInstanceNameLabel);
            this.tnsNamingBox.Controls.Add(this.tnsServerLabel);
            this.tnsNamingBox.Controls.Add(this.tnsNameLabel);
            this.tnsNamingBox.Location = new System.Drawing.Point(3, 177);
            this.tnsNamingBox.Name = "tnsNamingBox";
            this.tnsNamingBox.Size = new System.Drawing.Size(550, 236);
            this.tnsNamingBox.TabIndex = 1;
            this.tnsNamingBox.TabStop = false;
            this.tnsNamingBox.Text = "TNS naming";
            // 
            // tnsName
            // 
            this.tnsName.FormattingEnabled = true;
            this.tnsName.Location = new System.Drawing.Point(112, 22);
            this.tnsName.Name = "tnsName";
            this.tnsName.Size = new System.Drawing.Size(221, 21);
            this.tnsName.TabIndex = 31;
            // 
            // tnsSid
            // 
            this.tnsSid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tnsSid.Location = new System.Drawing.Point(112, 187);
            this.tnsSid.Name = "tnsSid";
            this.tnsSid.ReadOnly = true;
            this.tnsSid.Size = new System.Drawing.Size(221, 20);
            this.tnsSid.TabIndex = 28;
            // 
            // tnsInstanceName
            // 
            this.tnsInstanceName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tnsInstanceName.Location = new System.Drawing.Point(112, 142);
            this.tnsInstanceName.Name = "tnsInstanceName";
            this.tnsInstanceName.ReadOnly = true;
            this.tnsInstanceName.Size = new System.Drawing.Size(221, 20);
            this.tnsInstanceName.TabIndex = 27;
            // 
            // tnsServer
            // 
            this.tnsServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tnsServer.Location = new System.Drawing.Point(112, 53);
            this.tnsServer.Name = "tnsServer";
            this.tnsServer.ReadOnly = true;
            this.tnsServer.Size = new System.Drawing.Size(221, 20);
            this.tnsServer.TabIndex = 25;
            // 
            // tnsServiceName
            // 
            this.tnsServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tnsServiceName.Location = new System.Drawing.Point(112, 116);
            this.tnsServiceName.Name = "tnsServiceName";
            this.tnsServiceName.ReadOnly = true;
            this.tnsServiceName.Size = new System.Drawing.Size(221, 20);
            this.tnsServiceName.TabIndex = 26;
            // 
            // tnsSidB
            // 
            this.tnsSidB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tnsSidB.AutoSize = true;
            this.tnsSidB.Enabled = false;
            this.tnsSidB.Location = new System.Drawing.Point(18, 188);
            this.tnsSidB.Name = "tnsSidB";
            this.tnsSidB.Size = new System.Drawing.Size(43, 17);
            this.tnsSidB.TabIndex = 23;
            this.tnsSidB.TabStop = true;
            this.tnsSidB.Text = "SID";
            this.tnsSidB.UseVisualStyleBackColor = true;
            // 
            // tnsServiceNameB
            // 
            this.tnsServiceNameB.AutoSize = true;
            this.tnsServiceNameB.Enabled = false;
            this.tnsServiceNameB.Location = new System.Drawing.Point(18, 117);
            this.tnsServiceNameB.Name = "tnsServiceNameB";
            this.tnsServiceNameB.Size = new System.Drawing.Size(88, 17);
            this.tnsServiceNameB.TabIndex = 24;
            this.tnsServiceNameB.TabStop = true;
            this.tnsServiceNameB.Text = "Název služby";
            this.tnsServiceNameB.UseVisualStyleBackColor = true;
            // 
            // tnsServerTypeLabel
            // 
            this.tnsServerTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tnsServerTypeLabel.AutoSize = true;
            this.tnsServerTypeLabel.Location = new System.Drawing.Point(15, 219);
            this.tnsServerTypeLabel.Name = "tnsServerTypeLabel";
            this.tnsServerTypeLabel.Size = new System.Drawing.Size(66, 13);
            this.tnsServerTypeLabel.TabIndex = 20;
            this.tnsServerTypeLabel.Text = "Typ serveru:";
            // 
            // tnsPortLabel
            // 
            this.tnsPortLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tnsPortLabel.AutoSize = true;
            this.tnsPortLabel.Location = new System.Drawing.Point(15, 82);
            this.tnsPortLabel.Name = "tnsPortLabel";
            this.tnsPortLabel.Size = new System.Drawing.Size(29, 13);
            this.tnsPortLabel.TabIndex = 19;
            this.tnsPortLabel.Text = "Port:";
            // 
            // tnsInstanceNameLabel
            // 
            this.tnsInstanceNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tnsInstanceNameLabel.AutoSize = true;
            this.tnsInstanceNameLabel.Location = new System.Drawing.Point(39, 145);
            this.tnsInstanceNameLabel.Name = "tnsInstanceNameLabel";
            this.tnsInstanceNameLabel.Size = new System.Drawing.Size(51, 13);
            this.tnsInstanceNameLabel.TabIndex = 22;
            this.tnsInstanceNameLabel.Text = "Instance:";
            // 
            // tnsServerLabel
            // 
            this.tnsServerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tnsServerLabel.AutoSize = true;
            this.tnsServerLabel.Location = new System.Drawing.Point(15, 56);
            this.tnsServerLabel.Name = "tnsServerLabel";
            this.tnsServerLabel.Size = new System.Drawing.Size(41, 13);
            this.tnsServerLabel.TabIndex = 21;
            this.tnsServerLabel.Text = "Server:";
            // 
            // tnsNameLabel
            // 
            this.tnsNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tnsNameLabel.AutoSize = true;
            this.tnsNameLabel.Location = new System.Drawing.Point(9, 25);
            this.tnsNameLabel.Name = "tnsNameLabel";
            this.tnsNameLabel.Size = new System.Drawing.Size(63, 13);
            this.tnsNameLabel.TabIndex = 0;
            this.tnsNameLabel.Text = "TNS jméno:";
            // 
            // ldapNamingBox
            // 
            this.ldapNamingBox.Controls.Add(this.ldapServiceName);
            this.ldapNamingBox.Controls.Add(this.ldapContext);
            this.ldapNamingBox.Controls.Add(this.ldapServiceNameLabel);
            this.ldapNamingBox.Controls.Add(this.ldapContextLabel);
            this.ldapNamingBox.Controls.Add(this.ldapServerLabel);
            this.ldapNamingBox.Controls.Add(this.ldapServer);
            this.ldapNamingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ldapNamingBox.Location = new System.Drawing.Point(3, 16);
            this.ldapNamingBox.Name = "ldapNamingBox";
            this.ldapNamingBox.Size = new System.Drawing.Size(550, 397);
            this.ldapNamingBox.TabIndex = 3;
            this.ldapNamingBox.TabStop = false;
            this.ldapNamingBox.Text = "LDAP";
            // 
            // ldapServiceName
            // 
            this.ldapServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ldapServiceName.Location = new System.Drawing.Point(91, 88);
            this.ldapServiceName.Name = "ldapServiceName";
            this.ldapServiceName.Size = new System.Drawing.Size(256, 20);
            this.ldapServiceName.TabIndex = 5;
            // 
            // ldapContext
            // 
            this.ldapContext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ldapContext.Location = new System.Drawing.Point(91, 52);
            this.ldapContext.Name = "ldapContext";
            this.ldapContext.Size = new System.Drawing.Size(256, 20);
            this.ldapContext.TabIndex = 5;
            // 
            // ldapServiceNameLabel
            // 
            this.ldapServiceNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ldapServiceNameLabel.AutoSize = true;
            this.ldapServiceNameLabel.Location = new System.Drawing.Point(7, 91);
            this.ldapServiceNameLabel.Name = "ldapServiceNameLabel";
            this.ldapServiceNameLabel.Size = new System.Drawing.Size(70, 13);
            this.ldapServiceNameLabel.TabIndex = 0;
            this.ldapServiceNameLabel.Text = "Název služby";
            // 
            // ldapContextLabel
            // 
            this.ldapContextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ldapContextLabel.AutoSize = true;
            this.ldapContextLabel.Location = new System.Drawing.Point(7, 55);
            this.ldapContextLabel.Name = "ldapContextLabel";
            this.ldapContextLabel.Size = new System.Drawing.Size(73, 13);
            this.ldapContextLabel.TabIndex = 0;
            this.ldapContextLabel.Text = "LDAP kontext";
            // 
            // ldapServerLabel
            // 
            this.ldapServerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ldapServerLabel.AutoSize = true;
            this.ldapServerLabel.Location = new System.Drawing.Point(7, 28);
            this.ldapServerLabel.Name = "ldapServerLabel";
            this.ldapServerLabel.Size = new System.Drawing.Size(72, 13);
            this.ldapServerLabel.TabIndex = 0;
            this.ldapServerLabel.Text = "Server LDAP:";
            // 
            // ldapServer
            // 
            this.ldapServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ldapServer.FormattingEnabled = true;
            this.ldapServer.Location = new System.Drawing.Point(91, 25);
            this.ldapServer.Name = "ldapServer";
            this.ldapServer.Size = new System.Drawing.Size(434, 21);
            this.ldapServer.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.advancedConnOptions);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(562, 559);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pokročilá nastavení";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // advancedConnOptions
            // 
            this.advancedConnOptions.Location = new System.Drawing.Point(6, 6);
            this.advancedConnOptions.Name = "advancedConnOptions";
            this.advancedConnOptions.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.advancedConnOptions.Size = new System.Drawing.Size(445, 341);
            this.advancedConnOptions.TabIndex = 1;
            // 
            // connmgrNabidka
            // 
            this.connmgrNabidka.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prevConnB,
            this.nextConnB,
            this.connList,
            this.toolStripSeparator1,
            this.newConnB,
            this.saveConnB,
            this.deleteConnB,
            this.toolStripSeparator2,
            this.testConnB,
            this.connB,
            this.toolStripSeparator3,
            this.importConnB,
            this.exportConnB});
            this.connmgrNabidka.Location = new System.Drawing.Point(0, 0);
            this.connmgrNabidka.Name = "connmgrNabidka";
            this.connmgrNabidka.Size = new System.Drawing.Size(598, 25);
            this.connmgrNabidka.TabIndex = 8;
            this.connmgrNabidka.Text = "toolStrip1";
            // 
            // prevConnB
            // 
            this.prevConnB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.prevConnB.Image = ((System.Drawing.Image)(resources.GetObject("prevConnB.Image")));
            this.prevConnB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prevConnB.Name = "prevConnB";
            this.prevConnB.Size = new System.Drawing.Size(52, 22);
            this.prevConnB.Text = "Previous";
            // 
            // nextConnB
            // 
            this.nextConnB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.nextConnB.Image = ((System.Drawing.Image)(resources.GetObject("nextConnB.Image")));
            this.nextConnB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextConnB.Name = "nextConnB";
            this.nextConnB.Size = new System.Drawing.Size(34, 22);
            this.nextConnB.Text = "Next";
            // 
            // connList
            // 
            this.connList.Name = "connList";
            this.connList.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // newConnB
            // 
            this.newConnB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newConnB.Image = ((System.Drawing.Image)(resources.GetObject("newConnB.Image")));
            this.newConnB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newConnB.Name = "newConnB";
            this.newConnB.Size = new System.Drawing.Size(32, 22);
            this.newConnB.Text = "New";
            // 
            // saveConnB
            // 
            this.saveConnB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveConnB.Image = ((System.Drawing.Image)(resources.GetObject("saveConnB.Image")));
            this.saveConnB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveConnB.Name = "saveConnB";
            this.saveConnB.Size = new System.Drawing.Size(35, 22);
            this.saveConnB.Text = "Save";
            // 
            // deleteConnB
            // 
            this.deleteConnB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteConnB.Image = ((System.Drawing.Image)(resources.GetObject("deleteConnB.Image")));
            this.deleteConnB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteConnB.Name = "deleteConnB";
            this.deleteConnB.Size = new System.Drawing.Size(42, 22);
            this.deleteConnB.Text = "Delete";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // testConnB
            // 
            this.testConnB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.testConnB.Image = ((System.Drawing.Image)(resources.GetObject("testConnB.Image")));
            this.testConnB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.testConnB.Name = "testConnB";
            this.testConnB.Size = new System.Drawing.Size(32, 22);
            this.testConnB.Text = "Test";
            // 
            // connB
            // 
            this.connB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.connB.Image = ((System.Drawing.Image)(resources.GetObject("connB.Image")));
            this.connB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connB.Name = "connB";
            this.connB.Size = new System.Drawing.Size(51, 22);
            this.connB.Text = "Connect";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // importConnB
            // 
            this.importConnB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.importConnB.Image = ((System.Drawing.Image)(resources.GetObject("importConnB.Image")));
            this.importConnB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importConnB.Name = "importConnB";
            this.importConnB.Size = new System.Drawing.Size(77, 22);
            this.importConnB.Text = "Importovat";
            // 
            // exportConnB
            // 
            this.exportConnB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exportConnB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vybranéSpojeníToolStripMenuItem1,
            this.všechnaSpojeníToolStripMenuItem1});
            this.exportConnB.Image = ((System.Drawing.Image)(resources.GetObject("exportConnB.Image")));
            this.exportConnB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportConnB.Name = "exportConnB";
            this.exportConnB.Size = new System.Drawing.Size(77, 22);
            this.exportConnB.Text = "Exportovat";
            // 
            // vybranéSpojeníToolStripMenuItem1
            // 
            this.vybranéSpojeníToolStripMenuItem1.Name = "vybranéSpojeníToolStripMenuItem1";
            this.vybranéSpojeníToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.vybranéSpojeníToolStripMenuItem1.Text = "Vybrané spojení";
            // 
            // všechnaSpojeníToolStripMenuItem1
            // 
            this.všechnaSpojeníToolStripMenuItem1.Name = "všechnaSpojeníToolStripMenuItem1";
            this.všechnaSpojeníToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.všechnaSpojeníToolStripMenuItem1.Text = "Všechna spojení";
            // 
            // tnsServerType
            // 
            this.tnsServerType.Location = new System.Drawing.Point(112, 216);
            this.tnsServerType.Name = "tnsServerType";
            this.tnsServerType.Size = new System.Drawing.Size(221, 20);
            this.tnsServerType.TabIndex = 32;
            // 
            // tnsPort
            // 
            this.tnsPort.Location = new System.Drawing.Point(112, 79);
            this.tnsPort.Name = "tnsPort";
            this.tnsPort.Size = new System.Drawing.Size(100, 20);
            this.tnsPort.TabIndex = 33;
            // 
            // ConnectionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 785);
            this.Controls.Add(this.connmgrNabidka);
            this.Controls.Add(this.connOptions);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.stornoB);
            this.Controls.Add(this.credentialsGroupBox);
            this.Name = "ConnectionManager";
            this.Text = "Správce připojení";
            this.credentialsGroupBox.ResumeLayout(false);
            this.credentialsGroupBox.PerformLayout();
            this.connOptions.ResumeLayout(false);
            this.connOptionsBasic.ResumeLayout(false);
            this.connOptionsBox.ResumeLayout(false);
            this.connOptionsBox.PerformLayout();
            this.connectionDescriptionBox.ResumeLayout(false);
            this.directNamingBox.ResumeLayout(false);
            this.directNamingBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.port)).EndInit();
            this.tnsNamingBox.ResumeLayout(false);
            this.tnsNamingBox.PerformLayout();
            this.ldapNamingBox.ResumeLayout(false);
            this.ldapNamingBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.connmgrNabidka.ResumeLayout(false);
            this.connmgrNabidka.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label connNameLabel;
        private System.Windows.Forms.Label conUserNameLabel;
        private System.Windows.Forms.Label connPasswordLabel;
        private System.Windows.Forms.TextBox conName;
        private System.Windows.Forms.TextBox connUsername;
        private System.Windows.Forms.GroupBox credentialsGroupBox;
        private System.Windows.Forms.CheckBox osAuthenticate;
        private System.Windows.Forms.ComboBox namingMethodType;
        private System.Windows.Forms.Label namingMethodTypeLabel;
        private System.Windows.Forms.ComboBox DBAPrivileges;
        private System.Windows.Forms.Label DBAPrivilegesLabel;
        private System.Windows.Forms.Button stornoB;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button okB;
        private System.Windows.Forms.MaskedTextBox connPassword;
        private System.Windows.Forms.TabControl connOptions;
        private System.Windows.Forms.TabPage connOptionsBasic;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip connmgrNabidka;
        private System.Windows.Forms.ToolStripButton newConnB;
        private System.Windows.Forms.ToolStripButton saveConnB;
        private System.Windows.Forms.ToolStripButton deleteConnB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton testConnB;
        private System.Windows.Forms.ToolStripButton connB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton prevConnB;
        private System.Windows.Forms.ToolStripButton nextConnB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton importConnB;
        private System.Windows.Forms.ToolStripSplitButton exportConnB;
        private System.Windows.Forms.ToolStripMenuItem vybranéSpojeníToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem všechnaSpojeníToolStripMenuItem1;
        private System.Windows.Forms.GroupBox connOptionsBox;
        private System.Windows.Forms.GroupBox connectionDescriptionBox;
        private System.Windows.Forms.PropertyGrid advancedConnOptions;
        private System.Windows.Forms.GroupBox tnsNamingBox;
        private System.Windows.Forms.Label tnsNameLabel;
        private System.Windows.Forms.GroupBox directNamingBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.TextBox sid;
        private System.Windows.Forms.TextBox instanceName;
        private System.Windows.Forms.TextBox serviceName;
        private System.Windows.Forms.RadioButton sidB;
        private System.Windows.Forms.RadioButton serviceNameB;
        private System.Windows.Forms.Label instanceNameLabel;
        private System.Windows.Forms.NumericUpDown port;
        private System.Windows.Forms.GroupBox ldapNamingBox;
        private System.Windows.Forms.ComboBox serverType;
        private System.Windows.Forms.Label serverTypeLabel;
        private System.Windows.Forms.Label ldapContextLabel;
        private System.Windows.Forms.Label ldapServerLabel;
        private System.Windows.Forms.ComboBox ldapServer;
        private System.Windows.Forms.TextBox ldapServiceName;
        private System.Windows.Forms.TextBox ldapContext;
        private System.Windows.Forms.Label ldapServiceNameLabel;
        private System.Windows.Forms.TextBox tnsSid;
        private System.Windows.Forms.TextBox tnsInstanceName;
        private System.Windows.Forms.TextBox tnsServer;
        private System.Windows.Forms.TextBox tnsServiceName;
        private System.Windows.Forms.RadioButton tnsSidB;
        private System.Windows.Forms.RadioButton tnsServiceNameB;
        private System.Windows.Forms.Label tnsServerTypeLabel;
        private System.Windows.Forms.Label tnsPortLabel;
        private System.Windows.Forms.Label tnsInstanceNameLabel;
        private System.Windows.Forms.Label tnsServerLabel;
        private System.Windows.Forms.ComboBox host;
        private System.Windows.Forms.ToolStripComboBox connList;
        private System.Windows.Forms.ComboBox tnsName;
        private System.Windows.Forms.TextBox tnsPort;
        private System.Windows.Forms.TextBox tnsServerType;
    }
}