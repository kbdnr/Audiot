using NAudio.Midi;
using NAudio.Wave;
using System.Collections.Generic;
using System.Linq;

namespace AudiotLogic.Devices
{
    public static class DeviceLogic
    {
        public static List<string> AvailableMidiInDevices()
        {
            var devInfo = new List<string>();

            for (int device = 0; device < MidiIn.NumberOfDevices; device++)
            {
                devInfo.Add(MidiIn.DeviceInfo(device).ProductName);
            }

            return devInfo;
        }

        public static List<string> AvailableMidiOutDevices()
        {
            var devInfo = new List<string>();

            for (int device = 0; device < MidiOut.NumberOfDevices; device++)
            {
                devInfo.Add(MidiOut.DeviceInfo(device).ProductName);
            }

            return devInfo;
        }

        public static List<string> AvailableAudioDevices()
        {
            return AsioOut.GetDriverNames().ToList();
        }

        public static MidiOut InitMidiOut(int dev)
        {
            return new MidiOut(dev);
        }

        public static MidiIn InitMidiIn(int dev)
        {
            return new MidiIn(dev);
        }
    }
}
