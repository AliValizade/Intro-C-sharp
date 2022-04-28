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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox t = new TextBox();
                    t.Multiline = true;
                    t.TextAlign = HorizontalAlignment.Center;
                    t.Font = new Font("Tahoma", 25);
                    t.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
                    tableLayoutPanel1.Controls.Add(t, i, j);

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_newgame_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();

            if(x.ShowDialog() == DialogResult.OK)
            {
                // MessageBox.Show("Yes");
                string file_path = x.FileName;
                //MessageBox.Show(file_path);
                StreamReader my_file = new StreamReader(file_path);

                string big_text = my_file.ReadToEnd();
                //MessageBox.Show(s);

                char[] my_seperators = { ' ', '\n' };
                string[] numbers = big_text.Split(my_seperators); // size 81
                
            }
            
        }
    }
}
