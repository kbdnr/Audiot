using NAudio.Midi;

namespace AudiotLogic.MidiLogic
{
    public static class MidiLogic
    {
        public static void PlayNote(MidiOut midiOut, int channel, int note, int volume = 127)
        {
            midiOut.Send(MidiMessage.StartNote(note, volume, channel).RawData);
        }

        public static void StopNote(MidiOut midiOut, int channel, int note, int volume = 127)
        {
            midiOut.Send(MidiMessage.StopNote(note, volume, channel).RawData);
        }

        public static void PlayChord(MidiOut midiOut, int channel, int volume = 127, params int[] chord)
        {
            midiOut.Send(MidiMessage.StartNote(chord[0], volume, channel).RawData);
            midiOut.Send(MidiMessage.StartNote(chord[1], volume, channel).RawData);
            midiOut.Send(MidiMessage.StartNote(chord[2], volume, channel).RawData);

            if(chord.Length == 4)
                midiOut.Send(MidiMessage.StartNote(chord[3], volume, channel).RawData);
        }

        public static void StopChord(MidiOut midiOut, int channel, int volume = 127, params int[] chord)
        {
            midiOut.Send(MidiMessage.StopNote(chord[0], volume, channel).RawData);
            midiOut.Send(MidiMessage.StopNote(chord[1], volume, channel).RawData);
            midiOut.Send(MidiMessage.StopNote(chord[2], volume, channel).RawData);

            if (chord.Length == 4)
                midiOut.Send(MidiMessage.StopNote(chord[3], volume, channel).RawData);
        }

        //CC Building
    }
}
