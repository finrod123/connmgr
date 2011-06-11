using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace connmgr
{
    public partial class ConnectionManager : Form
    {
        const decimal MIN_TCPPORT = 0,
                      MAX_TCPPORT = 65535;

        GroupBox namingBox;
        ENamingMethod currentNamingMethod;

        public ConnectionManager()
        {
            InitializeComponent();
            // proved uvodni nastaveni
            initAuthentication();
            initNamingMethods();

            // nacti informace o pripojenich ze zdroju aplikace (XML soubor?)

            // priprav okno na zadani noveho spojeni => volej NoveSpojeni

        }

        /// <summary>
        /// Nastavi pri instanciaci okna pole pro zadavani informaci souvisejicich
        /// s autentizaci
        /// </summary>
        void initAuthentication()
        {
            // nastav chovani tlacitka pro volbu typu autentizace
            osAuthenticate.CheckedChanged += new EventHandler(zmenaTypuAutentizace);

            DBAPrivileges.DisplayMember = "Name";
            DBAPrivileges.ValueMember = "Value";
            DBAPrivileges.AutoCompleteMode = AutoCompleteMode.Suggest;
            DBAPrivileges.DropDownStyle = ComboBoxStyle.DropDownList;
            // vloz hodnoty pro vyber zvlastnich privilegii pro prihlaseni k databazi
            DBAPrivileges.Items.AddRange(new object[3] {
                new { Name = "normální", Value = EDbaPrivileges.Normal },
                new { Name = "SYSDBA", Value = EDbaPrivileges.SysDba },
                new { Name = "SYSOPER", Value = EDbaPrivileges.SysOper }
            });
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
            namingMethodType.DisplayMember = "Name";
            namingMethodType.ValueMember = "Value";
            // vloz hodnoty do seznamu s vyberem typu naming method
            namingMethodType.Items.AddRange(new object[3] {
                new { Name = "connect descriptor", Value = ENamingMethod.ConnectDescriptor },
                new { Name = "TNS název", Value = ENamingMethod.TnsServiceName },
                new { Name = "LDAP", Value = ENamingMethod.Ldap }});
            // udalosti: vyber naming metody zobrazuje prislusnou zalozku
            namingMethodType.SelectedValueChanged += new EventHandler(namingMethodChanged);
            // nastav direct naming
            initDirectNaming();
            // nastav TNS service name naming
            initTnsNaming();
            // nastav LDAP naming
            initLdapNaming();
        }

        void namingMethodChanged(object sender, EventArgs e)
        {
            ENamingMethod selected = (ENamingMethod)namingMethodType.SelectedValue;

            if (selected == currentNamingMethod)
            {
                return;
            }

            currentNamingMethod = selected;

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
            serverType.DisplayMember = "Name";
            serverType.ValueMember = "Value";
            // nasyp hodnoty
            serverType.Items.AddRange(new object[3] {
                new { Name = "dedicated", Value = EDBServerType.Dedicated},
                new { Name = "shared", Value = EDBServerType.Shared},
                new { Name = "pooled", Value = EDBServerType.Pooled}
            });
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
        /// Nastavi pokrocile moznosti connection stringu
        /// </summary>
        void initAdvancedConnectionStringOptions()
        {
            
        }

        public void NoveSpojeni()
        {

        }
    }
}
