using Problem2_MultiThread.Model;

namespace Problem2_MultiThread.Logic
{
    internal class FilesDivider
    {
        public FilesDividedIntoThreadsModel DivideFilesIntoThreads(List<string> paths)
        {
            var dividedFiles = new FilesDividedIntoThreadsModel
            {
                Thread1Files = new List<string>(),
                Thread2Files = new List<string>(),
                Thread3Files = new List<string>(),
                Thread4Files = new List<string>()
            };

            int i = 0;
            foreach (var path in paths)
            {
                var threadFiles = GetCorrectThreadFiles(i, dividedFiles);
                threadFiles.Add(path);

                if (i < 3)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }

            return dividedFiles;
        }

        private List<string> GetCorrectThreadFiles(int i, FilesDividedIntoThreadsModel dividedFiles)
        {
            switch (i)
            {
                case 0:
                    {
                        return dividedFiles.Thread1Files;
                    }
                case 1:
                    {
                        return dividedFiles.Thread2Files;
                    }
                case 2:
                    {
                        return dividedFiles.Thread3Files;
                    }
                case 3:
                    {
                        return dividedFiles.Thread4Files;
                    }
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
