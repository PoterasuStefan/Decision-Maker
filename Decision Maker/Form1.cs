using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decision_Maker
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int Winner;

        public Form1()
        {
            InitializeComponent();

            
        }


        int Mode_nr = 1;

        

        private void button1_Click(object sender, EventArgs e)
        {
            var lines = Input.Lines.Where(line => !String.IsNullOrWhiteSpace(line)).Count();
            Winner = random.Next(0, lines);
            
            if (Mode_nr==1)
            {
                Result.Text = Input.Lines[Winner];
            }
            else if (lines>=1)
            {
                Result.Text = Input.Lines[Winner];
                List<string> linesList = new List<string>(Input.Lines);
                linesList.RemoveAt(Winner);
                Input.Lines = linesList.ToArray();
                
            }
            else
            {
                MessageBox.Show("No options left");
            }
            History.Text = Result.Text + "\n" + History.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Input.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Mode.Text=="Mode: Keep")
            {
                Mode.Text = "Mode: Cut";
                Mode_nr = 0;
            }
            else
            {
                Mode.Text = "Mode: Keep";
                Mode_nr = 1;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            History.Text = null;
        }
    }
}
