using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xinerji.Configuration.Settings;

namespace Xinerji.Configuration
{
    public static class ConfigurationManager
    {

        private static System.Configuration.Configuration config;

        private static void SetConfigurationManager()
        {

            if (ConfigurationManager.config == null)
            {
                System.Configuration.ExeConfigurationFileMap configMap = new System.Configuration.ExeConfigurationFileMap();

                configMap.ExeConfigFilename = @"c:\config\xinerji.config";

                ConfigurationManager.config =
                    System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configMap,
                    ConfigurationUserLevel.None);
            }
        }

        public static DatabaseSetting GetDatabaseSetting()
        {
            SetConfigurationManager();

            return (DatabaseSetting)config.GetSection("databaseSetting");
        }

        public static MailServerSetting GetMailServerSetting()
        {
            SetConfigurationManager();

            return (MailServerSetting)config.GetSection("mailServerSetting");
        }

        public static SmsServerSetting GetSmsServerSetting()
        {
            SetConfigurationManager();

            return (SmsServerSetting)config.GetSection("smsServerSetting");
        }

        public static NameValueCollection GetServiceElement(string serviceName)
        {
            SetConfigurationManager();

            ConfigurationSection myParamsSection = config.GetSection(serviceName);

            string myParamsSectionRawXml = myParamsSection.SectionInformation.GetRawXml();
            XmlDocument sectionXmlDoc = new XmlDocument();
            sectionXmlDoc.Load(new StringReader(myParamsSectionRawXml));
            NameValueSectionHandler handler = new NameValueSectionHandler();

            NameValueCollection handlerCreatedCollection =
                        handler.Create(null, null, sectionXmlDoc.DocumentElement) as NameValueCollection;

            return handlerCreatedCollection;
        }

    }
}
