
using Problem2_MultiThread.Logic;

// Added as embedded resource, for test purposes
var paths = new List<string> { "Inputs\\DataPb2-002.txt", "Inputs\\DataPb2-003.txt", "Inputs\\DataPb2-004.txt", "Inputs\\DataPb2-005.txt", "Inputs\\DataPb2-006.txt" };
var divider = new FilesDivider();

var dividedFilesModel = divider.DivideFilesIntoThreads(paths);
var handler = new Problem2Handler();
var t1 = new Thread(new ThreadStart(() => handler.HandleProblem2(dividedFilesModel.Thread1Files)));
var t2 = new Thread(new ThreadStart(() => handler.HandleProblem2(dividedFilesModel.Thread2Files)));
var t3 = new Thread(new ThreadStart(() => handler.HandleProblem2(dividedFilesModel.Thread3Files)));
var t4 = new Thread(new ThreadStart(() => handler.HandleProblem2(dividedFilesModel.Thread4Files)));

t1.Start();
t2.Start();
t3.Start();
t4.Start();

Console.ReadKey();
