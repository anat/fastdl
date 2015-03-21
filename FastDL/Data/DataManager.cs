using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.VisualBasic;

namespace FastDL.Data
{
    
    public class DataManager
    {
        private FileStream fs;
        private Object lockObject = new Object();
        private BackgroundWorker bgw;
        private Queue<Data> _queue;
        private TimeSpan t;
        public DataManager(string path)
        {
            bgw = new BackgroundWorker();
            bgw.WorkerReportsProgress = true;
            bgw.WorkerSupportsCancellation = true;
            bgw.DoWork += Writer;
            _queue = new Queue<Data>();
            fs = new FileStream(path, FileMode.Create);
            bgw.RunWorkerAsync();
        }

        public void push(Data d)
        {
            lock (lockObject)
            {
                _queue.Enqueue(d);
            }
        }

        private void add(Data d)
        {
            fs.Seek(d.current, SeekOrigin.Begin);
            fs.Write(d.buffer, 0, d.read);
        }

        public void Writer(Object sender, DoWorkEventArgs e)
        {
           Data d = null;
           bool flag;
            while (1 == 1)
            {
                while (1 == 1)
                {
                    lock (lockObject)
                    {
                        if (_queue.Count() == 0)
                            flag = true;
                        else
                        {
                            flag = false;
                            d = _queue.Dequeue();
                        }
                    }
                    if (flag)
                        System.Threading.Thread.Sleep(1);
                    else
                        break;
                    t.Add(new TimeSpan(0, 0, 0, 0, 1));
                }

                if (d.end)
                {
                    MessageBox.Show("End of writing");
                    this.close();
                    return;
                }
                add(d);

            }

        }

        public void close()
        {
            MessageBox.Show(t.TotalSeconds.ToString() + " seconds" + "\n" + _queue.Count());

            fs.Close();
        }
    }
}
