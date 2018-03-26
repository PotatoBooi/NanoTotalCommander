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

        }

        private string[] getReadyDrives()
        {
            model.loadDrives();
            return model.DrivesList;
        }
      

    }
   
}
