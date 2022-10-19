using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccessLayer
{
    
    public class RepositoryFileDB
    {
        public string FullPath { get; set; }
        public StreamReader Stream { get; set; }
        public RepositoryFileDB(string path)
        {
            this.FullPath = path;
            this.OpenFile();
        }

        private void OpenFile()
        {
            if (string.IsNullOrEmpty(this.FullPath))
            {
                throw new Exception("File is empty or null");
            }
            try
            {
                FileInfo f = new FileInfo(this.FullPath);
                this.Stream = f.OpenText();
               
            }
            catch (Exception ex)
            {
                throw new Exception("Your enter physical paht is invalid");
            }
            
        }
    }
}
