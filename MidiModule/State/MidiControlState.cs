namespace MidiModule.State
{
    public class MidiControlState
    {
        public bool ProgVisible { get; set; }
        public bool ShapeVisible { get; set; }

        public MidiControlState(MidiControlStateEnum uiMode)
        {
            if (uiMode == MidiControlStateEnum.MidiMode)
            {
                ProgVisible = false;
                ShapeVisible = true;
            }
            else
            {
                ProgVisible = true;
                ShapeVisible = false;
            }
        }
    }

    public enum MidiControlStateEnum
    {
        MidiMode,
        CompositionMode
    }
}
