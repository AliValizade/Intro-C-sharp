using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sudoku
{
    public partial class Sudoku : Form
    {
        TextBox[,] cells;
        int n = 9;
        public Sudoku()
        {
            InitializeComponent();
            cells = new TextBox[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cells[i, j] = new TextBox();
                    cells[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
                    tableLayoutPanel1.Controls.Add(cells[i, j], i, j);
                    cells[i, j].MaxLength = 1;
                    cells[i, j].TextAlign = HorizontalAlignment.Center;
                    cells[i, j].Font = new Font("Tahoma", 14);
                    cells[i, j].BackColor = Color.LightBlue;
                    cells[i, j].Click += new EventHandler(textbox_click);
                }
            }
        }
        

        private void textbox_click(object sender, EventArgs e)
        {
            //----------------------The User can only Enter a number ------------------------
            for (int i = 0; i < n; i++)
            {
                
                for (int j = 0; j < n; j++)
                {
                    if (cells[i, j].Text == "1" || cells[i, j].Text == "2" || cells[i, j].Text == "3" || cells[i, j].Text == "4" || cells[i, j].Text == "5" || cells[i, j].Text == "6" || cells[i, j].Text == "7" || cells[i, j].Text == "8" || cells[i, j].Text == "9")
                    {
                        //Nothing
                    }
                    else
                    {
                        cells[i, j].Text = "";
                    }
                }
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_newgame_Click(object sender, EventArgs e)
        {
            //------------------------Empty sudoku table-------------------
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cells[i, j].ReadOnly = false;
                    cells[i, j].Text = "";
                    cells[i, j].BackColor = Color.LightBlue;
                }
            }
            //--------------------------------End--------------------------

            btn_newgame.BackColor = Color.LightBlue;
            OpenFileDialog x = new OpenFileDialog();
            if (x.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("Yes");
                string file_path = x.FileName;
                //MessageBox.Show(file_path);
                StreamReader my_file = new StreamReader(file_path);
                string big_text = my_file.ReadToEnd();
                //MessageBox.Show(big_text);
                big_text = big_text.Replace("\n", "");
                string[] numbers = big_text.Split(); // size 81
                int index = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (numbers[index] != "0")
                        {
                            cells[j, i].ReadOnly = true;
                            cells[j, i].Text = numbers[index];
                            cells[j, i].BackColor = Color.LightGreen;
                        }
                        index++;
                    }
                }
            }              
        }

       
        private void check_btn_Click(object sender, EventArgs e)
        {
            // --------------------- row & col check -----------------------
            int x, y, count = 0;  
            for (int i = 0; i < n; i++)
            {
                int[] row = new int[n];
                int[] col = new int[n];

                for (int j = 0; j < n; j++)
                {
                    if (cells[i, j].Text != "" && cells[j, i].Text != "")
                    {
                        x = Convert.ToInt32(cells[i, j].Text);
                        y = Convert.ToInt32(cells[j, i].Text);
                        if (x >= 1 && x <= n && !row.Contains(x))
                        {
                            row[j] = x;
                        }
                        if (y >=0 && y <= n && !col.Contains(y))
                        {
                            col[j] = y;
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must be filled all of textboxes!");
                        return;
                    }
                    
                }
            }

            // -------------------------- squre check ------------------------
            for (int k = 0; k < n-2; k+=3)
            {
                int[] sq = new int[n];
                for (int l = 0; l < n-2; l+=3)
                {
                    for (int m = k; m < k+3; m++)
                    {
                        for (int p = l; p < l+3; p++)
                        {
                            if (cells[m, p].Text != "" && cells[p, m].Text != "")
                            {
                                x = Convert.ToInt32(cells[m, p].Text);
                                if (x >= 1 && x <= n && !sq.Contains(x))
                                {
                                    sq[count] = x;
                                    count++;
                                }
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Solved Ok. ❤✔");

        }
        

    }
}
