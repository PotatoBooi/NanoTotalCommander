using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanoTotalCommander
{
    public partial class View : Form, IView
    {
        public View()
        {
            InitializeComponent();
            vControlLeft.OnLoadDrives += new EventHandler(this.vControlLoadDrives);
            vControlLeft.OnPathChange += new EventHandler(this.loadFiles);

        }

        public string[] DrivesList { get { return vControlLeft.Drives; } set { vControlLeft.Drives = value; } }
        public string LeftControlPath { get {return vControlLeft.CurrentPath; } set { vControlLeft.CurrentPath = value; } }
        public string[] LeftControlFiles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string RightControlPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string[] RightControlFiles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Func<string[]> LoadDrives;
        public event Func<string, string[]> LoadFiles;

        private void View_Load(object sender, EventArgs e)
        {
            if (LoadDrives != null)
            {
                DrivesList = LoadDrives();
            }
        }

        private void vControlLoadDrives(object sender, EventArgs e)
        {
            if(LoadDrives!= null)
            {
                DrivesList = LoadDrives();
            }
        }

        private void loadFiles(object sender, EventArgs e)
        {
            VControl control = (VControl)sender;

            if(LoadFiles != null)
            {
                control.FilesList = LoadFiles(control.CurrentPath);
            }
        }
    }
}
