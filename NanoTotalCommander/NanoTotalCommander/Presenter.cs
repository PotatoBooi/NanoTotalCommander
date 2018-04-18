using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoTotalCommander
{
    public class Presenter
    {
        Model model;
        IView view;
        public Presenter(Model model, IView view)
        {
            this.model = model;
            this.view = view;
            view.LoadDrives += getReadyDrives;
            view.LoadFiles += getFiles;
            view.CheckItem += checkItem;
            view.GetParentPath += getParent;
            view.ButtonsClicked += operation;

        }

        private string[] getReadyDrives()
        {
            return model.LoadDrives();
        }
      
        private string[] getFiles(string path)
        {
            
            return model.LoadFiles(path);
        }
        private string checkItem(string item, string path)
        {
           
            return model.CheckItem(item, path);
        }
        private string getParent(string path)
        {
            return model.GetParent(path);
        }
        private void operation(object obj, EventArgs e,string source, string target, string item, string operation)
        {
           
            model.PerformOperation(source, target, item, operation);
        }
      

    }
   
}
