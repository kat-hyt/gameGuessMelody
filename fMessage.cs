using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Guess_Melody_Framework
{
    public partial class fMessage : Form
    {
        
        int timeAnswer =5;
        public fMessage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fMessage_Load(object sender, EventArgs e)
        {
            timeAnswer = 5;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            timeAnswer --;
            lblTimer.Text = timeAnswer.ToString();
            if ( timeAnswer == 0 )
            {
                timer1.Stop();
                SoundPlayer sp = new SoundPlayer(@"<your local location>\mixkit-wrong-answer-fail-notification-946.wav");
                sp.Play();
                
            }
            else
            {
                
            }
        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }

        private void fMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void lblShowAnswer_Click(object sender, EventArgs e)
        {
            var mp3file = TagLib.File.Create(Victorina.answer);
            
            lblShowAnswer.Text = mp3file.Tag.FirstAlbumArtist +" "+ mp3file.Tag.Title;
            //Покажет ответ при клике на "показать ответ"
        }
    }
}
