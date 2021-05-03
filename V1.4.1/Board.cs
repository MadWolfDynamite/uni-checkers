using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersGame {
    class Board : IComparable {
        private Grid[,] boardState;

        private int rows, cols;
        private int darkTotal, lightTotal;

        private int[] activeSpace = { 99, 99 };

        //A Construtor with no parametres
        public Board() {
            rows = 8;
            cols = 8;

            darkTotal = 0;
            lightTotal = 0;

            boardState = new Grid[rows, cols];
        }

        //A Construtor with a single parametre (Board Size)
        public Board(int size) {
            rows = size;
            cols = size;

            darkTotal = 0;
            lightTotal = 0;

            boardState = new Grid[rows, cols];
        }

        //A Function which initialises the game (and the board spaces)
        public void StartGame(int mode) {
            switch (mode) {
                case 1: //English Variation
                    for (int r = 0; r < rows; r++)
                        for (int c = 0; c < cols; c++) {
                            if (r % 2 == 0) {
                                if (c % 2 == 1) {
                                    boardState[r,c] = new Grid(1);

                                    if (r < 3) {
                                        boardState[r,c].Status = 3;
                                        lightTotal++;
                                    }
                                    else if (r > 4) {
                                        boardState[r,c].Status = 2;
                                        darkTotal++;
                                    }
                                }
                                else
                                    boardState[r,c] = new Grid();
                            }
                            else {
                                if (c % 2 == 0) {
                                    boardState[r,c] = new Grid(1);

                                    if (r < 3) {
                                        boardState[r,c].Status = 3;
                                        lightTotal++;
                                    }
                                    else if (r > 4) {
                                        boardState[r,c].Status = 2;
                                        darkTotal++;
                                    }
                                }
                                else
                                    boardState[r,c] = new Grid();
                            }
                        }
                    break;
                case 2: //International Variation
                    break;
                default: //For GameTree
                    for (int r = 0; r < rows; r++)
                        for (int c = 0; c < cols; c++)
                            boardState[r, c] = new Grid();
                    return;
            }
        }

        //A Function which outputs the board (returns the corresponding image)
        public String Draw(int[] selection) {
            String result = null;

            switch (boardState[selection[0], selection[1]].Status) {
                case 0: //Dark (Blocked) Space
                    result = "Images/BoardSpace_Blocked.png";
                    break;
                case 1: //Light (Vacant) Space
                    result = "Images/BoardSpace_Vacant.png";
                    if (legalDirection(selection) != 0)
                        result = "Images/BoardSpace_VacantLegal.png";
                    break;
                case 2: //Dark Piece (Man)
                    result = "Images/BoardSpace_DarkMan.png";
                    if (selection[0] == activeSpace[0] && selection[1] == activeSpace[1])
                        result = "Images/BoardSpace_DarkManActive.png";
                    break;
                case 3: //Light Piece (Man)
                    result = "Images/BoardSpace_LightMan.png";
                    if (selection[0] == activeSpace[0] && selection[1] == activeSpace[1])
                        result = "Images/BoardSpace_LightManActive.png";
                    break;
                case 4: //Dark Piece (King)
                    result = "Images/BoardSpace_DarkKing.png";
                    if (selection[0] == activeSpace[0] && selection[1] == activeSpace[1])
                        result = "Images/BoardSpace_DarkKingActive.png";
                    break;
                case 5: //Light Piece (King)
                    result = "Images/BoardSpace_LightKing.png";
                    if (selection[0] == activeSpace[0] && selection[1] == activeSpace[1])
                        result = "Images/BoardSpace_LightKingActive.png";
                    break;
            }

            return result;
        }

        //A Function which Selects the space on the board
        public void SelectMove(int[] selection, int playerSide) {
            if (selection[0] == activeSpace[0] && selection[1] == activeSpace[1]) {
                activeSpace[0] = 99;
                activeSpace[1] = 99;
                return;
            }

            switch (playerSide) {
                case 0: //Dark Player
                    switch (boardState[selection[0], selection[1]].Status) {
                        case 2:
                        case 4:
                            if (boardState[selection[0], selection[1]].LegalMoves > 0)
                                activeSpace = selection;
                            break;
                    }
                    break;
                case 1: //Light Player
                    switch (boardState[selection[0], selection[1]].Status) {
                        case 3:
                        case 5:
                            if (boardState[selection[0], selection[1]].LegalMoves > 0)
                                activeSpace = selection;
                            break;
                    }
                    break;
            }
        }

        //A Function which modifes and returns the size of the board
        public int Size {
            set {
                rows = value;
                cols = value;
            }
            get { return rows; }
        }

        //A function which returns the status of a specific location
        public int Status(int[] selection) {
            return boardState[selection[0],selection[1]].Status;
        }

        //Set of functions which return the specific location of the legal moves for a specific space
        public int[] MoveFL(int[] selection) {
            return boardState[selection[0],selection[1]].MoveFL;
        }
        public int[] MoveFR(int[] selection) {
            return boardState[selection[0],selection[1]].MoveFR;
        }
        public int[] MoveBL(int[] selection)  {
            return boardState[selection[0],selection[1]].MoveBL;
        }
        public int[] MoveBR(int[] selection) {
            return boardState[selection[0],selection[1]].MoveBR;
        }

        //Checks if the space is legal (for the active space)
        public Boolean isLegal(int[] selection) {
            if (activeSpace[0] == 99)
                return false;

            int[] move = boardState[activeSpace[0], activeSpace[1]].MoveFL;
            if (move[0] == selection[0] && move[1] == selection[1])
                return true;

            move = boardState[activeSpace[0], activeSpace[1]].MoveFR;
            if (move[0] == selection[0] && move[1] == selection[1])
                return true;

            move = boardState[activeSpace[0], activeSpace[1]].MoveBL;
            if (move[0] == selection[0] && move[1] == selection[1])
                return true;

            move = boardState[activeSpace[0], activeSpace[1]].MoveBR;
            if (move[0] == selection[0] && move[1] == selection[1])
                return true;

            return false;
        }

        //Gets the direction of the legal space
        public int legalDirection(int[] selection) {
            if (activeSpace[0] == 99)
                return 0;

            int[] move = boardState[activeSpace[0], activeSpace[1]].MoveFL;
            if (move[0] == selection[0] && move[1] == selection[1])
                return 1;

            move = boardState[activeSpace[0], activeSpace[1]].MoveFR;
            if (move[0] == selection[0] && move[1] == selection[1])
                return 2;

            move = boardState[activeSpace[0], activeSpace[1]].MoveBL;
            if (move[0] == selection[0] && move[1] == selection[1])
                return 3;

            move = boardState[activeSpace[0], activeSpace[1]].MoveBR;
            if (move[0] == selection[0] && move[1] == selection[1])
                return 4;

            return 0;
        }

        //A Function which checks the current state of the board
        public void StateCheck() {
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++) {
                    switch (boardState[r,c].Status) {
                        case 2: //Dark Man
                            if (r > 0) {
                                if (c > 0) { //Forward Left
                                    int[] result = {r - 1,c - 1};

                                    switch (boardState[result[0], result[1]].Status) {
                                        case 1:
                                            boardState[r, c].MoveFL = result;
                                            break;
                                        case 3:
                                        case 5:
                                            if (result[0] > 0 && result[1] > 0) {
                                                int[] newResult = { result[0] - 1, result[1]- 1};

                                                if (boardState[newResult[0], newResult[1]].Status == 1) {
                                                    boardState[r, c].MoveFL = newResult;

                                                    boardState[r, c].DeletePiece(1, result);
                                                    stateCheck(ref boardState[r, c], newResult, 1);
                                                }
                                            }
                                            break;
                                    }
                                }
                                if (c < cols - 1) { //Forward Right
                                    int[] result = { r - 1, c + 1 };

                                    switch (boardState[result[0], result[1]].Status) {
                                        case 1:
                                            boardState[r, c].MoveFR = result;
                                            break;
                                        case 3:
                                        case 5:
                                            if (result[0] > 0 && result[1] < cols - 1) {
                                                int[] newResult = { result[0] - 1, result[1] + 1 };

                                                if (boardState[newResult[0], newResult[1]].Status == 1) {
                                                    boardState[r, c].MoveFR = newResult;

                                                    boardState[r, c].DeletePiece(2, result);
                                                    stateCheck(ref boardState[r, c], newResult, 2);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                            break;

                        case 3: //Light Man
                            if (r < rows - 1) {
                                if (c > 0) { //Forward Left
                                    int[] result = { r + 1, c - 1 };

                                    switch (boardState[result[0], result[1]].Status) {
                                        case 1:
                                            boardState[r, c].MoveFL = result;
                                            break;
                                        case 2:
                                        case 4:
                                            if (result[0] < rows - 1 && result[1] > 0) {
                                                int[] newResult = { result[0] + 1, result[1] - 1 };

                                                if (boardState[newResult[0], newResult[1]].Status == 1) {
                                                    boardState[r, c].MoveFL = newResult;

                                                    boardState[r, c].DeletePiece(1, result);
                                                    stateCheck(ref boardState[r, c], newResult, 1);
                                                }
                                            }
                                            break;
                                    }
                                }
                                if (c < cols - 1) { //Forward Right
                                    int[] result = { r + 1, c + 1 };

                                    switch (boardState[result[0], result[1]].Status) {
                                        case 1:
                                            boardState[r, c].MoveFR = result;
                                            break;
                                        case 2:
                                        case 4:
                                            if (result[0] < rows - 1 && result[1] < cols - 1) {
                                                int[] newResult = { result[0] + 1, result[1] + 1 };

                                                if (boardState[newResult[0], newResult[1]].Status == 1) {
                                                    boardState[r, c].MoveFR = newResult;

                                                    boardState[r, c].DeletePiece(2, result);
                                                    stateCheck(ref boardState[r, c], newResult, 2);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                            break;
                        case 4: //Dark King
                            if (r > 0) {
                                if (c > 0) { //Forward Left
                                    int[] result = { r - 1, c - 1 };

                                    switch (boardState[result[0], result[1]].Status) {
                                        case 1:
                                            boardState[r, c].MoveFL = result;
                                            break;
                                        case 3:
                                        case 5:
                                            if (result[0] > 0 && result[1] > 0) {
                                                int[] newResult = { result[0] - 1, result[1] - 1 };

                                                if (boardState[newResult[0], newResult[1]].Status == 1) {
                                                    boardState[r, c].MoveFL = newResult;

                                                    boardState[r, c].DeletePiece(1, result);
                                                    stateCheck(ref boardState[r, c], newResult, 1);
                                                }
                                            }
                                            break;
                                    }
                                }
                                if (c < cols - 1) { //Forward Right
                                    int[] result = { r - 1, c + 1 };

                                    switch (boardState[result[0], result[1]].Status) {
                                        case 1:
                                            boardState[r, c].MoveFR = result;
                                            break;
                                        case 3:
                                        case 5:
                                            if (result[0] > 0 && result[1] < cols - 1) {
                                                int[] newResult = { result[0] - 1, result[1] + 1 };

                                                if (boardState[newResult[0], newResult[1]].Status == 1) {
                                                    boardState[r, c].MoveFR = newResult;

                                                    boardState[r, c].DeletePiece(2, result);
                                                    stateCheck(ref boardState[r, c], newResult, 2);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }

                            if (r < rows - 1) {
                                if (c > 0) { //Backward Left
                                    int[] result = { r + 1, c - 1 };

                                    switch (boardState[result[0], result[1]].Status) {
                                        case 1:
                                            boardState[r, c].MoveBL = result;
                                            break;
                                        case 3:
                                        case 5:
                                            if (result[0] < rows - 1 && result[1] > 0) {
                                                int[] newResult = { result[0] + 1, result[1] - 1 };

                                                if (boardState[newResult[0], newResult[1]].Status == 1) {
                                                    boardState[r, c].MoveBL = newResult;

                                                    boardState[r, c].DeletePiece(3, result);
                                                    stateCheck(ref boardState[r, c], newResult, 3);
                                                }
                                            }
                                            break;
                                    }
                                }
                                if (c < cols - 1) { //Backward Right
                                    int[] result = { r + 1, c + 1 };

                                    switch (boardState[result[0], result[1]].Status) {
                                        case 1:
                                            boardState[r, c].MoveBR = result;
                                            break;
                                        case 3:
                                        case 5:
                                            if (result[0] < rows - 1 && result[1] < cols - 1) {
                                                int[] newResult = { result[0] + 1, result[1] + 1 };

                                                if (boardState[newResult[0], newResult[1]].Status == 1) {
                                                    boardState[r, c].MoveBR = newResult;

                                                    boardState[r, c].DeletePiece(4, result);
                                                    stateCheck(ref boardState[r, c], newResult, 4);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                            break;
                        case 5: //Light King (Directions from Dark's Perspective)
                            if (r > 0) {
                                if (c > 0) { //Forward Left
                                    int[] result = { r - 1, c - 1 };

                                    switch (boardState[result[0], result[1]].Status) {
                                        case 1:
                                            boardState[r, c].MoveFL = result;
                                            break;
                                        case 2:
                                        case 4:
                                            if (result[0] > 0 && result[1] > 0) {
                                                int[] newResult = { result[0] - 1, result[1] - 1 };

                                                if (boardState[newResult[0], newResult[1]].Status == 1) {
                                                    boardState[r, c].MoveFL = newResult;

                                                    boardState[r, c].DeletePiece(1, result);
                                                    stateCheck(ref boardState[r, c], newResult, 1);
                                                }
                                            }
                                            break;
                                    }
                                }
                                if (c < cols - 1) { //Forward Right
                                    int[] result = { r - 1, c + 1 };

                                    switch (boardState[result[0], result[1]].Status) {
                                        case 1:
                                            boardState[r, c].MoveFR = result;
                                            break;
                                        case 2:
                                        case 4:
                                            if (result[0] > 0 && result[1] < cols - 1) {
                                                int[] newResult = { result[0] - 1, result[1] + 1 };

                                                if (boardState[newResult[0], newResult[1]].Status == 1) {
                                                    boardState[r, c].MoveFR = newResult;

                                                    boardState[r, c].DeletePiece(2, result);
                                                    stateCheck(ref boardState[r, c], newResult, 2);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }

                            if (r < rows - 1) {
                                if (c > 0) { //Backward Left
                                    int[] result = { r + 1, c - 1 };

                                    switch (boardState[result[0], result[1]].Status) {
                                        case 1:
                                            boardState[r, c].MoveBL = result;
                                            break;
                                        case 2:
                                        case 4:
                                            if (result[0] < rows - 1 && result[1] > 0) {
                                                int[] newResult = { result[0] + 1, result[1] - 1 };

                                                if (boardState[newResult[0], newResult[1]].Status == 1) {
                                                    boardState[r, c].MoveBL = newResult;

                                                    boardState[r, c].DeletePiece(3, result);
                                                    stateCheck(ref boardState[r, c], newResult, 3);
                                                }
                                            }
                                            break;
                                    }
                                }
                                if (c < cols - 1) { //Backward Right
                                    int[] result = { r + 1, c + 1 };

                                    switch (boardState[result[0], result[1]].Status) {
                                        case 1:
                                            boardState[r, c].MoveBR = result;
                                            break;
                                        case 2:
                                        case 4:
                                            if (result[0] < rows - 1 && result[1] < cols - 1) {
                                                int[] newResult = { result[0] + 1, result[1] + 1 };

                                                if (boardState[newResult[0], newResult[1]].Status == 1) {
                                                    boardState[r, c].MoveBR = newResult;

                                                    boardState[r, c].DeletePiece(4, result);
                                                    stateCheck(ref boardState[r, c], newResult, 4);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                            break;
                    }
                }

        }
        private void stateCheck(ref Grid start, int[] location, int direction) { //Recursive variation for deleting more pieces
            switch (start.Status) {
                case 2: //Dark Man
                    if (location[0] > 0) {
                        if (location[1] > 0) { //Forward Left
                            int[] result = { location[0] - 1, location[1] - 1 };

                            switch (boardState[result[0], result[1]].Status) {
                                case 3:
                                case 5:
                                    if (result[0] > 0 && result[1] > 0)
                                    {
                                        int[] newResult = { result[0] - 1, result[1] - 1 };

                                        if (boardState[newResult[0], newResult[1]].Status == 1)
                                        {
                                            start.MoveFL = newResult;

                                            start.DeletePiece(1, result);
                                            stateCheck(ref start, newResult, direction);
                                        }
                                    }
                                    break;
                            }
                        }
                        if (location[1] < cols - 1) { //Forward Right
                            int[] result = { location[0] - 1, location[1] + 1 };

                            switch (boardState[result[0], result[1]].Status) {
                                case 3:
                                case 5:
                                    if (result[0] > 0 && result[1] < cols - 1) {
                                        int[] newResult = { result[0] - 1, result[1] + 1 };

                                        if (boardState[newResult[0], newResult[1]].Status == 1) {
                                            start.MoveFR = newResult;

                                            start.DeletePiece(direction, result);
                                            stateCheck(ref start, newResult, direction);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;

                case 3: //Light Man
                    if (location[0] < rows - 1) {
                        if (location[1] > 0) { //Forward Left
                            int[] result = { location[0] + 1, location[1] - 1 };

                            switch (boardState[result[0], result[1]].Status) {
                                case 2:
                                case 4:
                                    if (result[0] < rows - 1 && result[1] > 0) {
                                        int[] newResult = { result[0] + 1, result[1] - 1 };

                                        if (boardState[newResult[0], newResult[1]].Status == 1) {
                                            start.MoveFL = newResult;

                                            start.DeletePiece(1, result);
                                            stateCheck(ref start, newResult, direction);
                                        }
                                    }
                                    break;
                            }
                        }
                        if (location[1] < cols - 1) { //Forward Right
                            int[] result = { location[0] + 1, location[1] + 1 };

                            switch (boardState[result[0], result[1]].Status) {
                                case 2:
                                case 4:
                                    if (result[0] < rows - 1 && result[1] < cols - 1) {
                                        int[] newResult = { result[0] + 1, result[1] + 1 };

                                        if (boardState[newResult[0], newResult[1]].Status == 1) {
                                            start.MoveFR = newResult;

                                            start.DeletePiece(direction, result);
                                            stateCheck(ref start, newResult, direction);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case 4: //Dark King
                    if (location[0] > 0) {
                        if (location[1] > 0) { //Forward Left
                            int[] result = { location[0] - 1, location[1] - 1 };

                            switch (boardState[result[0], result[1]].Status) {
                                case 3:
                                case 5:
                                    if (result[0] > 0 && result[1] > 0) {
                                        int[] newResult = { result[0] - 1, result[1] - 1 };

                                        if (boardState[newResult[0], newResult[1]].Status == 1) {
                                            start.MoveFL = newResult;

                                            start.DeletePiece(1, result);
                                            stateCheck(ref start, newResult, direction);
                                        }
                                    }
                                    break;
                            }
                        }
                        if (location[1] < cols - 1) { //Forward Right
                            int[] result = { location[0] - 1, location[1] + 1 };

                            switch (boardState[result[0], result[1]].Status) {
                                case 3:
                                case 5:
                                    if (result[0] > 0 && result[1] < cols - 1) {
                                        int[] newResult = { result[0] - 1, result[1] + 1 };

                                        if (boardState[newResult[0], newResult[1]].Status == 1) {
                                            start.MoveFR = newResult;

                                            start.DeletePiece(direction, result);
                                            stateCheck(ref start, newResult, direction);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    if (location[0] < rows - 1) {
                        if (location[1] > 0) { //Backward Left
                            int[] result = { location[0] + 1, location[1] - 1 };

                            switch (boardState[result[0], result[1]].Status) {
                                case 3:
                                case 5:
                                    if (result[0] < rows - 1 && result[1] > 0) {
                                        int[] newResult = { result[0] + 1, result[1] - 1 };

                                        if (boardState[newResult[0], newResult[1]].Status == 1) {
                                            start.MoveBL = newResult;

                                            start.DeletePiece(direction, result);
                                            stateCheck(ref start, newResult, direction);
                                        }
                                    }
                                    break;
                            }
                        }
                        if (location[1] < cols - 1) { //Backward Right
                            int[] result = { location[0] + 1, location[1] + 1 };

                            switch (boardState[result[0], result[1]].Status) {

                                case 3:
                                case 5:
                                    if (result[0] < rows - 1 && result[1] < cols - 1) {
                                        int[] newResult = { result[0] + 1, result[1] + 1 };

                                        if (boardState[newResult[0], newResult[1]].Status == 1) {
                                            start.MoveBR = newResult;

                                            start.DeletePiece(direction, result);
                                            stateCheck(ref start, newResult, direction);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case 5: //Light King (Directions from Dark's Perspective)
                    if (location[0] > 0) {
                        if (location[1] > 0) { //Forward Left
                            int[] result = { location[0] - 1, location[1] - 1 };

                            switch (boardState[result[0], result[1]].Status) {
                                case 2:
                                case 4:
                                    if (result[0] > 0 && result[1] > 0) {
                                        int[] newResult = { result[0] - 1, result[1] - 1 };

                                        if (boardState[newResult[0], newResult[1]].Status == 1) {
                                            start.MoveFL = newResult;

                                            start.DeletePiece(1, result);
                                            stateCheck(ref start, newResult, direction);
                                        }
                                    }
                                    break;
                            }
                        }
                        if (location[1] < cols - 1) { //Forward Right
                            int[] result = { location[0] - 1, location[1] + 1 };

                            switch (boardState[result[0], result[1]].Status) {
                                case 2:
                                case 4:
                                    if (result[0] > 0 && result[1] < cols - 1) {
                                        int[] newResult = { result[0] - 1, result[1] + 1 };

                                        if (boardState[newResult[0], newResult[1]].Status == 1) {
                                            start.MoveFR = newResult;

                                            start.DeletePiece(direction, result);
                                            stateCheck(ref start, newResult, direction);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    if (location[0] < rows - 1) {
                        if (location[1] > 0) { //Backward Left
                            int[] result = { location[0] + 1, location[1] - 1 };

                            switch (boardState[result[0], result[1]].Status) {
                                case 2:
                                case 4:
                                    if (result[0] < rows - 1 && result[1] > 0) {
                                        int[] newResult = { result[0] + 1, result[1] - 1 };

                                        if (boardState[newResult[0], newResult[1]].Status == 1) {
                                            start.MoveBL = newResult;

                                            start.DeletePiece(direction, result);
                                            stateCheck(ref start, newResult, direction);
                                        }
                                    }
                                    break;
                            }
                        }
                        if (location[1] < cols - 1) { //Backward Right
                            int[] result = { location[0] + 1, location[1] + 1 };

                            switch (boardState[result[0], result[1]].Status) {

                                case 2:
                                case 4:
                                    if (result[0] < rows - 1 && result[1] < cols - 1) {
                                        int[] newResult = { result[0] + 1, result[1] + 1 };

                                        if (boardState[newResult[0], newResult[1]].Status == 1) {
                                            start.MoveBR = newResult;

                                            start.DeletePiece(direction, result);
                                            stateCheck(ref start, newResult, direction);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
            }
        }

        //A function which updates the state of the board (and remove any pieces if necessary)
        public void UpdateBoard(int[] newMove) {
            if (activeSpace[0] == 99 || !isLegal(newMove))
                return;

            LinkedList<int[]> extraPieces = new LinkedList<int[]>();

            int direction = legalDirection(newMove);
            if (direction == 0)
                return;

            switch (boardState[activeSpace[0],activeSpace[1]].Status) {
                case 2:
                case 4:
                    extraPieces = boardState[activeSpace[0], activeSpace[1]].GetStoredMoves(direction);

                    if (newMove[0] == 0 && boardState[activeSpace[0], activeSpace[1]].Status == 2)
                        boardState[activeSpace[0], activeSpace[1]].Status += 2;
                    break;
                case 3:
                case 5:
                    extraPieces = boardState[activeSpace[0], activeSpace[1]].GetStoredMoves(direction);

                    if (newMove[0] == rows - 1 && boardState[activeSpace[0], activeSpace[1]].Status == 3)
                        boardState[activeSpace[0], activeSpace[1]].Status += 2;
                    break;
            }

            boardState[newMove[0], newMove[1]].Status = boardState[activeSpace[0], activeSpace[1]].Status;
            boardState[activeSpace[0], activeSpace[1]].Status = 1;

            foreach (int[] index in extraPieces)
                boardState[index[0], index[1]].Status = 1;

            activeSpace[0] = 99;
            activeSpace[1] = 99;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    boardState[r,c].ResetMoves();
        }

        //A set of functions which returns the total remaining pieces for each player
        public int RemainingDark() {
            darkTotal = 0;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++) {
                    if (boardState[r, c].Status == 2 || boardState[r, c].Status == 4)
                        darkTotal++;
                }

            return darkTotal;
        }
        public int RemainingLight() {
            lightTotal = 0;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++) {
                    if (boardState[r, c].Status == 3 || boardState[r, c].Status == 5)
                        lightTotal++;
                }

            return lightTotal;
        }

        //A function which returns the total legal moves for each side
        public int LegalMoves(int side) {
            int result = 0;

            switch (side) {
                case 0: //Light Player
                    for (int r = 0; r < rows; r++)
                        for (int c = 0; c < cols; c++) {
                            if (boardState[r, c].Status == 3 || boardState[r, c].Status == 5)
                                result += boardState[r, c].LegalMoves;
                        }
                    break;
                case 1: //Dark Player
                    for (int r = 0; r < rows; r++)
                        for (int c = 0; c < cols; c++) {
                            if (boardState[r, c].Status == 2 || boardState[r, c].Status == 4)
                                result += boardState[r, c].LegalMoves;
                        }
                    break;
            }

            return result;
        }

        //Required for comparison in LinkList Class
        public int CompareTo(object obj) {
            int result = 0;
            Board other = (Board)obj;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    result += (boardState[r,c].Status - other.boardState[r,c].Status);

            return result;
        }

        //Used for cross class comparisons
        public bool Equals(Board other) {
            if (rows != other.rows || cols != other.cols)
                return false;

            if (darkTotal != other.darkTotal || lightTotal != other.lightTotal)
                return false;

            if (CompareTo(other) != 0)
                return false;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++) {
                    int[] move01 = boardState[r, c].MoveFL;
                    int[] move02 = other.boardState[r, c].MoveFL;

                    if (move01[0] != move02[0] || move01[1] != move02[1])
                        return false;

                    move01 = boardState[r, c].MoveFR;
                    move02 = other.boardState[r, c].MoveFR;

                    if (move01[0] != move02[0] || move01[1] != move02[1])
                        return false;

                    move01 = boardState[r, c].MoveBL;
                    move02 = other.boardState[r, c].MoveBL;

                    if (move01[0] != move02[0] || move01[1] != move02[1])
                        return false;

                    move01 = boardState[r, c].MoveBR;
                    move02 = other.boardState[r, c].MoveBR;

                    if (move01[0] != move02[0] || move01[1] != move02[1])
                        return false;
                }

            return true;
        }

        //Copies an instance of another board
        public void Copy(Board other) {
            rows = other.rows;
            cols = other.cols;

            darkTotal = other.darkTotal;
            lightTotal = other.lightTotal;

            boardState = new Grid[rows, cols];
            StartGame(0);

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++) {
                    boardState[r, c].Copy(other.boardState[r, c]);
                }
        }
    }
}
