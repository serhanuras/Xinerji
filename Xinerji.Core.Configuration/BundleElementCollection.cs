using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Xinerji.Configuration
{
    [ConfigurationCollection(typeof(BundleElement))]
    public class BundleElementCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "bundle";

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        protected override string ElementName
        {
            get
            {
                return PropertyName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName,
              StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool IsReadOnly()
        {
            return false;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new BundleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((BundleElement)(element)).Key;
        }

        public BundleElement this[string idx]
        {
            get { return (BundleElement)BaseGet(idx); }
        }
    }
}
