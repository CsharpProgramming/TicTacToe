using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool isWin = false;
        List<Button> availableButtons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            availableButtons.AddRange(new Button[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 }); //Fill the List for the first time with available moves
        }

        private void ComputerTurn()
        {
            if (availableButtons.Count == 0) //No more available moves
            {
                //Draw
                MessageBox.Show("Nobody won!");
                return;
            }

            if (!isWin) //If nobody won
            {
                //Perform a random move
                Random ComputerRandom = new Random();
                int randomIndex = ComputerRandom.Next(0, availableButtons.Count);
                availableButtons[randomIndex].Text = "O";
                availableButtons[randomIndex].Enabled = false;
                availableButtons.Remove(availableButtons[randomIndex]);

                CheckForWin("O"); //Check did it cause a win
            }
        }

        private void PlayerMove(object sender, EventArgs e)
        {
            //Perform a player move
            Button btn = sender as Button;

            btn.Text = "X";
            btn.Enabled = false;

            availableButtons.Remove(btn);
            
            CheckForWin("X"); //Check did it cause a win

            if (!isWin) //If it didn't cause a win then call for the computer move
            {
                ComputerTurn();
            }
        }

        private void CheckForWin(string player)
        {
            //Big if statement to check for all possible winning combinations
            if ((btn1.Text != "" && btn1.Text == btn2.Text && btn1.Text == btn3.Text) || //Vertical
                (btn4.Text != "" && btn4.Text == btn5.Text && btn4.Text == btn6.Text) || //Vertical
                (btn7.Text != "" && btn7.Text == btn8.Text && btn7.Text == btn9.Text) || //Vertical
                (btn1.Text != "" && btn1.Text == btn5.Text && btn1.Text == btn9.Text) || //Horizontal
                (btn3.Text != "" && btn3.Text == btn5.Text && btn3.Text == btn7.Text) || //Horizontal
                (btn1.Text != "" && btn1.Text == btn4.Text && btn1.Text == btn7.Text) || //Horizontal
                (btn2.Text != "" && btn2.Text == btn5.Text && btn2.Text == btn8.Text) || //Diagonal
                (btn3.Text != "" && btn3.Text == btn6.Text && btn3.Text == btn9.Text))   //Diagonal
            {
                isWin = true;
                MessageBox.Show("Player " + player + " wins!");
            }
        }

        private void ResetGame()
        {
            isWin = false;
            //Reset the available moves
            availableButtons.Clear();
            availableButtons.AddRange(new Button[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 });

            foreach (Button btn in availableButtons) //Loop all the buttons to make the text blank and enable them
            {
                btn.Text = "";
                btn.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetGame(); //Reset the game on click
        }
    }
}
