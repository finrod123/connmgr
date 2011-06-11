using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public class Connection {
        // nazev spojeni
        string name;
        // uzivatelske jmeno
        string userName;
        // typ autentizace
        EAuthType authType;
        // zvlastni opravneni pro pripojeni k databazi
        EDbaPrivileges dbPrivileges;
        // typ naming metody
        ENamingMethod namingMethodType;

        // datove struktury nesouci identifikaci zdroje
        // 1) ConnectDescriptor
        ConnectDescriptor connectDesc;
        // 2) TNS Service Name
        string tnsServiceName;
        // 3) LDAP naming
        LdapDescriptor ldapDesc;

        // kolekce pokrocilych nastaveni Connection Stringu
        StringDictionary connectStringOptions;

        // vlastnosti pro read-only pristup k datum
        public string Name { get { return name; } }
        public string UserName { get { return userName; } }
        public EAuthType AuthType { get { return authType; } }
        public EDbaPrivileges DbPrivileges { get { return dbPrivileges; } }
        public ENamingMethod NamingMethod { get { return namingMethodType; } }
        public ConnectDescriptor ConnectDescriptor { get { return connectDesc; } }
        public string TnsServiceName { get { return tnsServiceName; } }
        public LdapDescriptor LdapDescriptor { get { return ldapDesc; } }

        // Metody spojeni
        /// <summary>
        /// Metoda konstruujici Connection String z dat instance Connection
        /// </summary>
        /// <returns>Valid Oracle Connection String</returns>
        string GetConnectionString() {
            return "";
        }

        
    }

    /// <summary>
    /// Struktura pro uchovavani dat Oracle Connect Descriptoru
    /// </summary>
    public struct ConnectDescriptor
    {
        ConnectDescriptorAddress address;
        // data CONNECT_DATA sekce
        ConnectDescriptorConnectData connectData;
    }

    /// <summary>
    /// Interface pro serializaci spojeni
    /// </summary>
    public interface ConnectionSerializer {
        
    }

    /// <summary>
    /// Struktura nesouci udaje o sekci s adresou listeneru v
    /// Connect Descriptoru (ADDRESS=...)
    /// </summary>
    struct ConnectDescriptorAddress {
        // hostname
        string host;
        // port
        int port;
    }

    /// <summary>
    /// Struktura nesouci udaje o CONNECT_DATA sekci Connect Descriptoru
    /// </summary>
    struct ConnectDescriptorConnectData {
        // service name
        string serviceName;
        // instance name?
        string instanceName;
        // Oracle SID
        string sid;
        // typ service handleru
        EDBServerType dbServerType;
    }

    /// <summary>
    /// Struktura nesouci udaje o LDAP serveru, OracleContext kontextu
    /// a Connect Identifieru
    /// </summary>
    public struct LdapDescriptor {
        // LDAP server
        string ldapHost;
        // port
        int ldapPort;
        // kontext
        string oracleContextDN;
        // nazev sluzby
        string serviceName;
    }
}
