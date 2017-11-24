using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.Text.RegularExpressions;

namespace AutoCompletion
{
    public class Autocompletion: IAutocompletion
    {
        private IDataProvider _dataProvider;
        private Dictionary<string, int> _dictionary;

        public Autocompletion(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _dictionary = dataProvider.GetData();
        }
        public List<string> Complete(string stringToComplete)
        {
            var sortedDictionary = _dictionary.OrderByDescending(item => item.Value).ToDictionary(item => item.Key, item => item.Value);
            var matches = new List<string>();
            
            foreach (var item in _dictionary)
            {
                if (item.Key.StartsWith(stringToComplete))
                    matches.Add(item.Key + " " + item.Value);
                if (matches.Count == 10)
                    break;
            }
            return matches;
            //var words = String.Join(" ", _dictionary.OrderByDescending(item => item.Value).Select(item => item.Key).ToList());
            //var matches = Regex.Matches(words, @"\b" + stringToComplete + @"\w*\b").Cast<Match>();
            //return matches.Select(item => item.Value + " " + _dictionary[item.Value]).Take(10).ToList();
        }

        public void AddToDictionary(string wordToAdd)
        {
            if (_dictionary.ContainsKey(wordToAdd))
                _dictionary[wordToAdd]++;
            else
                _dictionary.Add(wordToAdd, 1);
        }

    }
}
