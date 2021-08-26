using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeSpil
{
    public enum Player
    {
        Ingen = 0,
        Bolle = 1,
        Kryds = 2,
    }

    public class Game
    {
        public Player CurrentPlayer { get; private set; } = Player.Kryds;
        private readonly Player[] moves = new Player[9];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="move">Index of move, value between 0 and 9(excl.)</param>
        public void MakeMove(int move)
        {
            moves[move] = CurrentPlayer;
            CurrentPlayer = CurrentPlayer == Player.Kryds ? Player.Bolle : Player.Kryds;
        }

        public Player GetCell(int index)
        {
            return moves[index];
        }

        public Player? CheckWinConditions()
        {
            if (moves[0] == moves[1] && moves[0] == moves[2])
            {
                if (moves[0] != Player.Ingen)
                {
                    return moves[0];
                }
            }
            if (moves[3] == moves[4] && moves[3] == moves[5])
            {
                if (moves[3] != Player.Ingen)
                {
                    return moves[3];
                }
            }
            if (moves[6] == moves[7] && moves[6] == moves[8])
            {
                if (moves[6] != Player.Ingen)
                {
                    return moves[6];
                }
            }
            if (moves[0] == moves[3] && moves[0] == moves[6])
            {
                if (moves[0] != Player.Ingen)
                {
                    return moves[0];
                }
            }
            if (moves[1] == moves[4] && moves[1] == moves[7])
            {
                if (moves[1] != Player.Ingen)
                {
                    return moves[1];
                }
            }
            if (moves[2] == moves[5] && moves[2] == moves[8])
            {
                if (moves[2] != Player.Ingen)
                {
                    return moves[2];
                }
            }
            if (moves[0] == moves[4] && moves[0] == moves[8])
            {
                if (moves[0] != Player.Ingen)
                {
                    return moves[0];
                }
            }
            if (moves[2] == moves[4] && moves[2] == moves[6])
            {
                if (moves[2] != Player.Ingen)
                {
                    return moves[2];
                }
            }

            if (!moves.Contains(Player.Ingen))
            {
                return Player.Ingen;
            }

            return null;
        }

    }
}
