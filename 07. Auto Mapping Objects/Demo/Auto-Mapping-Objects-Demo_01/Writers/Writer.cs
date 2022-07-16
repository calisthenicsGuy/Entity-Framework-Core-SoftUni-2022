using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Mapping_Objects_Demo_01.Writers
{
    public static class Writer
    {
        public static void Write(string text)
        {
            using StreamReader reader = new StreamReader(text);
            using StreamWriter writer = new StreamWriter(@"..\..\..\output.txt");

            string line = reader.ReadLine();

            while (String.IsNullOrEmpty(line))
            {
                writer.WriteLine(line);

                line = reader.ReadLine();
            }
        }
    }
}
