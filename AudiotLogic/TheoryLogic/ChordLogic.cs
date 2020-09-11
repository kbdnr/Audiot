using AudiotLogic.TheoryClass;
using System;
using System.Linq;

namespace AudiotLogic.TheoryLogic
{
    public static class ChordLogic
    {
        public class TriadShape
        {
            public int[] Shape { get; set; }

            public TriadShape(params int[] offsets)
            {
                Shape = offsets;
            }

            public TriadShape(TriadShapeEnum shape)
            {
                if(shape == TriadShapeEnum.Major)
                    Shape = new int[] { 0, 4, 7 };
                if(shape == TriadShapeEnum.Minor)
                    Shape = new int[] { 0, 3, 7 }; 
                if(shape == TriadShapeEnum.Augmented)
                    Shape = new int[] { 0, 4, 8 };
                if(shape == TriadShapeEnum.Diminished)
                    Shape = new int[] { 0, 3, 6 };
            }
        }

        public static Chord ChordBuilder(int root, TriadShape triad)
        {
            if (triad.Shape == null || triad.Shape.Count() < 3)
                throw new IndexOutOfRangeException();

            return new Chord(root + triad.Shape[0], root + triad.Shape[1], root + triad.Shape[2]);
        }
    }
}
