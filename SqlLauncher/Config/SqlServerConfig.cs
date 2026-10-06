using System;

namespace SqlLauncher.Config
{
    public class SqlServerConfig
    {
        public string Server { get; private set; }
        public bool IntegratedSecurity { get; private set; }
        public string UserId { get; private set; }
        public string Password { get; private set; }
        public bool TrustServerCertificate { get; private set; }

        private SqlServerConfig() { }

        // Crea la configuracion directamente desde los valores del formulario
        public static SqlServerConfig FromValues(string server, bool integratedSecurity, string userId, string password, bool trustServerCertificate = true)
        {
            if (string.IsNullOrWhiteSpace(server))
                throw new ArgumentException("El servidor no puede estar vacio.", "server");

            if (!integratedSecurity && string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("El usuario es obligatorio para SQL Login.", "userId");

            if (!integratedSecurity && string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contrasena es obligatoria para SQL Login.", "password");

            return new SqlServerConfig
            {
                Server = server,
                IntegratedSecurity = integratedSecurity,
                UserId = userId,
                Password = password,
                TrustServerCertificate = trustServerCertificate
            };
        }
        // Convencion de variable: SqlServer.Password -> SQLSERVER_PASSWORD
        public static SqlServerConfig FromConfiguration()
        {
            return new SqlServerConfig
            {
                Server = GetValue("SqlServer.Server"),
                IntegratedSecurity = bool.Parse(GetValue("SqlServer.IntegratedSecurity", "false")),
                UserId = GetValue("SqlServer.UserId", null, true),
                Password = GetValue("SqlServer.Password", null, true),
                TrustServerCertificate = bool.Parse(GetValue("SqlServer.TrustServerCertificate", "true"))
            };
        }

        private static string GetValue(string key, string defaultValue = null, bool optional = false)
        {
            string envKey = key.Replace(".", "_").ToUpperInvariant();
            string envVal = Environment.GetEnvironmentVariable(envKey);
            if (!string.IsNullOrEmpty(envVal))
                return envVal;

            string cfgVal = System.Configuration.ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrEmpty(cfgVal))
                return cfgVal;

            if (defaultValue != null)
                return defaultValue;

            if (optional)
                return null;

            throw new InvalidOperationException("Configuracion requerida no encontrada: '" + key + "'");
        }
    }
}