using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace FastDL.MISC
{


    // Classe qui permet de savoir les interfaces dispos ainsi que toutes leurs adresse IPv4
    // Pour testé pour chacune si elle a internet

    public class AdapterManager
    {
        public System.Net.NetworkInformation.NetworkInterface[] AllAdapters;
        public List<System.Net.NetworkInformation.NetworkInterface> InternetIntefaces = new List<System.Net.NetworkInformation.NetworkInterface>();
        public List<IPAddress> InternetAddresses = new List<IPAddress>();
        public AdapterManager()
        {
            AllAdapters = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
        }

        public List<NetworkInterface> GetInterfaces()
        {
            List<System.Net.NetworkInformation.NetworkInterface> upAdapter = new List<System.Net.NetworkInformation.NetworkInterface>();
            foreach (System.Net.NetworkInformation.NetworkInterface adapter in AllAdapters)
            {
                if ((adapter.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up))
                {
                    upAdapter.Add(adapter);
                }
            }
            return upAdapter;
        }

        public void setIPUp()
        {
            List<IPAddress> IPUp = new List<IPAddress>();
            List<NetworkInterface> ITUp = new List<NetworkInterface>();
            foreach (NetworkInterface adapter in GetInterfaces())
            {
                foreach (UnicastIPAddressInformation adr in adapter.GetIPProperties().UnicastAddresses)
                {
                    if ((adr.Address.AddressFamily == AddressFamily.InterNetwork & adr.Address.ToString() != "127.0.0.1"))
                    {
                        if (checkAvailability(adr.Address))
                        {
                            IPUp.Add(adr.Address);
                            ITUp.Add(adapter);
                        }
                    }
                }
            }
            InternetAddresses = IPUp;
            InternetIntefaces = ITUp;
        }

        public bool checkAvailability(IPAddress adapter)
        {
            Pinger pg = new Pinger();
            return pg.ping(adapter, 500);
        }


    }

}
