using System.Collections.Generic;
using System.Linq;
using static AudiotLogic.TheoryLogic.ChordLogic;

namespace AudiotLogic.TheoryClass
{
    /// <summary>
    /// Chord class for specifying a list of notes.
    /// 
    /// Additional chord properties can be exposed here.
    /// </summary>
    public class Chord
    {
        public Chord(int root, TriadShape triad, int? color = null)
        {
            Notes = new List<int>(
                new int[] 
                {
                    root + triad.Shape[0], root + triad.Shape[1], root + triad.Shape[2]
                });

            if (color != null)
                Notes.Add(root + color.Value);
        }

        public Chord(params int[] notes)
        {
            Notes = notes.ToList();
        }

        public List<int> Notes { get; set; }

        public int? Root
        {
            get
            {
                if (Notes != null && Notes.Any())
                    return Notes[0];
                else
                    return null;
            }
        }

        public int? Color
        {
            get
            {
                if (Notes != null && Notes.Count == 4)
                {
                    return Notes[3];
                }
                else
                    return null;
            }
        }
    }

    /// <summary>
    /// Chord Progression class for specifying a list of Chords
    /// </summary>
    public class ChordProgression
    {
        public ChordProgression()
        {
            Chords = new List<Chord>();
        }

        public ChordProgression(List<Chord> chords)
        {
            Chords = chords;
        }

        public List<Chord> Chords { get; set; }
    }
}
