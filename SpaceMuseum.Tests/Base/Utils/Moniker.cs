using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Tests.Base.Utils
{
    public class Moniker
    {
        private static Moniker Instance = new Moniker();

        #region Sugar 

        public static string Noun => Instance.RandomWord(Instance._nouns);
        public static string Adjective => Instance.RandomWord(Instance._adjectives);
        public static string Verb => Instance.RandomWord(Instance._verbs);
        public static string FirstName = Instance.RandomWord(Instance._firstNames);
        public static string LastName = Instance.RandomWord(Instance._lastNames);

        public static string Title => $"{Adjective} {Noun}";
        public static string UserName => $"{FirstName}{Noun}";

        public static double Double => Instance._rnd.NextDouble();
        public static int Integer => Instance._rnd.Next();
        public static int Digit => Instance._rnd.Next(10);

        public static string ForThing => $"{Adjective} {Noun}";
        public static string ForStateOfThing => $"{Adjective}";


        public static string LimitedNown(int maxLength)
        {
            var r = Noun;
            if (r.Length > maxLength)
                r = r.Substring(0, maxLength);
            return r;
        }

        public static string Digits(int length)
        {
            var result = new StringBuilder(length);
            for (var i = 0; i < length; i++)
                result.Append(Digit);
            return result.ToString();
        }


        #endregion
        
        private Random _rnd = new Random();
        private readonly List<string> _nouns = new List<string>();
        private readonly List<string> _verbs = new List<string>();
        private readonly List<string> _adjectives = new List<string>();
        private readonly List<string> _firstNames = new List<string>();
        private readonly List<string> _lastNames = new List<string>();

        private Moniker()
        {
            _nouns = ReadDictionary("nouns");
            _verbs = ReadDictionary("verbs");
            _adjectives = ReadDictionary("adjectives");
            _firstNames = ReadDictionary("first");
            _lastNames = ReadDictionary("last");
        }

        private List<string> ReadDictionary(string name)
        {
            var result = new List<string>();
            var assembly = GetType().Assembly;
            var resourceStream = assembly.GetManifestResourceStream($"SpaceMuseum.Tests.Base.Utils.Dictionaries.{name}.txt");

            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    var word = reader.ReadLine();
                    result.Add(word);
                }
            }

            return result;
        }

        private string RandomWord(List<string> words)
        {
            return words[_rnd.Next(words.Count)];
        }
    }
}
