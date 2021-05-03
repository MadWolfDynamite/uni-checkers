using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckersGame {
    public partial class MainForm : Form {
        private PictureBox[,] boardGrid;
        private Board gameBoard;
        private int gameMode = 1, player = 0, boardSize = 8;

        private GameTree opponent = new GameTree();

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            buildBoard(boardSize);
            drawBoard(boardSize);

            normalRadio.Select();
        }

        private void buildBoard(int size) { //Draws the arrary of Pictureboxes
            int xPos = 0;
            int yPos = 0;

            boardGrid = new PictureBox[size,size];

            gameBoard = new Board(size);
            gameBoard.StartGame(gameMode);
            gameBoard.StateCheck();

            for(int r = 0; r < size; r++)
                for (int c = 0; c < size; c++) {
                    boardGrid[r,c] = new PictureBox();

                    boardGrid[r, c].Tag = r + "-" + c;
                    boardGrid[r, c].Width = 65;
                    boardGrid[r, c].Height = 65;

                    xPos = 15 + boardGrid[r, c].Width * c;
                    yPos = 20 + boardGrid[r, c].Width * r;

                    boardGrid[r, c].Left = xPos;
                    boardGrid[r, c].Top = yPos;

                    boardBox.Controls.Add(boardGrid[r, c]);
                    boardGrid[r, c].SizeMode = PictureBoxSizeMode.StretchImage;

                    boardGrid[r, c].Click += new System.EventHandler(selectSpace);
                }
        }

        private void selectSpace(object sender, EventArgs e) {
            PictureBox result = (PictureBox)sender;

            String[] spaceID = result.Tag.ToString().Select(c => c.ToString()).ToArray();
            int[] idResult = {Convert.ToInt32(spaceID[0]),Convert.ToInt32(spaceID[2])};

            if (gameBoard.Status(idResult) == 1) {
                if (gameBoard.isLegal(idResult)) {
                    gameBoard.UpdateBoard(idResult);
                    gameBoard.StateCheck();

                    if (!isTerminal()) {
                        opponent.GenerateMoves(gameBoard, player);
                        gameBoard = opponent.SelectMove();
                        gameBoard.StateCheck();
                    }
                    else
                        endGame();
                }
            }
            else
                gameBoard.SelectMove(idResult, player);

            drawBoard(boardSize);
        }

        private void drawBoard(int size) {
            for(int r = 0; r < size; r++)
                for (int c = 0; c < size; c++) {
                    int[] location = { r, c };
                    boardGrid[r, c].Load(gameBoard.Draw(location));
                }

            remainingDarkLabel.Text = gameBoard.RemainingDark().ToString();
            remainingLightLabel.Text = gameBoard.RemainingLight().ToString();
        }

        //Checks if the player's move ends the game
        private bool isTerminal() {
            if (gameBoard.RemainingDark() == 0 || gameBoard.RemainingLight() == 0)
                return true;
            if (gameBoard.LegalMoves(player) == 0 || gameBoard.LegalMoves(player + 1) == 0)
                return true;

            return false;
        }

        //Starts the game (and locks the difficulty)
        private void startButton_Click(object sender, EventArgs e) {
            boardBox.Enabled = true;
            diffBox.Enabled = false;

            endButton.Enabled = true;
            resetButton.Enabled = true;
            startButton.Enabled = false;

            gameBoard.StartGame(gameMode);
            gameBoard.StateCheck();
            drawBoard(boardSize);
        }

        //Ends the game (and outputs the Winner)
        private void endGame() {
            boardBox.Enabled = false;
            diffBox.Enabled = true;

            endButton.Enabled = false;
            resetButton.Enabled = false;
            startButton.Enabled = true;

            if (gameBoard.RemainingDark() > gameBoard.RemainingLight() || gameBoard.LegalMoves(player) == 0)
                MessageBox.Show("You Won!!!", "Congratulations");
            else if (gameBoard.RemainingDark() < gameBoard.RemainingLight() || gameBoard.LegalMoves(player + 1) == 0)
                MessageBox.Show("You Lost.\nTry adjusting the difficulty if you are struggling.", "Better Luck Next Time");
        }

        private void endButton_Click(object sender, EventArgs e) {
            endGame();
        }

        private void resetButton_Click(object sender, EventArgs e) {
            gameBoard.StartGame(gameMode);
            gameBoard.StateCheck();
            drawBoard(boardSize);
        }

        private void aiDifficulty() {
            if (easyRadio.Checked == true)
                opponent.Depth = 0;
            else if (normalRadio.Checked == true)
                opponent.Depth = 2;
            else
                opponent.Depth = 4;
        }

        private void easyRadio_CheckedChanged(object sender, EventArgs e) {
            aiDifficulty();
        }

        private void normalRadio_CheckedChanged(object sender, EventArgs e) {
            aiDifficulty();
        }

        private void hardRadio_CheckedChanged(object sender, EventArgs e) {
            aiDifficulty();
        }

        
    }
}
