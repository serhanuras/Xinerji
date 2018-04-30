using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Utilities;

namespace Xinerji.Configuration.Settings
{
    public class SmsServerSetting : ConfigurationSection
    {
        [ConfigurationProperty("host", IsRequired = true, IsKey = true)]
        public string Host
        {
            get { return (string)base["host"]; }
        }

        [ConfigurationProperty("userName", IsRequired = true, IsKey = true)]
        public string UserName
        {
            get { return (string)base["userName"]; }
        }

        public static string password = "";

        [ConfigurationProperty("password", IsRequired = true, IsKey = true)]
        public string Password
        {
            get
            {
                if (SmsServerSetting.password == "")
                {
                    SmsServerSetting.password = CryptoUtil.DESDecrypt((string)base["password"]);
                }

                return SmsServerSetting.password;
            }
        }

        [ConfigurationProperty("header", IsRequired = true, IsKey = true)]
        public string Header
        {
            get { return (string)base["header"]; }
        }

        [ConfigurationProperty("validity", IsRequired = true, IsKey = true)]
        public string Validity
        {
            get { return (string)base["validity"]; }
        }

        [ConfigurationProperty("timeout", IsRequired = true, IsKey = true)]
        public int Timeout
        {
            get { return (int)base["timeout"]; }
        }
    }
}
