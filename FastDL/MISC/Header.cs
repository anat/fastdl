using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace FastDL.MISC
{

    // Ancienne récupation d'un header ( Méthode à l'ancienne > création de la requête GET 
    // en mode manouche etc ...)

    public class Header
    {
        public long size;
        public string header;
        public Header()
        {
            size = 0;
        }


        public void setHeader(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.CookieContainer = new CookieContainer();
            //request.CookieContainer.Add(URLManager.GetCredential("mamare1", "17111981"));
            //request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(BindIPEndPointCallback);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            size = response.ContentLength;


            // Déclaration des variables
            //string Resultat = "";
            //string RecupHTTPChaine = "";
            //System.Net.Sockets.TcpClient WebClient = new System.Net.Sockets.TcpClient();
            //NetworkStream WebStream = null;
            //StreamWriter WebWriter = null;
            //StreamReader WebReader = null;
            //int toread = 4000;

            //RecupHTTPChaine = "GET " + new Uri(url).AbsolutePath + " HTTP/1.1" + "\r\n" + "Host: " + new Uri(url).Host + "\r\n" + "\r\n";
            //WebClient.Connect(new Uri(url).Host, 80);
            //WebStream = WebClient.GetStream();
            //WebWriter = new StreamWriter(WebStream, Encoding.Default, RecupHTTPChaine.Length);
            //WebWriter.Write(RecupHTTPChaine);
            //WebWriter.Flush();
            //WebReader = new StreamReader(WebStream);

            //char[] b = new char[toread + 1];
            //WebReader.Read(b, 0, toread);
            //Resultat = string.Concat(b);
            //WebStream.Close();
            //WebClient.Close();
            //WebWriter.Close();
            //WebReader.Close();

            //header = Resultat.Substring(0, Resultat.IndexOf("\r\n\r\n"));
            //string lookfor = "Content-Length:";
            //if (header.Contains(lookfor))
            //{
            //    size = Convert.ToInt32(header.Substring(header.IndexOf(lookfor) + lookfor.Length, Resultat.IndexOf("\r\n", header.IndexOf(lookfor)) - header.IndexOf(lookfor) - lookfor.Length));
            //}
        }
    }

}
