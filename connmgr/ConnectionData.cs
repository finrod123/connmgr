using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace connmgr
{
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

    /// <summary>
    /// Trida reprezentujici pripojeni, umoznuje spojeni
    /// upravovat, mazat, testovat a otevirat, rovnez
    /// poskytuje read-only pristup k datum spojeni
    /// </summary>
    [DefaultProperty("Pooling")]
    public class ConnectionData {
        // nazev spojeni
        [Browsable(false)]
        public string Name { get; set; }
        // uzivatelske jmeno
        [Browsable(false)]
        public string UserName { get; set; }
        // typ autentizace
        [Browsable(false)]
        public EAuthType AuthType { get; set; }
        // zvlastni opravneni pro pripojeni k databazi
        [Browsable(false)]
        public EDbaPrivileges DbaPrivileges { get; set; }
        // typ naming metody
        [Browsable(false)]
        public ENamingMethod NamingMethod { get; set; }

        // datove struktury nesouci identifikaci zdroje
        // 1) ConnectDescriptor
        ConnectDescriptor connectDescriptor;
        [Browsable(false)]
        public ConnectDescriptor ConnectDescriptor
        {
            get { return connectDescriptor; }
        }
        // 2) TNS Service Name
        [Browsable(false)]
        public string TnsServiceName { get; set; }
        // 3) LDAP naming
        LdapDescriptor ldapDescriptor;
        [Browsable(false)]
        public LdapDescriptor LdapDescriptor
        {
            get { return ldapDescriptor; }
        }

        // pokrocile moznosti connection stringu
        [Category("Connection pooling"),
         Description("Zapíná/vypíná connection pooling"),
         DefaultValue(true)]
        public bool Pooling { get; set; }

        [Category("Connection pooling"),
         Description("Minimální velikost connection pool"),
         DefaultValue(1)]
        public int MinPoolSize { get; set; }

        [Category("Connection pooling"),
         Description("Maximální velikost connection pool"),
        DefaultValue(100)]
        public int MaxPoolSize { get; set; }

        [Category("Connection pooling"),
         Description("Pool increment size"),
        DefaultValue(5)]
        public int IncrPoolSize { get; set; }

        [Category("Connection pooling"),
         Description("Pool decrement size"),
        DefaultValue(1)]
        public int DescPoolSize { get; set; }

        [Category("Connection pooling"),
         Description("Connection lifetime (sekundy)"),
        DefaultValue(0)]
        public int ConnectionLifetime { get; set; }

        [Category("Connection pooling"),
         Description("Connection timeout (sekundy)"),
        DefaultValue(15)]
        public int ConnectionTimeout { get; set; }

        [Category("Proxy spojení"),
         Description("Uživatelské jméno proxy uživatele")]
        public string ProxyUserId { get; set; }

        [Category("Proxy spojení"),
         Description("Heslo proxy uživatele"),
         PasswordPropertyText(true)]
        public string ProxyUserPassword { get; set; }
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
        public string Host { get; set; }
        // port
        public int Port { get; set; }
        // kontext
        public string OracleContextDN { get; set; }
        // nazev sluzby
        public string ServiceName { get; set; }
    }
}