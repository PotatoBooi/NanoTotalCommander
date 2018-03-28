using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoTotalCommander
{
    public class Model
    {
        private string[] drives;
        private string[] files;
        private string path;

        public string Path { get { return path; } }
        public string[] FilesList
        {
            get { return files; }
        }
        public string[] DrivesList { get { return drives; } }

        public void LoadDrives()
        {
            System.IO.DriveInfo[] tmp = System.IO.DriveInfo.GetDrives();
            List<string> drivesList = new List<string>();
            foreach (System.IO.DriveInfo drive in tmp)
            {
                if (drive.IsReady)
                {
                    drivesList.Add(drive.ToString());
                }
            }


            drives = drivesList.ToArray();
        }
        public void LoadFiles(string path)
        {
            List<string> items = new List<string>();
            if(System.IO.Directory.Exists(path))
            {
                items.AddRange(System.IO.Directory.GetDirectories(path));
                items.AddRange(System.IO.Directory.GetFiles(path));
            }
            files = items.ToArray();
        }

        public void ChangePath(string upath)
        {
            if (System.IO.Directory.Exists(upath))
            {
                path = upath;
            }
        }
        public string[] MakeListToSend()
        {
            
            foreach (string file in FilesList)
            {

                Console.WriteLine("wywolanie kurcze" + file);

            }
            List<string> listtosend = new List<string>();
            foreach (string file in FilesList)
            {
                string tmp = System.IO.Directory.GetParent(file).ToString();
                
                if (isDir(file))
                {
                    listtosend.Add(file.Replace(tmp, "<dir> "));


                }
                else
                {
                    listtosend.Add(file.Replace(tmp, ""));
                }

            }
            return listtosend.ToArray();
        }
        private bool isDir(string pathtocheck)
        {
           
                
                System.IO.FileAttributes attr = System.IO.File.GetAttributes(pathtocheck);
                if (attr.HasFlag(System.IO.FileAttributes.Directory))
                {
                    return true;
                }
               
           

                return false;
        }
    }
}
