using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH01D
{
    internal class NetworkingWork
    {
        public void CheckNetworkStatus(object data)
        {
            for (int i = 0; i < 12; i++)
            {
                bool isNetworkUp = System.Net.
                NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                Console.WriteLine($"Thread priority {(string)data}; Is network available? Answer: {isNetworkUp}");
                i++;
            }
        }
    }
}
