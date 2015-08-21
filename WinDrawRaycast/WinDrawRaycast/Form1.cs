using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinDrawRaycast
{
    public partial class RayCastForm : Form
    {
        public int Seccond = 1000;
        public const int FPS = 5;
        public int val0 = 0;
        public Graphics RenderGraphics;
        public SolidBrush rSolidBrush;
        public Pen RPen=null;
        private List<SolidBrush> solidBrushes=new List<SolidBrush>();
        private List<Pen> pens=new List<Pen>();
        private SolidBrush[] Brushes;
        private Pen[] PensA;

        private CRayCast MyRayCast;

        public SolidBrush GetBrushFromList(List<SolidBrush> brushes, int index)
        {
            int _index = 0;
            foreach (var solidBrush in brushes)
            {
                if (_index == index)
                {
                    return solidBrush;
                    
                }
                _index++;
            }
            return new SolidBrush(Color.Black);
        }

        public Pen GetPenFromList(List<Pen> pens, int index)
        {
            int _index = 0;
            foreach (var pen in pens)
            {
                if (_index == index)
                {
                    return pen;

                }
                _index++;
            }
            return new Pen(new SolidBrush(Color.Black));
        }

        public SolidBrush GetColorToBrush(int[,] rgbArray, int ic=0)
        {
            if (rgbArray!=null) return new SolidBrush(Color.FromArgb(rgbArray[ic,0],rgbArray[ic,1],rgbArray[ic,2]) );
            return null;
        }

        public int GenerateBrushes()
            //генерим массив брашей по данным с райкаста из rgbarray
        {
            int bLength = 5;
            Brushes=new SolidBrush[bLength];
            for (int bi = 0; bi <bLength; bi++)
            {
                Brushes[bi] = GetColorToBrush(MyRayCast.RGBArray, bi);
            }
            return bLength;
        }
        
        public void GeneratePens()
        {
            int pLength = GenerateBrushes();
            PensA=new Pen[pLength];
            for (int pi = 0; pi < pLength; pi++)
            {
                PensA[pi] = new Pen(Brushes[pi]);
            }
        }

        public RayCastForm()
        {
            InitializeComponent();
            UpdateWorker.WorkerReportsProgress = true;
            UpdateWorker.WorkerSupportsCancellation = true;

            RenderGraphics=this.CreateGraphics();


            for (int i = 0; i <=10; i++)
            {
                rSolidBrush = new SolidBrush(Color.FromArgb(i*25, 0, 0));
                solidBrushes.Add(rSolidBrush);
                pens.Add(new Pen(rSolidBrush));
            }
            
            int ix = 0;
            //RPen = new Pen(GetBrushFromList(solidBrushes,10));
            RPen = GetPenFromList(pens, 10);     
            
            MyRayCast=new CRayCast(this.Width,this.Height);
            MyRayCast.InitRayCast();
            GeneratePens();
            mPen = new Pen(new SolidBrush(Color.White));
            backpen = new Pen(new SolidBrush(Color.Red));
            
            backpen.DashStyle=DashStyle.Dash;
            UpdateWorker.RunWorkerAsync();
            
            Paint +=new PaintEventHandler(RayCastForm_Paint);
            
            
            //RenderGraphics.Dispose();
        }

        public void RayCastForm_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void UpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //for (int i = 1; i <= 10; i++)
            for (; ; )
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    //Random r1=new Random();
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(Seccond/FPS);
                    
                    try
                    {
                        worker.ReportProgress(Seccond/FPS); //r1.Next(0,1000));//(int)video.CurrentPosition);
                    }
                    catch (Exception)
                    {
                        worker.ReportProgress(0);
                    }

                }
            }
        }

        private Pen mPen;
        private Pen backpen;

        private void UpdateWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Random r1=new Random();
            //val0 = r1.Next(0, 1000);
            //this.Text = val0.ToString();
            
            //Random ri = new Random();
            //for (int i = 0; i < 100; i++)
            //{

                //var _ri = ri.Next(0, 11);
                //RenderGraphics.Clear(Color.FromArgb(_ri*10,_ri*10,_ri*10));
                //RenderGraphics.DrawLine(RPen,0f,0f+i*i,100f,100f);
                //RenderGraphics.DrawLine(GetPenFromList(pens, _ri), 0f + i, 0f + i, 10f * _ri, 10f);
            //}
            //RenderGraphics.DrawLine(GetPenFromList(pens, 1), 10, 10, 100, 10);

            //RenderGraphics.Clear(this.BackColor);

            //RenderGraphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, this.Width, this.Height);
            RenderGraphics.FillRectangle(new LinearGradientBrush( new Rectangle(0, 0, 1, 275),
                Color.LightBlue, Color.Black, 90.0f), 0, 0, this.Width, this.Height);

            for (int wlg = MyRayCast.WdS; wlg < MyRayCast.WdE; wlg++)
            {
                
                MyRayCast.WLG = wlg;

                MyRayCast.RenderRayCast();

                RenderGraphics.DrawLine(
                //    PensA[MyRayCast.COL],
                    new Pen(Color.FromArgb( (int) MyRayCast.ColR, (int) MyRayCast.ColG, (int) MyRayCast.ColB)), 
                    MyRayCast.PX1, MyRayCast.PY1, MyRayCast.PX2, MyRayCast.PY2);
     
            }
            
            MyRayCast.Rot = 0;
//            RenderGraphics.Clear(Color.Black);
            
            
        }

        private void RayCastForm_Load(object sender, EventArgs e)
        {
            
        }

        private void RayCastForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void UpdateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }

        private void RayCastForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  Thread.Sleep(1);
            if (e.KeyChar == 'w' || e.KeyChar == 'W')
            {
                
                //Random ri = new Random();
                //for (int i = 0; i < 100; i++)
                //{
                    
                    //var _ri = ri.Next(0, 11);
                    //RenderGraphics.Clear(Color.Fuchsia);
                    //RenderGraphics.DrawLine(RPen,0f,0f+i*i,100f,100f);
                    //RenderGraphics.DrawLine(GetPenFromList(pens, _ri), 0f+i, 0f + i,10f*_ri, 10f);
                //}
                MyRayCast.Move(mDirEnum.Forward);
            }

            if (e.KeyChar == 's' || e.KeyChar == 'S')
            {
                MyRayCast.Move(mDirEnum.Backward);
            }

            if (e.KeyChar == 'a' || e.KeyChar == 'A')
            {
                MyRayCast.Move(mDirEnum.RotLeft);
            }

            if (e.KeyChar == 'd' || e.KeyChar == 'D')
            {
                MyRayCast.Move(mDirEnum.RotRight);
            }

            if (e.KeyChar == 'e' || e.KeyChar == 'E')
            {

            }

            if (e.KeyChar == 'q' || e.KeyChar == 'Q')
            {
               
            }

            if (e.KeyChar == (decimal) Keys.Escape) Environment.Exit(0);
            
            //testlabel1.Text = e.KeyChar.ToString();
        }

        

    }
}
