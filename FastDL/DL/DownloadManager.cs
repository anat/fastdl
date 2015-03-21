using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Windows.Forms;

namespace FastDL.DL
{

    public class DownloadManager
    {
        public FastDL.DB.DBManager dbm;
       
        private BackgroundWorker bgw = new BackgroundWorker();
        private List<BackgroundWorker> dlers = new List<BackgroundWorker>();
        private mainForm _form;
        private List<IPAddress> _ips;
        private List<System.Net.NetworkInformation.NetworkInterface> _adapters;
        private long _blockSize;
        private FastDL.Data.DataManager _dm;
        private int _nbConnPerInterface;
        public Stopwatch timer;
        private DownloadInformationWorker _diw;
        private StatsManager stats;

        public DownloadManager(mainForm form, List<System.Net.NetworkInformation.NetworkInterface> adapters, List<IPAddress> IPs, int BlockSize, int nbConnPerInterface)
        {
            _form = form;
            _blockSize = BlockSize * 1048576;
            _nbConnPerInterface = nbConnPerInterface;
            _ips = IPs;
            _adapters = adapters;
            dbm = new FastDL.DB.DBManager();
        }


        public void addDownload(string url)
        {
            if (dbm.exists(url))
            {
                MessageBox.Show("Already added");
            }
            else
            {
                stats = new StatsManager(_form, url);
                
                // Création du DBDownload (asynchrone)
                _diw = new DownloadInformationWorker(url, _ips, this);
                // La méthode startDownload est ensuite appelée automatiquement
            }

        }

        public void startDownload(object sender, RunWorkerCompletedEventArgs e)
        {
            Hashtable ht = (Hashtable)(((object[])(e.Result))[0]);
            DB.DBDownload dbd = (DB.DBDownload)(((object[])(e.Result))[1]);
            //string url, DB.DBDownload dbd)
            
            //Création du stream/fichier
            _dm = new FastDL.Data.DataManager(dbd.path + "\\" + dbd.name);

            int thread = 0;
            foreach (IPAddress ip in _ips)
            {
                dbd.url = (string)ht[ip.ToString()];
                for (int i = 1; i <= _nbConnPerInterface; i++)
                {
                    bgw = new BackgroundWorker();
                    bgw.WorkerReportsProgress = true;
                    bgw.WorkerSupportsCancellation = true;

                    bgw.DoWork += DoDownload;
                    bgw.RunWorkerCompleted += EndDownload;
                    bgw.ProgressChanged += stats.update;

                    dlers.Add(bgw);
                    bgw.RunWorkerAsync(new object[] { _adapters[_ips.IndexOf(ip)], ip, dbd });
                    System.Threading.Thread.Sleep(500);
                    thread += 1;
                }
            }
            timer = new Stopwatch();
            timer.Start();
            MessageBox.Show("Started " + thread + " threads !");
        }


        public void DoDownload(object sender, DoWorkEventArgs e)
        {
            System.Net.NetworkInformation.NetworkInterface adapter = (NetworkInterface)(((object[])(e.Argument))[0]);
            IPAddress ip = (IPAddress)(((object[])(e.Argument))[1]);
            FastDL.DB.DBDownload dbd = (FastDL.DB.DBDownload)(((object[])(e.Argument))[2]);
            Downloader dl = new FastDL.DL.Downloader((BackgroundWorker)sender, adapter, ip, dbd, _dm);
            e.Result = dbd;
        }

        public void EndDownload(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker bgw = (BackgroundWorker)sender;
            dlers.Remove(bgw);
            if (dlers.Count() == 0)
            {
                dbm.endDownload(((DB.DBDownload)(e.Result)).id);
                // end of write
                _dm.push(new Data.Data());
                MessageBox.Show("Téléchargé en " + timer.Elapsed.Seconds + " secondes.");
            }

        }

        public void addAndProcessChunk(FastDL.DB.DBDownload dbd)
        {
            Int64 remain = Convert.ToInt64(dbd.size % _blockSize);
            Int64 nbAdd = Convert.ToInt64(dbd.size / _blockSize);
            for (Int32 i = 0; i <= Convert.ToInt32(dbd.size - remain - 1); i += Convert.ToInt32(_blockSize))
                dbm.addChunk(dbd.id, i, Convert.ToInt64(i + _blockSize - 1));
            if (remain != 0)
                dbm.addChunk(dbd.id, dbd.size - remain, dbd.size - 1);
        }


    }

}
