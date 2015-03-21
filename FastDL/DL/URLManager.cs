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
        public static IPAddress _ip;
        public static string getURL(FastDL.DB.DBDownload dbd, IPAddress ip)
        {
            _ip = ip;
            //if (dbd.url.Contains("http://www.website.com/"))
            //{
            //    return this.websiteAuth();
            //}
            return dbd.url;
        }


        public static IPEndPoint BindIPEndPointCallback(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
        {
            return new IPEndPoint(_ip, 0);
        }


    }

}
