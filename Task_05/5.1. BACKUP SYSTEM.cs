using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Threading;
using System.Globalization;
using static _5._1.BACKUP_SYSTEM.EyeOfTheOdin;

namespace _5._1.BACKUP_SYSTEM
{
    public class EyeOfTheOdin
    {
        private static readonly string myPathToBackupFolder = @"D:\My folder 2";
        private static bool flag = true;
        public static bool Flag
        {
            set => flag = value;
        }
        private static bool CheckingFilesForChange(string pathToTheFile, string backupFolder)//Метод сравнивает каталог. Передаем ссылку на нашу директорию и на бекап
        {
            var DirectoryPath = new DirectoryInfo(pathToTheFile);
            var DirectoryBackup = new DirectoryInfo(backupFolder);
            if (!DirectoryBackup.Exists) return false;
            var filesPath = DirectoryPath.GetFiles().OrderBy(x => x.Name).ToList();
            var filesCacheFolder = DirectoryBackup.GetFiles().OrderBy(x => x.Name).ToList();
            if (filesCacheFolder.Count != filesPath.Count) return false;
            for(int i = 0; i < filesPath.Count; i++)
            {
                if (!filesPath[i].Name.Equals(filesCacheFolder[i].Name) || filesPath[i].LastWriteTime != filesCacheFolder[i].LastWriteTime) return false;
            }
            foreach(DirectoryInfo item in DirectoryPath.GetDirectories())
            {
                if (!CheckingFilesForChange(item.FullName, $@"{backupFolder}\{item.Name}")) return false;
            }
            return true;
        }
        private static void CopyFolder(string pathToTheFile, string backupFolder)//Метод копирует одну папку в другую
        {
            var DirectoryPath = new DirectoryInfo(pathToTheFile);
            Directory.CreateDirectory(backupFolder);
            foreach (FileInfo item in DirectoryPath.GetFiles())
            {
                File.Copy(item.FullName, $@"{backupFolder}/{item.Name}");
            }
            foreach (DirectoryInfo item in DirectoryPath.GetDirectories())
            {
                Directory.CreateDirectory($@"{backupFolder}\{item.Name}");
                CopyFolder(item.FullName, $@"{backupFolder}\{item.Name}");
            }

        }
        private static void SurveillanceMode(string pathToTheFile)//Режим ослеживания, каждые 5 секунд проверяет папку на изменение, и создает бекап в случае изменения
        {
            Directory.CreateDirectory(myPathToBackupFolder);
            ClearDirectory(myPathToBackupFolder);
            string backupFullName = myPathToBackupFolder;
            while (flag)
            {
                if (!CheckingFilesForChange(pathToTheFile, backupFullName))
                {
                    string backupName = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                    Directory.CreateDirectory($@"{myPathToBackupFolder}\{backupName}");
                    CopyFolder(pathToTheFile, $@"{myPathToBackupFolder}/{backupName}");
                    backupFullName = $@"{myPathToBackupFolder}/{backupName}";
                }
                Thread.Sleep(5);
            }
        }
        private static void ClearDirectory(string pathToDirectory)//Очищает выбранную директорию
        {
            var myDirectory = new DirectoryInfo(pathToDirectory);
            foreach (FileInfo item in myDirectory.GetFiles())
            {
                item.Delete();
            }
            foreach (DirectoryInfo item in myDirectory.GetDirectories())
            {
                item.Delete(true);
            }
        }
        public static void StartSurveillanceMode(string pathToTheFile)//Запускает в отдельном потоке
        {
            Thread surveillanceMode = new Thread(() => SurveillanceMode(pathToTheFile));
            surveillanceMode.Start();
        }
        public static bool RollbackChanges(string pathToDirectory, DateTime dateBackup)//Делает откат и возвращает true если получилось, если нужного бекапа нет, то вернет false
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "dd.MM.yyyy HH.mm.ss";
            var DirectoryBackup = new DirectoryInfo(myPathToBackupFolder);
            var foldersInMyDirectoryBackup = DirectoryBackup.GetDirectories().OrderBy(x => x.Name).ToList();
            for (int i = 1; i < foldersInMyDirectoryBackup.Count; i++)
            {
                if(dateBackup > DateTime.ParseExact(foldersInMyDirectoryBackup[i - 1].Name, format, provider) && dateBackup < DateTime.ParseExact(foldersInMyDirectoryBackup[i].Name, format, provider))
                {
                    ClearDirectory(pathToDirectory);
                    CopyFolder($@"{myPathToBackupFolder}/{foldersInMyDirectoryBackup[i - 1].Name}", pathToDirectory);
                    return true;
                }
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tracking changes has begun.Enter the backup date, or 'Stop', to exit the program.");
            StartSurveillanceMode(@"D:\My folder");//Адресс моей папки, где будет происходить проверка
            while (true)
            {
                string myDate = Console.ReadLine();
                try
                {
                    DateTime myDateTime = DateTime.Parse(myDate);
                    if(!RollbackChanges(@"D:\My folder", myDateTime)) Console.WriteLine("Enter the correct date and time, or 'Stop', to terminate the program.");
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine($"{e}: Enter the correct date and time, or 'Stop', to terminate the program.");
                }
                
                if (myDate == "Stop")
                {
                    Flag = false;
                    break;
                }
            }
        }
    }
}
