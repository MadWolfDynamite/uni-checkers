using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersGame
{
    class GameTree {
        private int maxDepth;
        private Node<Board> root;

        //A constructor with no parametres
        public GameTree() {
            maxDepth = 2;
            root = null;
        }

        //A function which changes the maximum depth of the tree
        public int Depth {
            set { maxDepth = value; }
        }

        //A function which generates and evaluates all possible moves to the specified depth
        public void GenerateMoves(Board state, int side) {
            root = new Node<Board>(state);
            generateMoves(state, side, ref root, 0);
        }
        private void generateMoves(Board state, int side, ref Node<Board> tree, int depth) { //recursive variation of previous function
            if (depth > maxDepth)
                return;

            int[] move;
            LinkedList<int[]> result = new LinkedList<int[]>();
            LinkedList<int[]> moveSet = new LinkedList<int[]>();

            state.StateCheck();

            for (int r = 0; r < state.Size; r++)
                for (int c = 0; c < state.Size; c++) {
                    int[] location = { r, c };

                    switch (side % 2) {
                        case 0: //Light Player
                            switch (state.Status(location)) {
                                case 3:
                                case 5:
                                    move = state.MoveFL(location);
                                    if (move[0] != 99) {
                                        result.AddLast(location);
                                        moveSet.AddLast(move);
                                    }   
                                    move = state.MoveFR(location);
                                    if (move[0] != 99) {
                                        result.AddLast(location);
                                        moveSet.AddLast(move);
                                    }

                                    move = state.MoveBL(location);
                                    if (move[0] != 99) {
                                        result.AddLast(location);
                                        moveSet.AddLast(move);
                                    }   
                                    move = state.MoveBR(location);
                                    if (move[0] != 99) {
                                        result.AddLast(location);
                                        moveSet.AddLast(move);
                                    }
                                    break;
                                }
                            break;
                        case 1: //Dark Player
                            switch (state.Status(location)) {
                                case 2:
                                case 4:
                                    move = state.MoveFL(location);
                                    if (move[0] != 99) {
                                        result.AddLast(location);
                                        moveSet.AddLast(move);
                                    }
                                    move = state.MoveFR(location);
                                    if (move[0] != 99) {
                                        result.AddLast(location);
                                        moveSet.AddLast(move);
                                    }

                                    move = state.MoveBL(location);
                                    if (move[0] != 99) {
                                        result.AddLast(location);
                                        moveSet.AddLast(move);
                                    }
                                    move = state.MoveBR(location);
                                    if (move[0] != 99 ) {
                                        result.AddLast(location);
                                        moveSet.AddLast(move);
                                    }
                                    break;
                            }
                            break;
                    }
                }

            int i = 0;
            
            foreach (int[] index in result) {
                Board temp = new Board();
                temp.Copy(state);
                temp.StateCheck();

                int[] newMove = moveSet.ElementAt(i);

                temp.SelectMove(index, (side % 2) + 1);
                temp.UpdateBoard(newMove);
                tree.child.AddLast(new Node<Board>(temp));

                Node<Board> childNode = tree.child.ElementAt(i);
                generateMoves(childNode.Data, (side + 1) % 2, ref childNode, depth + 1);

                i++;
            }
        } //end of 'generateMoves'
        private void evalMoves(int depth) {
            foreach (Node<Board> index in root.child) {
                index.Cost = minMove(index, maxDepth);
            }
        }
        //Functions which evaluates the moves for the Computer
        private int maxMove(Node<Board> tree, int depth) {
            tree.Data.StateCheck();

            if (depth == 0 || tree.isTerminal(depth % 2,tree.Data))
                return tree.EvaluateNode(tree.Data);

            int max = -9999;
            foreach (Node<Board> index in tree.child) {
                int score = minMove(index, depth - 1);
                if (score > max)
                    max = score;
            }

            return max;
        }
        private int minMove(Node<Board> tree, int depth) {
            if (depth == 0 || tree.isTerminal(depth % 2, tree.Data))
                return tree.EvaluateNode(tree.Data);

            int min = 9999;
            foreach (Node<Board> index in tree.child)
            {
                int score = maxMove(index, depth - 1);
                if (score < min)
                    min = score;
            }

            return min;
        }

        //A function which returns the optimal move for the Computer
        public Board SelectMove() {
            Board result = null;
            int max = -9999;

            foreach (Node<Board> index in root.child) {
                if (index.Cost > max) {
                    max = index.Cost;
                    result = index.Data;
                }

            }

            return result;
        }  
    }
}
