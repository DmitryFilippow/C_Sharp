using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace ConsoleSorter
{
    internal class Program
    {
        public static List<string> NFNames = new List<string>();
        public static DirectoryInfo DirInfo;
        public static FileInfo fDirInfo;
        public static int TotalFiles = 0;
        public static int Types = 0;
        public static FileInfo[] FilesInfo;
        public static Random Xr = new Random(DateTime.Now.Millisecond);
        public static string _xr = "";
        public const int K4 = (1024) * 4;//4kb
        public static IEnumerable<string> ExtsE;
        public static long TotalSize = 0;
        public static string LFName = "";
        public static string Sortdir = @"Sort\";
        public static bool LogRes = false;
        public static bool SorterStart = false;

        static void Exit()
        {
            if (SorterStart)
            {
                switch (LogRes)
                {
                    case true:
                        Console.WriteLine("Лог файл сортировки {0} создан", LFName);
                        break;
                    default:
                        Console.WriteLine("Лог файл не был создан");
                        break;
                }
            }
            Environment.Exit(1);
        }

        static DirectoryInfo GetDirInfo()
        {
            return fDirInfo.Directory;
        }

        static bool CreateLog(string pathname)
        {
            string logReader = "Notepad";
            long inByte = TotalSize;
            string gmb_s = "мега";
            FileInfo LogFile = new FileInfo(pathname);

            using (StreamWriter LogSW = LogFile.CreateText())
            {
                LogSW.WriteLine("Список файлов и их старые пути");
                foreach (var fl in FilesInfo)
                {
                    LogSW.WriteLine(fl.FullName);
                }
                LogSW.WriteLine("Список файлов по новому пути");
                foreach (var fn in NFNames)
                {
                    LogSW.WriteLine(fn);
                }

                TotalSize = TotalSize / (1024 * 1024);
                LogSW.WriteLine("Всего типов файлов обработано = {0} с учетом регистра расширения", Types);
                LogSW.WriteLine("Всего файлов отсортировано = {0}", TotalFiles);
                if (TotalSize < 1)
                {
                    if (inByte < 1024) { gmb_s = ""; }
                    else
                    {
                        gmb_s = "кило";
                        inByte = inByte / 1024;
                    }
                    TotalSize = inByte;
                }
                if (TotalSize >= 1024)
                {
                    gmb_s = "гига";
                    TotalSize = TotalSize / 1024;
                }
                LogSW.WriteLine("Объем отсортированных файлов = {0} {1}байт", TotalSize, gmb_s);
                try
                {
                    Process.Start(logReader, LFName);
                }
                catch (Win32Exception)
                {
                    Console.WriteLine(String.Format("Не смог запустить {0} для просмотра лога!", logReader));
                }
                finally
                {
                    Console.WriteLine("Пуск {0}  для просмотра лога", logReader);
                }
                return true;
            }
        }

        public static string[] SetArgs = new string[2];

        static void CheckDirInfo(string[] args)
        {
            fDirInfo = new FileInfo(args[0]);
            try
            {
                Sortdir = args[1];
            }
            catch (Exception)
            {
                Sortdir = @"C:\Sort\";
            }

            Console.WriteLine("Папка с отсортированными файлами = {0} \n(Нажмите любую кнопку для начала сортировки)", Sortdir);
            Console.ReadKey();

            DirInfo = GetDirInfo();
            string diend = String.Format("{0}{1}", DirInfo.FullName, "\u005c");

            if (fDirInfo.ToString().CompareTo(diend) != 0)
            {
                Console.WriteLine(@"А гдэ '\' в конце?");
                Console.Write(@"Выбранная директория: {0}   [ Y/N/'Any key' ]  ( 'N' перейти в = {1}\ 'Any key' - Выход )  ",
                    DirInfo.FullName, fDirInfo.ToString());
                string yn = Console.ReadLine();
                switch (yn)
                {
                    case "y":
                    case "Y":
                        break;

                    case "n":
                    case "N":
                        diend = null;
                        args[0] = String.Format("{0}{1}", fDirInfo.ToString(), "\u005c");
                        CheckDirInfo(SetArgs);
                        break;

                    default:
                        Exit();
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            string disk1 = Path.GetPathRoot(Environment.SystemDirectory);
            Sortdir = String.Format("{0}{1}", disk1, Sortdir);
            string appname = String.Format("{0}.exe", Assembly.GetExecutingAssembly().GetName().Name);
            Console.Clear();
            Console.Title = appname;
            if (args.Length == 0)
            {
                Console.Write(@"/help - показать справку");
                return;
            }
            args[0] = args[0].ToLower();
            if (args[0] == @"/help")
            {
                Console.WriteLine(@"{0} {1} {2}",
                                  appname,
                                  @"[d:\Что сортируем\]",
                                  @"[d:\Куда сортируем\]");
                Console.WriteLine(@"(По умолчанию сортируем в {0} )", Sortdir);
                Console.WriteLine("Пример");
                Console.WriteLine(@"{0} {1} {2}", appname, @"E:\Games\Fallout2\", Sortdir);
                Exit();
            }

            SorterStart = true;

            Console.SetBufferSize(80, 3000);

            int aI = 0;
            foreach (var arg in args)
            {
                SetArgs[aI] = arg;
                aI++;
            }

            try
            {
                if (!SetArgs[1].Any()) { }
            }
            catch (Exception)
            {
                SetArgs[1] = Sortdir;
            }

            CheckDirInfo(SetArgs);

            TotalFiles = 0;
            if (Directory.Exists(DirInfo.FullName))//Есть такая папка?
            {
                Console.WriteLine("Читаю папку {0}, подождите", DirInfo.FullName);

                FilesInfo = DirInfo.GetFiles("*.*", SearchOption.AllDirectories);
                if (FilesInfo.Length > 0)
                {
                    int cf = 1;
                    string newpath = "";

                    List<string> Exts = new List<string>();//все расширения файлов
                    foreach (var fileInfo in FilesInfo)
                    {
                        TotalSize = TotalSize + fileInfo.Length;
                        Exts.Add(fileInfo.Extension);
                    }
                    TotalFiles = FilesInfo.Length;
                    ExtsE = Exts.Distinct();//отрезаем всё лишнее
                    Types = ExtsE.Count();

                    //Создаем папки для наших файлов
                    if (!Directory.Exists(Sortdir))
                    {
                        Console.WriteLine("Создаю папку {0}", Sortdir);
                        Directory.CreateDirectory(Sortdir);
                    }
                    foreach (var folder in ExtsE)
                    {
                        if (!Directory.Exists(Path.Combine(Sortdir + folder.ToString())))
                        {
                            Console.WriteLine(@"Создаю папку {0}{1}\", Sortdir, folder.ToString());
                            Directory.CreateDirectory(Sortdir + folder.ToString());
                        }
                    }

                    foreach (var fileInfo in FilesInfo)
                    {
                        Xr = new Random(DateTime.Now.Millisecond);

                        fileInfo.Attributes = FileAttributes.Normal;
                        fileInfo.Attributes = FileAttributes.NotContentIndexed;
                        DirInfo.Attributes = FileAttributes.NotContentIndexed; ;
                        DirInfo.Attributes = FileAttributes.Normal;

                        if (File.Exists(fileInfo.FullName))
                        {
                            _xr = "";
                            newpath = Path.Combine(Sortdir + fileInfo.Extension.ToString() + @"\", fileInfo.Name);
                            try
                            {
                                fileInfo.CopyTo(newpath);
                            }
                            catch (Exception)
                            {
                                if (fileInfo.Length <= K4)
                                {
                                    // Специальная задержка текущего потока для файла размера менее 4k т.к. 
                                    // для маленьких файлов нехватает времени сгенерировать рандомные имена
                                    // и они пересекались друг друга переписываю,
                                    Thread.Yield();
                                }
                                _xr = Xr.Next(0, 9999).ToString();

                                newpath = Path.Combine(Sortdir + fileInfo.Extension.ToString() + @"\",
                                                       @"copy_" +
                                                       String.Format("{0}-{1}-{2}-{3}_", DateTime.Now.Hour.ToString(),
                                                                     DateTime.Now.Minute.ToString(),
                                                                     DateTime.Now.Second.ToString(), _xr) + fileInfo.Name);

                                fileInfo.CopyTo(newpath, true);
                            }
                        }

                        NFNames.Add(newpath.ToString());

                        Console.Clear();
                        Console.WriteLine("Директория:{0} ", DirInfo.FullName);
                        Console.WriteLine("Идёт сортировка, подождите");
                        Console.WriteLine("Файлов отсортировано:[ {0} из {1} ]", cf, TotalFiles);
                        Console.WriteLine(fileInfo.FullName);
                        cf++;
                    }
                    String[] TotalFilesA = new string[TotalFiles];
                    for (int i = 0; i < FilesInfo.Length; i++)
                    {
                        TotalFilesA[i] = FilesInfo[i].FullName;
                    }
                    TotalFilesA = TotalFilesA.OrderBy(c => c).ToArray();
                    foreach (var s in TotalFilesA)
                    {
                        Console.WriteLine(s);
                    }

                    Console.WriteLine("Всего файлов: {0}", TotalFiles);

                    LFName = Path.Combine(Sortdir,
                                                 String.Format("{0}-{1}-{2}_", DateTime.Now.Hour.ToString(),
                                                               DateTime.Now.Minute.ToString(),
                                                               DateTime.Now.Second.ToString()) +
                                                 @"log.txt");

                    LogRes = CreateLog(LFName);
                    Exit();
                }
            }
            else
            {
                Console.WriteLine("Хрен тебе, а не {0}, нет такой папки! ", DirInfo.FullName);
                Exit();
            }
        }

    }
}
