using Orient.Client;

namespace OrientTest
{
    public static class OrientConnection
    {
        private static string _hostname = "localhost";
        //private static string _hostname = "addiscandb2.cloudapp.net";
        private static int _port = 2424;
        private static string _username = "admin";
        private static string _password = "admin";

        private static string _rootUserName = "root";
        private static string _rootUserParssword = "yon123;";
        //private static string _rootUserParssword = "ADAACDAECB69D331BB3F5673C2CE562D5BB565A9547854DD305BBD115A66561E";
        private static OServer _server;
        public static int GlobalDatabasePoolSize { get { return 3; } }
        public static string GlobalDatabaseName { get; private set; }
        public static ODatabaseType GlobalDatabaseType { get; private set; }
        public static string GlobalDatabaseAlias { get; private set; }

        static OrientConnection()
        {
            _server = new OServer(_hostname, _port, _rootUserName, _rootUserParssword);

            //GlobalTestDatabaseName = "globalTestDatabaseForNetDriver001";
            GlobalDatabaseName = "TestModelDB";
            GlobalDatabaseType = ODatabaseType.Graph;
            GlobalDatabaseAlias = "globalTestModelDB";
        }

        public static void CreateDatabase()
        {
            // DropTestDatabase();

            _server.CreateDatabase(GlobalDatabaseName, GlobalDatabaseType, OStorageType.PLocal);
        }

        public static void DropDatabase()
        {
            if (_server.DatabaseExist(GlobalDatabaseName, OStorageType.PLocal))
            {
                _server.DropDatabase(GlobalDatabaseName, OStorageType.PLocal);
            }
        }

        public static void CreatePool()
        {
            OClient.CreateDatabasePool(
                _hostname,
                _port,
                GlobalDatabaseName,
                GlobalDatabaseType,
                _username,
                _password,
                GlobalDatabasePoolSize,
                GlobalDatabaseAlias
            );
        }

        public static void DropPool()
        {
            OClient.DropDatabasePool(GlobalDatabaseAlias);
        }

        public static OServer GetServer()
        {
            return _server;
        }

    }

}
