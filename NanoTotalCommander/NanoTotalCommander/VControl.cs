using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanoTotalCommander
{
    public partial class VControl : UserControl
    {
        public VControl()
        {
            InitializeComponent();
        }
        public string CurrentPath { get { return textBoxPath.Text; } set { textBoxPath.Text = value; } }
        public string[] Drives { get { return comboBoxDrives.Items.OfType<string>().ToArray(); } set { comboBoxDrives.Items.Clear(); comboBoxDrives.Items.AddRange(value); } }
        public string[] FilesList
        {
            get
            { return listBoxFiles.Items.OfType<string>().ToArray(); }
            set
            {
                listBoxFiles.Items.Clear();
                if (value != null)
                { listBoxFiles.Items.AddRange(value); }
            }
        }
        public string ClickedItem { get { if (listBoxFiles.SelectedIndex != -1) return listBoxFiles.SelectedItem.ToString(); else return ""; }  }
        public bool IsFocused { get { if (listBoxFiles.SelectedIndex != -1) return true; else return false; } }
        public event EventHandler OnLoadDrives;
        public event EventHandler OnPathChange;
        public event EventHandler OnItemClicked;
        public event EventHandler GetParentPath;

        private void VControl_Load(object sender, EventArgs e)
        {
           //wywolanie eventu loaddrives
        }

        private void comboBoxDrives_DropDown(object sender, EventArgs e)
        {
            
            if (OnLoadDrives != null)
            {
                OnLoadDrives(sender, e);
            }
        }

        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxDrives.SelectedIndex !=-1)
            {
                CurrentPath = comboBoxDrives.SelectedItem.ToString();
                if(OnPathChange!=null)
                {
                    OnPathChange(this, e);
                }
            }
        }

        private void listBoxFiles_DoubleClick(object sender, EventArgs e)
        {

           
                if (OnItemClicked != null)
                {
                    OnItemClicked(this, e);
                }
            
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if(GetParentPath != null)
            {
                GetParentPath(this, e);
            }
        }
        public void Reload(object sender, EventArgs e)
        {
            OnPathChange(this, e);
        }
    }
}
