using System.Collections.Generic;

namespace AudiotLogic.TheoryLogic
{
    public class Scale
    {
        public List<int> Steps { get; set; }
        public int Divisions { get; set; }
        public string Name { get; set; }

        public Scale(List<int> steps, int divisions, string scaleName)
        {
            Steps = steps;
            Divisions = divisions;
            Name = scaleName;
        }
    }

    /// <summary>
    /// Scale logic from Supercollider Scales.sc
    /// </summary>
    public static class Scales
    {
        // TWELVE TONES PER OCTAVE
        // 5 note scales
        public static Scale MinorPentatonic = new Scale(new List<int>(new int[] { 0, 3, 5, 7, 10 }), 12, "Minor Pentatonic");
        public static Scale MajorPentatonic = new Scale(new List<int>(new int[] { 0, 2, 4, 7, 9 }), 12, "Major Pentatonic");
        public static Scale Ritusen = new Scale(new List<int>(new int[] { 0, 2, 5, 7, 9 }), 12, "Ritusen");
        // another mode of major pentatonic
        public static Scale Egyptian = new Scale(new List<int>(new int[] { 0, 2, 5, 7, 10 }), 12, "Egyptian");

        public static Scale Kumoi = new Scale(new List<int>(new int[] { 0, 2, 3, 7, 9 }), 12, "Kumoi");
        public static Scale Hirajoshi = new Scale(new List<int>(new int[] { 0, 2, 3, 7, 8 }), 12, "Hirajoshi");
        public static Scale Iwato = new Scale(new List<int>(new int[] { 0, 1, 5, 6, 10 }), 12, "Iwato");
        public static Scale Chinese = new Scale(new List<int>(new int[] { 0, 4, 6, 7, 11 }), 12, "Chinese");
        public static Scale Indian = new Scale(new List<int>(new int[] { 0, 4, 5, 7, 10 }), 12, "Indian");
        public static Scale Pelog = new Scale(new List<int>(new int[] { 0, 1, 3, 7, 8 }), 12, "Pelog");

        public static Scale Prometheus = new Scale(new List<int>(new int[] { 0, 2, 4, 6, 11 }), 12, "Prometheus");
        public static Scale Scriabin = new Scale(new List<int>(new int[] { 0, 1, 4, 7, 9 }), 12, "Scriabin");

        // han chinese pentatonic scales
        public static Scale Gong = new Scale(new List<int>(new int[] { 0, 2, 4, 7, 9 }), 12, "Gong");
        public static Scale Shang = new Scale(new List<int>(new int[] { 0, 2, 5, 7, 10 }), 12, "Shang");
        public static Scale Jiao = new Scale(new List<int>(new int[] { 0, 3, 5, 8, 10 }), 12, "Jiao");
        public static Scale Zhi = new Scale(new List<int>(new int[] { 0, 2, 5, 7, 9 }), 12, "Zhi");
        public static Scale Yu = new Scale(new List<int>(new int[] { 0, 3, 5, 7, 10 }), 12, "Yu");

        // 6 note scales
        public static Scale Whole = new Scale(new List<int>(new int[] { 0, 2, 4, 6, 8, 10 }), 12, "Whole");
        public static Scale Augmented = new Scale(new List<int>(new int[] { 0, 3, 4, 7, 8, 11 }), 12, "Augmented");
        public static Scale Augmented2 = new Scale(new List<int>(new int[] { 0, 1, 4, 5, 8, 9 }), 12, "Augmented 2");

        // hexatonic modes with no tritone
        public static Scale HexMajor7 = new Scale(new List<int>(new int[] { 0, 2, 4, 7, 9, 11 }), 12, "Hex Major 7");
        public static Scale HexDorian = new Scale(new List<int>(new int[] { 0, 2, 3, 5, 7, 10 }), 12, "Hex Dorian");
        public static Scale HexPhrygian = new Scale(new List<int>(new int[] { 0, 1, 3, 5, 8, 10 }), 12, "Hex Phrygian");
        public static Scale HexSus = new Scale(new List<int>(new int[] { 0, 2, 5, 7, 9, 10 }), 12, "Hex Sustained");
        public static Scale HexMajor6 = new Scale(new List<int>(new int[] { 0, 2, 4, 5, 7, 9 }), 12, "Hex Major 6");
        public static Scale HexAeolian = new Scale(new List<int>(new int[] { 0, 3, 5, 7, 8, 10 }), 12, "Hex Aeolian");

        // 7 note scales
        public static Scale Major = new Scale(new List<int>(new int[] { 0, 2, 4, 5, 7, 9, 11 }), 12, "Major");
        public static Scale Ionian = new Scale(new List<int>(new int[] { 0, 2, 4, 5, 7, 9, 11 }), 12, "Ionian");
        public static Scale Dorian = new Scale(new List<int>(new int[] { 0, 2, 3, 5, 7, 9, 10 }), 12, "Dorian");
        public static Scale Phrygian = new Scale(new List<int>(new int[] { 0, 1, 3, 5, 7, 8, 10 }), 12, "Phrygian");
        public static Scale Lydian = new Scale(new List<int>(new int[] { 0, 2, 4, 6, 7, 9, 11 }), 12, "Lydian");
        public static Scale Mixolydian = new Scale(new List<int>(new int[] { 0, 2, 4, 5, 7, 9, 10 }), 12, "Mixolydian");
        public static Scale Aeolian = new Scale(new List<int>(new int[] { 0, 2, 3, 5, 7, 8, 10 }), 12, "Aeolian");
        public static Scale Minor = new Scale(new List<int>(new int[] { 0, 2, 3, 5, 7, 8, 10 }), 12, "Minor");
        public static Scale Locrian = new Scale(new List<int>(new int[] { 0, 1, 3, 5, 6, 8, 10 }), 12, "Locrian");

        public static Scale HarmonicMinor = new Scale(new List<int>(new int[] { 0, 2, 3, 5, 7, 8, 11 }), 12, "Harmonic Minor");
        public static Scale HarmonicMajor = new Scale(new List<int>(new int[] { 0, 2, 4, 5, 7, 8, 11 }), 12, "Harmonic Major");
        public static Scale MelodicMinor = new Scale(new List<int>(new int[] { 0, 2, 3, 5, 7, 9, 11 }), 12, "Melodic Minor");
        public static Scale MelodicMinorDesc = new Scale(new List<int>(new int[] { 0, 2, 3, 5, 7, 8, 10 }), 12, "Melodic Minor Descending");
        public static Scale MelodicMajor = new Scale(new List<int>(new int[] { 0, 2, 4, 5, 7, 8, 10 }), 12, "Melodic Major");
        public static Scale Bartok = new Scale(new List<int>(new int[] { 0, 2, 4, 5, 7, 8, 10 }), 12, "Bartok");
        public static Scale Hindu = new Scale(new List<int>(new int[] { 0, 2, 4, 5, 7, 8, 10 }), 12, "Hindu");

        //Raga Modes
        public static Scale Todi = new Scale(new List<int>(new int[] { 0, 1, 3, 6, 7, 8, 11 }), 12, "Todi");
        public static Scale Purvi = new Scale(new List<int>(new int[] { 0, 1, 4, 6, 7, 8, 11 }), 12, "Purvi");
        public static Scale Marva = new Scale(new List<int>(new int[] { 0, 1, 4, 6, 7, 9, 11 }), 12, "Marva");
        public static Scale Bhairav = new Scale(new List<int>(new int[] { 0, 1, 4, 5, 7, 8, 11 }), 12, "Bhairav");
        public static Scale Ahirbhairav = new Scale(new List<int>(new int[] { 0, 1, 4, 5, 7, 9, 10 }), 12, "Ahirbhairav");

        public static Scale SuperLocrian = new Scale(new List<int>(new int[] { 0, 1, 3, 4, 6, 8, 10 }), 12, "Super Locrian");
        public static Scale RomanianMinor = new Scale(new List<int>(new int[] { 0, 2, 3, 6, 7, 9, 10 }), 12, "Romanian Minor");
        public static Scale HungarianMinor = new Scale(new List<int>(new int[] { 0, 2, 3, 6, 7, 8, 11 }), 12, "Hungarian Minor");
        public static Scale NeapolitanMinor = new Scale(new List<int>(new int[] { 0, 1, 3, 5, 7, 8, 11 }), 12, "Neapolitan Minor");
        public static Scale Enigmatic = new Scale(new List<int>(new int[] { 0, 1, 4, 6, 8, 10, 11 }), 12, "Enigmatic");
        public static Scale Spanish = new Scale(new List<int>(new int[] { 0, 1, 4, 5, 7, 8, 11 }), 12, "Spanish");

        // modes of whole tones with added note ->
        public static Scale LeadingWhole = new Scale(new List<int>(new int[] { 0, 2, 4, 6, 8, 10, 11 }), 12, "Leading Whole");
        public static Scale LydianMinor = new Scale(new List<int>(new int[] { 0, 2, 4, 6, 7, 8, 10 }), 12, "Lydian Minor");
        public static Scale NeapolitanMajor = new Scale(new List<int>(new int[] { 0, 1, 3, 5, 7, 9, 11 }), 12, "Neapolitan Major");
        public static Scale LocrianMajor = new Scale(new List<int>(new int[] { 0, 2, 4, 5, 6, 8, 10 }), 12, "Locrian Major");

        //// 8 note scales
        public static Scale Diminished = new Scale(new List<int>(new int[] { 0, 1, 3, 4, 6, 7, 9, 10 }), 12, "Diminished");
        public static Scale Diminished2 = new Scale(new List<int>(new int[] { 0, 2, 3, 5, 6, 8, 9, 11 }), 12, "Diminished 2");

        // 12 note scales
        public static Scale Chromatic = new Scale(new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }), 12, "Chromatic");

        //// TWENTY-FOUR TONES PER OCTAVE
        //\chromatic24 -> Scale.new((0..23), 24, name: "Chromatic 24"),

        //// maqam ajam
        //\ajam -> Scale.new(#[0,4,8,10,14,18,22], 24, name: "Ajam"),
        //\jiharkah -> Scale.new(#[0,4,8,10,14,18,21], 24, name: "Jiharkah"),
        //\shawqAfza -> Scale.new(#[0,4,8,10,14,16,22], 24, name: "Shawq Afza"),

        //// maqam sikah
        //\sikah -> Scale.new(#[0,3,7,11,14,17,21], 24, name: "Sikah"),
        //\sikahDesc -> Scale.new(#[0,3,7,11,13,17,21], 24, name: "Sikah Descending"),
        //\huzam -> Scale.new(#[0,3,7,9,15,17,21], 24, name: "Huzam"),
        //\iraq -> Scale.new(#[0,3,7,10,13,17,21], 24, name: "Iraq"),
        //\bastanikar -> Scale.new(#[0,3,7,10,13,15,21], 24, name: "Bastanikar"),
        //\mustar -> Scale.new(#[0,5,7,11,13,17,21], 24, name: "Mustar"),

        //// maqam bayati
        //\bayati -> Scale.new(#[0,3,6,10,14,16,20], 24, name: "Bayati"),
        //\karjighar -> Scale.new(#[0,3,6,10,12,18,20], 24, name: "Karjighar"),
        //\husseini -> Scale.new(#[0,3,6,10,14,17,21], 24, name: "Husseini"),

        //// maqam nahawand
        //\nahawand -> Scale.new(#[0,4,6,10,14,16,22], 24, name: "Nahawand"),
        //\nahawandDesc -> Scale.new(#[0,4,6,10,14,16,20], 24, name: "Nahawand Descending"),
        //\farahfaza -> Scale.new(#[0,4,6,10,14,16,20], 24, name: "Farahfaza"),
        //\murassah -> Scale.new(#[0,4,6,10,12,18,20], 24, name: "Murassah"),
        //\ushaqMashri -> Scale.new(#[0,4,6,10,14,17,21], 24, name: "Ushaq Mashri"),

        //// maqam rast
        //\rast -> Scale.new(#[0,4,7,10,14,18,21], 24, name: "Rast"),
        //\rastDesc -> Scale.new(#[0,4,7,10,14,18,20], 24, name: "Rast Descending"),
        //\suznak -> Scale.new(#[0,4,7,10,14,16,22], 24, name: "Suznak"),
        //\nairuz -> Scale.new(#[0,4,7,10,14,17,20], 24, name: "Nairuz"),
        //\yakah -> Scale.new(#[0,4,7,10,14,18,21], 24, name: "Yakah"),
        //\yakahDesc -> Scale.new(#[0,4,7,10,14,18,20], 24, name: "Yakah Descending"),
        //\mahur -> Scale.new(#[0,4,7,10,14,18,22], 24, name: "Mahur"),

        //// maqam hijaz
        //\hijaz -> Scale.new(#[0,2,8,10,14,17,20], 24, name: "Hijaz"),
        //\hijazDesc -> Scale.new(#[0,2,8,10,14,16,20], 24, name: "Hijaz Descending"),
        //\zanjaran -> Scale.new(#[0,2,8,10,14,18,20], 24, name: "Zanjaran"),

        //// maqam hijazKar
        //\hijazKar -> Scale.new(#[0,2,8,10,14,16,22], 24, name: "hijazKar"),

        //// maqam saba
        //\saba -> Scale.new(#[0,3,6,8,12,16,20], 24, name: "Saba"),
        //\zamzam -> Scale.new(#[0,2,6,8,14,16,20], 24, name: "Zamzam"),

        //// maqam kurd
        //\kurd -> Scale.new(#[0,2,6,10,14,16,20], 24, name: "Kurd"),
        //\kijazKarKurd -> Scale.new(#[0,2,8,10,14,16,22], 24, name: "Kijaz Kar Kurd"),

        //// maqam nawa Athar
        //\nawaAthar -> Scale.new(#[0,4,6,12,14,16,22], 24, name: "Nawa Athar"),
        //\nikriz -> Scale.new(#[0,4,6,12,14,18,20], 24, name: "Nikriz"),
        //\atharKurd -> Scale.new(#[0,2,6,12,14,16,22], 24, name: "Athar Kurd"),


        //// Ascending/descending scales
        //\melodicMinor -> ScaleAD(#[0,2,3,5,7,9,11], 12, #[0,2,3,5,7,8,10], name: "Melodic Minor"),
        //\sikah -> ScaleAD(#[0,3,7,11,14,17,21], 24, #[0,3,7,11,13,17,21], name: "Sikah"),
        //\nahawand -> ScaleAD(#[0,4,6,10,14,16,22], 24, #[0,4,6,10,14,16,20], name: "Nahawand"),

        // Partch's Otonalities and Utonalities
        //\partch_o1 -> Scale.new(#[0,8,14,20,25,34], 43,
        //    Tuning.partch, "Partch Otonality 1"),
        //\partch_o2 -> Scale.new(#[0,7,13,18,27,35], 43,
        //    Tuning.partch, "Partch Otonality 2"),
        //\partch_o3 -> Scale.new(#[0,6,12,21,29,36], 43,
        //    Tuning.partch, "Partch Otonality 3"),
        //\partch_o4 -> Scale.new(#[0,5,15,23,30,37], 43,
        //    Tuning.partch, "Partch Otonality 4"),
        //\partch_o5 -> Scale.new(#[0,10,18,25,31,38], 43,
        //    Tuning.partch, "Partch Otonality 5"),
        //\partch_o6 -> Scale.new(#[0,9,16,22,28,33], 43,
        //    Tuning.partch, "Partch Otonality 6"),
        //\partch_u1 -> Scale.new(#[0,9,18,23,29,35], 43,
        //    Tuning.partch, "Partch Utonality 1"),
        //\partch_u2 -> Scale.new(#[0,8,16,25,30,36], 43,
        //    Tuning.partch, "Partch Utonality 2"),
        //\partch_u3 -> Scale.new(#[0,7,14,22,31,37], 43,
        //    Tuning.partch, "Partch Utonality 3"),
        //\partch_u4 -> Scale.new(#[0,6,13,20,28,38], 43,
        //    Tuning.partch, "Partch Utonality 4"),
        //\partch_u5 -> Scale.new(#[0,5,12,18,25,33], 43,
        //    Tuning.partch, "Partch Utonality 5"),
        //\partch_u6 -> Scale.new(#[0,10,15,21,27,34], 43,
        //    Tuning.partch, "Partch Utonality 6"),

        public static List<string> GetScaleNames()
        {
            List<string> ScaleNames = new List<string>();

            var scales = typeof(Scales);
            var fields = scales.GetFields();

            foreach (var field in fields)
            {
                var scaleObject = field.GetValue(null);
                Scale scale = (Scale)scaleObject;
                ScaleNames.Add(scale.Name);
            }

            return ScaleNames;
        }

        public static Scale ConstructScaleFromName(string name)
        {
            var scales = typeof(Scales);
            var fields = scales.GetFields();

            foreach (var field in fields)
            {
                var scaleObject = field.GetValue(null);
                Scale scale = (Scale)scaleObject;

                if (scale.Name == name)
                    return scale;
            }

            return null;
        }
    }
}
