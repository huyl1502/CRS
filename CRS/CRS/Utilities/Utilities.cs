using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace CRS.Utilities
{
	public class Utilities
	{
		public static List<PhysicalAddress> GetMacAddress()
		{
            var lstAddress = new List<PhysicalAddress>();
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                lstAddress.Add(nic.GetPhysicalAddress());
            }
            return lstAddress;
        }
	}
}

