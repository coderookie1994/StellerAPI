using System.Collections.Generic;

namespace StellerAPI.StellerCore
{
    public class DbConnectionSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }

        public Collections Collections { get; set; }
    }

    public class Collections
    {
        public string Environments { get; set; }
    }
}