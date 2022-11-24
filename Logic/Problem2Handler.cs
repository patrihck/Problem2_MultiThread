namespace Problem2_MultiThread.Logic
{
    internal class Problem2Handler
    {
        public void HandleProblem2(List<string> filePaths)
        {
            foreach (var filePath in filePaths)
            {
                var dataReader = new Problem2DataReader();
                var dataModel = dataReader.GetProblem2DataModelFromFile(filePath, 1);
                var quantileIndex = (int)Math.Round(0.9 * dataModel.Length, 0);
                var quantile = dataModel[quantileIndex];
                var fileName = Path.GetFileName(filePath);
                var row = new string[1][] { new string[2] { fileName, quantile.ToString() } };

                var dataWriter = new Problem2DataWriter();
                dataWriter.WriteData($"Inputs\\final-{fileName}", row);
            }            
        }
    }
}
