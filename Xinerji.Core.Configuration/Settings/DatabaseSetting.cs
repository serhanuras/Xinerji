using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Utilities;

namespace Xinerji.Configuration.Settings
{
    public class DatabaseSetting : ConfigurationSection
    {
        [ConfigurationProperty("server", IsRequired = true, IsKey = true)]
        public string Server
        {
            get { return (string)base["server"]; }
        }

        [ConfigurationProperty("catalog", IsRequired = true, IsKey = true)]
        public string Catalog
        {
            get { return (string)base["catalog"]; }
        }

        [ConfigurationProperty("userId", IsRequired = true, IsKey = true)]
        public string UserId
        {
            get { return (string)base["userId"]; }
        }

        [ConfigurationProperty("password", IsRequired = true, IsKey = true)]
        public string Password
        {
            get { return (string)base["password"]; }
        }

        private static string decryptedPassword = "";
        public string GetDecryptedPassword()
        {

            if (decryptedPassword == "")
            {
                decryptedPassword = CryptoUtil.Rfc289Decrypt(Password);
            }

            return decryptedPassword;
        }
    }
}
