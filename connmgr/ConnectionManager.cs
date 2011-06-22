using System;
using System.Collections.Generic;

namespace connmgr
{
    public enum EConnectionOperationSource
    {
        ConnectionManagerDialog,
        Other
    }

    public class ConnectionAddedEventArgs : EventArgs
    {
        public Connection Connection { get; set; }
        public EConnectionOperationSource Source { get; set; }
    }

    public delegate void ConnectionAddedDelegate(ConnectionAddedEventArgs e);

    public class ConnectionManager
    {
        // slovniky pro uchovavani spojeni podle cisla i jmena
        Dictionary<int, ConnectionData> connections = new Dictionary<int, ConnectionData>();
        Dictionary<string, ConnectionData> connectionNames = new Dictionary<string, ConnectionData>();

        // pomocna promenna pro pocitani ID pro spojeni
        int maxId = -1;

        // udalost pro ohlaseni noveho spojeni
        public event ConnectionAddedDelegate ConnectionAdded;

        /// <summary>
        /// V konstruktoru se nactou pripojeni z uloziste aplikace (XML uloziste?)
        /// </summary>
        public ConnectionManager()
        {

        }

        public EConnectionSaveCode AddConnection(ConnectionData data)
        {
            EConnectionSaveCode saveCode;
            string connName = data.Name;

            // jmeno spojeni musi byt unikatni
            if (connectionNames.ContainsKey(connName))
            {
                return EConnectionSaveCode.DuplicateConnectionName;
            }

            // spojeni musi byt validni
            if ((saveCode = data.ValidateConnectionData()) != EConnectionSaveCode.Ok)
                return saveCode;

            // ziskej nove id
            int nextId = getNextConnectionId();
            //klonuj
            ConnectionData clone = data.Clone() as ConnectionData;
            // pridej do slovniku
            connections.Add(nextId, clone);
            connectionNames.Add(connName, clone);
            // vytvor handle a ohlas jej
            Connection handle = new Connection(nextId, clone);
            ConnectionAdded(new ConnectionAddedEventArgs()
            {
                Connection = handle,
                Source = EConnectionOperationSource.ConnectionManagerDialog
            });

            return EConnectionSaveCode.Ok;
        }

        int getNextConnectionId()
        {
            for (int i = 0; i < maxId; ++i)
            {
                if (!connections.ContainsKey(i))
                    return i;
            }

            return ++maxId;
        }
    }
}