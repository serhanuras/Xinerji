using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Configuration
{
    public class AbstractBundle : ConfigurationSection
    {
        [ConfigurationProperty("bundles")]
        public BundleElementCollection Bundles
        {
            get { return ((BundleElementCollection)(base["bundles"])); }
            set { base["bundles"] = value; }
        }
    }
}
