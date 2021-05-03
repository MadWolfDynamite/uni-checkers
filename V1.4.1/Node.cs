using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersGame
{
    class Node<T>
        where T : IComparable {
        private T data;
        private int cost;

        public LinkedList<Node<Board> > child; //Public, so no need for functions

        //A constructor with a single parametre (the item which becomes the node)
        public Node(T item) {
            data = item;
            child = new LinkedList<Node<Board> >();

            cost = 0;
        }

        //A Function which modifies and returns the data stored in the node
        public T Data {
            set { data = value; }
            get { return data; }
        }

        //A function which modifies and returns the cost of the node
        public int Cost {
            set { cost = value; }
            get { return cost; }
        }

        //Checks if the node ends the game
        public bool isTerminal(int player, Board state) {
            bool terminalNode = false;

            switch (player) {
                case 0: //Light Player
                    if (state.RemainingLight() == 0)
                        terminalNode = true;
                    break;
                case 1: //Dark Player
                    if (state.RemainingDark() == 0)
                        terminalNode = true;
                    break;
            }

            if (state.LegalMoves(player) == 0) {
                terminalNode = true;
            }

            return terminalNode;
        }

        //Used to evaluate the cost of the node
        public int EvaluateNode(Board state) {
            int lightScore = 0, darkScore = 0;

            if (state.RemainingLight() == 0 || state.LegalMoves(0) == 0)
                return -999;
            if (state.RemainingDark() == 0 || state.LegalMoves(1) == 0)
                return 999;

            for(int r = 0; r < state.Size; r++)
                for (int c = 0; c < state.Size; c++) {
                    int[] location = {r, c};
                    switch(state.Status(location)) {
                        case 2:
                            if (r == 0 || r == state.Size - 1) {
                                if (c == 0 || c == state.Size - 1) {
                                    darkScore += 6;
                                    break;
                                }
                                if (c > 2 || c > state.Size - (state.Size / 2)) {
                                    darkScore += 4;
                                    break;
                                }
                            }
                            if (r > 2 || r > (state.Size / 2)) {
                                if (c == 0 || c == state.Size - 1) {
                                    darkScore += 4;
                                    break;
                                }
                                if (c > 2 || c > state.Size - (state.Size / 2)) {
                                    darkScore += 2;
                                    break;
                                }
                            }
                            if (c == 0 || c == state.Size - 1) {
                                    darkScore += 4;
                                    break;
                                }
                           if (c > 2 || c > state.Size - (state.Size / 2)) {
                                    darkScore += 2;
                                    break;
                           }
                           darkScore += 1;
                            break;
                        case 3:
                            if (r == 0 || r == state.Size - 1) {
                                if (c == 0 || c == state.Size - 1) {
                                    lightScore += 6;
                                    break;
                                }
                                if (c > 2 || c > state.Size - (state.Size / 2)) {
                                    lightScore += 4;
                                    break;
                                }
                            }
                            if (r > 2 || r > (state.Size / 2)) {
                                if (c == 0 || c == state.Size - 1) {
                                    lightScore += 4;
                                    break;
                                }
                                if (c > 2 || c > state.Size - (state.Size / 2)) {
                                    lightScore += 2;
                                    break;
                                }
                            }
                            if (c == 0 || c == state.Size - 1) {
                                lightScore += 4;
                                    break;
                            }
                           if (c > 2 || c > state.Size - (state.Size / 2)) {
                               lightScore += 2;
                               break;
                           }
                           lightScore += 1;
                            break;
                        case 4:
                            if (r == 0 || r == state.Size - 1) {
                                if (c == 0 || c == state.Size - 1) {
                                    darkScore += 12;
                                    break;
                                }
                                if (c > 2 || c > state.Size - (state.Size / 2)) {
                                    darkScore += 8;
                                    break;
                                }
                            }
                            if (r > 2 || r > (state.Size / 2)) {
                                if (c == 0 || c == state.Size - 1) {
                                    darkScore += 8;
                                    break;
                                }
                                if (c > 2 || c > state.Size - (state.Size / 2)) {
                                    darkScore += 4;
                                    break;
                                }
                            }
                            if (c == 0 || c == state.Size - 1) {
                                    darkScore += 8;
                                    break;
                                }
                           if (c > 2 || c > state.Size - (state.Size / 2)) {
                                    darkScore += 4;
                                    break;
                                }
                           darkScore += 2;
                            break;
                        case 5:
                            if (r == 0 || r == state.Size - 1) {
                                if (c == 0 || c == state.Size - 1) {
                                    lightScore += 12;
                                    break;
                                }
                                if (c > 2 || c > state.Size - (state.Size / 2)) {
                                    lightScore += 8;
                                    break;
                                }
                            }
                            if (r > 2 || r > (state.Size / 2)) {
                                if (c == 0 || c == state.Size - 1) {
                                    lightScore += 8;
                                    break;
                                }
                                if (c > 2 || c > state.Size - (state.Size / 2)) {
                                    lightScore += 4;
                                    break;
                                }
                            }
                            if (c == 0 || c == state.Size - 1) {
                                lightScore += 8;
                                    break;
                            }
                           if (c > 2 || c > state.Size - (state.Size / 2)) {
                               lightScore += 4;
                               break;
                           }
                           lightScore += 2;
                            break;
                    }
                }

            return (lightScore * state.RemainingLight()) - (darkScore * state.RemainingDark());
        }
    }
}
