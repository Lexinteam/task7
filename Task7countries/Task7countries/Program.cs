using System;
using System.Collections.Generic;

namespace Task7countries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Generator gen1 = new Generator();
            // to create path variable
            Dictionary<int, Country> dict1 = gen1.Countries(Generator.AssemblyDirectory + @"..\..\..\..\countries.txt");
            // @"C:\Users\work\source\repos\task7\task7\Task7countries\Task7countries\countries.txt"

            Generator.updateCountry(dict1, "Denmark", true);
            Generator.updateCountry(dict1, "Hungary", true);
            Generator.addCountry(dict1, "Ukraine", false);

            Generator.showFalse(dict1);


        }
    }
}
