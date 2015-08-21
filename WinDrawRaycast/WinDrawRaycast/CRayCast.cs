using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using WinDrawRaycast;
namespace WinDrawRaycast
{

    public enum mDirEnum
    {
        Forward,
        Backward,
        RotLeft,
        RotRight
    }

    class CRayCast
    {
        public float PR, PX, PZ, PXOld, PZOld,
                     Alpha, KX, KX2, KZ, KZ2, KY,
                     LD, Rot;
        public int ArX, ArZ, RetX, RetZ, LX, LY,
                   WdS, WdE, xl, zl, RGBDL, RGB,
                   CameraDist;

        public int[,] RGBArray;
        public int[,] LArray;

        public CRayCast(int Width=320, int Height=240)
        {
            WdS = -Width/2; WdE = (Width/2) - 1;

            LX = Width/2; LY = Height/2;

            xl = 15; zl = 15;

            RGBDL = 4; RGB = 2;

            PX = 4f; PZ = 4f;
            
            CameraDist = 1000;

            //KX = 0.125f; KZ = 0.125f;
            KX = .002f; KZ =.001f; 
            //KX2 = 5f;KZ2 = 5f;
            KX2 = 10f; KZ2 = 10f;
            KY = 2200f;//700f;
            LD = 128;//64f;
            PXOld = 0f; PZOld = 0f;
            PR = 0f; Rot = 0f;

        }

        public static int rgbArrL;
        public void InitRayCast()
        {
            FillRGBArray();
            FillLabirintArray();
            
        }
        
        private void AbsXZ(float x, float z)
        {
            if (x < 0) x = -x;
            if (z < 0) z = -z;
            RetX = (int) x;
            RetZ = (int) z;
        }

        public int WLG=0;
        public int COL = 0;
        public void RenderRayCast()
        {
            //for (int WLG = WdS; WLG < WdE; WLG++)
            //{
                rayX = PX;
                rayZ = PZ;
                
                drawX = (float) (Math.Sin(Alpha + KX * WLG)/KX2);
                drawZ = (float)(Math.Cos(Alpha + KX * WLG) / KZ2);

                int n = 0;
                int col = 0;
            
                while (col==0 && n<CameraDist)
                {
                    rayX = rayX + drawX;
                    rayZ = rayZ + drawZ;
                    n = n + 1;
                    AbsXZ(rayX, rayZ);
                    if (LArray[RetX, RetZ] > 0)
                    {
                        AbsXZ(rayX,rayZ);
                        col = LArray[RetX, RetZ];
                    }
                }
            float h = 0;
            float shade=0;
                if (col != 0)
                {
                    h = KY/n;
                    shade = h/LD;
                    if (shade > 1f) shade = 1f;
                    ColR = RGBArray[col, 0]*shade;
                    ColG = RGBArray[col, 1] * shade;
                    ColB = RGBArray[col, 2] * shade;
                    PX1 = LX - WLG;
                    PY1 = LY - h;
                    PX2 = LX - WLG;
                    PY2 = LY + h;
                    COL = col;
                }

            //}
            
        }

        public float ColR, ColG, ColB;
        public float PX1=0, PY1=0, PX2=0, PY2=0;
        private float drawX, drawZ;
        private float rayX { get; set; }
        private float rayZ { get; set; }

        private void Slide()
        {
            AbsXZ(PX,PZ);
            if (LArray[RetX, RetZ] != 0)
            {
                PR = PX;
                PX = PXOld;
                AbsXZ(PX,PZ);
                if (LArray[RetX, RetZ] != 0)
                {
                    PX = PR;
                    PZ = PZOld;
                    AbsXZ(PX,PZ);
                    if (LArray[RetX, RetZ] != 0)
                    {
                        PX = PXOld;
                        AbsXZ(PX,PZ);
                    }
                }
            }
        }

        private float Step = 30f;
        public void Move(mDirEnum mDir)
        {
            switch (mDir)
            {
                case mDirEnum.Forward:
                    PXOld = PX;
                    PZOld = PZ;
                    PX = (float) (PX + Math.Sin(Alpha)/Step);
                    PZ = (float) (PZ + Math.Cos(Alpha)/Step);
                    Slide();
                    break;
                case mDirEnum.Backward:
                    PXOld = PX;
                    PZOld = PZ;
                    PX = (float)(PX - Math.Sin(Alpha) / Step);
                    PZ = (float)(PZ - Math.Cos(Alpha) / Step);
                    Slide();
                    break;
                case mDirEnum.RotLeft:
                    Rot =-.05f;
                    break;
                case mDirEnum.RotRight:
                    Rot =+.05f;
                    break;
            }
            Alpha = Alpha - Rot;
            if (Alpha > 360) Alpha = 0;
        }

        private void FillRGBArray()
        {
            RGBArray = new int[5, 3]
                {
                    { 127, 127, 127 }, 
                    { 255, 127, 255 }, 
                    { 0, 0, 255 }, 
                    { 0, 255, 0 }, 
                    { 255, 0, 0 }
                };
        }

        private void FillLabirintArray()
        {
            LArray = new int[16,10]
                {
                    {2,2,3,3,1,2,3,3,1,2},
                    {2,0,1,0,1,0,1,0,1,2},
                    {3,0,0,0,0,0,0,0,0,3},
                    {2,1,0,0,0,1,0,0,1,2},
                    {2,1,0,0,0,0,0,0,0,2},
                    {3,0,0,0,0,1,1,1,1,3},
                    {2,1,0,0,0,0,0,0,0,2},
                    {3,0,0,0,0,1,0,0,1,3},
                    {2,1,0,0,0,0,0,0,0,2},
                    {3,0,0,0,0,0,1,0,1,3},
                    {2,1,0,0,0,1,1,0,0,2},
                    {3,0,0,0,0,0,1,1,1,3},
                    {2,1,1,1,0,0,0,0,0,2},
                    {3,0,0,0,0,0,0,0,1,3},
                    {3,0,3,0,1,0,1,0,0,3},
                    {3,3,3,2,2,2,2,2,2,3}
                };
        }

    }
}
