using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCheatsDBSQL
{

    public struct CfgDataStruct
    {
        public string CfgHdr;
        public string ConStr;
    }

    public static class CConfig
    {
        public static CfgDataStruct CfgDatas=new CfgDataStruct();
        public static string ConString = "123";
        private static string _ch="GCDBCFG";
        public static string _ccs = _ccs = @"Data Source=P4\SQLEXPRESS;Initial Catalog=GCDB;Integrated Security=True";
        public static string FileName = "GCDB.cfg";
        public static FileInfo cfgFInfo = new FileInfo(FileName);
        public static long cfgFSize=0;
        private static bool _bValue=false;

        

        

        public static void Init()
        {
            //get{ return _bValue; }
            //set { _bValue = value; }

        }


        static CConfig()
        {
           //CfgDatas = new CfgDataStruct();
           CfgDatas.CfgHdr = _ch;
           CfgDatas.ConStr = _ccs;
          Load();
          
          if (!_bValue)
          {
              
              New();
          }
          
        }

        public static void New()//создаем конфиг с дефолт данными
        {
            CfgDatas.CfgHdr = _ch;
            CfgDatas.ConStr = _ccs;

                using (BinaryWriter binWriter=new BinaryWriter(new FileStream(FileName,FileMode.CreateNew)))
                {
                    binWriter.WriteStruct<CfgDataStruct>(CfgDatas);
                    
                }
                //MessageBox.Show("Config create");
                Load();
        }

        public static void Load()//грузим конфиг
        {
            //MessageBox.Show(15.ToString());
            if (cfgFInfo.Exists)
            {
                cfgFSize = cfgFInfo.Length;
                _bValue = true;
                //MessageBox.Show("file est");
                if (cfgFSize != 0)
                {
                    //MessageBox.Show(cfgFSize.ToString());
                    //грузим конфиг
                    
                    using (BinaryReader binReader = new BinaryReader(new FileStream(FileName, FileMode.Open)))
                    {
                        GCDBExtensions.Init();
                        
                        CfgDatas= binReader.ReadStruct<CfgDataStruct>();
                        ConString = CfgDatas.ConStr;
                        if (CfgDatas.CfgHdr != _ch)
                        {
                            MessageBox.Show("Ошибка при считывании header'а конфиг файла, создаю новый конфиг");
                            New();
                        }
                        

                    }
                }
                else
                {
                    MessageBox.Show(cfgFSize.ToString());
                    New();
                }
            }
            else
            {
                MessageBox.Show("not ok file");
                _bValue = false;
            }

        }

        public static void Save()//сохраняем конфиг
        {
            
        }

        
    }
}
