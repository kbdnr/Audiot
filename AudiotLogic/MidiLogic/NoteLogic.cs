using System.Collections.Generic;

namespace AudiotLogic.MidiLogic
{
    public static class NoteLogic
    {
        public static List<int> OctaveC = new List<int>(new int[] {12, 24, 36, 48, 60, 72, 84, 96, 108, 120 });

        public static int OctaveAdjust(int noteOffset, int octaveOffset, int keyOffset = 0)
        {
            return noteOffset + OctaveC[(octaveOffset + 4)] + keyOffset;
        }
    }
}
