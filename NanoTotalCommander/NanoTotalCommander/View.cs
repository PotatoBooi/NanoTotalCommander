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
            vControlLeft.OnItemClicked += new EventHandler(this.itemClicked);
            vControlLeft.GetParentPath += new EventHandler(this.getParentPath);
            vControlRight.OnLoadDrives += new EventHandler(this.vControlLoadDrives);
            vControlRight.OnPathChange += new EventHandler(this.loadFiles);
            vControlRight.OnItemClicked += new EventHandler(this.itemClicked);

            vControlRight.GetParentPath += new EventHandler(this.getParentPath);

        }

        public string[] DrivesList { get { return vControlLeft.Drives; } set { vControlLeft.Drives = value; vControlRight.Drives = value; } }
        public string LeftControlPath { get {return vControlLeft.CurrentPath; } set { vControlLeft.CurrentPath = value; } }
        public string[] LeftControlFiles { get { return vControlLeft.FilesList; } set { vControlLeft.FilesList = value; } }
        public string RightControlPath { get { return vControlRight.CurrentPath; } set { vControlRight.CurrentPath = value; } }
        public string[] RightControlFiles { get { return vControlRight.FilesList; } set { vControlRight.FilesList = value; } }

        public event Func<string[]> LoadDrives;
        public event Func<string, string[]> LoadFiles;
        public event Func<string, string, string> CheckItem;
        public event Func<string,string> GetParentPath;
        public event Action<object, EventArgs,string,string,string,string> ButtonsClicked;

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


        private void itemClicked(object sender, EventArgs e)
        {
            VControl control = (VControl)sender;
            if(CheckItem != null && LoadFiles !=null && control.ClickedItem !=null)
            {

                string tmp = control.CurrentPath;
                control.CurrentPath = CheckItem(control.ClickedItem, control.CurrentPath);
                if (control.CurrentPath != tmp && LoadFiles != null)
                {
                    control.FilesList = LoadFiles(control.CurrentPath);
                }
            }

        }
        private void getParentPath(object sender, EventArgs e)
        {
            VControl control = (VControl)sender;
            if(control.CurrentPath.Length >3 && GetParentPath != null && LoadFiles != null)
            {
                control.CurrentPath = GetParentPath(control.CurrentPath);
                control.FilesList = LoadFiles(control.CurrentPath);
            }

        }

        private void operationButtonsClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (ButtonsClicked != null)
            {
                if (vControlLeft.IsFocused)
                {
                 ButtonsClicked(sender, e, LeftControlPath, RightControlPath, vControlLeft.ClickedItem,button.Text);
                 vControlLeft.Reload(vControlLeft, e);
                 vControlRight.Reload(vControlLeft, e);
                }
                else if(vControlRight.IsFocused)
                {
                    ButtonsClicked(sender, e, RightControlPath, LeftControlPath, vControlRight.ClickedItem, button.Text);
                    vControlRight.Reload(vControlLeft, e);
                    vControlLeft.Reload(vControlLeft, e);
                }

            }

            
        }
    }
}
