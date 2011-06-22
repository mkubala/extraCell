﻿using extraCell.formula.functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for minTest and is intended
    ///to contain all minTest Unit Tests
    ///</summary>
    [TestClass()]
    public class minTest
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
        public void min_1_2_3()
        {
            min target = new min(); // TODO: Initialize to an appropriate value
            object[] args = new string[3]; // TODO: Initialize to an appropriate value

            args[0] = "1";
            args[1] = "2";
            args[2] = "3";


            object expected = "1"; // TODO: Initialize to an appropriate value
            object actual = target.run(args);
            actual = target.run(args);
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void min_5_1_6_7()
        {
            min target = new min(); // TODO: Initialize to an appropriate value
            object[] args = new string[4]; // TODO: Initialize to an appropriate value

            args[0] = "5";
            args[1] = "1";
            args[2] = "6";
            args[3] = "7";


            object expected = "1"; // TODO: Initialize to an appropriate value
            object actual = target.run(args);
            actual = target.run(args);
            Assert.AreEqual(expected, actual);

        }
    }
}
