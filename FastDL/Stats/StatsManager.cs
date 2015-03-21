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
    public class StatsManager
    {
        // Deserve UI
        private mainForm _form;
        public DataGridView status;
        private System.Windows.Forms.DataGridViewTextBoxColumn nthread;
        private System.Windows.Forms.DataGridViewTextBoxColumn bytesdownloaded;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentblock;
        private System.Windows.Forms.DataGridViewTextBoxColumn part;
        private TabPage tpDownload;

        // Deserve stats
        private FastDL.Stats.FileMap filemap = new FastDL.Stats.FileMap();
        List<FastDL.DB.DBChunk> coord = new List<FastDL.DB.DBChunk>();
        private int DownloadedInASecond;
        private int totalReceived;

        private Label lblSpeed;
        private PictureBox pbProgressBlock;
        private Stopwatch sw = null;



        public StatsManager(mainForm form, string url)
        {
            _form = form;
            this.initDGV(url);
            this._form.dgvDownloads.Rows.Add(url.Substring(url.LastIndexOf("/") + 1), null, "", "", "", url);
        }


        private void initDGV(string url)
        {
            // création
            this.nthread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bytesdownloaded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentblock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.pbProgressBlock = new System.Windows.Forms.PictureBox();

            this.status = new System.Windows.Forms.DataGridView();

            // 
            // nthread
            // 
            this.nthread.HeaderText = "#thread";
            this.nthread.Name = "nthread";
            this.nthread.ReadOnly = true;
            this.nthread.Width = 60;
            // 
            // bytesdownloaded
            // 
            this.bytesdownloaded.HeaderText = "Ko";
            this.bytesdownloaded.Name = "bytesdownloaded";
            this.bytesdownloaded.ReadOnly = true;
            // 
            // part
            // 
            this.part.HeaderText = "part";
            this.part.Name = "part";
            this.part.ReadOnly = true;

            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(8, 7);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(86, 23);
            this.lblSpeed.TabIndex = 7;
            this.lblSpeed.Text = "0 Ko / sec";
            // 
            // pbProgressBlock
            // 
            this.pbProgressBlock.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbProgressBlock.Location = new System.Drawing.Point(100, 32);
            this.pbProgressBlock.Name = "pbProgressBlock";
            this.pbProgressBlock.Size = new System.Drawing.Size(600, 30);
            this.pbProgressBlock.TabIndex = 8;
            this.pbProgressBlock.TabStop = false;
            this.pbProgressBlock.Visible = true;

            ((System.ComponentModel.ISupportInitialize)(this.pbProgressBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.status)).BeginInit();


            this.status.AllowUserToAddRows = false;
            this.status.AllowUserToDeleteRows = false;
            this.status.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.status.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nthread,
            this.bytesdownloaded,
            this.part});
            this.status.Location = new System.Drawing.Point(9, 95);
            this.status.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.status.Name = "dgvThread";
            this.status.ReadOnly = true;
            this.status.RowHeadersVisible = false;
            this.status.Size = new System.Drawing.Size(425, 172);
            this.status.TabIndex = 2;


            tpDownload = new TabPage(url.Substring(url.LastIndexOf("/") + 1));
            tpDownload.Size = _form.tcMain.Size;
            tpDownload.ImageIndex = 1;

            tpDownload.Controls.Add(lblSpeed);
            tpDownload.Controls.Add(this.pbProgressBlock);
            tpDownload.Controls.Add(this.status);

            _form.tcMain.Controls.Add(tpDownload);
            _form.tcMain.SelectedTab = tpDownload;

            pbProgressBlock.Image = filemap.stats;
        }


        public void update(object sender, ProgressChangedEventArgs recv)
        {
            int received = (int)(((object[])recv.UserState)[0]);
            FastDL.DB.DBChunk dbc = (FastDL.DB.DBChunk)((object[])recv.UserState)[1];
            FastDL.DB.DBDownload dbd = (FastDL.DB.DBDownload)((object[])(recv.UserState))[2];


            BackgroundWorker bgw = (BackgroundWorker)sender;
            bool exists = false;



            foreach (DataGridViewRow row in status.Rows)
            {
                if (((int)row.Cells["nthread"].Value == bgw.GetHashCode()))
                {
                    exists = true;

                    row.Cells["bytesdownloaded"].Value = (int)row.Cells["bytesdownloaded"].Value + (received / 1024);
                    if (row.Cells["part"].Value.ToString() != (dbc.start_byte.ToString() + " " + dbc.end_byte.ToString()))
                    {
                        row.Cells["part"].Value = dbc.start_byte.ToString() + " " + dbc.end_byte.ToString();
                    }

                }
            }
            if (!exists)
            {
                status.Rows.Add(bgw.GetHashCode(), 0 + received, dbc.start_byte.ToString() + " " + dbc.end_byte.ToString());
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
                    long fromStart = Microsoft.VisualBasic.DateAndTime.DateDiff(DateInterval.Second, dbd.startDate, DateTime.Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1);
                    //?
                    long current = totalReceived;
                    long total = dbd.size;


                    string leftMinutes = Math.Round((decimal)(((Convert.ToInt64(fromStart) * Convert.ToInt64(total)) / current) / 60)).ToString();
                    lblSpeed.Text = Math.Round((decimal)(DownloadedInASecond / 1024), 1).ToString() + " Ko/sec  Restant : " + leftMinutes;
                    lblSpeed.Text += "\nTotal : " + Math.Round((decimal)totalReceived / 1024).ToString() + " / " + (dbd.size / 1024).ToString() + " Ko";
                    decimal avgSpeed = (totalReceived / 1024) / fromStart;
                    lblSpeed.Text += "\nAverage : " + avgSpeed + " Ko";

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
            
            // Inutile pour le moment savoir combien de Mo on a DL ... 
            //lblDlState.Text = (totalReceived / 1024 / 1024).ToString() + "/" + (dbc.dbd.size / 1024 / 1024).ToString();
        }
    }
}
