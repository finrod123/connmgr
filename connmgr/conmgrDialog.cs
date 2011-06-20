using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace connmgr
{
    public partial class ConnectionManagerForm : Form
    {
        const decimal MIN_TCPPORT = 0,
                      MAX_TCPPORT = 65535,
                      DEFAULT_TCPPORT = 1521;

        GroupBox namingBox;
        // datovy kontejner pro ulozeni dat o spojeni
        ConnectionData connectData;
        // priznak zadavani noveho pripojeni
        bool newConnection;

        public ConnectionManagerForm()
        {
            InitializeComponent();
            // vytvor datovy kontejner
            connectData = new ConnectionData()
            {
                Pooling = true,
                MinPoolSize = 1,
                MaxPoolSize = 100,
                IncrPoolSize = 5,
                DescPoolSize = 1,
                ConnectionLifetime = 0,
                ConnectionTimeout = 15
            };
            // proved uvodni nastaveni
            initAuthentication();
            initNamingMethods();
            initAdvancedConnectionStringOptions();
            // nastav dalsi udalosti
            setToolBarHandlers();
            setHandlers();
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
            // ukladam nove spojeni -> volej ConnectionManager
            if (newConnection)
            {

            }
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
            resetConnectionData();
            // proved refresh jeho zobrazeni
            advancedConnOptions.Refresh();
        }

        void resetConnectionData()
        {
            // nastav pokrocile moznosti connect stringu
            connectData.Pooling = true;
            connectData.MinPoolSize = 1;
            connectData.MaxPoolSize = 100;
            connectData.IncrPoolSize = 5;
            connectData.DescPoolSize = 1;
            connectData.ConnectionLifetime = 0;
            connectData.ConnectionTimeout = 15;
        }

        
    }
}
