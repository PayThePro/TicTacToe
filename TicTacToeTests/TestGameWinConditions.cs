using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TicTacToeSpil;

namespace TicTacToeTests
{
    [TestClass]
    public class TestGameWinConditions
    {
        [TestMethod]
        public void TestStraightLineWin()
        {
            Game game = new Game();
            game.MakeMove(0); // kryds
            game.MakeMove(5); // bolle
            game.MakeMove(1); // kryds
            game.MakeMove(6); // bolle
            game.MakeMove(2); // kryds

            Assert.AreEqual(Player.Kryds, game.CheckWinConditions());
        }
    }
}
