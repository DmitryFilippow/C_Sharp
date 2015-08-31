using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace GameCheatsDBSQL
{
    
    public partial class CheatsDBForm : Form
    {
        public static string ConString = "GCDB";
        private static string _ch = "GCDBCFG";
        public static string _ccs = _ccs = String.Format(@"Data Source={0}\SQLEXPRESS;Initial Catalog=GCDB;Integrated Security=True", Environment.MachineName);
        public static string FileName = "GCDB.cfg";
        public static FileInfo cfgFInfo;
        public static long cfgFSize = 0;
        public bool ConnectOK = false;

        [SerializableAttribute]
        public struct CfgDataStruct2
        {
            public string CfgHdr;
            public string ConStr;
        }

        
        public List<Cheat> GCheatsSave = new List<Cheat>();
        public DirectoryInfo dirInfo=new DirectoryInfo(Directory.GetCurrentDirectory());

        public CfgDataStruct2 CfgData2=new CfgDataStruct2();

        public void DBLoad()
        {
            using (GCDBContext dbc=new GCDBContext(ConString))
            {
                
            }

        }
        public void DBSave()
        {
            using (GCDBContext dbc=new GCDBContext(CfgData2.ConStr))
            {
                Cheat cheat = new Cheat()
                {
                    FileName = @"c:\test"
                };
                dbc.Cheats.Add(cheat);
                dbc.SaveChanges();
            }
        }

        public void CfgNew()//создаем конфиг с дефолт данными
        {
            CfgData2.CfgHdr = _ch;
            CfgData2.ConStr = _ccs;
            FileStream fileWrite = File.Create(FileName);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileWrite,CfgData2);
            fileWrite.Close();
            MessageBox.Show("Config create");
        }

        public bool CfgLoad()//грузим конфиг
        {
            cfgFInfo = new FileInfo(FileName);
            if (cfgFInfo.Exists)
            {
                cfgFSize = cfgFInfo.Length;
                if (cfgFSize != 0)
                {
                    if (File.Exists(FileName))
                    {
                        FileStream fileRead = File.Open(FileName, FileMode.Open);
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        try
                        {
                            CfgData2 = (CfgDataStruct2) binaryFormatter.Deserialize(fileRead);
                        }
                        catch (SerializationException se)
                        {
                            MessageBox.Show(String.Format("Нарушена структура файла - {0}", se.Message));
                            fileRead.Close();
                            return false;
                        }
                        fileRead.Close();
                        DBLoad();
                        
                        //dbSL1.Text = CfgData2.ConStr;
                        ConString = CfgData2.ConStr;
                        ConStrTB.Text = ConString;
                        
                        dbSLok.Text = ":ok";
                    }
                    
                }
                return true;
                
            }
            dbSLok.Text = ":fail";
            return false;
        }

        public void CfgSave()//сохраняем конфиг
        {
            CfgData2.CfgHdr = _ch;
            CfgData2.ConStr = ConStrTB.Text;
            dbSL1.Text = CfgData2.ConStr;
            FileStream fileWrite = File.Create(FileName);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileWrite, CfgData2);
            fileWrite.Dispose();
            fileWrite.Close();
        }


        
        public CheatsDBForm()
        {
            InitializeComponent();
            //KeyPress+= new KeyPressEventHandler(CheatsDBForm_KeyPress);
        }

        private void CoonectDBButton_Click(object sender, EventArgs e)
        {
            if (!CfgLoad())
            {
                CfgNew();
                CfgLoad();
            }
            //dbc=new GCDBContext(CfgData2.ConStr);
            CFGPanel.Enabled = true;
            DBContentPanel.Enabled = true;
            UpdateContent();
            ConnectOK = true;
            
        }

        private int[] _genresNum;
        private List<string> _genresStr=new List<string>();
        
        public Cheat CurCheat=new Cheat();

        private void UpdateContent()
        {
            Type gType = typeof (GenrEnum);
            int im = 0;
            GameLB.Items.Clear();
            GenreCB.Items.Clear();
            foreach (var g in gType.GetFields())
            {
                _genresStr.Add(g.Name);
                GenreCB.Items.Add(g.Name);
                im++;
            }
            
            GenreCB.Items[0] = "Все";
            if (GenreCB.Items.Count>1) GenreCB.SelectedIndex = 0;

            _genresNum=new int[im];
            for (int i = 0; i < im; i++)
            {
                _genresNum[i] = i;
            }

            using (GCDBContext _dbc =new GCDBContext(ConString))
            {
                dbSL1.Text = _dbc.Database.Connection.Database;//SELECT DB_NAME() AS [Current Database];
                             
                var GCheatsLoad = from c in _dbc.Cheats 
                              //where c.Id>2 
                              select c;
                /*foreach (var cheat in GCheatsLoad)
                {
                    GameLB.Items.Add(cheat.GameName);
                }*/
                RefreshGameLB();
            }
            

        }

        public string SelectGameName = "";
        public int genreShowNum = 0;
        public void RefreshGameLB()
        {
            genreShowNum = GenreCB.SelectedIndex;
            GameLB.Items.Clear();
            Cheats.Clear();
            using (GCDBContext _dbc = new GCDBContext(ConString))
            {
                IQueryable<Cheat> req;
                if (genreShowNum == 0)
                {
                    req = from VAR in _dbc.Cheats
                              select VAR;

                }
                else
                {
                    req = from VAR in _dbc.Cheats
                          where VAR.Genre == genreShowNum
                          select VAR;
                }
                foreach (var cheat in req)
                {
                    Cheats.Add(cheat);

                }
                foreach (var cheat in Cheats)
                {
                    GameLB.Items.Add(cheat.GameName);
                }
                if (GameLB.Items.Count>0) GameLB.SelectedIndex = 0;
            }
            
        }

        
        

        private void SaveCFGButton_Click(object sender, EventArgs e)
        {
            CfgSave();
        }

        private void DelFromDBButton_Click(object sender, EventArgs e)
        {
            RemoveGame();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            
        }

        public void RemoveGame()
        {
            /*var rreq = from game in Cheats
                       where game.GameName == SelectGameName
                       select game;*/
            using (GCDBContext _dbc = new GCDBContext(ConString))
            {
                var RR = _dbc.Cheats.FirstOrDefault(c => c.GameName == SelectGameName);
                if (RR != null)
                {
                    _dbc.Cheats.Remove(RR);
                    _dbc.SaveChanges();
                    RefreshGameLB();
                }

            }
        }
        public void AddGame()
        {
            if (LastSetFileName.Length <= 0)
            {
                LastSetFileName = BrowseCFD.SafeFileName;
                //LastSetFileName = BrowseCFD.FileName;
            }
            else
            {
                LastSetFileName = CurCheat.GameName;
                //LastSetFileName = Path.Combine(dirInfo.FullName, CurCheat.GameName);
            }
            //CheatFileName = BrowseCFD.FileName;
            CheatFileName = LastSetFileName;
            
            CurCheat.FileName = CheatFileName;
            CurCheat.GameName = GameNameTB.Text;
            CurCheat.Genre = GenreCB.SelectedIndex;
            
            //MessageBox.Show(CurCheat.FileName);
            //MessageBox.Show(CurCheat.GameName);
            //MessageBox.Show(CurCheat.Genre.ToString());
            AddToDB(dbc);
            LastSetFileName = "";
        }

        private void AddToBaseButton_Click(object sender, EventArgs e)
        {
            AddGame();
            RefreshGameLB();
        }

        public void AddToDB(GCDBContext _dbc)
        {
            using (_dbc=new GCDBContext(ConString))
            {
                _dbc.Cheats.Add(CurCheat);
                _dbc.SaveChanges();
            }
        }

        public StringBuilder ContCheat;

        private void BrowseFileCheat_Click(object sender, EventArgs e)
        {
            /*BrowseCheat();
            if (File.Exists(CheatFileName))
            {
                if (ContCheat != null) ContCheat=null;
                ContCheat = new StringBuilder();
                CheatContRTB.Clear();
                
                using (FileStream fStream = new FileStream(CheatFileName, FileMode.Open, FileAccess.Read))
                {
                    using (TextReader textR = new StreamReader(fStream, Encoding.Default))
                    {
                        string curStr = textR.ReadLine();
                        while (curStr != null)
                        {
                            curStr = textR.ReadLine();
                            ContCheat.AppendLine(curStr);
                        }
                        CheatContRTB.Text = ContCheat.ToString();//AppendText(String.Format("{0}\n", curStr));
                    }
                    
                }

            }*/
            CheatContRTB.Enabled = false;
            CurCheat.FileName = BrowseLCheat();
            CCFName = CurCheat.FileName;
            CheatContRTB.Enabled = true;
        }
        
        public string LastSetFileName = "";
        public string CheatFileName="";
        public string BrowseCheat()
        {
            BrowseCFD.InitialDirectory = dirInfo.FullName;
            BrowseCFD.ShowDialog();
            return CheatFileName = BrowseCFD.SafeFileName;
            //return CheatFileName = Path.Combine(dirInfo.FullName, BrowseCFD.FileName);
        }

        public string BrowseSCheat()
        {
            BrowseSCFD.InitialDirectory = dirInfo.FullName;
            
            if ((DialogResult) BrowseSCFD.ShowDialog() != DialogResult.Cancel)
            {
                FileInfo fileInfo = new FileInfo(BrowseSCFD.FileName);
                //MessageBox.Show(fileInfo.Name);
                return CheatFileName = fileInfo.Name; //BrowseSCFD.FileName;
            }
            else return CheatFileName = CurCheat.GameName;
            //return CheatFileName = Path.Combine(dirInfo.FullName, BrowseSCFD.FileName);
        }

        private void BrowseSaveFileCheat_Click(object sender, EventArgs e)
        {
            CurCheat.FileName=BrowseSCheat();
            CCFName = CurCheat.FileName;
            //BrowseSCheat();
         }

        public string BrowseLCheat()
        {
            BrowseCheat();
            
            if (File.Exists(CheatFileName))
            {
                if (ContCheat != null) ContCheat = null;
                ContCheat = new StringBuilder();
                CheatContRTB.Clear();
                using (FileStream fStream = new FileStream(CheatFileName, FileMode.Open, FileAccess.Read))
                {
                    using (TextReader textR = new StreamReader(fStream, Encoding.Default))
                    {
                        string curStr = textR.ReadLine();
                        while (curStr != null)
                        {
                            curStr = textR.ReadLine();
                            ContCheat.AppendLine(curStr);
                        }
                        CheatContRTB.Text = ContCheat.ToString();//AppendText(String.Format("{0}\n", curStr));
                    }
                    
                }

            }
            return CheatFileName = BrowseCFD.SafeFileName;
            //return CheatFileName = Path.Combine(dirInfo.FullName, BrowseCFD.FileName);
        }

        private void ClearBaseButton_Click(object sender, EventArgs e)
        {
            ClearDB(dbc);
            UpdateContent();
            
        }

        public void ClearDB(GCDBContext _dbc)
        {

            using (_dbc=new GCDBContext(ConString))
            {

                var all = _dbc.Cheats;//.Where(c => c.Id > -1);
                if (all.Any())
                {
/*                    using (SqlConnection s1=new SqlConnection(ConString))
                    {

                        using (SqlCommand cmd = new SqlCommand())
                        {

                            cmd.Connection = s1;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "DELETE FROM Cheats";

                        }
                        
                       
                    }*/

                    _dbc.Database.ExecuteSqlCommand("DELETE FROM Cheats");
                    
                    /*foreach (var cheat in all)
                    {
                        _dbc.Cheats.Remove(cheat);
                    }*/
                    
                    _dbc.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Cheats', RESEED, -1)");
                    _dbc.SaveChanges();
                    MessageBox.Show("Game cheat база очищена");
                }
                else
                {
                    MessageBox.Show("Game cheat база пустая");
                }
            }
            
        }

        public void ConnectToDB(Action ActionMethod )
        {
            if (ActionMethod == null) throw new ArgumentNullException("ActionMethod is null");
            using (dbc)
            {
                this.Invoke(ActionMethod);
            }
            
        }

        private GCDBContext dbc;
        public void test1()
        {
            MessageBox.Show("test1");
        }

        private void ConStrTB_TextChanged(object sender, EventArgs e)
        {
            ConString = ConStrTB.Text;
        }

        private void BrowseSCFD_FileOk(object sender, CancelEventArgs e)
        {
            SaveCheatFile(BrowseSCFD.FileName);
        }

        public void SaveCheatFile(string fileName)
        {
            //if (ContCheat != null) ContCheat.Clear();
            //ContCheat = new StringBuilder();
            //ContCheat.Append(CheatContRTB.Text);
            /*using (FileStream fStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (TextWriter textW = new StringWriter(ContCheat))
                    {
                    textW.Write(CheatContRTB); 
                    //CheatContRTB.Text = ContCheat.ToString();//AppendText(String.Format("{0}\n", curStr));
                    
                    }
                
                }*/
            //File.WriteAllText(fileName, CheatContRTB.Text, Encoding.Default);
            CheatContRTB.SaveFile(fileName,RichTextBoxStreamType.PlainText);
        }

        private void CheatContRTB_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void CheatsDBForm_Load(object sender, EventArgs e)
        {

        }

        private void CheatsDBForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (ConnectOK)
            {
                case true:
                //if (e.Control == true && e.KeyCode == Keys.S) BrowseSCheat();
                    switch (e.Control)
                    {
                        case true:
                            //if (e.KeyCode == Keys.S) BrowseSCheat();
                            switch (e.KeyCode)
                            {
                                case Keys.S:
                                    BrowseSCheat();
                                    break;
                                    case Keys.L:
                                    CurCheat.FileName = BrowseLCheat();
                                    CCFName = CurCheat.FileName;
                                    break;
                                    case Keys.A:
                                    AddGame();
                                    RefreshGameLB();
                                    break;
                            }
                            break;

                    }
                break;
            }
            
            }

        private void GenreCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGameLB();
            RefreshCheatTxt(SelectGameName);
        }

        public void RefreshCheatTxt(string gameName)
        {
            if (gameName != null)
            {
                
            }
        }

        public void ShowCheat()
        {
            try
            {
                if (GameLB.SelectedItem != null) GameLB.SelectedItem = 0;
                SelectGameName = GameLB.SelectedItem.ToString();
            }
            catch (NullReferenceException ex)
            {
                GameLB.SelectedItem = 0;

            }
            

            var req = from cheat in Cheats
                      where cheat.GameName == SelectGameName
                      select cheat;
                      //select cheat.FileName;

            string FName = "";
            foreach (var cheat in req)
            {
                CheatFileName = cheat.FileName;
                GameNameTB.Text = cheat.GameName;
                TestLabel2.Text = CheatFileName;
                GLabel.Text = GenreCB.Items[cheat.Genre].ToString();
                //MessageBox.Show(CheatFileName);
            }
            if (File.Exists(CheatFileName))
            {
                //if (ContCheat != null) ContCheat = null;
                ContCheat = new StringBuilder();
                CheatContRTB.Clear();

                using (FileStream fStream = new FileStream(CheatFileName, FileMode.Open, FileAccess.Read))
                {
                    using (TextReader textR = new StreamReader(fStream, Encoding.Default))
                    {
                        string curStr = textR.ReadLine();
                        ContCheat.AppendLine(curStr);
                        while (curStr != null)
                        {
                            curStr = textR.ReadLine();
                            ContCheat.AppendLine(curStr);
                        }
                        CheatContRTB.Text = ContCheat.ToString(); //AppendText(String.Format("{0}\n", curStr));
                    }

                }

            }
        }

        private void GameLB_SelectedIndexChanged(object sender, EventArgs e)
        {
           ShowCheat();

            
        }
        public List<Cheat> Cheats=new List<Cheat>();

        private void FindDBButton_Click(object sender, EventArgs e)
        {
            RefreshGameLBFind();
        }

        public void RefreshGameLBFind()
        {
//            genreShowNum = GenreCB.SelectedIndex;
            if (GameNameTB.Text.Any())
            {
                GameLB.Items.Clear();

                //Cheats.Clear();


                var req1 = from cheat1 in Cheats
                           where cheat1.GameName == GameNameTB.Text
                           select cheat1;

                foreach (var cheat in req1)
                {
                    GameLB.Items.Add(cheat.GameName);
                    ShowCheat();

                }
            }
            else
            {
                RefreshGameLB();
            }
        }

        private void GameNameTB_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void EditDBButton_Click(object sender, EventArgs e)
        {
            
            EditGame();
        }

        public string CCFName = "";
        public void EditGame()
        {
            if (CCFName.Length != 0)
            {
                using (GCDBContext _dbc = new GCDBContext(ConString))
                {
                    var EGR = _dbc.Cheats.FirstOrDefault(c => c.GameName == SelectGameName);
                    if (EGR != null)
                    {
                        EGR.GameName = GameNameTB.Text;
                        CurCheat.FileName = CCFName;
                        EGR.FileName = CurCheat.FileName;
                        EGR.Genre = GenreCB.SelectedIndex;
                    }
                    _dbc.SaveChanges();
                    RefreshGameLB();
                }
            }
            else
            {
                MessageBox.Show("Необходимо привязать cheat file");
                return;
            }

        }

        private void GenreCB_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void CheatsDBForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void BackupDB()
        {
            
            string BackupCmd =
                @"BACKUP DATABASE [{0}] TO DISK = N'{1}' WITH NOFORMAT, NOINIT, NAME = N'MyGCDB backup!', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
            using (GCDBContext dbc=new GCDBContext(ConString))
            {
                string dbName = dbc.Database.Connection.Database;
                dbc.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction,
                                               String.Format(BackupCmd, dbName, Path.Combine(dirInfo.FullName,"GCDBBackup")));

            }
        }
        public void RestoreDB()
        {
                SqlConnection ObjConnection=new SqlConnection(ConString);
                ObjConnection.Open();

                SqlCommand RestoreCmd = new SqlCommand();
                RestoreCmd.Connection = ObjConnection;
                string bakfile = Path.Combine(dirInfo.FullName,"GCDBBackup");
            try
            {
                RestoreCmd.CommandText = "Use Master   ALTER DATABASE GCDB SET OFFLINE WITH ROLLBACK IMMEDIATE  " +
                                         "Restore Database GCDB From Disk='" + bakfile + "'" +
                                         "   ALTER DATABASE GCDB SET ONLINE WITH ROLLBACK IMMEDIATE";
                RestoreCmd.CommandType = CommandType.Text;
                RestoreCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не нашел бэкап!");
            }
            ObjConnection.Close();
            ObjConnection.Dispose();
        }

        private void BackupDBButton_Click(object sender, EventArgs e)
        {
            BackupDB();
        }



        private void RestoreDBButton_Click(object sender, EventArgs e)
        {
            RestoreDB();
            UpdateContent();
        }

        }
    }

