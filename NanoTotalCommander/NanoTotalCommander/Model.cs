using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoTotalCommander
{
    public class Model
    {
        private string dirTag = "<dir> ";

        #region Public Methods
        public string [] LoadDrives()
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


            return drivesList.ToArray();
        }
        public string[] LoadFiles(string path)
        {
            try
            {
                System.IO.FileAttributes attr = (new System.IO.FileInfo(path)).Attributes;
                Console.Write(attr);
                List<string> items = new List<string>();
                    if (System.IO.Directory.Exists(path))
                    {
                        items.AddRange(System.IO.Directory.GetDirectories(path));
                        items.AddRange(System.IO.Directory.GetFiles(path));
                    }
                    return makeListToSend(items.ToArray());
               
                
            }
            catch (Exception)
            {
                System.IO.FileAttributes attr = (new System.IO.FileInfo(path)).Attributes;
                Console.Write("UnAuthorizedAccessException: Unable to access file. ");
                Console.WriteLine(attr);
                
                return null;
            }
           
        }


        public string CheckItem(string item, string currentpath)
        {

            string toreplace = dirTag;
           
            if (item.Contains(toreplace))
            {
                
                if (hasPermission(combineItemWithPath(item,currentpath), System.Security.AccessControl.FileSystemRights.ListDirectory) && hasAccessToRead(combineItemWithPath(item, currentpath)))
                {
                    if(currentpath.EndsWith("\\"))
                    {
                        return currentpath + item.Replace(toreplace, "");
                    }
                    else
                        return currentpath + "\\" + item.Replace(toreplace, "");

                }
                else

                    return currentpath;
            }
            else
            {

                openFile(currentpath + "\\" + item);
                return currentpath;
            }



        }

        public string GetParent(string path)
        {
            Console.WriteLine(System.IO.Directory.GetParent(path).ToString());
            if (System.IO.Directory.Exists(path))
                return System.IO.Directory.GetParent(path).ToString();
           
            return path;
        }
        public void PerformOperation(string source, string target, string item, string operation)
        {

            Console.WriteLine(source);
            string itempath = combineItemWithPath(item, source);
            if (operation == "Delete")
            {
                if (System.IO.Directory.Exists(source))
                {
                    if (isDir(itempath))
                    {
                        System.IO.Directory.Delete(itempath, true);

                    }
                    else
                    {
                        if(System.IO.File.Exists(itempath))
                        {
                            System.IO.File.Delete(itempath);
                        }
                    }
                }
            }
            else if(operation =="Move")
            {
                if (System.IO.Directory.Exists(itempath) && isDir(itempath))
                {
                    if (System.IO.Directory.GetDirectoryRoot(itempath) == System.IO.Directory.GetDirectoryRoot(target))
                    {
                        System.IO.Directory.Move(itempath,combineItemWithPath(item,target));

                    }
                    else
                    {
                        CopyDir(itempath, combineItemWithPath(item, target));
                        System.IO.Directory.Delete(itempath);
                    }
                   
                }
                else
                {
                    if (System.IO.File.Exists(itempath))
                        System.IO.File.Move(itempath, combineItemWithPath(item, target));
                }
            }
            else if(operation =="Copy")
            {
                if (System.IO.Directory.Exists(itempath) && isDir(itempath))
                {
                    CopyDir(itempath, combineItemWithPath(item, target));
                }
                else
                     if (System.IO.File.Exists(itempath))
                         System.IO.File.Copy(itempath, combineItemWithPath(item, target));
            }
        }
        #endregion
        #region Private Methods
        private string[] makeListToSend(string[] list)
        {

           
            List<string> listtosend = new List<string>();
            foreach (string file in list)
            {
                string tmp = System.IO.Directory.GetParent(file).ToString();
                

                if (isDir(file))
                {
                    if (tmp.Length <= 3)
                    {
                        listtosend.Add(file.Replace(tmp, dirTag));
                    }
                    else
                        listtosend.Add(file.Replace(tmp + "\\", dirTag));

                }
                else
                {
                    if (tmp.Length <= 3)
                    {
                        listtosend.Add(file.Replace(tmp, ""));
                    }
                    else
                        listtosend.Add(file.Replace(tmp + "\\", ""));
                }

            }
            //for (int i = 0; i < listtosend.Count; i++)
            //{

            //    if (listtosend[i].Contains("\\"))
            //    {
            //        int index = listtosend[i].IndexOf("\\");
            //        listtosend[i] = listtosend[i].Remove(index, 1);
            //    }
            //}
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
        private void openFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
        }
        private bool hasPermission(string path, System.Security.AccessControl.FileSystemRights accessRight )
        {
            try
            {
                System.Security.AccessControl.AuthorizationRuleCollection rules = System.IO.Directory.GetAccessControl(path).GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
                System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();

                foreach (System.Security.AccessControl.FileSystemAccessRule rule in rules)
                {
                    if (identity.Groups.Contains(rule.IdentityReference))
                    {
                        if ((accessRight & rule.FileSystemRights) == accessRight)
                        {
                            if (rule.AccessControlType == System.Security.AccessControl.AccessControlType.Allow)
                                return true;
                        }
                    }
                }
            }
            catch { }
            return false;
        }
        private bool hasAccessToRead(string path)
        {
            System.IO.FileAttributes attr = System.IO.File.GetAttributes(path);
            if (!attr.HasFlag(System.IO.FileAttributes.Hidden))
                return true;
            return false;
        }
        private string combineItemWithPath(string item, string path)
        {

            string trimmedItem = item.Replace(dirTag, "");
            if (item.Contains(dirTag))
            {
                if (path.EndsWith("\\"))
                {
                    return path + trimmedItem;

                }
                else
                    return path + "\\" + trimmedItem;
            }
            else
            {
                if (path.EndsWith("\\"))
                {
                    return path + item;
                }
                else
                {
                    return path + "\\" + item;
                }
            }
        }
        private void CopyDir(string source, string target)
        {
            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(source);

            System.IO.DirectoryInfo[] directories = info.GetDirectories();
            if(!System.IO.Directory.Exists(target))
            {
                System.IO.Directory.CreateDirectory(target);
            }
            System.IO.FileInfo[] files = info.GetFiles();
            foreach (System.IO.FileInfo file in files)
            {
                file.CopyTo(System.IO.Path.Combine(target, file.Name), true);

            }
            foreach(System.IO.DirectoryInfo dir in directories )
            {
                CopyDir(dir.FullName, System.IO.Path.Combine(target,dir.Name));
            }

        }
    }
    #endregion
}
