namespace Problem2_MultiThread.Logic
{
    internal class Problem2DataReader
    {
        public double[] GetProblem2DataModelFromFile(string filePath, int columnIndex)
        {
            var lines = File.ReadAllLines(filePath);
            var dataRows = new double[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                var columnValues = lines[i].Split("\t");
                dataRows[i] = double.Parse(columnValues[columnIndex], System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            }
            return dataRows.OrderBy(d => d).ToArray();
        }
    }
}
