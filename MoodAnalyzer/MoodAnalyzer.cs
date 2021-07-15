using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    /// <summary>
    /// refactoring MoodAnalyze with parameterized constructure
    /// </summary>
    public class MoodAnalyze
    {
        string message;
       public MoodAnalyze(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            message = message.ToLower();
            if(message.Contains("sad"))
            {
                return "sad";
            }
            else
            {
                return "happy";
            }
        }
    }
}
