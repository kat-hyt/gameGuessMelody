using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guess_Melody_Framework
{
    public partial class Form1 : Form
    {
        fParam fp = new fParam();
        fGame fg = new fGame();
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnParam_Click(object sender, EventArgs e)
        {
            
            fp.ShowDialog();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                fg.ShowDialog();
            }
            catch (Exception)
            {
                
                

            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Victorina.ReadParam();
            Victorina.ReadMusic();
        }
    }
}
