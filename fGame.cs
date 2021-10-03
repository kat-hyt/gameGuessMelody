using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Guess_Melody_Framework
{
    public partial class fGame : Form
    {
        fParam param = new fParam();
        Random rnd = new Random();
        int musicDuration = Victorina.musicDuration; //продолжительность музыки
        int musicContinue = Victorina.musicDuration;
        //int gameDuration = Victorina.gameDuration;

        bool[] players = new bool[2];
        public fGame()
        {
            InitializeComponent();
        }
        private void fGame_Load(object sender, EventArgs e)
        {
            
            //timer1.Start();
            lblMelodyCount.Text = Victorina.list.Count.ToString();

            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Victorina.musicDuration; //время ответа
            lblMusicDuration.Text = musicContinue.ToString();
            
        }

        void MakeMusic()
        {
            musicDuration = musicContinue;
            if (Victorina.list.Count == 0)
            {
                lblMelodyCount.Text = Victorina.list.Count.ToString();
                
                MessageBox.Show(new Form { TopLevel = true }, $"Поздавляем! \nВыиграл(и) игрок со счётом: \n{lblCounter1.Text} : {lblCounter2.Text}", "              Результат");
              
                EndGame();
            }
            else
            {
               
                lblMelodyCount.Text = Victorina.list.Count.ToString();
                //musicDuration = Victorina.musicDuration;
                int n = rnd.Next(0, Victorina.list.Count); //находит в списке случайно номер песни
                WMP.URL = Victorina.list[n];

                Victorina.answer = WMP.URL;

                Victorina.list.RemoveAt(n); //чтобы не почторяась одинаковая композиция 
                players[0] = false;
                players[1] = false;

            }
        }

       

        private void btnNext_Click(object sender, EventArgs e)
        {
            lblMusicDuration.Text = Convert.ToString(Victorina.musicDuration);
            
            progressBar1.Value = 0;
            //this.timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Start();
            //WMP.URL = Victorina.list[2]; //возпроизводит 3=ю композицию
            MakeMusic();
           
        }

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void WMP_Enter(object sender, EventArgs e)
        {

        }

        

        private void btHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

       

        private void btnPause_Click(object sender, EventArgs e)
        {
            GamePause();            
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            GamePlay();
        }
        private void fGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            WMP.Ctlcontrols.stop();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            
            //lblMusicDuration.Text = Convert.ToString(musicDuration);
            if (progressBar1.Value == progressBar1.Maximum)//перправить на gameDuration
            {
                EndGame();
                return;
            }
            else
            {
               
                //progressBar1.Increment(1);
                progressBar1.Value++; //= progressBar1.Value + 1;
                lblMusicDuration.Text = Convert.ToString(musicDuration--);
                //musicDuration = musicContinue;

            }
            if (musicDuration == 0)
            {
                MakeMusic();
            }
        }
        void EndGame()
        {
            timer1.Stop();
            MessageBox.Show(new Form { TopLevel = true}, "Время прослушивания вышло :( ") ;

            WMP.Ctlcontrols.stop();
          
        }
        void GamePause()
        {
            timer1.Stop();
            WMP.Ctlcontrols.pause();
        }
        void GamePlay()
        {
            timer1.Start();
            WMP.Ctlcontrols.play();

        }
        private void fGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (!timer1.Enabled )//!timer1.Enabled 
            {
                return;
            }
            
            if (players[0] ==false && e.KeyData == Keys.A)
            {
                GamePause();
                fMessage fm = new fMessage();
                fm.lblMessage.Text = "\tИгрок 1\nПравильный ответ ?";
                SoundPlayer sp = new SoundPlayer(@"C:\Users\1\source\repos\Guess Melody\Guess Melody Framework\Resources\игрок 1.wav");
                sp.PlaySync();
                players[0] = true;

                if (fm.ShowDialog() == DialogResult.Yes)
                {
                    lblCounter1.Text = Convert.ToString(Convert.ToInt32(lblCounter1.Text) + 1);
                    //MakeMusic();
                }
                //GamePlay();
            }
            if (players[1] == false && e.KeyData == Keys.B)
            {
                GamePause();
                fMessage fm = new fMessage();
                fm.lblMessage.Text = "\tИгрок 2\nПравильный ответ ?";
                SoundPlayer sp = new SoundPlayer(@"C:\Users\1\source\repos\Guess Melody\Guess Melody Framework\Resources\игрок 2.wav");
                sp.PlaySync();
                players[1] = true;

                if (fm.ShowDialog() == DialogResult.Yes)
                {
                    lblCounter2.Text = Convert.ToString(Convert.ToInt32(lblCounter2.Text) + 1);
                    //MakeMusic();
                }
                //GamePlay();
            }
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void WMP_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            if (Victorina.randomStart) 
            {
                if (WMP.openState == WMPLib.WMPOpenState.wmposMediaOpen)
                {
                    //воспроизводит со случайного места, из середины скорее всего
                    WMP.Ctlcontrols.currentPosition = rnd.Next(0, (int)WMP.currentMedia.duration / 2);
                }
            }
        }

        private void lblCounter1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                (sender as Label).Text = Convert.ToString(Convert.ToInt32((sender as Label).Text) + 1);
            }
            if (e.Button == MouseButtons.Right)
            {
                (sender as Label).Text = Convert.ToString(Convert.ToInt32((sender as Label).Text) - 1);
            }
        }
    
    }
}
