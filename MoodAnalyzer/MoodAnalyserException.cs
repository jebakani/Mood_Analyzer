﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    public class MoodAnalyserException:Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION, CLASS_NOT_FOUND, CONSTRUCTOR_NOT_FOUND, NO_METHOD_FOUND, NO_FEILD_EXIST
        }
        public MoodAnalyserException(ExceptionType type,string message) : base(message)
        {
            this.type = type;
        }
    }
}
