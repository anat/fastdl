using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace FastDL
{
    public partial class mainForm : Form
    {
        private FastDL.DL.DownloadManager dlm;
        private FastDL.MISC.AdapterManager ad = new FastDL.MISC.AdapterManager();

        public mainForm()
        {
            InitializeComponent();
            ServicePointManager.DefaultConnectionLimit = 100;
            rtbURL.Text = "http://d212.uploadstation.com/file/es8mKk8/X-vFBnjzOauZ7tR7ZYQJqxeV-0FWi-LPCWBTd_1hg2LPpDVd21UJ1ttXgwu_yzCJvzR-mdKc-CZya8fRtxbx1jx7-IObMSOiL5rF8M1zHhLLov5Nx-RDSgWZK11dxONWSYAXxS83Yva28jwStAz0yNyM4PZciKO9umzC-4M6LAA./Trackmania.2.rar";
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            tcMain.SelectedTab = tpDownloads;
            ad.setIPUp();
            lblNbInterfaces.Text = ad.InternetAddresses.Count().ToString();
            DB.DBManager dbm = new DB.DBManager();
            foreach (DB.DBDownload dl in dbm.getAllDownloads())
            {
                if (dl.endDate != null)
                {
                    dgvDownloads.Rows.Add(dl.name, null, dl.size, "", "Finished");
                }
                else
                {
                    dgvDownloads.Rows.Add(dl.name, null, dl.size,"", "");
                }

            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
              dlm = new FastDL.DL.DownloadManager(this, ad.InternetIntefaces, ad.InternetAddresses,(int)nudBlockSize.Value,(int)nudConnPerInterfaces.Value);
              dlm.addDownload(rtbURL.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FastDL.DB.DBManager dbm = new FastDL.DB.DBManager();
            dbm.deleteAllDownloads();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FastDL.DL.URLManager._ip = ad.InternetAddresses[0];
            MISC.Search s = new FastDL.MISC.Search(tbSearch.Text, dgvSearch);
        }



        private void linkGrabber(object sender, EventArgs e)
        {
            MessageBox.Show("Has focus");
        }


        //override protected void OnGotFocus(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Has focus2");
        //}

    }
}
