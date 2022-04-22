using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puzzle15
{
    public partial class Form1 : Form
    {
        Button[,] cells;
        int empty_x, empty_y;

        public Form1()
        {
            InitializeComponent();

            new_game();
           
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button this_button = sender as Button;
            int x = 0, y = 0;
            //this_button.BackColor = Color.LightGreen;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (cells[i, j] == this_button)
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            //بررسی شرط همسایگی
            if ((x == empty_x && (y == empty_y - 1 || y == empty_y + 1)) ||
               (y == empty_y && (x == empty_x - 1 || x == empty_x + 1)))
            {
                // MessageBox.Show("همسایه");

                cells[empty_x, empty_y].Text = this_button.Text;
                this_button.Text = "16";

                cells[empty_x, empty_y].Show();
                this_button.Hide();

                empty_x = x;
                empty_y = y;
            }

            check_game();

        }
        public void check_game()
        {
            int k = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (cells[i, j].Text == Convert.ToString(k))
                    {
                        k++;
                    }
                }

            }
            if (k == 17)
            {
                MessageBox.Show("you win.");
            }
        }
        public void new_game()
        {
            cells = new Button[4, 4] { {button1, button2, button3, button4},
                                       {button5, button6, button7, button8},
                                       {button9, button10, button11, button12},
                                       {button13, button14, button15, button16}};
            // -------------Creat an array with random number--------------------
            Random r = new Random();
            int[] a = new int[16];
            int x;

            for (int i = 0; i < 16; i++)
            {
                do
                {
                    x = r.Next(1, 17);

                } while (a.Contains(x));

                a[i] = x;
            }
            // ------------End----------------------

            int index = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (a[index] == 16)
                    {
                        cells[i, j].Hide();
                        empty_x = i;
                        empty_y = j;
                    }
                    cells[i, j].Text = Convert.ToString(a[index]);
                    index++;
                    cells[i, j].Font = new Font("Arial", 20);
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            cells[empty_x, empty_y].Show();
            new_game();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
