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

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            size = response.ContentLength;
        }
    }

}
