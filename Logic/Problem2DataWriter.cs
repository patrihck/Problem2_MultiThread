using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_MultiThread.Logic
{
    internal class Problem2DataWriter
    {
        public void WriteData(string path, string[][] rows)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    writer.WriteLine(string.Join("\t", rows[i]));
                }
            }
        }
    }
}
