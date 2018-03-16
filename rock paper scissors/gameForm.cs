using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rock_paper_scissors
{
    public partial class gameForm : Form
    {
        private int cChoice, pChoice = 1;
        private int pScore, cScore = 0;

        public gameForm()
        {
            InitializeComponent();
        }


        private void btnRock_Click(object sender, EventArgs e)
        {
            pChoice = 1;
            playerReady();
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            pChoice = 2;
            playerReady();
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            pChoice = 3;
            playerReady();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnRock.Enabled = true;
            btnPaper.Enabled = true;
            btnScissors.Enabled = true;
            tbxResult.Text = "";
        }

        private void playerReady()
        {
            Random rand = new Random();

            btnStart.Enabled = true;
            btnRock.Enabled = false;
            btnPaper.Enabled = false;
            btnScissors.Enabled = false;
            cChoice = rand.Next(1, 4);

            String cChoiceStr = "";
            String pChoiceStr = "";
            String winner = "";

            switch (cChoice)
            {
                case 1:
                    cChoiceStr = "Rock";
                    break;
                case 2:
                    cChoiceStr = "Paper";
                    break;
                case 3:
                    cChoiceStr = "Scissors";
                    break;
            }
            switch (pChoice)
            {
                case 1:
                    pChoiceStr = "Rock";
                    break;
                case 2:
                    pChoiceStr = "Paper";
                    break;
                case 3:
                    pChoiceStr = "Scissors";
                    break;
            }

            if(pChoice == cChoice)
            {
                winner = "Tie";
            }
            else if ((pChoice == 1 && cChoice == 3) || (pChoice == 2 && cChoice == 1) || (pChoice == 3 && cChoice == 2))
            {
                pScore++;
                winner = "Player wins";
            }
            else
            {
                cScore++;
                winner = "Computer wins";
            }

            tbxComputersChoice.Text = cChoiceStr;
            tbxResult.Text = "Computer choose " + cChoiceStr + ". Player choose " + pChoiceStr + ". " + winner + ".";
            tbxAllResults.AppendText("Computer: " + cScore + ". Player: " + pScore + ".\n");
            btnStart.Focus();
        }
    }
}
