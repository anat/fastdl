﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Net;
using System.IO;
namespace FastDL.MISC
{
    public class Search
    {
        private BackgroundWorker bgw = new BackgroundWorker();
        private DataGridView _dgv;
        string _words;

        public Search(string words, DataGridView dgv)
        {
            _words = words;
            _dgv = dgv;
            bgw.WorkerReportsProgress = true;
            bgw.WorkerSupportsCancellation = true;

            bgw.DoWork += DoSearch;
            bgw.RunWorkerCompleted += EndSearch;

            bgw.RunWorkerAsync();
        }


        private void DoSearch(object sender, DoWorkEventArgs e)
        {
            getResults();
        }

        private void EndSearch(object sender, RunWorkerCompletedEventArgs e)
        {

        }


        private List<SearchResult> getResults()
        {
            List<SearchResult> list = new List<SearchResult>();

            list.AddRange(Megaupload());
            return list;
        }

        private List<SearchResult> Megaupload()
        {
            return GoogleResult("site:megaupload.com " + _words);
        }


        private List<SearchResult> GoogleResult(string query)
        {
            List<SearchResult> list = new List<SearchResult>();
            string url = "http://www.google.fr/search?q=" + query + "&num=100";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = response.GetResponseStream();
            byte[] buff = new byte[50001];
            string str = "";
            int read = 1;
            while (read != 0)
            {
                read = s.Read(buff, 0, 5000);
                str += ASCIIEncoding.ASCII.GetString(buff, 0, read);
            }

            string token = "http://www.megaupload.com/?d=";
            int i = 0;

            // Get All urls
            while (i != -1 && i + token.Length + 8 < str.Length)
            {
                if (str.IndexOf(token, i) != -1)
                {
                    list.Add(new SearchResult(str.Substring(str.IndexOf(token, i), token.Length + 8)));
                    i = str.IndexOf(token, i) + token.Length + 1;
                }
                else
                {
                    i = -1;
                }
                    // MessageBox.Show(str.Substring(str.IndexOf(token, i), token.Length + 8));
            }

            // Get Description and Filename
            foreach (SearchResult sr in list)
            {
                string page = DL.URLManager.megaupload(sr.url);

                sr.name =  DL.URLManager.getMegauploadURL(page);
                sr.name = sr.name.Substring(sr.name.LastIndexOf("/"));
                sr.desc = DL.URLManager.getMegauploadDesc(page);
                MessageBox.Show("Name : " + sr.name + "\nDesc : " + sr.desc + "\nURL : " + sr.url);
            }

            return list;
        }
    }
}
