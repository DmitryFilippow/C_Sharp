using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;
using Timer = System.Threading.Timer;

namespace VideoPlayer
{
    public partial class Form1 : Form
    {
        public OpenFileDialog openFileDialog1;
        public Video video;
        public int VideoState = 0;
        public int Min, Hour, Sec;
        //public BackgroundWorker bw=new BackgroundWorker();


        private enum VideoStateEnum
        {
            None,
            Play,
            Pause,
            Stop,
            Open
        }

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

        }


        public void SeekRefresh()
        {
            //ChatBox.BeginInvoke(AcceptDelegate, new object[] { "Received " + Encoding.Default.GetString(MessageR.ToArray()), ChatBox });

            label1.Text = video.CurrentPosition.ToString();
            //trackBar1.Value=(int)video.CurrentPosition;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //VideoState = (int)VideoStateEnum.Open;

            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Видео файл (*.avi)|*.avi|Видео файл (*.wmv)|*.wmv|Видео файл (*.mp4)|*.mp4|Все файлы (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                if (fi.Length > 0)
                {
                    if (video != null &&
                        (VideoState == (int) VideoStateEnum.Stop || VideoState == (int) VideoStateEnum.Play))
                    {
                        video.Stop();
                    }
                    if (video == null) backgroundWorker1.RunWorkerAsync();

                        video = new Video(openFileDialog1.FileName);
                        video.Open(openFileDialog1.FileName);
                        video.Owner = panel1;
                        VideoState = (int) VideoStateEnum.Stop;
                        label1.Text = video.Duration.ToString();
                        label2.Text = video.StopPosition.ToString();
                        trackBar1.Maximum = (int) video.Duration;
                        trackBar1.TickFrequency = (int) video.Duration/100;
                        VolumeTrackBar.Minimum = -5000;
                        VolumeTrackBar.Maximum = 0;
                        VolumeTrackBar.TickFrequency = VolumeTrackBar.Minimum/10;
                        video.Audio.Volume = VolumeTrackBar.Minimum/2;
                        VolumeTrackBar.Value = video.Audio.Volume;

                        video.StopWhenReady();

                }
            }
            else
            {
                VideoState = (int) VideoStateEnum.None;
            }

        }

        public void bw_DoWork(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker worker = sender as BackgroundWorker;
            //for (int i = 1; i <= 10; i++)
            for (;;)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(1000);
                    try
                    {
                        worker.ReportProgress((int) video.CurrentPosition);
                    }
                    catch (Exception)
                    {
                        worker.ReportProgress(0);
                    }

                }
            }
        }

        public int cs = 0;

        public void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Min = (int) Math.Floor(video.CurrentPosition/60);
            Hour = (int) Math.Floor((double) (Min/60));
            Sec = (int) Math.Round(video.CurrentPosition);
            label0.Text = Hour.ToString();
            label1.Text = Min.ToString();
            label2.Text = Sec.ToString();
            trackBar1.Value = (int)video.CurrentPosition;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private delegate void SendMsg(String Text, Label Rtb);

        private SendMsg AcceptDelegate = (String Text, Label Rtb) => { Rtb.Text = Text; };

        private void button2_Click(object sender, EventArgs e)
        {
            if (VideoState != (int) VideoStateEnum.None)
            {
                if (video.Playing)
                {
                    PlayButton.Text = "Играть";
                    video.Stop();
                    trackBar1.Value = trackBar1.Minimum;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (video != null)
            {
                if (video.Playing)
                {
                    PlayButton.Text = "Играть";
                    video.Pause();
                    VideoState = (int) VideoStateEnum.Pause;
                    return;
                }
                else
                {
                    PlayButton.Text = "Пауза";
                    video.Play();
                    VideoState = (int) VideoStateEnum.Play;
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (video != null) video.CurrentPosition = trackBar1.Value;

        }

        private void VolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            if (video != null) video.Audio.Volume = VolumeTrackBar.Value;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
         
            
        }


        
      
    }
}

