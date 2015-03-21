using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace FastDL.MISC
{
    public static class Utils
    {

        public static string getPage(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; fr; rv:1.9.2.12) Gecko/20101026 Firefox/3.6.12";
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
            return str;
        }
    }
}
