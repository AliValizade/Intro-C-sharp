using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        Button[,] dokmeha;
        int ply;

        public Form1()
        {
            InitializeComponent();

            dokmeha = new Button[3, 3] {{button1, button2, button3},
                                                  {button4, button5, button6},
                                                  {button7, button8, button9}};
            new_game();

            //button1.BackColor = Color.Red;
            //button2.BackColor = Color.Red;
            //button3.BackColor = Color.Red;
            //button4.BackColor = Color.Red;
            //button5.BackColor = Color.Red;
            //button6.BackColor = Color.Red;
            //button7.BackColor = Color.Red;
            //button8.BackColor = Color.Red;
            //button9.BackColor = Color.Red;
            //button1.Text = "";
            //button2.Text = "";
            //button3.Text = "";
            //button4.Text = "";
            //button5.Text = "";
            //button6.Text = "";
            //button7.Text = "";
            //button8.Text = "";
            //button9.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button this_button = (sender as Button);

            if (this_button.Text == "")
            {
                if (ply == 1) //نوبت بازیکن شماره 1
                {
                    this_button.Text = "X";
                    this_button.ForeColor = Color.DarkGreen;
                    this_button.BackColor = Color.LightGreen;

                    ply = 2;
                }
                else if (ply == 2)  //نوبت بازیکن شماره 2
                {
                    this_button.Text = "O";
                    this_button.ForeColor = Color.Red;
                    this_button.BackColor = Color.Pink;
                    ply = 1;
                }

                check_game();
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            Button this_button = (sender as Button);
            //this_button.BackColor = Color.DarkBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button this_button = (sender as Button);
            //this_button.BackColor = Color.SkyBlue;
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            new_game();
        }

        private void new_game()
        {
            ply = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dokmeha[i, j].BackColor = Color.SkyBlue;
                    dokmeha[i, j].Text = "";
                }
            }
        }

        private void check_game()
        {
            for(int i=0; i<3; i++)
            {
                if(dokmeha[i, 0].Text == "X" && dokmeha[i, 1].Text == "X" && dokmeha[i, 2].Text == "X")
                {
                    MessageBox.Show("Player 1 Wins.");
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (dokmeha[0, i].Text == "X" && dokmeha[1, i].Text == "X" && dokmeha[2, i].Text == "X")
                {
                    MessageBox.Show("Player 1 Wins.");
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (dokmeha[i, 0].Text == "O" && dokmeha[i, 1].Text == "O" && dokmeha[i, 2].Text == "O")
                {
                    MessageBox.Show("Player 2 Wins.");
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (dokmeha[0, i].Text == "O" && dokmeha[1, i].Text == "O" && dokmeha[2, i].Text == "O")
                {
                    MessageBox.Show("Player 2 Wins.");
                }
            }
            if(dokmeha[0, 0].Text == "O" && dokmeha[1, 1].Text == "O" && dokmeha[2, 2].Text == "O")
            {
                MessageBox.Show("Player 2 Wins.");
            }
            else if (dokmeha[0, 0].Text == "X" && dokmeha[1, 1].Text == "X" && dokmeha[2, 2].Text == "X")
            {
                MessageBox.Show("Player 1 Wins.");
            }
            else if(dokmeha[2, 0].Text == "X" && dokmeha[1, 1].Text == "X" && dokmeha[1, 2].Text == "X")
            {
                MessageBox.Show("Player 1 Wins.");
            }
            else if (dokmeha[2, 0].Text == "O" && dokmeha[1, 1].Text == "O" && dokmeha[1, 2].Text == "O")
            {
                MessageBox.Show("Player 2 Wins.");
            }
        }
    }
}
