using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;


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
            list.AddRange(downloadsnl());
            return list;
        }

        private List<SearchResult> downloadsnl()
        {
            string url = "http://www.downloads.nl/results/mp3/1/" + _words.Replace(" ", "+");


            string page = Utils.getPage(url);
            string token = "class=\"tl j-lnk\" href=\"";

            string reg = "((" + token + ")[.*](\"))+";

            Regex r = new Regex(reg);
            MatchCollection matches = r.Matches(page);
            foreach(Match m in matches)
            {
                MessageBox.Show(m.Groups[0].Value);
            }
            string[] result = r.Split(page);
            foreach (string s in result)
            {
                MessageBox.Show(s);
            }
            return new List<SearchResult>();
        }
    }
}
