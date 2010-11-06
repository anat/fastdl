﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.ComponentModel;

namespace FastDL.DL
{


    // Téléchargeur pur

    public class Downloader
    {
        public static FileStream fs;
        private const int BUFFER_SIZE = 400000;
        private const int READ_SIZE = 350000;
        private byte[] _buffer;
        //public delegate void received(object sender, DataDownloadEvent e);
        public mainForm _form;
        private FastDL.DB.DBManager _dbm = new FastDL.DB.DBManager();
        private Stream _stream;
        private bool _eos;
        private IPEndPoint _localIP;
        private FastDL.DB.DBDownload _dbd;
        public BackgroundWorker _bgw;
        public bool Downloaded;

        static object fileLock = new object();
        public Downloader(BackgroundWorker bgw, System.Net.NetworkInformation.NetworkInterface adapter, IPAddress localIP, FastDL.DB.DBDownload dbd, mainForm f)
        {
            _bgw = bgw;
            _dbd = dbd;
            _form = f;
            _buffer = new byte[BUFFER_SIZE + 1];
            _localIP = new IPEndPoint(localIP, 0);
            FastDL.DB.DBChunk dbc = _dbm.getNext(dbd);

            while ((dbc != null))
            {
                Downloaded = false;
                dbc.adapter = adapter;
                while (Downloaded == false)
                {
                    dbc.current_byte = dbc.start_byte;
                    startDownload(dbd.url, dbc);
                }
                _dbm.setDownloadingState(dbc.id, false);
                _dbm.setOwnedState(dbc.id, true);
                dbc = _dbm.getNext(dbd);
            }
        }



        public void startDownload(string url, FastDL.DB.DBChunk dbc)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AddRange(Convert.ToInt32(dbc.start_byte), Convert.ToInt32(dbc.end_byte));
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(URLManager.GetCredential("mamare1", "17111981"));
            request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(BindIPEndPointCallback);
            bool good = false;
            HttpWebResponse response = null;
            while (good == false)
            {
                response = (HttpWebResponse)request.GetResponse();
                if (response.ContentLength == dbc.end_byte - dbc.start_byte + 1)
                {
                    good = true;
                    //MsgBox("TRUE" & response.CharacterSet())
                }
                else
                {
                    MessageBox.Show("Erreur");
                }
            }


            _stream = response.GetResponseStream();
            Stream.Synchronized(_stream);
            _stream.BeginRead(_buffer, 0, READ_SIZE, callB, dbc);

            while (_eos == false)
            {
                System.Threading.Thread.Sleep(10);
            }
            _eos = false;
        }

        public void callB(IAsyncResult ar)
        {
            FastDL.DB.DBChunk current = (FastDL.DB.DBChunk)ar.AsyncState;
            int read = _stream.EndRead(ar);
            if ((read == 0))
            {
                if (current.current_byte != current.end_byte + 1)
                {
                    Downloaded = false;
                    MessageBox.Show("Partie mal téléchargé\\ncur:" + current.current_byte + Constants.vbNewLine + "end:" + current.end_byte);
                }
                else
                {
                    Downloaded = true;
                }
                _stream.Close();
                _eos = true;

            }
            else
            {
                //tp.SetMaxThreads()
                //MsgBox(current.current_byte)
                lock (fileLock)
                {
                    fs.Seek(current.current_byte, SeekOrigin.Begin);
                    fs.Lock(current.current_byte, read);
                    fs.Write(_buffer, 0, read);
                    fs.Unlock(current.current_byte, read);
                }
                current.current_byte += read;
                _bgw.ReportProgress(0, new object[] {
				read,
				current,
				_dbd
			});
                _stream.BeginRead(_buffer, 0, READ_SIZE, callB, current);
            }
        }



        private IPEndPoint BindIPEndPointCallback(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
        {
            return _localIP;
        }

    }

}
