using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CensoredWordsApp.model;
using System.Threading;

namespace CensoredWordsApp
{
    public class FileHandler
    {
        private object _lockObject = new object();
        public bool IsExistWord(
            string filePath,
            IEnumerable<string> censorWords,
            ManualResetEventSlim limit,
            CancellationToken token)
        {
            bool res = false;
            var text = GetLine(filePath);
            string[] words;
            foreach (string line in text)
            {
                limit.Wait();
                if (token.IsCancellationRequested)
                {
                   token.ThrowIfCancellationRequested();
                }
                words = line.Trim().ToLower().Split(' ');
                if (censorWords.Any(w => words.Contains(w.ToLower())))
                    return true;
            }
            return res;
        }

        public void ReplaceCensor(
            FileInfo readFile,
            FileInfo writeFile,
            List<string> censorWords,
            ref StatisticCensor statistic,
            ManualResetEventSlim limit,
            CancellationToken token
            )
        {
            var text = GetLine(readFile.FullName);
            if (File.Exists(writeFile.FullName))
                return;
            lock (_lockObject)
            {
                using (var fileWrite = File.AppendText(writeFile.FullName))
                {
                    string str = "";
                    foreach (var line in text)
                    {
                        str = line;
                        string temp = str;
                        foreach (var censor in censorWords)
                        {
                            limit.Wait();
                            if (token.IsCancellationRequested)
                            {
                                token.ThrowIfCancellationRequested();
                            }
                            str = temp.Replace(censor, "*******");
                            if (str != temp)
                            {
                                if (statistic.CountsCensoredWords.ContainsKey(censor))
                                    statistic.CountsCensoredWords[censor]++;
                                else
                                    statistic.CountsCensoredWords.Add(censor, 1);

                                if (statistic.FileInfos.ContainsKey(writeFile))
                                    statistic.FileInfos[writeFile]++;
                                else
                                    statistic.FileInfos.Add(writeFile, 1);
                                //Thread.Sleep(1000);
                            }
                            temp = str;
                        }
                        fileWrite.WriteLine(str);
                    }
                }
            }
        }

        private IEnumerable<string> GetLine(string filePath)
        {
            string line;
            lock (_lockObject)
            {
                using (var file = File.OpenText(filePath))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        yield return line;
                    }
                }
            }
        }
    }
}
