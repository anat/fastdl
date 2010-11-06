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
        Stopwatch sw = null;
        private int DownloadedInASecond;
        private int totalReceived;
        private FastDL.Stats.FileMap filemap = new FastDL.Stats.FileMap();
        private FastDL.DL.DownloadManager dlm;
        List<FastDL.DB.DBChunk> coord = new List<FastDL.DB.DBChunk>();
        private FastDL.MISC.AdapterManager ad = new FastDL.MISC.AdapterManager();

        public mainForm()
        {
            InitializeComponent();
            //rtbURL.Text = "http://www.megaupload.com/?d=Y182D810";
            //rtbURL.Text = "http://ovh.dl.sourceforge.net/project/vlc/1.1.4/win32/vlc-1.1.4-win32.exe";
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            ServicePointManager.DefaultConnectionLimit = 100;
            pbProgressBlock.Image = filemap.stats;
            ad.setIPUp();
            foreach (NetworkInterface ni in ad.InternetIntefaces)
            {
                dgvInterfaces.Rows.Add(ni.Description, ni.Speed.ToString());
            }
        }

        public void maj2(object sender, ProgressChangedEventArgs recv)
        {
            int received = (int)(((object[])recv.UserState)[0]);
            FastDL.DB.DBChunk dbc = (FastDL.DB.DBChunk)((object[])recv.UserState)[1];
            FastDL.DB.DBDownload dbd = (FastDL.DB.DBDownload)((object[])(recv.UserState))[2];
            int percent = 100 - (((int)dbc.end_byte - (int)dbc.current_byte) * 100) / ((int)dbc.end_byte - (int)dbc.start_byte);

            BackgroundWorker bgw = (BackgroundWorker)sender;
            bool exists = false;



            foreach (DataGridViewRow row in dgvThread.Rows)
            {
                if (((int)row.Cells["nthread"].Value == bgw.GetHashCode()))
                {
                    exists = true;
                    //row.Cells["bytesdownloaded"].Value += received;
                    row.Cells["percentblock"].Value = percent;
                    if (row.Cells["part"].Value.ToString() != (dbc.start_byte.ToString() + " " + dbc.end_byte.ToString()))
                    {
                        row.Cells["part"].Value = dbc.start_byte.ToString() + " " + dbc.end_byte.ToString();
                    }
                }
            }
            if (!exists)
            {
                dgvThread.Rows.Add(bgw.GetHashCode(), 0 + received, percent, dbc.start_byte.ToString() + " " + dbc.end_byte.ToString());
            }



            dbc.dbd = dbd;
            if ((sw == null))
            {
                sw = new Stopwatch();
                sw.Start();
                DownloadedInASecond = 0;
            }
            else
            {
                if (sw.Elapsed.Seconds >= 1)
                {
                    long fromStart = Microsoft.VisualBasic.DateAndTime.DateDiff(DateInterval.Second, dbd.startDate, DateTime.Now, FirstDayOfWeek.Monday,FirstWeekOfYear.Jan1);
                    //?
                    long current = totalReceived;
                    long total = dbd.size;


                    //string leftMinutes = Math.Round(((Convert.ToInt64(fromStart) * Convert.ToInt64(total)) / current) / 60).ToString();
                    lblSpeed.Text = Math.Round((decimal)(DownloadedInASecond / 1024 / 1024), 1).ToString() + " Mo/sec  Restant : ";// +leftMinutes;
                    DownloadedInASecond = 0;
                    sw = new Stopwatch();
                    sw.Start();
                    //filemap.update(coord)
                    //coord = New List(Of DBChunk)
                    //PictureBox1.Image = filemap.stats
                }
                else
                {
                    DownloadedInASecond += received;
                }
            }
            totalReceived += received;
            //For Each dgvr As DataGridViewRow In DataGridView2.Rows
            //    If (dgvr.Cells("Adapter").Value = dbc.adapter.Description) Then
            //        dgvr.Cells("Speed").Value = (totalReceived / 1024 / 1024)  '(adapter.GetIPv4Statistics.BytesReceived / 1024 / 1024).ToString() & " Mo"
            //        dgvr.Cells("Percent").Value = percent
            //    End If
            //Next
            coord.Add(dbc);
            filemap.update(coord);
            coord = new List<FastDL.DB.DBChunk>();
            pbProgressBlock.Image = filemap.stats;
            //DataGridView2.Rows(0).Cells("Speed").Value = recv.NetworkInterface.GetIPv4Statistics.BytesReceived
        }

        private void button1_Click(object sender, EventArgs e)
        {
              dlm = new FastDL.DL.DownloadManager(rtbURL.Text, this, ad.InternetIntefaces, ad.InternetAddresses,(int)nudBlockSize.Value,(int)nudConnPerInterfaces.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FastDL.DB.DBManager dbm = new FastDL.DB.DBManager();
            dbm.deleteAllDownloads();
        }

    }
}
