using System;
using System.Xml;

namespace cacheCopy
{
    /// <summary>
    /// Object to deal with updates: checking for a new versions available, 
    /// downloading installation files, installing new versions.
    /// </summary>
    class Updater
    {
        public bool NewVersionAvailable = false;
        public Version newVersion;
        public string newVersionUrl;

        public void CheckNewVersion()
        {
            // new version software url
            XmlTextReader reader = null;
            try
            {
                //TODO get the xml file uploaded
                string xmlURL = "http://trailmax.info/cachecopy/updater.xml";
                reader = new XmlTextReader(xmlURL);

                // simply (and easily) skip the junk at the beginning  
                reader.MoveToContent();
                
                // internal - as the XmlTextReader moves only forward, we save current xml element name  
                // in elementName variable. When we parse a text node, we refer to elementName to check  
                // what was the node name  
                string elementName = "";

                // we check if the xml starts with a proper "cachecopy" element node  
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "cachecopy"))
                {
                    while (reader.Read())
                    {
                        // when we find an element node, we remember its name  
                        if (reader.NodeType == XmlNodeType.Element)
                            elementName = reader.Name;
                        else
                        {
                            // for text nodes...  
                            if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                            {
                                // we check what the name of the node was  
                                switch (elementName)
                                {
                                    case "version":
                                        // that is why we keep the version info in xxx.xxx.xxx.xxx format  
                                        // the Version class does the parsing for us  
                                        newVersion = new Version(reader.Value);
                                        break;
                                    case "url":
                                        newVersionUrl = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                NewVersionAvailable = false;
                newVersionUrl = "";
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }     

}
}
