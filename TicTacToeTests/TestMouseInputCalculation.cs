using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeSpil;

namespace TicTacToeTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestMouseInputCalculation
    {
        [TestMethod]
        public void TestInputOutsideBoard()
        {
            int? result = Program.CheckInput(30,  30);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestInputOnBorder()
        {
            int? result = Program.CheckInput(0, 8);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestInputInsideCell()
        {
            int? result = Program.CheckInput(1, 1);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestInputInsideCellFurther()
        {
            int? result = Program.CheckInput(5, 5);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestInputInsideCellEvenFurther()
        {
            int? result = Program.CheckInput(11, 11);

            Assert.AreEqual(4, result);
        }
    }
}
