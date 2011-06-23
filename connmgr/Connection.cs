using System;

namespace connmgr
{
    public class Connection : IConnection
    {
        // ciselny identifikator zdroje
        int id;
        // cache jmena spojeni
        string name;
        // odkaz na data
        ConnectionData data;
        
        public Connection(int id, ConnectionData data)
        {
            this.id = id;
            // prirad datovy kontejner a prihlas se k odberu jeho udalosti
            this.data = data;
            data.ConnectionInvalidated += connectionDataInvalidatedHandler;
        }

        void connectionDataInvalidatedHandler()
        {
            // uloz pro ucely zpracovani vyjimek
            name = data.Name;
            // nuluj odkaz na data
            data = null;
        }

        public int Id
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);

                return id;
            }
        }

        public string Name
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);

                return data.Name;
            }
        }

        public string UserName
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.UserName;
            }
        }

        public bool OsAuthentication
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);

                return data.OsAuthentication;
            }
        }

        public EDbaPrivileges DbaPrivileges
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.DbaPrivileges;
            }
        }

        public ENamingMethod NamingMethod
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.NamingMethod;
            }
        }

        public string TnsServiceName
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.TnsServiceName;
            }
        }

        public bool Pooling
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.Pooling;
            }
        }

        public int MinPoolSize
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.MinPoolSize;
            }
        }

        public int MaxPoolSize
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.MaxPoolSize;
            }
        }

        public int IncrPoolSize
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.IncrPoolSize;
            }
        }

        public int DecrPoolSize
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.DecrPoolSize;
            }
        }

        public int ConnectionLifetime
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.ConnectionLifetime;
            }
        }

        public int ConnectionTimeout
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.ConnectionTimeout;
            }
        }

        public string ProxyUserId
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.ProxyUserId;
            }
        }

        public string ProxyUserPassword
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.ProxyUserPassword;
            }
        }

        public string Server
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.Server;
            }
        }

        public decimal Port
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.Port;
            }
        }

        public string ServiceName
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.ServiceName;
            }
        }

        public string InstanceName
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.InstanceName;
            }
        }

        public string Sid
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.Sid;
            }
        }

        public bool UsingSid
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.UsingSid;
            }
        }

        public EDBServerType ServerType
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.ServerType;
            }
        }

        public string LdapServer
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.LdapServer;
            }
        }

        public decimal LdapPort
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.LdapPort;
            }
        }

        public string LdapServiceName
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.LdapServiceName;
            }
        }

        public string LdapContext
        {
            get
            {
                if (data == null)
                    throw new ObjectDisposedException(name);
                return data.LdapContext;
            }
        }
    }
}