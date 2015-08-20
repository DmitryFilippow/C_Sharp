using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3Player
{
    public partial class Form1 : Form
    {
        private string _command;
        public bool isOpen;
        public bool isLoop = false;
        public bool VolUp = true;
        public bool VolDown = false;
        public float Volume = 500f;

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string com, StringBuilder ret, int iRetLen, IntPtr hwndCB);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.SpecialFolder.MyMusic.ToString();
            ofd.Filter = "MP3 files (*.mp3)|*.mp3|Все файлы (*.*)|*.*";
            ofd.FilterIndex = 1;
            PlrPanel.Enabled = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = ofd.FileName.ToString();
                PlrPanel.Enabled = true;
                ClosePlayer();
                }
            else
            {
                PlrPanel.Enabled = true;
            }

        }

        private void ApplyCommand(string _cmd)
        {
            mciSendString(_cmd, null, 0, IntPtr.Zero);
        }

        private void Play(bool loop)
        {
            if (isOpen)
            {
                _command = "play MediaFile";
            }
            if (loop) _command += " REPEAT";
            ApplyCommand(_command);
        }

        private void SetVolume(bool UpDown)
        {
            if (UpDown == VolUp )
            {
                if (Volume<1000) Volume +=100f;
            }
            else
            {
                if (Volume>0) Volume -=100f;
            }
            string cmd = "SetAudio MediaFile volume to " + Volume.ToString();
            VolLabel.Text = String.Format("{0}%", (Volume/10).ToString());
            ApplyCommand(cmd);
        }
        private bool Pause()
        {
            ApplyCommand("Pause MediaFile");
            return true; 
        }
        private void OpenPlayer(string fileName)
        {
            _command = "Open \"" + fileName + "\" type mpegvideo alias MediaFile";
            ApplyCommand(_command);
            isOpen = true;
        }

        private void ClosePlayer()
        {
            _command = "Close MediaFile";
            ApplyCommand(_command);
            isOpen = false;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.OpenPlayer(this.textBox1.Text);
                this.Play(isLoop);
                string cmd = "SetAudio MediaFile volume to " + Volume.ToString();
                ApplyCommand(cmd);
                VolLabel.Text = (Volume / 10).ToString() + "%";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClosePlayer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoopCB_CheckedChanged(object sender, EventArgs e)
        {
            isLoop = LoopCB.Checked;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            Pause();
        }

        private void UpVolButton_Click(object sender, EventArgs e)
        {
            SetVolume(VolUp);
        }

        private void DwnVolButton_Click(object sender, EventArgs e)
        {
            SetVolume(VolDown);
        }
    }
}
