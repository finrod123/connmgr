using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace connmgr
{
    public enum EConnectionSaveCode
    {
        Ok,
        EmptyConnectionName,
        EmptyUsername,
        EmptyPassword,
        EmptyHost,
        EmptyServiceName,
        EmptySid,
        EmptyTnsIdentifier,
        EmptyLdapServiceName,
        EmptyLdapServer,
        EmptyLdapContext,
        EmptyProxyPassword,
        DuplicateConnectionName,
        Error
    }

    public partial class ConnectionManagerForm : Form
    {
        const decimal MIN_TCPPORT = 0,
                      MAX_TCPPORT = 65535,
                      DEFAULT_TCPPORT = 1521;

        GroupBox namingBox;
        // datovy kontejner pro ulozeni dat o spojeni
        ConnectionData connectData = new ConnectionData();
        // priznak zadavani noveho pripojeni
        bool newConnection;
        // odkaz na ConnectionManager
        ConnectionManager connectionManager;
        BindingSource connSource = new BindingSource();

        public ConnectionManagerForm(ConnectionManager connectionManager)
        {
            InitializeComponent();
            // prirad odkaz na connection manager a 
            this.connectionManager = connectionManager;
            linkWithConnectManager();
            // vytvor datovy kontejner a resetuj nektera jeho nastaveni
            connectData.resetConnectionStringValues();
            // proved uvodni nastaveni
            initAuthentication();
            initNamingMethods();
            initAdvancedConnectionStringOptions();
            setConnectionBindingSource();
            setConnectionBindings();
            setToolbar();

            // nastav dalsi udalosti
            setHandlers();
        }

        void setConnectionBindings()
        {
            // nastav bindingy pro prvky formulare
            // zakladni a autentizacni udaje
            connName.DataBindings.Add(new Binding("Text", connSource, "Name"));
            connUsername.DataBindings.Add(new Binding("Text", connSource, "UserName"));
            osAuthenticate.DataBindings.Add(new Binding("Checked", connSource, "OsAuthenticaion"));
            DBAPrivileges.DataBindings.Add(new Binding("Value", connSource, "EDbaPrivileges"));
            namingMethodType.DataBindings.Add(new Binding("Value", connSource, "NamingMethod"));
            // udaje naming metod
            // 1) direct naming
            host.DataBindings.Add(new Binding("Text", connSource, "Server"));
            port.DataBindings.Add(new Binding("Value", connSource, "Port"));
            sidB.DataBindings.Add(new Binding("Checked", connSource, ""));
            serviceName.DataBindings.Add(new Binding("Text", connSource, "ServiceName"));
            instanceName.DataBindings.Add(new Binding("Text", connSource, "InstanceName"));
            sid.DataBindings.Add(new Binding("Text", connSource, "Sid"));
            serverType.DataBindings.Add(new Binding("Value", connSource, "ServerType"));
            // 2) TNS naming
            tnsName.DataBindings.Add(new Binding("Text", connSource, "TnsServiceName"));
            // 3) LDAP naming
            ldapServiceName.DataBindings.Add(new Binding("Text", connSource, "LdapServiceName"));
            ldapServer.DataBindings.Add(new Binding("Text", connSource, "LdapServer"));
            ldapContext.DataBindings.Add(new Binding("Text", connSource, "LdapContext"));
            // nastav binding pro combobox v toolbaru
            connList.ComboBox.DataSource = connSource;
            connList.ComboBox.DisplayMember = "Name";
            connList.ComboBox.ValueMember = "Name"; Binding b;b.Control
        }

        void setConnectionBindingSource()
        {
            connSource.AllowNew = true;
            connSource.DataSource = typeof(Connection);
        }

        void setToolbar()
        {
            // nastav seznam pripojeni
            connList.AutoCompleteMode = AutoCompleteMode.Suggest;
            connList.AutoCompleteSource = AutoCompleteSource.ListItems;
            // nastav udalosti
            setToolBarHandlers();
        }

        void linkWithConnectManager()
        {
            // prihlas se o odber informaci o novem pripojeni
            connectionManager.ConnectionAdded += connectionAddedEventHandler;
        }

        /// <summary>
        /// Obsluha pridani noveho pripojeni
        /// </summary>
        /// <param name="e"></param>
        void connectionAddedEventHandler(ConnectionAddedEventArgs e)
        {
            // pridej pripojeni do seznamu pripojeni
            Connection connection = e.Connection;
            connSource.Add(connection);
            MessageBox.Show("Connection added!");
        }

        void formClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        void setHandlers()
        {
            FormClosing += new FormClosingEventHandler(formClosing);
        }

        void setToolBarHandlers()
        {
            saveConnB.Click += new EventHandler(saveConnB_Click);
        }

        void saveConnB_Click(object sender, EventArgs e)
        {
            // pokud neni potreba ulozit nova data, skonci
            if (!isSaveNeeded())
                return;
            // pokud to potreba je, zkus je ulozit
            if (saveData() &&
               newConnection)
            {
                newConnection = false;
            }
        }

        /// <summary>
        /// Metoda, ktera ulozi data spojeni a vrati priznak uspesnosti operace
        /// </summary>
        /// <returns></returns>
        bool saveData()
        {
            // zkontroluj validitu dat
            switch (validateInput())
            {
                case EConnectionSaveCode.EmptyConnectionName:
                case EConnectionSaveCode.EmptyUsername:
                case EConnectionSaveCode.EmptyPassword:
                case EConnectionSaveCode.EmptyHost:
                case EConnectionSaveCode.EmptyServiceName:
                case EConnectionSaveCode.EmptySid:
                case EConnectionSaveCode.EmptyTnsIdentifier:
                case EConnectionSaveCode.EmptyLdapServiceName:
                case EConnectionSaveCode.EmptyLdapServer:
                case EConnectionSaveCode.EmptyLdapContext:
                    errorLabel.Text = "Je nutné doplnit některá chybějící data!";
                    return false;
                case EConnectionSaveCode.Error:
                    errorLabel.Text = "Došlo k neznámé chybě!";
                    return false;
            }

            // zapis data z formulare do connectData objektu
            refreshConnectData();
            // data jsou validni -> ulozeni dat
            if (newConnection)
            {
                switch (connectionManager.AddConnection(connectData))
                {
                    case EConnectionSaveCode.DuplicateConnectionName:
                        errorLabel.Text = "Připojení s takovým názvem už existuje!";
                        return false;
                    case EConnectionSaveCode.Error:
                        errorLabel.Text = "Došlo k neznámé chybě!";
                        return false;
                }

                // jinak vse probehlo v poradku
                errorLabel.Text = "";
                return true;
            }

            // zmena dat spojeni

            errorLabel.Text = "";
            return true;
        }

        void refreshConnectData()
        {
            // zapis zakladni data
            connectData.Name = connName.Text;
            // zapis autentizacni data
            if (!(connectData.OsAuthentication = osAuthenticate.Checked))
            {
                connectData.UserName = connUsername.Text;
            }

            connectData.DbaPrivileges = (EDbaPrivileges)DBAPrivileges.SelectedValue;

            // nastav naming metody
            switch (connectData.NamingMethod = (ENamingMethod)namingMethodType.SelectedValue)
            {
                case ENamingMethod.ConnectDescriptor:
                    
                    connectData.Server = host.Text;
                    connectData.Port = port.Value;
                    
                    if (connectData.UsingSid = sidB.Checked)
                        connectData.Sid = sid.Text;
                    else
                    {
                        connectData.ServiceName = serviceName.Text;
                        connectData.InstanceName = instanceName.Text;
                    }

                    connectData.ServerType = (EDBServerType)serverType.SelectedValue;
                    break;

                case ENamingMethod.TnsServiceName:

                    connectData.TnsServiceName = tnsName.Text;
                    break;

                case ENamingMethod.Ldap:

                    connectData.LdapServiceName = ldapServiceName.Text;
                    connectData.LdapServer = ldapServer.Text;
                    connectData.LdapContext = ldapContext.Text;
                    break;
            }
            
            // pokrocile connection string moznosti jsou uz nastaveny, nebot
            // jsou prubezne nastavovany behem upravy dat v dialogu
        }

        EConnectionSaveCode validateInput()
        {
            EConnectionSaveCode saveCode;

            // zkontroluj jmeno pripojeni
            if (string.IsNullOrEmpty(connName.Text))
            {
                connNameErrorLabel.Text = "Chybí jméno připojení!";
                return EConnectionSaveCode.EmptyConnectionName;
            } else
                connNameErrorLabel.Text = "";

            // zkontroluj autentizacni data
            saveCode = validateAuthentication();
            if (saveCode != EConnectionSaveCode.Ok)
                return saveCode;

            // zkontroluj naming metody
            saveCode = validateNamingMethods();
            if (saveCode != EConnectionSaveCode.Ok)
                return saveCode;
            
            // zkontoluj pokrocile moznosti connection stringu
            return validateAdvancedConnectionStringOptions();
        }

        /// <summary>
        /// Pomocna metoda, ktera rozhoduje, zda je nutne provest ulozeni dat
        /// (true pro nova spojeni, pro existujici spojeni nutno porovnat aktualne
        /// zadana data s temi v handle existujiciho spojeni (metoda Equals)
        /// </summary>
        /// <returns></returns>
        bool isSaveNeeded()
        {
            return newConnection;
        }

        EConnectionSaveCode validateAuthentication()
        {
            if (!osAuthenticate.Checked)
            {
                if (string.IsNullOrEmpty(connUsername.Text))
                {
                    connUsernameErrorLabel.Text = "Chybí uživatelské jméno!";
                    return EConnectionSaveCode.EmptyUsername;
                } else
                    connUsernameErrorLabel.Text = "";
            }

            return EConnectionSaveCode.Ok;
        }

        EConnectionSaveCode validateNamingMethods()
        {
            EConnectionSaveCode saveCode;

            switch ((ENamingMethod)namingMethodType.SelectedValue)
            {
                case ENamingMethod.ConnectDescriptor:
                    saveCode = validateDirectNaming();
                    break;
                case ENamingMethod.TnsServiceName:
                    saveCode = validateTnsNaming();
                    break;
                case ENamingMethod.Ldap:
                    saveCode = validateLdapNaming();
                    break;
                default:
                    saveCode = EConnectionSaveCode.Error;
                    break;
            }

            return saveCode;
        }

        EConnectionSaveCode validateDirectNaming()
        {
            if (string.IsNullOrEmpty(host.Text))
            {
                hostErrorLabel.Text = "Není vybrán žádný server!";
                namingMethodType.SelectedValue = ENamingMethod.ConnectDescriptor;
                return EConnectionSaveCode.EmptyHost;
            } else
                hostErrorLabel.Text = "";

            if (serviceNameB.Checked)
            {
                if (string.IsNullOrEmpty(serviceName.Text))
                {
                    serviceNameErrorLabel.Text = "Není zadáno jméno služby!";
                    namingMethodType.SelectedValue = ENamingMethod.ConnectDescriptor;
                    return EConnectionSaveCode.EmptyServiceName;
                } else
                    serviceNameErrorLabel.Text = "";

            } else if (string.IsNullOrEmpty(sid.Text))
            {
                sidErrorLabel.Text = "Není zadán identifikátor SID!";
                namingMethodType.SelectedValue = ENamingMethod.ConnectDescriptor;
                return EConnectionSaveCode.EmptySid;
            } else
                sidErrorLabel.Text = "";

            return EConnectionSaveCode.Ok;
        }

        EConnectionSaveCode validateTnsNaming()
        {
            if (string.IsNullOrEmpty(tnsName.Text))
            {
                tnsNameErrorLabel.Text = "Není vybrán žádný TNS identifikátor!";
                namingMethodType.SelectedValue = ENamingMethod.TnsServiceName;
                return EConnectionSaveCode.EmptyTnsIdentifier;
            } else
                tnsNameErrorLabel.Text = "";

            return EConnectionSaveCode.Ok;
        }

        EConnectionSaveCode validateLdapNaming()
        {
            if (string.IsNullOrEmpty(ldapServiceName.Text))
            {
                ldapServiceNameErrorLabel.Text = "Není zadáno jméno služby!";
                namingMethodType.SelectedValue = ENamingMethod.Ldap;
                return EConnectionSaveCode.EmptyLdapServiceName;
            } else
                ldapServiceNameErrorLabel.Text = "";

            if (string.IsNullOrEmpty(ldapServer.Text))
            {
                ldapServerErrorLabel.Text = "Není zadán LDAP server!";
                namingMethodType.SelectedValue = ENamingMethod.Ldap;
                return EConnectionSaveCode.EmptyLdapServer;
            } else
                ldapServerErrorLabel.Text = "";

            if (string.IsNullOrEmpty(ldapContext.Text))
            {
                ldapContextErrorLabel.Text = "Není zadán žádný Oracle context!";
                namingMethodType.SelectedValue = ENamingMethod.Ldap;
                return EConnectionSaveCode.EmptyLdapContext;
            } else
                ldapContextErrorLabel.Text = "";

            return EConnectionSaveCode.Ok;
        }

        EConnectionSaveCode validateAdvancedConnectionStringOptions()
        {
            if (!string.IsNullOrEmpty(connectData.ProxyUserId) &&
                string.IsNullOrEmpty(connectData.ProxyUserPassword))
            {
                advancedConnectionStringOptionsErrorLabel.Text =
                    "Je nutné zadat heslo proxy uživatele!";
                connOptions.SelectedTab = advancedConnectionOptionsPage;
                return EConnectionSaveCode.EmptyProxyPassword;
            } else
                advancedConnectionStringOptionsErrorLabel.Text = "";

            return EConnectionSaveCode.Ok;
        }

        /// <summary>
        /// Nastavi pri instanciaci okna pole pro zadavani informaci souvisejicich
        /// s autentizaci
        /// </summary>
        void initAuthentication()
        {
            // nastav chovani tlacitka pro volbu typu autentizace
            osAuthenticate.CheckedChanged += new EventHandler(zmenaTypuAutentizace);

            
            DBAPrivileges.AutoCompleteMode = AutoCompleteMode.Suggest;
            DBAPrivileges.DropDownStyle = ComboBoxStyle.DropDownList;
            // vloz hodnoty pro vyber zvlastnich privilegii pro prihlaseni k databazi
            DBAPrivileges.DataSource = new ArrayList() {
                new { Name = "normální", Value = EDbaPrivileges.Normal },
                new { Name = "SYSDBA", Value = EDbaPrivileges.SysDba },
                new { Name = "SYSOPER", Value = EDbaPrivileges.SysOper }
            };

            DBAPrivileges.ValueMember = "Value";
            DBAPrivileges.DisplayMember = "Name";
            
            // udalosti: vyber konkretnich pristupovych opravneni

        }

        /// <summary>
        /// Nastavi vstupni pole pro zadani informaci souvisejicich s vybranou
        /// naming metodou (napr. server, port, jmeno databaze atd.)
        /// </summary>
        void initNamingMethods()
        {
            namingMethodType.AutoCompleteMode = AutoCompleteMode.Suggest;
            namingMethodType.DropDownStyle = ComboBoxStyle.DropDownList;
            // vloz hodnoty do seznamu s vyberem typu naming method
            namingMethodType.DataSource = new[] {
                new { Name = "connect descriptor", Value = ENamingMethod.ConnectDescriptor },
                new { Name = "TNS název", Value = ENamingMethod.TnsServiceName },
                new { Name = "LDAP", Value = ENamingMethod.Ldap }};

            namingMethodType.DisplayMember = "Name";
            namingMethodType.ValueMember = "Value";
            
            // nastav direct naming
            initDirectNaming();
            // nastav TNS service name naming
            initTnsNaming();
            // nastav LDAP naming
            initLdapNaming();
            // vyber defaultni naming box a nastav mu viditelnost
            (namingBox = directNamingBox).Visible = true;
            namingMethodType.SelectedValue = ENamingMethod.ConnectDescriptor;
            // nastav viditelnost ostatnich panelu naming metod
            tnsNamingBox.Visible = false;
            ldapNamingBox.Visible = false;

            // udalosti: vyber naming metody zobrazuje prislusnou zalozku
            namingMethodType.SelectedValueChanged += new EventHandler(namingMethodChanged);
        }

        void namingMethodChanged(object sender, EventArgs e)
        {
            ENamingMethod selected = (ENamingMethod)namingMethodType.SelectedValue;

            // zneviditelni predchozi naming box
            namingBox.Visible = false;

            // podle vybrane hodnoty zviditelni pozadovany naming box
            switch (selected)
            {
                case ENamingMethod.ConnectDescriptor:
                    namingBox = directNamingBox;
                    break;
                case ENamingMethod.TnsServiceName:
                    namingBox = tnsNamingBox;
                    break;
                case ENamingMethod.Ldap:
                    namingBox = ldapNamingBox;
                    break;
            }

            connOptions.SelectedTab = connOptionsBasic;
            namingBox.Visible = true;
        }

        void initDirectNaming()
        {
            // 1) host
            host.AutoCompleteMode = AutoCompleteMode.Suggest;
            host.AutoCompleteSource = AutoCompleteSource.ListItems;
            host.DropDownStyle = ComboBoxStyle.DropDown;
            // pridani polozek menu pozdeji pri nacitani connect descriptoru a serveru
            // z ostatnich pripojeni

            // TODO: udalosti: vyber daneho serveru?

            // 2) port
            port.Minimum = MIN_TCPPORT;
            port.Maximum = MAX_TCPPORT;
            // TODO: udalosti: zmena TCP portu?

            // 3)service name
            serviceName.AutoCompleteMode = AutoCompleteMode.Suggest;
            serviceName.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList;

            // 4 instance name
            instanceName.AutoCompleteMode = AutoCompleteMode.Suggest;
            instanceName.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList;
            // udalosti: zmena zaskrtnuti serviceNameB?
            serviceNameB.CheckedChanged += new EventHandler(zmenaPojmenovaniDb);

            // 5) SID
            sid.AutoCompleteMode = AutoCompleteMode.Suggest;
            sid.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList;
            // udalosti:
            sidB.CheckedChanged += new EventHandler(zmenaPojmenovaniDb);

            // 6) typ databazoveho service handleru
            serverType.AutoCompleteMode = AutoCompleteMode.Suggest;
            serverType.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList;
            serverType.DropDownStyle = ComboBoxStyle.DropDownList;
            
            // nasyp hodnoty
            serverType.DataSource = new[] {
                new { Name = "dedicated", Value = EDBServerType.Dedicated},
                new { Name = "shared", Value = EDBServerType.Shared},
                new { Name = "pooled", Value = EDBServerType.Pooled}
            };

            serverType.DisplayMember = "Name";
            serverType.ValueMember = "Value";
            // TODO: udalosti: zmena typu service handleru?
        }

        void zmenaPojmenovaniDb(object sender, EventArgs e)
        {
            sid.Enabled = !(serviceName.Enabled = instanceName.Enabled = serviceNameB.Checked);
        }

        void zmenaTypuAutentizace(object sender, EventArgs e)
        {
            connUsername.Enabled =
            connPassword.Enabled = !osAuthenticate.Checked;
        }

        void initTnsNaming()
        {
            tnsName.AutoCompleteMode = AutoCompleteMode.Suggest;
            tnsName.AutoCompleteSource = AutoCompleteSource.ListItems;
            tnsName.DropDownStyle = ComboBoxStyle.DropDown;
            // TODO: naplneni pozdeji
            // TODO: udalosti: vyber tns name -> nacteni do ostatnich ovladacich prvku pro TNS naming

            // tns server
            tnsServer.Enabled = false;
            // tns port
            tnsPort.Enabled = false;
            // tns service name
            tnsServiceName.Enabled = false;
            tnsServiceNameB.Enabled = false;
            // tns instance name
            tnsInstanceName.Enabled = false;
            // tns sid
            tnsSid.Enabled = false;
            tnsSidB.Enabled = false;
            // tns server type
            tnsServerType.Enabled = false;
        }

        /// <summary>
        /// Nastavi ovladaci prvky pro zadavani informaci pro LDAP naming metodu
        /// </summary>
        void initLdapNaming()
        {
            ldapServer.AutoCompleteMode = AutoCompleteMode.Suggest;
            ldapServer.AutoCompleteSource = AutoCompleteSource.ListItems;
            ldapServer.DropDownStyle = ComboBoxStyle.DropDown;
            // TODO: nacist seznam serveru (ldap.ora)?
            // TODO: udalosti: vyber konkretniho LDAP serveru?

            ldapContext.AutoCompleteMode = AutoCompleteMode.Suggest;
            ldapContext.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList;

            ldapServiceName.AutoCompleteMode = AutoCompleteMode.Suggest;
            ldapServiceName.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList;
        }

        /// <summary>
        /// Nastavi pokrocile moznosti connection stringu:
        /// - connection pooling:
        ///     - pooling, min pool size, max pool size,
        ///       incr pool size, decr pool size,
        ///       connection timeout, conection lifetime
        /// - proxy user id, proxy user password
        /// </summary>
        void initAdvancedConnectionStringOptions()
        {
            // nastavi zakladni vlastnosti property grid:
            advancedConnOptions.HelpVisible = true;
            advancedConnOptions.ToolbarVisible = true;
            advancedConnOptions.LargeButtons = false;
            advancedConnOptions.PropertySort = PropertySort.CategorizedAlphabetical;
            // nastav objekt pro zobrazeni
            advancedConnOptions.SelectedObject = connectData;
        }

        /// <summary>
        /// Metoda pro pripravu dialogu na zadani noveho pripojeni
        /// </summary>
        public void NoveSpojeni()
        {
            Show();
            noveSpojeni();
        }

        /// <summary>
        /// Pomocna metoda pro pripravu dialogu na zadani noveho pripojeni
        /// </summary>
        void noveSpojeni()
        {
            // resetuj zakladni udaje
            connName.Clear();
            resetAuthentication();
            resetNamingMethods();
            resetAdvancedConnectionStringOptions();
            // zrus vyber spojeni v connListu
            connList.SelectedItem = null;
            // nastav priznak noveho spojeni
            newConnection = true;
        }

        /// <summary>
        /// Pomocna metoda pro noveSpojeni()
        /// </summary>
        void resetAuthentication()
        {
            connUsername.Clear();
            connPassword.Clear();

            osAuthenticate.Checked = false;
            DBAPrivileges.SelectedValue = EDbaPrivileges.Normal;
        }

        /// <summary>
        /// Pomocna metoda pro noveSpojeni()
        /// </summary>
        void resetNamingMethods()
        {
            resetDirectNaming();
            resetTnsNaming();
            resetLdapNaming();

            namingMethodType.SelectedValue = ENamingMethod.ConnectDescriptor;
        }

        void resetDirectNaming()
        {
            host.SelectedItem = null;
            port.Value = DEFAULT_TCPPORT;

            serviceName.Clear();
            instanceName.Clear();
            sid.Clear();
            serviceNameB.Checked = !(sidB.Checked = false);

            serverType.SelectedValue = EDBServerType.Dedicated;
        }

        void resetTnsNaming()
        {
            tnsName.SelectedItem = null;
        }

        void resetLdapNaming()
        {
            ldapServer.SelectedItem = null;
            ldapContext.Clear();
            ldapServiceName.Clear();
        }

        void resetAdvancedConnectionStringOptions()
        {
            // resetuj connect data objekt
            connectData.resetConnectionStringValues();
            // proved refresh jeho zobrazeni
            advancedConnOptions.Refresh();
        }

        private void credentialsGroupBox_Enter(object sender, EventArgs e)
        {
        
        }
    }
}
