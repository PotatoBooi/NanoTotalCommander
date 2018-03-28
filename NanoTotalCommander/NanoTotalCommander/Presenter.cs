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

        }

        private string[] getReadyDrives()
        {
            model.LoadDrives();
            return model.DrivesList;
        }
        private string changePath()
        {
            // model.ChangePath(view.)
            return model.Path;
        }
        private string[] getFiles(string path)
        {
            model.LoadFiles(path);
            return model.MakeListToSend();
        }
      

    }
   
}
