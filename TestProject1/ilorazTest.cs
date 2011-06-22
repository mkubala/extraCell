using extraCell.formula.functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ilorazTest and is intended
    ///to contain all ilorazTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ilorazTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for run
        ///</summary>
        [TestMethod()]
        public void dzielenie_2_przez_1()
        {
            iloraz target = new iloraz(); // TODO: Initialize to an appropriate value
            object[] args = new string[2]; // TODO: Initialize to an appropriate value

            args[0] = "2.0";
            args[1] = "1";


            object expected = "2"; // TODO: Initialize to an appropriate value
           object actual = target.run(args);
            Assert.AreEqual(expected, actual);
            // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for run
        ///</summary>
        [TestMethod()]
        public void dzielenie_2_liczb()
        {
            iloraz target = new iloraz(); // TODO: Initialize to an appropriate value
            object[] args = new string[2]; // TODO: Initialize to an appropriate value

            args[0] = "2.0";
            args[1] = "5";
            


            object expected = "0,4"; // TODO: Initialize to an appropriate value
            object actual = target.run(args);
            Assert.AreEqual(expected, actual);
            
        }
    }
}
