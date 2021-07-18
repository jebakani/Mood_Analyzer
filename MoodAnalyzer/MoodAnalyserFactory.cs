using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;
namespace MoodAnalyzer
{
    public class MoodAnalyserFactory
    {
        public static object CreateObjectForMoodAnalyser(string className,string constructorName)
        {
            //create the pattern and checks whether constructor name and class name are equal
            string pattern = @"." + constructorName + "";
            Match result = Regex.Match(className,pattern);
            //if yes create the object
            if(result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                //if no class found then then throw class not found exception
                catch(ArgumentNullException)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
                }
            }
            //if constructor name not equal to class name then throw constructor not found exception
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
            }

        }
        public static object CreateObjectForMoodAnalyserParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = Type.GetType(className);
            try
            {
                //if yes create the object
                if (type.FullName.Equals(className) || type.Name.Equals(className))
                {
                    if (type.Name.Equals(constructorName))
                    {
                        ConstructorInfo info = type.GetConstructor(new[] { typeof(string) });
                        object instance = info.Invoke(new object[] { message });
                        return instance;
                    }
                    //if no class found then then throw class not found exception
                    else
                    {
                        throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
                    }

                }
                //if constructor name not equal to class name then throw constructor not found exception
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
                }
            }
            catch(Exception e)
            {
                return e;
            }
        }

        public static string InvokeMoodAnalyser(string message, string methodName)
        {
            //create an object using parameterize constructor method and invoke the method 
            try
            {
                Type type = Type.GetType("MoodAnalyzer.MoodAnalyze");
                object moodAnalyseObject = MoodAnalyserFactory.CreateObjectForMoodAnalyserParameterizedConstructor("MoodAnalyzer.MoodAnalyze", "MoodAnalyze", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyseObject,null);
                return mood.ToString();
            }
            //if method not found throw method not found exception
            catch(NullReferenceException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_METHOD_FOUND, "No method found");
            }
        }
        public static string SetFeild(string message,string fieldName)
        {
            //change the feild name dynamically
            try
            {
                MoodAnalyze moodAnalyze = new MoodAnalyze();
                Type type = typeof(MoodAnalyze);
                //get the field info 
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                //if message is null then throw Null exception in custom exception class
                if(message==null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_EXCEPTION, "Message should not be null");
                }
                //if message not null then set the message to the feild 
                fieldInfo.SetValue(moodAnalyze, message);
                return moodAnalyze.message;
            }
            //if no such field found then throw No field exist exception
            catch(NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_FEILD_EXIST, "Field is not found");
            }
        }
    }
}
