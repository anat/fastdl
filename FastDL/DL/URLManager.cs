using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.IO;
using mshtml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace FastDL.DL
{
 

    //Classe degueulasse à abstraire pour N type d'authentification > rapidshare ?

    public class URLManager
    {
        private string _baseurl;
        static IPAddress _ip;

        private Socket _socket;
        public static string getURL(FastDL.DB.DBDownload dbd, IPAddress ip)
        {
            _ip = ip;
            if (dbd.url.Contains("http://www.megaupload.com/?d="))
            {
                return megaupload(dbd);
            }
            return dbd.url;
        }



        public static string megaupload(FastDL.DB.DBDownload dbd)
        {
            CookieCollection theCookie = GetCredential("mamare1", "17111981");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(dbd.url);
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(theCookie);
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
            int start = str.IndexOf("<div style=\"position:absolute; left:727px; top:40px; \" id=\"downloadlink\">");
            start = str.IndexOf("<a href=\"", start) + 9;
            int done = str.IndexOf("\"", start);

            return str.Substring(start, done - start);
        }



        public static CookieCollection GetCredential(string login, string password)
        {
            if (File.Exists(_ip.ToString() + "megaupload.bin"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream(_ip.ToString() + "megaupload.bin", FileMode.Open))
                {
                    return (CookieCollection)bf.Deserialize(fs);
                }
            }
            else
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://megaupload.com/?c=login");
                byte[] data = ASCIIEncoding.ASCII.GetBytes("login=1&redir=0&username=" + login + "&password=" + password);
                request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(BindIPEndPointCallback);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.CookieContainer = new CookieContainer();
                Stream s = request.GetRequestStream();
                s.Write(data, 0, data.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.Headers["Set-Cookie"] == null)
                {
                    MessageBox.Show("Couldn't login with your megaupload account");
                }
                else
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream fs = new FileStream(_ip.ToString() + "megaupload.bin", FileMode.OpenOrCreate))
                    {
                        bf.Serialize(fs, response.Cookies);
                    }
                    return response.Cookies;
                }
            }
            return null;
        }





        public static IPEndPoint BindIPEndPointCallback(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
        {
            return new IPEndPoint(_ip, 0);
        }


    }

}
