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
    class DownloadInformationWorker
    {
        private BackgroundWorker _bgw;
        private DB.DBManager _dbm = new FastDL.DB.DBManager();
        private List<IPAddress> _ips;
        private FastDL.MISC.Header _header;
        private string _baseurl;
        private DownloadManager _dm;

        public DownloadInformationWorker(string url, List<IPAddress> ips, DownloadManager dm)
        {
            _bgw = new BackgroundWorker();
            _bgw.WorkerReportsProgress = true;
            _bgw.WorkerSupportsCancellation = true;
            _ips = ips;
            _dm = dm;
            _baseurl = url;
            _bgw.DoWork += getInfo;
            _bgw.RunWorkerCompleted += _dm.startDownload;
            _bgw.RunWorkerAsync();
            _header = new FastDL.MISC.Header();
        }

        public void getInfo(object sender, DoWorkEventArgs e)
        {
            if (_ips.Count != 0)
            {

                // Aucune information récupérée dans ce bloc
                FastDL.DB.DBDownload dbd = new FastDL.DB.DBDownload();
                // Information vraies :
                dbd.url = _baseurl;
                dbd.path = Application.StartupPath;
                dbd.startDate = DateAndTime.Now;
                // Information Inconnues:
                dbd.header = "rien";
                dbd.size = 0;
                dbd.name = _baseurl;

                // Il faudrait ici reportProgress éventuellement

                // Récupération de l'URL de l'ip 0
                dbd.url = URLManager.getURL(dbd, _ips[0]);
                _header.setHeader(dbd.url);
                // Mise à jour de la vraie taille
                dbd.size = _header.size;
                // Mise à jour du vrai nom
                dbd.name = Uri.UnescapeDataString(dbd.url.Substring(dbd.url.LastIndexOf("/") + 1));
                //MessageBox.Show("ICI");

                // Récupération des URL supplémentaires sans prendre en compte l'ip 0
                Hashtable ht = new Hashtable();
                ht.Add(_ips[0].ToString(), dbd.url);
                foreach (IPAddress ip in _ips)
                {
                    if (ip.ToString() != _ips[0].ToString())
                    {
                        ht.Add(ip.ToString(), URLManager.getURL(dbd, ip));
                    }
                }

                // Ajout du download à la BDD
                dbd.url = _baseurl;
                _dbm.addDownload(ref dbd);

                // Ajout des chunks à la BDD
                _dm.addAndProcessChunk(dbd);

                // On met le résultat de tout ca dans Result
                e.Result = new object[] { ht, dbd };
            }
            else
            {
                MessageBox.Show("Vous n'etes pas connecté à internet.");
            }
        }
    }
}
