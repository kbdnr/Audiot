using System.Collections.Generic;

namespace AudiotLogic.TheoryLogic
{
    public class Key
    {
        public string Name { get; set; }
        public int Offset { get; set; }

        public Key(int offset, string keyname)
        {
            Offset = offset;
            Name = keyname;
        }
    }

    public static class Keys
    {
        public static Key C = new Key(0, "C");
        public static Key CSharp = new Key(1, "C♯");
        public static Key D = new Key(2, "D");
        public static Key DSharp = new Key(3, "D♯");
        public static Key E = new Key(4, "E");
        public static Key F = new Key(5, "F");
        public static Key FSharp = new Key(6, "F♯");
        public static Key G = new Key(7, "G");
        public static Key GSharp = new Key(8, "G♯");
        public static Key A = new Key(9, "A");
        public static Key ASharp = new Key(10, "A♯");
        public static Key B = new Key(11, "B");

        public static List<string> GetKeyNames()
        {
            List<string> KeyNames = new List<string>();

            var keys = typeof(Keys);
            var fields = keys.GetFields();

            foreach (var field in fields)
            {
                var keyObject = field.GetValue(null);
                Key key = (Key)keyObject;
                KeyNames.Add(key.Name);
            }

            return KeyNames;
        }

        public static Key ConstructKeyFromName(string name)
        {
            var keys = typeof(Keys);
            var fields = keys.GetFields();

            foreach (var field in fields)
            {
                var keyObject = field.GetValue(null);
                Key key = (Key)keyObject;

                if (key.Name == name)
                    return key;
            }

            return null;
        }
    }
}
