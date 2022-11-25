using System.Collections.Concurrent;

namespace Problem2_MultiThread.Logic
{
    internal class Problem2Handler
    {
        public void HandleProblem2(List<string> filePaths)
        {
            ConcurrentDictionary<string, object> locks = new ConcurrentDictionary<string, object>();

            foreach (var filePath in filePaths)
            {
                var dataReader = new Problem2DataReader();
                var dataModel = dataReader.GetProblem2DataModelFromFile(filePath, 1);
                var quantileIndex = (int)Math.Round(0.9 * dataModel.Length, 0);
                var quantile = dataModel[quantileIndex];
                var fileName = Path.GetFileName(filePath);
                var row = new string[1][] { new string[2] { fileName, quantile.ToString() } };

                var dataWriter = new Problem2DataWriter();

                var finalDestname = "Inputs\\final.txt";

                // This is how we should behave in case of big app - LockManager
                //LockManager.GetLock(finalDestname, () =>
                //{
                //    dataWriter.WriteData(finalDestname, row);
                //});

                // But for this simple we can treat finalDestname as unique for whole app, so for this example this is enough
                lock (finalDestname)
                {
                    dataWriter.WriteData(finalDestname, row);
                }
            }            
        }
    }
}
