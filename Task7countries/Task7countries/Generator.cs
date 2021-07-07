using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task7countries
{
    class Generator

    {

        // reads list of countries from file and creates Dictionary ( int, Value - Country. ) using Country class
        public Dictionary<int, Country> Countries(string pathToCsvFile)
        {
            Dictionary<int, Country> dictionary = new Dictionary<int, Country>();
            using (var reader = new StreamReader(pathToCsvFile))
            {
                int counter = 0;
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(':');
                    string country = values[0];
                    bool supported = bool.Parse(values[1]);

                    //create each country and add to dictionary
                    dictionary.Add(counter++, new Country(country, supported));
                }
            }

            return dictionary;
        }

        // maybe to create with bool parameter to show false, true or all countries
        public static void showFalse(Dictionary<int, Country> d)
        {

            //Console.WriteLine(d.Count);
            foreach (KeyValuePair<int, Country> kvp in d)
            {
                if (kvp.Value.IsTelenorSupported == false)
                {
                    Console.WriteLine("{0}, IsTelenorSupported = {1}", kvp.Value.Name, kvp.Value.IsTelenorSupported);
                }

            }

        }

        // facepalm, but can't merge 2 updating methods into one as difficult to iterate via object Country
        public static void updateCountry(Dictionary<int, Country> d, string countryToChange, bool b1)
        {
            foreach (KeyValuePair<int, Country> kvp in d)
            {
                if (kvp.Value.Name == countryToChange)
                {
                    kvp.Value.IsTelenorSupported = b1;
                }
            }
            // change in file
            // delete contents of existing file
            System.IO.File.WriteAllText(Generator.AssemblyDirectory + @"..\..\..\..\countries.txt", string.Empty);
            // write updated dictionary to existing (but already empty) file
            WriteDictToFile(d);

        }

        public static void addCountry(Dictionary<int, Country> d, string countryToChange, bool b1)
        {
            d.Add(d.Count, new Country(countryToChange, b1));

            // change in file
            // delete contents of existing file
            System.IO.File.WriteAllText(Generator.AssemblyDirectory + @"..\..\..\..\countries.txt", string.Empty);
            // write updated dictionary to existing (but already empty) file
            WriteDictToFile(d);

        }
        public static void WriteDictToFile(Dictionary<int, Country> someDict)
        {
            using (StreamWriter fileWriter = new StreamWriter(Generator.AssemblyDirectory + @"..\..\..\..\countries.txt"))
            {
                // You can modify <string, string> notation by placing your types.
                foreach (KeyValuePair<int, Country> kvPair in someDict)
                {
                    fileWriter.WriteLine("{0}:{1}", kvPair.Value.Name, kvPair.Value.IsTelenorSupported);
                }
                fileWriter.Close();
            }
    }

    public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
