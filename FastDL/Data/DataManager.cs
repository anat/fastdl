using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FastDL.Data
{
    
    public class DataManager
    {
        private FileStream fs;
        private Object lockObject = new Object();

        public DataManager(string path)
        {
            fs = new FileStream(path, FileMode.Create);
        }

        public void add(long current, byte[] buffer, int read)
        {
            lock(lockObject)
            {
            fs.Seek(current, SeekOrigin.Begin);
            fs.Write(buffer, 0, read);
            }
        }

        public void close()
        {
            fs.Close();
        }
    }
}
