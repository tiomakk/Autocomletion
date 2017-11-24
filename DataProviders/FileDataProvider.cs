using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.IO;

namespace DataProviders
{
    public class FileDataProvider : IDataProvider
    {
        private string _pathToFile;
        public string PathToFile
        {
            get
            {
                return _pathToFile;
            }
            set
            {
                if (!File.Exists(value))
                    throw new FileNotFoundException("Wrong path to file");
                else
                    _pathToFile = value;
            }
        }
        
        public Dictionary<string, int> GetData()
        {
            var dictionary = new Dictionary<string, int>();
            using (var streamReader = new StreamReader(PathToFile))
            {
                if (!Int32.TryParse(streamReader.ReadLine(), out int length) || length < 0)
                    throw new Exception("Wrong number of lines at the beginning of the file");

                for(int i = 0; i < length; i++)
                {
                    string stringIn = streamReader.ReadLine();
                    string[] splitedString = stringIn.Split(' ');

                    if (!(splitedString.Length != 2))
                        if ((Int32.TryParse(splitedString[1], out int wordFrequency)) && wordFrequency > 0)
                            dictionary.Add(splitedString[0], wordFrequency);
                    else
                        throw new Exception("Wrong file data"); 
                                        
                }
                streamReader.ReadLine();
                while (!streamReader.EndOfStream)
                {
                    string word = streamReader.ReadLine();
                    if (dictionary.ContainsKey(word))
                        dictionary[word]++;
                    else
                        dictionary.Add(word, 1);
                }
            }
            return dictionary;
        }

        public FileDataProvider(string pathToFile)
        {
            PathToFile = pathToFile;
        }
    }
}
