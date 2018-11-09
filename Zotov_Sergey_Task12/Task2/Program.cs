using System;
using System.IO;
using System.Security.Permissions;


namespace Task2
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Выберите одно из двух:\n" +
                "1. Слежка\n" +
                "2. Бэкап");
            if (Console.ReadKey().KeyChar == 49)
            {
                Run();
            }
            else if (Console.ReadKey().KeyChar == 50)
            {
                if (Directory.Exists(@".\Versions"))
                {
                    Console.WriteLine('\n');
                    CopyToDirectory(new DirectoryInfo(Directory.GetCurrentDirectory() + $@"\Versions\{Console.ReadLine()}"),
                        new DirectoryInfo(Directory.GetCurrentDirectory()), true);
                }
                else
                {
                    Console.WriteLine("Вы не устанавливали слежку! Перезапустите приложение и повторите попытку снова.");
                }
            }

            Console.ReadKey();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
            string path = $@"{Directory.GetCurrentDirectory()}\Versions\{DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss")}";
            DirectoryInfo directory = Directory.CreateDirectory(path);
            FileSystemWatcher watcher = new FileSystemWatcher
            {
                Path = ".",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                Filter = "*.txt",
                IncludeSubdirectories = true
            };
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.EnableRaisingEvents = true;
            Console.WriteLine("\nPress \'q\' and then press Enter to quit the sample.");
            while (Console.Read() != 'q')
            {
                ;
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            string path = $@"{Directory.GetCurrentDirectory()}\Versions\{DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss")}";
            try
            {
                Directory.CreateDirectory(path);
                CopyToDirectory(new DirectoryInfo(Directory.GetCurrentDirectory()), new DirectoryInfo(path), false);
            }
            catch (IOException) { }
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            string path = $@"{Directory.GetCurrentDirectory()}\Versions\{DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss")}";
            try
            {
                Directory.CreateDirectory(path);
                CopyToDirectory(new DirectoryInfo(Directory.GetCurrentDirectory()), new DirectoryInfo(path), false);
            }
            catch (IOException) { }
        }

        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            string path = $@"{Directory.GetCurrentDirectory()}\Versions\{DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss")}";
            try
            {
                Directory.CreateDirectory(path);
                CopyToDirectory(new DirectoryInfo(Directory.GetCurrentDirectory()), new DirectoryInfo(path), false);
            }
            catch (IOException) { }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            string path = $@"{Directory.GetCurrentDirectory()}\Versions\{DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss")}";
            try
            {
                Directory.CreateDirectory(path);
                CopyToDirectory(new DirectoryInfo(Directory.GetCurrentDirectory()), new DirectoryInfo(path), false);
            }
            catch (IOException) { }
        }

        public static void CopyToDirectory(DirectoryInfo source, DirectoryInfo target, bool isBackup)
        {
            if (isBackup)
            {
                foreach (var dir in Directory.GetDirectories(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories))
                {
                    if (dir.Contains("Versions"))
                    {
                        continue;
                    }

                    try
                    {
                        Directory.Delete(dir, true);
                    }
                    catch (IOException) { }
                }

                foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt"))
                {
                    File.Delete(file);
                }
            }
            //copy all the files into the new directory
            foreach (FileInfo fi in source.GetFiles("*.txt"))
            {
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }
            //copy all the sub directories using recursion
            foreach (DirectoryInfo diSourceDir in source.GetDirectories())
            {
                if (!isBackup && diSourceDir.FullName.Contains("Versions"))
                {
                    continue;
                }

                DirectoryInfo nextTargetDir = target.CreateSubdirectory(diSourceDir.Name);
                CopyToDirectory(diSourceDir, nextTargetDir, isBackup);
            }
        }
    }
}
