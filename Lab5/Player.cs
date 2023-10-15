using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab5 {
    internal class Player {

        public static int size;
        private int allDistance = 0;
        private int xPoses;

        public Player() : this(0) {
        }
        public Player(int startPos) {
            this.xPoses = startPos; 
        }

        public int XPoses { get { return xPoses; } }
        public int AllDistance { get { return allDistance; } }

        public void changePosition(int changeValue) {
            this.allDistance += Math.Abs(changeValue) * (this.xPoses == -1 ? 0 : 1);
            if (changeValue >= 0) {
                this.xPoses = (xPoses + changeValue) % Math.Max(size, 1);
            } else {
                this.xPoses = (xPoses + changeValue + size - 1) % Math.Max(size, 1);
            }
        }

        public static int getDistance(Player player1, Player player2) {
            return Math.Abs(player1.XPoses - player2.XPoses);
        }

    }
}
