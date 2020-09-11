using AudiotLogic.MidiLogic;
using AudiotLogic.TheoryClass;
using AudiotLogic.Utils;
using System.Collections.Generic;
using static AudiotLogic.TheoryLogic.ChordLogic;

namespace AudiotLogic.TheoryLogic
{
    public static class Triad
    {
        public static Chord InputChordGen(int root, TriadShapeEnum shapeEnum)
        {
            var triadShape = new TriadShape(shapeEnum);

            return new Chord(root, triadShape);
        }

        public static ChordProgression ChordGen(Scale Scale, int duration = 1, int Root = 0, int Offset1 = 2, int Offset2 = 4)
        {
            ChordProgression ChordList = new ChordProgression();

            ChordList.Chords.Add(new Chord(Scale.Steps[Root], Scale.Steps[Offset1], Scale.Steps[Offset2]));

            for(int i = 1; i < Scale.Steps.Count * duration; i++)
            {
                ChordList.Chords.Add(new Chord(
                    Scale.Steps[i % Scale.Steps.Count],
                    Scale.Steps[(i + Offset1) % Scale.Steps.Count],
                    Scale.Steps[(i + Offset2) % Scale.Steps.Count]
                ));
            }

            return ChordList;
        }

        public static ChordProgression ChordGen(Scale Scale, List<int> ProgPattern, List<int> ColorPattern, int duration = 1, int Root = 1, int Offset1 = 2, int Offset2 = 4)
        {
            ChordProgression ChordList = new ChordProgression();
            ChordProgression PureList = new ChordProgression();
            int counter = 0;

            //Use Progression Pattern
            if(ProgPattern != null)
            {
                foreach (var chordNum in ProgPattern)
                {
                    var scaleIndex = chordNum - 1;
                    var root = Scale.Steps[scaleIndex % Scale.Steps.Count];

                    //Do we need to add an octave?
                    bool octPlus = (scaleIndex + Offset1) >= Scale.Steps.Count;
                    var c2 = Scale.Steps[(scaleIndex + Offset1) % Scale.Steps.Count];
                    var third = octPlus ? c2 + Scale.Divisions : c2;

                    octPlus = (scaleIndex + Offset2) >= Scale.Steps.Count;
                    var c3 = Scale.Steps[(scaleIndex + Offset2) % Scale.Steps.Count];
                    var fifth = octPlus ? c3 + Scale.Divisions : c3;

                    var chord = new Chord( 
                        root,
                        third,
                        fifth
                    );

                    if(ColorPattern != null && ColorPattern.Count > 0)
                    {
                        var colorNum = ColorPattern[counter % ColorPattern.Count];

                        if(colorNum > Scale.Steps.Count)
                            chord.Notes.Add(Scale.Steps[(scaleIndex + (colorNum - 1)) % Scale.Steps.Count] + Scale.Divisions);
                        else
                            chord.Notes.Add(Scale.Steps[(scaleIndex + (colorNum - 1)) % Scale.Steps.Count]);
                    }

                    PureList.Chords.Add(chord);

                    counter++;
                }
            }
            else //Otherwise default to all scale roots
            {
                for (int step = 0; step < Scale.Steps.Count; step++)
                {
                    var root = Scale.Steps[step % Scale.Steps.Count];

                    //Do we need to add an octave?
                    bool octPlus = (step + Offset1) >= Scale.Steps.Count;
                    var c2 = Scale.Steps[(step + Offset1) % Scale.Steps.Count];
                    var third = octPlus ? c2 + Scale.Divisions : c2;

                    octPlus = (step + Offset2) >= Scale.Steps.Count;
                    var c3 = Scale.Steps[(step + Offset2) % Scale.Steps.Count];
                    var fifth = octPlus ? c3 + Scale.Divisions : c3;

                    var chord = new Chord(
                        root,
                        third,
                        fifth
                    );

                    if(ColorPattern != null && ColorPattern.Count > 0)
                    {
                        var colorNum = ColorPattern[counter % ColorPattern.Count];

                        if (colorNum > Scale.Steps.Count)
                            chord.Notes.Add(Scale.Steps[(step + colorNum) % Scale.Steps.Count] + Scale.Divisions);
                        else
                            chord.Notes.Add(Scale.Steps[(step + colorNum) % Scale.Steps.Count]);
                    }

                    PureList.Chords.Add(chord);

                    counter++;
                }
            }

            for(int i = 0; i < duration; i++)
            {
                ChordList.Chords.AddRange(PureList.Chords);
            }

            return ChordList;
        }

        public static ChordProgression Inversion(ChordProgression chordList, List<int> octList, List<int> inversionList, Key key)
        {
            ChordProgression chordInvList = new ChordProgression();
            List<int> invOrder = new List<int>();
            int specInv;
            int c1; int c2; int c3; int c4;

            int counter = 0;

            foreach (var chord in chordList.Chords)
            {
                if (inversionList != null && inversionList.Count != 0)
                {
                    invOrder = new List<int>(new int[] { 0, 1, 2 });
                    specInv = inversionList[counter % inversionList.Count];
                    c1 = NoteLogic.OctaveAdjust(chord.Notes[specInv], octList[counter % octList.Count]);
                    c1 = c1 + key.Offset;
                    invOrder.Remove(specInv);
                    invOrder.Shuffle();
                }
                else
                {
                    invOrder = new List<int>(new int[] { 0, 1, 2 });
                    specInv = invOrder[0];
                    invOrder.Remove(specInv);
                    c1 = NoteLogic.OctaveAdjust(chord.Notes[specInv], octList[counter % octList.Count]);
                    c1 = c1 + key.Offset;
                }

                int octShift1;
                if (invOrder[0] < specInv)
                    octShift1 = 1;
                else
                    octShift1 = 0;

                c2 = NoteLogic.OctaveAdjust(chord.Notes[invOrder[0]], octList[counter % octList.Count] + octShift1);
                c2 = c2 + key.Offset;

                int octShift2;
                if (invOrder[1] < invOrder[0])
                    octShift2 = octShift1 + 1;
                else
                    octShift2 = octShift1;

                c3 = NoteLogic.OctaveAdjust(chord.Notes[invOrder[1]], octList[counter % octList.Count] + octShift2);
                c3 = c3 + key.Offset;

                if(chord.Notes.Count == 4)
                {
                    c4 = NoteLogic.OctaveAdjust(chord.Notes[3], octList[counter % octList.Count]);
                    c4 = c4 + key.Offset;
                    chordInvList.Chords.Add(new Chord( c1, c2, c3, c4 ));
                }
                else
                    chordInvList.Chords.Add(new Chord( c1, c2, c3 ));

                counter++;
            }

            return chordInvList;
        }
    }
}
