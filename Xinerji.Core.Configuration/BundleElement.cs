using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Xinerji.Configuration
{
    public class BundleElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
        public string Key
        {
            get { return (string)base["key"]; }
        }

        [ConfigurationProperty("tr", IsRequired = false)]
        public string Tr
        {
            get { return (string)base["tr"]; }
        }

        [ConfigurationProperty("eng", IsRequired = false)]
        public string Eng
        {
            get { return (string)base["eng"]; }
        }
    }
}
