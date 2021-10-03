using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guess_Melody_Framework
{
    public partial class fParam : Form
    {
        

        public fParam()
        {
            InitializeComponent();
        }


        private void btnSelectFolder_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //new Form { TopLevel = true };
            

            if (fbd.ShowDialog() == DialogResult.OK) //не забыть нажать F10 ддля загрузки проводника
            {
                string[] soundList = Directory.GetFiles(fbd.SelectedPath, "*.mp3",cbAllDirectory.Checked? SearchOption.AllDirectories:SearchOption.TopDirectoryOnly);
                Victorina.lastFolder = fbd.SelectedPath;
                listBox1.Items.Clear();
                listBox1.Items.AddRange(soundList);
                Victorina.list.Clear();
                Victorina.list.AddRange(soundList);

               
            };

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        //    using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "MP3|*.mp3", Multiselect = false, ValidateNames = true })
        //    {
        //        if (ofd.ShowDialog() == DialogResult.OK)
        //        {
        //            listBox1.Text = ofd.FileName;
        //        }

        //    }
        }

        private void fParam_Load(object sender, EventArgs e)
        {
            Set();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Victorina.list.ToArray());
        }

        public void btnOk_Click(object sender, EventArgs e)
        {
            Victorina.allDirectories = cbAllDirectory.Checked;
            Victorina.gameDuration = Convert.ToInt32(cbGameDuration.Text);
            Victorina.musicDuration =Convert.ToInt32(cbMusicDuration.Text);
            Victorina.randomStart = cbRandomStart.Checked;
            Victorina.WriteParam();
            this.Hide();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //cbAllDirectory.Checked = Victorina.allDirectories;
            //cbGameDuration.Text = Victorina.gameDuration.ToString();
            //cbMusicDuration.Text = Victorina.musicDuration.ToString();
            //cbRrandomStart.Checked = Victorina.randomStart;
            Set();
            this.Hide();
        }
        void Set()
        {
            cbAllDirectory.Checked = Victorina.allDirectories;
            cbGameDuration.Text = Victorina.gameDuration.ToString();
            cbMusicDuration.Text = Victorina.musicDuration.ToString();
            cbRandomStart.Checked = Victorina.randomStart;

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
