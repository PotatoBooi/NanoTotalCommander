using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoTotalCommander
{
    public interface IView
    {
        string[] DrivesList { get; set; }
        string LeftControlPath { get; set; }
        string[] LeftControlFiles { get; set; }
        string RightControlPath { get; set; }
        string[] RightControlFiles { get; set; }

        event Func<string[]> LoadDrives;

    }
}
