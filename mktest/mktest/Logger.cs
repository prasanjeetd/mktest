using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mktest
{
    public class Logger
    {
        static string file = Path.Combine(Environment.CurrentDirectory, "Logs.txt");

        public static void Log(string text)
        {
            File.AppendAllLines(file, new string[] { text });
        }

    }
}
