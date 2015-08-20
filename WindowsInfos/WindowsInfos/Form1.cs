using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInfos.Properties;
using System.Management.Instrumentation;
using System.Diagnostics;

namespace WindowsInfos
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefrInfo();
        }

        public void RefrInfo()
        {
            ShowNetworkInterfaces();
            ShowTemp();
            ShowHDDTemp();
            CounterInfo();
        }
        
        public  void ShowNetworkInterfaces()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            ConsoleWriteLine(computerProperties.HostName.ToString());
            ConsoleWriteLine(computerProperties.DomainName.ToString());
            if (nics == null || nics.Length < 1)
            {
                ConsoleWriteLine("  No network interfaces found.");
                return;
            }

            ConsoleWriteLine(nics.Length.ToString());
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
            
                ConsoleWriteLine(adapter.Description);
                ConsoleWriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                ConsoleWriteLine(adapter.NetworkInterfaceType.ToString());
                ConsoleWriteLine(adapter.GetPhysicalAddress().ToString());
                ConsoleWriteLine(adapter.OperationalStatus.ToString());
                string versions = "";

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions = "IPv4";
                }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                    }
                    versions += "IPv6";
                }
                ConsoleWriteLine(versions.ToString());
                ConsoleWriteLine(properties.ToString());
                ShowIPAddresses(properties);

                // The following information is not useful for loopback adapters.
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    continue;
                }
                ConsoleWriteLine(properties.DnsSuffix.ToString());

                string label;
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    IPv4InterfaceProperties ipv4 = properties.GetIPv4Properties();
                    ConsoleWriteLine(ipv4.Mtu.ToString());
                    if (ipv4.UsesWins)
                    {

                        IPAddressCollection winsServers = properties.WinsServersAddresses;
                        if (winsServers.Count > 0)
                        {
                            foreach (var winsServer in winsServers)
                            {
                                ConsoleWriteLine(winsServer.ToString());
                            }
                        }
                    }
                }

                ConsoleWriteLine(properties.IsDnsEnabled.ToString());
                ConsoleWriteLine(properties.IsDynamicDnsEnabled.ToString());
                ConsoleWriteLine(adapter.IsReceiveOnly.ToString());
                ConsoleWriteLine(adapter.SupportsMulticast.ToString());
                ShowInterfaceStatistics(adapter);

                
            }

        }

        private static void ShowIPAddresses(IPInterfaceProperties properties)
        {
            throw new NotImplementedException();
        }

        private static void ShowIPAddresses(string label, IPAddressCollection winsServers)
        {
            throw new NotImplementedException();
        }

        private static void ShowInterfaceStatistics(NetworkInterface adapter)
        {
            throw new NotImplementedException();
        }

        public void ConsoleWriteLine(string text)
        {
            RB.AppendText(String.Format("{0}\n",text));
        }
        public void ConsoleWriteLine(RichTextBox RTB,string text)
        {
            RTB.AppendText(String.Format("{0}\n", text));
        }

        private void GTButton_Click(object sender, EventArgs e)
        {
            ShowTemp();
            ShowHDDTemp();
            CounterInfo();
            
        }
        private void ShowHDDTemp()
        {
            HDDTempTB.Clear();
            int i = 0;
            foreach (var vartemp in GetHDDTemp())
            {
                
                ConsoleWriteLine(HDDTempTB,String.Format("HDD №{0} = {1}*C",i,vartemp.ToString()));
                i++;
            }
        }

        private ManagementObjectSearcher MOS;
        private const byte TEMP_HDD = 194;
        private List<byte> GetHDDTemp()
        {
            List<byte> rval=new List<byte>();
            try
            {
                MOS =new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSStorageDriver_ATAPISmartData");
                foreach (var qobj in MOS.Get())
                {
                    byte[] arrVS=(byte[]) qobj.GetPropertyValue("VendorSpecific");
                    int tindex = Array.IndexOf(arrVS, TEMP_HDD);
                    rval.Add(arrVS[tindex+5]);
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return rval;
        }
        private void ShowTemp()
        {
            TempListBox.Items.Clear();
            try
            {
                double CPUtprt = 0;
                MOS=new ManagementObjectSearcher("root\\WMI","SELECT * FROM MSAcpi_ThermalZoneTemperature");
                foreach (ManagementObject MO in MOS.Get())
                {
                    double t, kel, cel, far;
                    double.TryParse(MO["CurrentTemperature"].ToString(), out t);
                    kel = t/10;
                    cel = kel - 273.15;
                    far = cel*9/5 + 32;
                    CPUtprt =
                        Convert.ToDouble(Convert.ToDouble(MO.GetPropertyValue("CurrentTemperature".ToString()))- 2732)/6.96;
                    //TempListBox.Items.Add(" CPU: " + CPUtprt.ToString() + " *C");
                    TempListBox.Items.Add(" CPU: " + cel.ToString() + " *C");
                }
                
            }
            catch (ManagementException ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        private PerformanceCounter m_memCounter;
        private PerformanceCounter m_cpuCounter;
        public void CounterInfo()
        {
            
            m_memCounter=new PerformanceCounter();
            m_memCounter.CategoryName = "Memory";
            m_memCounter.CounterName = "Available MBytes";
            m_cpuCounter=new PerformanceCounter();
            m_cpuCounter.CategoryName = "Processor";
            m_cpuCounter.CounterName = "% Processor Time";
            m_cpuCounter.InstanceName = "_Total";
            TestTB.Clear();
            ConsoleWriteLine(TestTB,m_memCounter.CategoryName.ToString());
            ConsoleWriteLine(TestTB,String.Format ("{0} {1}",m_memCounter.CounterName.ToString(), GetAMem().ToString()));
            ConsoleWriteLine(TestTB,m_cpuCounter.CategoryName.ToString());
            ConsoleWriteLine(TestTB,String.Format("{0} {1}", m_cpuCounter.CounterName.ToString(), GetCPUL().ToString()));
        }
        public float GetAMem()
        {
            return m_memCounter.NextValue();
        }
        public float GetCPUL()
        {
            return m_cpuCounter.NextValue();
        }

        [DllImport("ntdll.dll")]
        public static extern int NtSetInformationProcess(IntPtr p, int c,ref int i, int l);
/*        public void _BSOD()
        {
            Process p = Process.GetCurrentProcess();
            int g = 1;
            NtSetInformationProcess(p.Handle, 29,ref g, 4);
            p.Kill();
        }
 */
    }
}