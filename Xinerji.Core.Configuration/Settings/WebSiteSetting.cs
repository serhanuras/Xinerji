using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Configuration.Settings
{
    public class WebSiteSetting : ConfigurationSection
    {
        [ConfigurationProperty("publicWebsiteUrl", IsRequired = true, IsKey = true)]
        public string PublicWebSiteUrl
        {
            get { return (string)base["publicWebsiteUrl"]; }
        }

        [ConfigurationProperty("internetWebsiteUrl", IsRequired = true, IsKey = true)]
        public string InternetWebSite
        {
            get { return (string)base["internetWebsiteUrl"]; }
        }
    }
}
