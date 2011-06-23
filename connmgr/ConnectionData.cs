using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace connmgr
{
    public interface IConnection
    {
        // basic properties
        string Name { get; }
        string UserName { get; }
        bool OsAuthentication { get; }
        EDbaPrivileges DbaPrivileges { get; }
        ENamingMethod NamingMethod { get; }
        
        // advanced connection string properties
        bool Pooling { get; }
        int MinPoolSize { get; }
        int MaxPoolSize { get; }
        int IncrPoolSize { get; }
        int DecrPoolSize { get; }
        int ConnectionLifetime { get; }
        int ConnectionTimeout { get; }
        string ProxyUserId { get; }
        string ProxyUserPassword { get; }

        // direct naming properties
        string Server { get; }
        decimal Port { get; }
        string ServiceName { get; }
        string InstanceName { get; }
        string Sid { get; }
        bool UsingSid { get; }
        EDBServerType ServerType { get; }

        // tns naming properties
        string TnsServiceName { get; }
        
        // LDAP naming properties
        string LdapServer { get; }
        decimal LdapPort { get; }
        string LdapServiceName { get; }
        string LdapContext { get; }
    }

    /// <summary>
    /// Vyctovy typ reprezentujici typ autentizace pri navazovani spojeni
    /// </summary>
    public enum EAuthType{
        Database,
        Os
    }

    /// <summary>
    /// Vyctovy typ reprezentujici typ pouzite Naming metody pro
    /// nalezeni Connect Descriptoru k zadanemu Connect Identifieru
    /// </summary>
    public enum ENamingMethod {
        ConnectDescriptor,
        TnsServiceName,
        Ldap
    }

    /// <summary>
    /// Typ spojeni se serverem
    /// </summary>
    public enum EDBServerType {
        Dedicated,
        Shared,
        Pooled
    }

    public enum EDbaPrivileges {
        Normal,
        SysOper,
        SysDba
    }

    public delegate void ConnectionInvalidatedDelegate();
    /// <summary>
    /// Trida reprezentujici pripojeni, umoznuje spojeni
    /// upravovat, mazat, testovat a otevirat, rovnez
    /// poskytuje read-only pristup k datum spojeni
    /// </summary>
    [DefaultProperty("Pooling")]
    public class ConnectionData : IConnection, ICloneable
    {
        // udalost ohlasujici invalidaci dat spojeni
        public event ConnectionInvalidatedDelegate ConnectionInvalidated;
        
        public ConnectionData()
        {
            connectDescriptor = new ConnectDescriptor();
            ldapDescriptor = new LdapDescriptor();
            //resetConnectionStringValues();
        }

        public void resetConnectionStringValues()
        {
            pooling = true;
            minPoolSize = 1;
            maxPoolSize = 100;
            incrPoolSize = 5;
            decrPoolSize = 1;
            connectionLifetime = 0;
            connectionTimeout = 15;

            ProxyUserId = string.Empty;
            ProxyUserPassword = string.Empty;
        }

        // nazev spojeni
        [Browsable(false)]
        public string Name { get; set; }
        // uzivatelske jmeno
        [Browsable(false)]
        public string UserName { get; set; }
        // typ autentizace
        [Browsable(false)]
        public bool OsAuthentication { get; set; }
        // zvlastni opravneni pro pripojeni k databazi
        [Browsable(false)]
        public EDbaPrivileges DbaPrivileges { get; set; }
        // typ naming metody
        [Browsable(false)]
        public ENamingMethod NamingMethod { get; set; }

        // datove struktury nesouci identifikaci zdroje
        // 1) ConnectDescriptor
        ConnectDescriptor connectDescriptor;
        // 2) TNS Service Name
        [Browsable(false)]
        public string TnsServiceName { get; set; }
        // 3) LDAP naming
        LdapDescriptor ldapDescriptor;

        // pokrocile moznosti connection stringu
        bool pooling = true;
        [Category("Connection pooling"),
         Description("Zapíná/vypíná connection pooling"),
         DefaultValue(true)]
        public bool Pooling { get { return pooling; } set { pooling = value; } }

        int minPoolSize = 1;
        [Category("Connection pooling"),
         Description("Minimální velikost connection pool"),
         DefaultValue(1)]
        public int MinPoolSize
        {
            get { return minPoolSize; }
            set
            {
                if (0 < value &&
                    value <= maxPoolSize)
                    minPoolSize = value;
            }
        }

        int maxPoolSize = 100;
        [Category("Connection pooling"),
         Description("Maximální velikost connection pool"),
        DefaultValue(100)]
        public int MaxPoolSize {
            get { return maxPoolSize; }
            set
            {
                if (minPoolSize <= value)
                    maxPoolSize = value;
            }
        }

        int incrPoolSize = 5;
        [Category("Connection pooling"),
         Description("Pool increment size"),
        DefaultValue(5)]
        public int IncrPoolSize {
            get { return incrPoolSize; }
            set
            {
                if (value > 0 &&
                   value <= (maxPoolSize - minPoolSize))
                    incrPoolSize = value;
            }
        }

        int decrPoolSize = 1;
        [Category("Connection pooling"),
         Description("Pool decrement size"),
        DefaultValue(1)]
        public int DecrPoolSize {
            get { return decrPoolSize; }
            set
            {
                if (value > 0 &&
                   value <= (maxPoolSize - minPoolSize))
                    decrPoolSize = value;
            }
        }

        int connectionLifetime = 0;
        [Category("Connection pooling"),
         Description("Connection lifetime (sekundy)"),
        DefaultValue(0)]
        public int ConnectionLifetime {
            get { return connectionLifetime; }
            set
            {
                if (value >= 0)
                    connectionLifetime = value;
            }
        }

        int connectionTimeout = 15;
        [Category("Connection pooling"),
         Description("Connection timeout (sekundy)"),
        DefaultValue(15)]
        public int ConnectionTimeout {
            get { return connectionTimeout; }
            set
            {
                if (value >= 0)
                    connectionTimeout = value;
            }
        }

        [Category("Proxy spojení"),
         Description("Uživatelské jméno proxy uživatele")]
        public string ProxyUserId { get; set; }

        [Category("Proxy spojení"),
         Description("Heslo proxy uživatele"),
         PasswordPropertyText(true)]
        public string ProxyUserPassword { get; set; }

        public string Server
        {
            get { return connectDescriptor.Host; }
            set { connectDescriptor.Host = value;}
        }

        public decimal Port
        {
            get { return connectDescriptor.Port; }
            set{ connectDescriptor.Port = (int)value; }
        }

        public string ServiceName
        {
            get { return connectDescriptor.ServiceName; }
            set { connectDescriptor.ServiceName = value; }
        }

        public string InstanceName
        {
            get { return connectDescriptor.InstanceName; }
            set { connectDescriptor.InstanceName = value; }
        }

        public string Sid
        {
            get { return connectDescriptor.Sid; }
            set { connectDescriptor.Sid = value;}
        }

        public EDBServerType ServerType
        {
            get { return connectDescriptor.ServerType; }
            set { connectDescriptor.ServerType = value;}
        }

        public string LdapServer
        {
            get { return ldapDescriptor.Server; }
            set { ldapDescriptor.Server = value;}
        }

        public decimal LdapPort
        {
            get { return ldapDescriptor.Port; }
            set { ldapDescriptor.Port = (int)value;}
        }

        public string LdapServiceName
        {
            get { return ldapDescriptor.ServiceName; }
            set { ldapDescriptor.ServiceName = value;}
        }

        public string LdapContext
        {
            get { return ldapDescriptor.LdapContext; }
            set { ldapDescriptor.LdapContext = value;}
        }

        bool usingSid;
        public bool UsingSid
        {
            get { return usingSid; }
            set { usingSid = value; }
        }

        public object Clone()
        {
            ConnectionData clone = new ConnectionData();

            clone.Name = Name;
            clone.UserName = UserName;
            clone.OsAuthentication = OsAuthentication;
            clone.NamingMethod = NamingMethod;

            switch (NamingMethod)
            {
                case ENamingMethod.ConnectDescriptor:
                    
                    clone.Server = Server;
                    clone.Port = Port;
                    
                    if (clone.UsingSid = UsingSid)
                    {
                        clone.Sid = Sid;
                    } else
                    {
                        clone.ServiceName = ServiceName;
                        clone.InstanceName = InstanceName;
                    }

                    clone.ServerType = ServerType;
                    break;
                case ENamingMethod.TnsServiceName:

                    clone.TnsServiceName = TnsServiceName;
                    break;

                case ENamingMethod.Ldap:

                    clone.LdapServiceName = LdapServiceName;
                    clone.LdapServer = LdapServer;
                    clone.LdapPort = LdapPort;
                    clone.LdapContext = LdapContext;
                    break;
            }

            // advanced connection string options
            clone.Pooling = Pooling;
            clone.MinPoolSize = MinPoolSize;
            clone.MaxPoolSize = MaxPoolSize;
            clone.IncrPoolSize = IncrPoolSize;
            clone.DecrPoolSize = DecrPoolSize;
            clone.ConnectionLifetime = ConnectionLifetime;
            clone.ConnectionTimeout = ConnectionTimeout;
            clone.ProxyUserId = ProxyUserId;
            clone.ProxyUserPassword = ProxyUserPassword;

            return clone;
        }

        /// <summary>
        ///  Metoda pro kontrolu validity dat spojeni:
        ///  - co kontrolovat?: navrhy:
        ///     - spravny format dat? (to jde i ve formulari)
        ///     - existenci serveru? (listener, LDAP atd.)
        ///     - moznost provadet autentizaci pomoci OS (to lze uz driv)
        /// </summary>
        /// <returns>Status spojeni</returns>
        public EConnectionSaveCode ValidateConnectionData()
        {
            return EConnectionSaveCode.Ok;
        }
    }

    /// <summary>
    /// Struktura pro uchovavani dat Oracle Connect Descriptoru
    /// </summary>
    public class ConnectDescriptor
    {
        // hostname
        public string Host { get; set; }
        // port
        public int Port { get; set; }
        // service name
        public string ServiceName { get; set; }
        // instance name?
        public string InstanceName { get; set; }
        // Oracle SID
        public string Sid { get; set; }
        // typ service handleru
        public EDBServerType ServerType { get; set; }
    }

    /// <summary>
    /// Struktura nesouci udaje o LDAP serveru, OracleContext kontextu
    /// a Connect Identifieru
    /// </summary>
    public class LdapDescriptor {
        // LDAP server
        public string Server { get; set; }
        // port
        public int Port { get; set; }
        // kontext
        public string LdapContext { get; set; }
        // nazev sluzby
        public string ServiceName { get; set; }
    }
}