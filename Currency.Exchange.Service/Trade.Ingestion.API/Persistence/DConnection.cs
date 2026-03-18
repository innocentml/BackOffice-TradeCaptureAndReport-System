using Microsoft.Extensions.Options;
using Trade.Ingestion.API.Models;

namespace Trade.Ingestion.API.Persistence
{
    public class DConnection : IDConnection
    {
        /// <summary>
        /// Holds the collection of configured database instances retrieved from application settings.
        /// </summary>
        private readonly List<DatabaseInstance> DatabaseInstances;

        /// <summary>
        /// Initialises a new instance of the <see cref="DConnection"/> class.
        /// </summary>
        /// <param name="options">The strongly-typed configuration options containing database connection details.</param>
        public DConnection(IOptions<DatabaseOptions> options)
        {
            // Value is retrieved from the IOptions wrapper during dependency injection
            DatabaseInstances = options.Value.DatabaseInstances;
        }

        /// <inheritdoc />
        public string GetConnectionStringAsync(string databaseName)
        {
            return DatabaseInstances.FirstOrDefault(x => x.DatabaseName == databaseName)?.ConnectionString!;
        }
    }
}
