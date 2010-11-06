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


    // Gestionnaire des téléchargeurs "Downloader"
    // fichier le plus commenté pour le moment
    

    public class DownloadManager
    {
        public FastDL.DB.DBManager dbm;
        private FastDL.MISC.Header header;
        private BackgroundWorker bgw = new BackgroundWorker();
        private List<BackgroundWorker> dlers = new List<BackgroundWorker>();
        private mainForm _form;
        private List<IPAddress> _ips;
        private List<System.Net.NetworkInformation.NetworkInterface> _adapters;
        private long _blockSize;
        //public DataManager _dm;
        private int _nbConnPerInterface;
        public Stopwatch timer;
        public DownloadManager(string url, mainForm form, List<System.Net.NetworkInformation.NetworkInterface> adapters, List<IPAddress> IPs, int BlockSize, int nbConnPerInterface)
        {
            _blockSize = BlockSize * 1048576;
            _nbConnPerInterface = nbConnPerInterface;
            _form = form;
            _ips = IPs;
            _adapters = adapters;
            dbm = new FastDL.DB.DBManager();
            header = new FastDL.MISC.Header();
            addDownload(url);
        }


        public void addDownload(string url)
        {
            BackgroundWorker bgw = null;

            if (dbm.exists(url))
            {
                MessageBox.Show("Already added");
            }
            else
            {
                //Création du DBDownload

                FastDL.DB.DBDownload dbd = new FastDL.DB.DBDownload();
                dbd.url = url;
                dbd.url = URLManager.getURL(dbd, _ips[0]);
                header.setHeader(dbd.url);
                dbd.name = dbd.url.Substring(dbd.url.LastIndexOf("/") + 1);
                dbd.url = dbd.url;
                dbd.path = Application.StartupPath;
                dbd.startDate = DateAndTime.Now;
                dbd.header = "rien";
                dbd.size = header.size;

                //Création du stream/fichier
                Downloader.fs = new FileStream(dbd.path + "\\" + dbd.name, FileMode.Create);
                Stream.Synchronized(Downloader.fs);

                //Ajout du download à la BDD
                dbd.url = url;
                dbm.addDownload(ref dbd);

                //Ajout des chunks à la BDD
                addAndProcessChunk(dbd);

                int thread = 0;

                foreach (IPAddress ip in _ips)
                {
                    dbd.url = url;
                    dbd.url = URLManager.getURL(dbd, ip);

                    for (int i = 1; i <= _nbConnPerInterface; i++)
                    {
                        bgw = new BackgroundWorker();
                        bgw.WorkerReportsProgress = true;
                        bgw.WorkerSupportsCancellation = true;

                        bgw.DoWork += DoDownload;
                        bgw.RunWorkerCompleted += EndDownload;
                        bgw.ProgressChanged += _form.maj2;

                        dlers.Add(bgw);
                        bgw.RunWorkerAsync(new object[] {_adapters[_ips.IndexOf(ip)], ip, dbd});
                        System.Threading.Thread.Sleep(500);
                        thread += 1;
                    }
                }
                timer = new Stopwatch();
                timer.Start();
                MessageBox.Show("Started " + thread + " threads !");
            }

        }

        public void DoDownload(object sender, DoWorkEventArgs e)
        {
            System.Net.NetworkInformation.NetworkInterface adapter = (NetworkInterface)(((object[])(e.Argument))[0]);
            IPAddress ip = (IPAddress)(((object[])(e.Argument))[1]);
            FastDL.DB.DBDownload dbd = (FastDL.DB.DBDownload)(((object[])(e.Argument))[2]);
            Downloader dl = new FastDL.DL.Downloader((BackgroundWorker)sender, adapter, ip, dbd, _form);
        }

        public void EndDownload(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker bgw = (BackgroundWorker)sender;
            dlers.Remove(bgw);
            if (dlers.Count() == 0)
            {
                Downloader.fs.Close();
                MessageBox.Show("Téléchargé en " + timer.Elapsed.Seconds + " secondes.");
            }

        }

        public void addAndProcessChunk(FastDL.DB.DBDownload dbd)
        {
            Int64 remain = Convert.ToInt64(dbd.size % _blockSize);
            Int64 nbAdd = Convert.ToInt64(dbd.size / _blockSize);
            for (Int32 i = 0; i <= Convert.ToInt32(dbd.size - remain - 1); i += Convert.ToInt32(_blockSize))
            {
                dbm.addChunk(dbd.id, i, Convert.ToInt64(i + _blockSize - 1));
            }
            dbm.addChunk(dbd.id, dbd.size - remain, dbd.size - 1);
        }


    }

}
