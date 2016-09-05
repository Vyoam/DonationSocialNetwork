using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSN.DAL
{
    public static class Constants
    {
        public static class SPROC
        {
            public const string GetUsersNetwork = "GetUsersNetwork";

            public const string GetNetwork = "GetNetwork";
        }

        public static class ConnectionStrings
        {
            public const string DSNDb = "DSNDb";

            public static string StringNotFound = "Connection string not found.";
        }

        public static class Individual
        {
            public const string Id = "Id";

            public const string Name = "Name";

            public const string Title = "Title";

            public const string Organization = "Organization";
        }

        public static class Organization
        {
            public const string Id = "Id";

            public const string Name = "Name";

            public const string Description = "Description";
        }

    }
}
