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
    }
}
