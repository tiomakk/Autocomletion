using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IAutocompletion
    {
        void AddToDictionary(string wordToAdd);
        List<string> Complete(string stringToComplete);
    }
}
