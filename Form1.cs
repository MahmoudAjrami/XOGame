using System;
using System.Drawing;
using System.Windows.Forms;
using XO_Game_Final.Properties;

namespace XO_Game_Final
{
    public partial class Form1 : Form
    {
        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;

        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }

        // Checks one row, column, or diagonal for three matching player marks.
        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

                GameStatus.Winner = enWinner.Player2;
                GameStatus.GameOver = true;
                EndGame();
                return true;
            }

            GameStatus.GameOver = false;
            return false;
        }

        // Updates the status labels and shows the game-over message.
        void EndGame()
        {
            lblTurn.Text = "Game Over";

            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player1";
                    break;

                case enWinner.Player2:
                    lblWinner.Text = "Player2";
                    break;

                default:
                    lblWinner.Text = "Draw";
                    break;
            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Tests every possible winning line on the board.
        public void CheckWinner()
        {
            //checked rows
            //check Row1
            if (CheckValues(button1, button2, button3))
                return;

            //check Row2
            if (CheckValues(button4, button5, button6))
                return;

            //check Row3
            if (CheckValues(button7, button8, button9))
                return;

            //checked cols
            //check col1
            if (CheckValues(button1, button4, button7))
                return;

            //check col2
            if (CheckValues(button2, button5, button8))
                return;

            //check col3
            if (CheckValues(button3, button6, button9))
                return;

            //check Diagonal
            //check Diagonal1
            if (CheckValues(button1, button5, button9))
                return;

            //check Diagonal2
            if (CheckValues(button3, button5, button7))
                return;
        }

        // Handles a player's move by placing X or O on the selected button.
        public void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;

                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }

        // Creates the form and loads all controls from the designer.
        public Form1()
        {
            InitializeComponent();
        }

        // Handles a click on the top-left board cell.
        private void button1_Click(object sender, EventArgs e)
        {
            ChangeImage(button1);
        }

        // Handles a click on the top-middle board cell.
        private void button2_Click(object sender, EventArgs e)
        {
            ChangeImage(button2);
        }

        // Handles a click on the top-right board cell.
        private void button3_Click(object sender, EventArgs e)
        {
            ChangeImage(button3);
        }

        // Handles a click on the middle-right board cell.
        private void button6_Click(object sender, EventArgs e)
        {
            ChangeImage(button6);
        }

        // Handles a click on the center board cell.
        private void button5_Click(object sender, EventArgs e)
        {
            ChangeImage(button5);
        }

        // Handles a click on the middle-left board cell.
        private void button4_Click(object sender, EventArgs e)
        {
            ChangeImage(button4);
        }

        // Handles a click on the bottom-right board cell.
        private void button9_Click(object sender, EventArgs e)
        {
            ChangeImage(button9);
        }

        // Handles a click on the bottom-middle board cell.
        private void button8_Click(object sender, EventArgs e)
        {
            ChangeImage(button8);
        }

        // Handles a click on the bottom-left board cell.
        private void button7_Click(object sender, EventArgs e)
        {
            ChangeImage(button7);
        }

        // Runs when the form finishes loading.
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Resets one board button back to the default question-mark state.
        private void RestButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }

        // Resets the whole board and starts a new game.
        private void RestartGame()
        {
            RestButton(button1);
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";
        }

        // Handles the Restart Game button click.
        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        // Draws the tic-tac-toe grid lines on the form.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color white = Color.FromArgb(255, 255, 255, 255);
            Pen whitePen = new Pen(white);
            whitePen.Width = 15;
            //whitePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            whitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            whitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //draw Horizental lines
            e.Graphics.DrawLine(whitePen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(whitePen, 400, 460, 1050, 460);

            //draw Vertical lines
            e.Graphics.DrawLine(whitePen, 610, 140, 610, 620);
            e.Graphics.DrawLine(whitePen, 840, 140, 840, 620);
        }
    }
}
