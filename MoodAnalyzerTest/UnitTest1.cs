using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;
namespace MoodAnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// TC 1.1 Given “I am in Sad Mood” message
        // Should Return SAD
        /// </summary>
        [TestMethod]
        public void ReturnSadTest()
        {
            //assign
            string expected = "sad";
            string message= "I am in SadMood";
            //act
            string actual = new MoodAnalyze(message).AnalyseMood();
            //assert
            Assert.AreEqual(expected, actual);

        }
        /// <summary>
        /// TC 1.2 Given “I am in any mood” message
        // Should Return happy
        /// </summary>
        [TestMethod]
        public void ReturnHappyTest()
        {
            //assign
            string expected = "happy";
            string message = "I am in happy mood";
            //act
            string actual = new MoodAnalyze(message).AnalyseMood();
            //assert
            Assert.AreEqual(expected, actual);

        }
        /// <summary>
        /// Nulls reference test.
        /// </summary>
        [TestMethod]
        public void NULLReferenceTest()
        {
            //assign
            string expected = "happy";
            string message = null;
            //act
            string actual = new MoodAnalyze(message).AnalyseMood();
            //assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ReturnCustomException()
        {
            string expected = "Mood should not be empty";
            try
            {
                string message = "";
                //act
                string actual = new MoodAnalyze(message).AnalyseMood();
            }
            catch (MoodAnalyserException ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }

        }
        [TestMethod]
        public void ReturnMoodShoulNotBeNull()
        {
            string expected = "Mood should not be null";
            try
            {
                string message = null;
                //act
                string actual = new MoodAnalyze(message).AnalyseMood();
            }
            catch (MoodAnalyserException ex)
            {
                //assert
                Assert.AreEqual(expected, ex.Message);
            }

        }
        /// <summary>
        /// T.C=4.1 Returns the mood analyser object with reflection-> Equal
        /// </summary>
        [TestMethod]
        public void ReturnMoodAnalyserObjectWithReflection()
        {
            object expected = new MoodAnalyze();
            object actual = MoodAnalyserFactory.CreateObjectForMoodAnalyser("MoodAnalyzer.MoodAnalyze", "MoodAnalyze");
            expected.Equals(actual);
        }
        /// <summary>
        /// T.C-4.2 Returns the mood analyser object with reflection1 -> class nbot found
        /// </summary>
        [TestMethod]
        public void ReturnMoodAnalyserObjectWithReflection1()
        {
            string expected = "Class not found";
            try
            {
                object actual = MoodAnalyserFactory.CreateObjectForMoodAnalyser("MoodAnalyzer.MoodAnalyzer", "MoodAnalyzer");
            }
            catch(MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// T.C-4.3 Returns the mood analyser object with reflection1 -> constructor not found
        /// </summary>
        [TestMethod]
        public void ReturnMoodAnalyserObjectWithReflection2()
        {
            string expected = "Constructor not found";
            try
            {
                object actual = MoodAnalyserFactory.CreateObjectForMoodAnalyser("MoodAnalyzer.MoodAnalyze", "MoodAnalyzer");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        ///T.C - 5.1 Returns the object with parameterized constructor.
        /// </summary>
        [TestMethod]
        public void ReturnObjectWithParameterizedConstructor()
        {
            object expected = new MoodAnalyze("I am happy");
            object actual = MoodAnalyserFactory.CreateObjectForMoodAnalyserParameterizedConstructor("MoodAnalyzer.MoodAnalyze", "MoodAnalyze","I am happy");
            expected.Equals(actual);
        }
        /// <summary>
        ///T.C - 5.2 Returns the object with parameterized constructor.-> Class Not found Exception
        /// </summary>
        [TestMethod]
        public void ReturnObjectWithParameterizedConstructor1()
        {
            string expected = "Class not found";
            try
            {
                object actual = MoodAnalyserFactory.CreateObjectForMoodAnalyserParameterizedConstructor("MoodAnalyzer.MoodAnalyzer", "MoodAnalyzer","I am happy");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        ///T.C - 5.3 Returns the object with parameterized constructor.-> Constructor Not found Exception
        /// </summary>
        [TestMethod]
        public void ReturnObjectWithParameterizedConstructor2()
        {
            string expected = "Constructor not found";
            try
            {
                object actual = MoodAnalyserFactory.CreateObjectForMoodAnalyserParameterizedConstructor("MoodAnalyzer.MoodAnalyze", "MoodAnalyzer", "I am happy");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC-6.1 Invokes the method using reflection->return happy
        /// </summary>
        [TestMethod]
        public void InvokeMethodUsingReflection()
        {
            string expected = "Happy";
            string actual = MoodAnalyserFactory.InvokeMoodAnalyser("I am happy", "AnalyseMood");
            expected.Equals(actual);

        }
        /// <summary>
        /// TC-6.2 Invokes the method using reflection->return happy
        /// </summary>
        [TestMethod]
        public void InvokeMethodUsingReflection1()
        {
            string expected = "No method found";
            try
            {
                string actual = MoodAnalyserFactory.InvokeMoodAnalyser("I am happy", "AnalyserMood");
                expected.Equals(actual);
            }
            catch(MoodAnalyserException me)
            {
                Assert.AreEqual(expected, me.Message);
            }

        }
    }
}
