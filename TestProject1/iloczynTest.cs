﻿using extraCell.formula.functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{


    /// <summary>
    ///This is a test class for iloczynTest and is intended
    ///to contain all iloczynTest Unit Tests
    ///</summary>
    [TestClass()]
    public class iloczynTest
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
        public void mnozenie_2_liczb()
        {
            iloczyn target = new iloczyn(); // TODO: Initialize to an appropriate value
            object[] args = new string[2]; // TODO: Initialize to an appropriate value

            args[0] = "2.0";
            args[1] = "5.5";


            object expected = "11"; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.run(args);
            Assert.AreEqual(expected, actual);
            // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for run
        ///</summary>
        [TestMethod()]
        public void mnozenie_3_liczb()
        {
            iloczyn target = new iloczyn(); // TODO: Initialize to an appropriate value
            object[] args = new string[3]; // TODO: Initialize to an appropriate value

            args[0] = "2.0";
            args[1] = "5";
            args[2] = "2.5";


            object expected = "25"; // TODO: Initialize to an appropriate value
            object actual = target.run(args);
            Assert.AreEqual(expected, actual);
        
        }
    }
}
