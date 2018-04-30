using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Configuration
{
    public class BundleManager
    {
        private LanguageEnum language;
        private AbstractBundle receiptBundle;

        public BundleManager(string bundleNode, LanguageEnum language)
        {
            this.language = language;
            BundleManager.SetConfigurationManager();
            receiptBundle = (AbstractBundle)bundle.GetSection(bundleNode);
        }

        private static System.Configuration.Configuration bundle;

        private static void SetConfigurationManager()
        {

            if (BundleManager.bundle == null)
            {
                System.Configuration.ExeConfigurationFileMap configMap = new System.Configuration.ExeConfigurationFileMap();

                configMap.ExeConfigFilename = @"c:\config\xinerji.bundle";

                BundleManager.bundle =
                    System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configMap,
                    ConfigurationUserLevel.None);
            }
        }

        public string GetValue(string Key)
        {
            if (receiptBundle.Bundles[Key] != null)
            {
                if (language == LanguageEnum.ENG)
                    return receiptBundle.Bundles[Key].Eng;
                else
                    return receiptBundle.Bundles[Key].Tr;
            }
            else
            {
                return "";
            }
        }
    }
}
