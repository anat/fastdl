using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;

namespace FastDL.MISC
{

    // Classe qui permet de savoir si on est connecté à internet !

    public class Pinger
    {
        private Socket _socket;
        private bool _Connected;

        private Stopwatch _sw;
        public bool ping(IPAddress adapter, int timeout)
        {
            _Connected = false;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(adapter, 0));

            _socket.BeginConnect("google.fr", 80, ConnectedCallBack, _socket);
            _sw = new Stopwatch();
            _sw.Start();
            while (_sw.ElapsedMilliseconds < timeout & _sw.IsRunning)
            {
                System.Threading.Thread.Sleep(1);
            }
            return _Connected;
        }

        public void ConnectedCallBack(IAsyncResult ar)
        {
            try
            {
                Socket s = (Socket)ar.AsyncState;
                s.EndConnect(ar);
                _Connected = true;
                s.Close();
            }
            catch
            {
                _Connected = false;
            }
            _sw.Stop();
        }
    }

}
