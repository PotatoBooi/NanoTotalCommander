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
        public string[] DrivesList { get { return drives; } }

        public void loadDrives()
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
    }
}
