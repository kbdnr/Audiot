using AudiotLogic.MidiLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AudiotTests
{
    [TestClass]
    public class ControlChangeTests 
    {
        [TestMethod]
        public void XMLRead()
        {
            try
            {
                XDocument xd1 = new XDocument();
                xd1 = XDocument.Load(@"C:\Users\sped\source\repos\audiot\AudiotLogic\ControlConfigs\sh01a.xml");
            }
            catch (XmlException exception)
            {
                Assert.Fail(exception.Message);
            }
        }

        [TestMethod]
        public void XMLDeserialize()
        {
            ControlChanges cc = null;
            string path = @"C:\Users\sped\source\repos\audiot\AudiotLogic\ControlConfigs\sh01a.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(ControlChanges));

            StreamReader reader = new StreamReader(path);
            cc = (ControlChanges)serializer.Deserialize(reader);
            reader.Close();
        }

        [TestMethod]
        public void GetConfigs()
        {
            var configs = ControlChangeLogic.GetSynthConfigs();
            Assert.IsNotNull(configs);
        }
    }
}
