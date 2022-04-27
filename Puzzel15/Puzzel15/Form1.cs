using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzel15
{
    public partial class Form1 : Form
    {
        Button[,] btn;
        int empty_x, empty_y;

        public Form1()
        {
            InitializeComponent();
            btn = new Button[4, 4];
            new_game();

        }

        //------------------------------New_game-----------------------------------

        public void new_game()
        {
            // -------------Creat an array with 16 random number--------------------
            Random r = new Random();
            int[] a = new int[16];
            int n;
            for (int i = 0; i < 16; i++)
            {
                do
                {
                    n = r.Next(1, 17);
                } while (a.Contains(n));
                a[i] = n;
            }
            //------------------- Creat 16 Buttons in table layout -----------------
            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    btn[i, j] = new Button();
                    btn[i, j].Click += new EventHandler(btn_click);


                    btn[i, j].Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                    tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                    tableLayoutPanel1.Controls.Add(btn[i, j], i, j);
                    btn[i, j].Text = Convert.ToString(a[k]);
                    btn[i, j].Font = new Font("Arial", 20);
                    k++;

                    if (btn[i, j].Text == Convert.ToString(16))
                    {
                        btn[i, j].Hide();
                        empty_x = i;
                        empty_y = j;
                    }

                }
            }
            //----------------------------End --------------------------------------



        }
        private void btn_click(object sender, EventArgs e)
        {
            Button this_button = sender as Button;
            int x = 0, y = 0;
            //this_button.BackColor = Color.LightGreen;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (btn[i, j] == this_button)
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            // Check the neighborhood condition
            if ((x == empty_x && (y == empty_y - 1 || y == empty_y + 1)) ||
               (y == empty_y && (x == empty_x - 1 || x == empty_x + 1)))
            {
                // MessageBox.Show("Neighbor");

                btn[empty_x, empty_y].Text = this_button.Text;
                this_button.Text = "16";

                btn[empty_x, empty_y].Show();
                this_button.Hide();

                empty_x = x;
                empty_y = y;

            }
            check_game();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


                
        private void btn_reset_Click(object sender, EventArgs e)
        {
            //cells[empty_x, empty_y].Show();
            
            new_game();
        }

        //------------------------------check_game-----------------------------------
        public void check_game()
        {
            int k = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (btn[i, j].Text == Convert.ToString(k))
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
    }
}
