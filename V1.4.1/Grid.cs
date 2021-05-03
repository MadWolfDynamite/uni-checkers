using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersGame
{
    class Grid {
        private int status, legalMoves;
        private int[] legalFLeft, legalFRight, legalBLeft, legalBRight;
        private LinkedList<int[]> moveStoreFL, moveStoreFR, moveStoreBL, moveStoreBR; //Saves the number of pieces required to delete

        //A constructor with no parametres
        public Grid() {
            status = 0;
            legalMoves = 0;

            legalFLeft = new int[2];
            legalFLeft[0] = 99;
            legalFLeft[1] = 99;

            legalFRight = new int[2];
            legalFRight[0] = 99;
            legalFRight[1] = 99;

            legalBLeft = new int[2];
            legalBLeft[0] = 99;
            legalBLeft[1] = 99;

            legalBRight = new int[2];
            legalBRight[0] = 99;
            legalBRight[1] = 99;

            moveStoreFL = new LinkedList<int[]>();
            moveStoreFR = new LinkedList<int[]>();
            moveStoreBL = new LinkedList<int[]>();
            moveStoreBR = new LinkedList<int[]>();
        }

        //A constructor with a single parametre (status)
        public Grid(int state) {
            status = state;
            legalMoves = 0;

            legalFLeft = new int[2];
            legalFLeft[0] = 99;
            legalFLeft[1] = 99;

            legalFRight = new int[2];
            legalFRight[0] = 99;
            legalFRight[1] = 99;

            legalBLeft = new int[2];
            legalBLeft[0] = 99;
            legalBLeft[1] = 99;

            legalBRight = new int[2];
            legalBRight[0] = 99;
            legalBRight[1] = 99;

            moveStoreFL = new LinkedList<int[]>();
            moveStoreFR = new LinkedList<int[]>();
            moveStoreBL = new LinkedList<int[]>();
            moveStoreBR = new LinkedList<int[]>();
        }

        //A function which modifies and returns the state of the board space
        public int Status {
            set { status = value; }
            get { return status; }
        }

        //A function which sets and receives the front left legal move of the board space
        public int[] MoveFL {
            set { 
                legalFLeft = value;
                legalMoves++;
            }
            get { return legalFLeft; }
        }
        //A function which sets and receives the front right legal move of the board space
        public int[] MoveFR {
            set { legalFRight = value; 
                legalMoves++;
            }
            get { return legalFRight; }
        }
        //A function which sets and receives the rear left legal move of the board space
        public int[] MoveBL {
            set { legalBLeft = value; 
             legalMoves++;
            }
            get { return legalBLeft; }
        }
        //A function which sets and receives the rear right legal move of the board space
        public int[] MoveBR {
            set {
                legalBRight = value; 
                legalMoves++;
            }
            get { return legalBRight; }
        }

        //A function which sends the total legal moves to an external source
        public int LegalMoves {
            get { return legalMoves; }
        }

        //A function which clears and resets the state of the legal moves for the next player's move
        public void ResetMoves() {
            legalFLeft[0] = 99;
            legalFLeft[1] = 99;
    
            legalFRight[0] = 99;
            legalFRight[1] = 99;
    
            legalBLeft[0] = 99;
            legalBLeft[1] = 99;
    
            legalBRight[0] = 99;
            legalBRight[1] = 99;
    
            legalMoves = 0;

            moveStoreFL = new LinkedList<int[]>();
            moveStoreFR = new LinkedList<int[]>();
            moveStoreBL = new LinkedList<int[]>();
            moveStoreBR = new LinkedList<int[]>();
        }

        //A function which adds to the specific moveStore for each direction
        public void DeletePiece(int direction, int[] location) {
            switch (direction) {
                case 1: //Forward Left
                    moveStoreFL.AddFirst(location);
                    break;
                case 2: //Forward Right
                    moveStoreFR.AddFirst(location);
                    break;
                case 3: //Backwards Left
                    moveStoreBL.AddFirst(location);
                    break;
                case 4: //Backwards Right
                    moveStoreBR.AddFirst(location);
                    break;
                default:
                    break;
            }
        }

        //A function which returns the specific moveStore for each direction
        public LinkedList<int[]> GetStoredMoves(int direction) {
            switch (direction) {
                case 1: //Forward Left
                    return moveStoreFL;
                case 2: //Forward Right
                    return moveStoreFR;
                case 3: //Backwards Left
                    return moveStoreBL;
                case 4: //Backwards Right
                    return moveStoreBR;
            }
            return null;
        }

        //Used for cross class comparisons
        public bool Equals(Grid other) {
            if (status != other.status)
                return false;

            if (legalFLeft[0] != other.legalFLeft[0] || legalFLeft[1] != other.legalFLeft[1])
                return false;
            if (legalFRight[0] != other.legalFRight[0] || legalFRight[1] != other.legalFRight[1])
                return false;
            if (legalBLeft[0] != other.legalBLeft[0] || legalBLeft[1] != other.legalBLeft[1])
                return false;
            if (legalBRight[0] != other.legalBRight[0] || legalBRight[1] != other.legalBRight[1])
                return false;

            return true;

        }

        //Copies an instance of another class
        public void Copy(Grid other) {
            status = other.status;
            legalMoves = other.legalMoves;

            legalFLeft = other.legalFLeft;
            legalFRight = other.legalFRight;

            legalBLeft = other.legalBLeft;
            legalBRight = other.legalBRight;

            moveStoreFL = other.moveStoreFL;
            moveStoreFR = other.moveStoreFR;
            moveStoreBL = other.moveStoreBL;
            moveStoreBR = other.moveStoreBR;
        }
    }
}
