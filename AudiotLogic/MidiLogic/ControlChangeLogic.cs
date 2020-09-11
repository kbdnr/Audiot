using NAudio.Midi;
using System;
using System.IO;
using System.Xml.Serialization;

namespace AudiotLogic.MidiLogic
{
    [Serializable()]
    public class ControlChange 
    {
        [XmlElement("CC")]
        public int CC { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Range")]
        public string Range { get; set; }
    }


    [Serializable()]
    [XmlRoot("ControlChangeCollection")]
    public class ControlChanges
    {
        [XmlArray("ControlChanges")]
        [XmlArrayItem("ControlChange", typeof(ControlChange))]
        public ControlChange[] ControlChange { get; set; }
    }

    public static class ControlChangeLogic
    {
        public static ControlChanges XMLDeserialize(string xmlConfig)
        {
            ControlChanges cc = null;
            string path = xmlConfig;

            XmlSerializer serializer = new XmlSerializer(typeof(ControlChanges));

            StreamReader reader = new StreamReader(path);
            cc = (ControlChanges)serializer.Deserialize(reader);
            reader.Close();

            return cc;
        }

        public static string[] GetSynthConfigs()
        {
            string[] files = Directory.GetFiles(@"..", "*.xml", SearchOption.AllDirectories);

            return files;
        }

        public static void SendControlChange(MidiOut midiOut, ControlChange cc, int value, int channel)
        {
            if(cc != null)
                midiOut.Send(MidiMessage.ChangeControl(cc.CC, value, channel).RawData);
        }
    }
}
