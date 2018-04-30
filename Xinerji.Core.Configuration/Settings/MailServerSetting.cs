using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Utilities;

namespace Xinerji.Configuration.Settings
{
    public class MailServerSetting : ConfigurationSection
    {
        [ConfigurationProperty("host", IsRequired = true, IsKey = true)]
        public string Host
        {
            get { return (string)base["host"]; }
        }

        [ConfigurationProperty("port", IsRequired = true, IsKey = true)]
        public string Port
        {
            get { return (string)base["port"]; }
        }

        [ConfigurationProperty("sender", IsRequired = true, IsKey = true)]
        public string Sender
        {
            get { return (string)base["sender"]; }
        }

        [ConfigurationProperty("senderName", IsRequired = true, IsKey = true)]
        public string SenderName
        {
            get { return (string)base["senderName"]; }
        }

        public static string password = "";

        [ConfigurationProperty("password", IsRequired = true, IsKey = true)]
        public string Password
        {
            get
            {
                if (MailServerSetting.password == "")
                {
                    MailServerSetting.password = CryptoUtil.DESDecrypt((string)base["password"]);
                }

                return MailServerSetting.password;
            }
        }

        [ConfigurationProperty("replyTo", IsRequired = true, IsKey = true)]
        public string ReplyTo
        {
            get { return (string)base["replyTo"]; }
        }
    }
}
