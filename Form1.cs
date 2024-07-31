using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormTic_Tac_Toe_Game.Properties;
using static System.Windows.Forms.Button;

namespace WindowsFormTic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {

        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;
        enum enPlayer { 
            Player1, 
            Player2
        };

        enum enWinner {  
            Player1,
            Player2,
            Draw,
            GameInProgress
        }; 
        
        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }

        public bool CheckValue(Button btn1, Button btn2,  Button btn3)
        {
            if(btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if(btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }
            GameStatus.GameOver = false;
            return false;
        }

        void EndGame()
        {
            lblTurn.Text = "Game Over";
            switch(GameStatus.Winner)
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

            Disable_Button(true);
            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public void CheckWinner()
        {
            if(CheckValue(button1, button2, button3))
            {
                return;
            }
            if (CheckValue(button1, button4, button7))
            {
                return;
            }
            if (CheckValue(button1, button5, button9))
            {
                return;
            }
            if (CheckValue(button2, button5, button8))
            {
                return;
            }
            if (CheckValue(button3, button5, button7))
            {
                return;
            }
            if (CheckValue(button3, button6, button9))
            {
                return;
            }
            if (CheckValue(button4, button5, button6))
            {
                return;
            }
            if (CheckValue(button7, button8, button9))
            {
                return;
            }
            
        }

        public void ChangeImage(Button btn)
        {

            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }

            }
            else
            {
                MessageBox.Show("Wrong Choise", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Pain_Load(object sender, PaintEventArgs e)
        {
            Color white = Color.FromArgb(255, 255, 255);

            Pen pen = new Pen(white); ;
            pen.Width = 10;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 250, 300, 750, 300);
            e.Graphics.DrawLine(pen, 250, 450, 750, 450);

            e.Graphics.DrawLine(pen, 400, 150, 400, 600);
            e.Graphics.DrawLine(pen, 600, 150, 600, 600);
        }

        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);
        }
        
        private void RestartButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }

        private void RestartGame()
        {
            RestartButton(button1);
            RestartButton(button2);
            RestartButton(button3);
            RestartButton(button4);
            RestartButton(button5);
            RestartButton(button6);
            RestartButton(button7);
            RestartButton(button8);
            RestartButton(button9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player1";
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";

            Disable_Button(false);
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        public void Disable_Button(bool t)
        {
            if(t)
            {
                button1.Enabled= false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
            }
            else
            {
                button1.Enabled= true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
            }


        }
    }
}
