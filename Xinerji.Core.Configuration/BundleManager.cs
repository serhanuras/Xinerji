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
        private Xinerji.Dc.Model.Enumurations.LanguageEnum language;
        private AbstractBundle bundleResource;

        public BundleManager(string bundleNode, Xinerji.Dc.Model.Enumurations.LanguageEnum language)
        {
            this.language = language;
            BundleManager.SetConfigurationManager();
            bundleResource = (AbstractBundle)bundle.GetSection(bundleNode);
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
            if (bundleResource != null)
            {
                if (bundleResource.Bundles[Key] != null)
                {
                    if (language == Xinerji.Dc.Model.Enumurations.LanguageEnum.ENG)
                        return bundleResource.Bundles[Key].Eng;
                    else
                        return bundleResource.Bundles[Key].Tr;
                }
                else
                {
                    return "[##" + Key + "##]";
                }
            }
            else
            {
                return "[!!" + Key + "!!]";
            }
        }
    }
}
