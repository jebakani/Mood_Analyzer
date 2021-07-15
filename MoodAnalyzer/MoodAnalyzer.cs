using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzers
{
    class MoodAnalyzer
    {
        public string AnalyseMood(string message)
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
