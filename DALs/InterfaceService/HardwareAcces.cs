using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custodian.DALs.Interfaces;
using System.Windows.Forms;
using System.IO;

namespace Custodian.DALs.InterfaceService
{
    class HardwareAcces : IHardwareAcces, IEnterHistory
    {
        public string HddID { get; private set; }
        public string MachineName { get; private set; }
        public int HardwareStatus { get; private set; }
        public string Orderclient { get; protected set; }
        private userDAL Dal { get; set; }

        public HardwareAcces(string orderclient)
        {
            this.Orderclient = orderclient;
            Dal = new userDAL();
            GetHardwareNames();
        }
        public void InitializeAcces()
        {
            GetCurrentHardvareStatus();
        }

        public void InitializeHistoryEnter()
        {
            GetMachineName();
        }

        public void InsertSucsessEnterInfo()
        {
            Dal.InsertLoginEvent(MachineName, Orderclient);
        }
        public void InsertExitInfo()
        {
            //Пока не нужно

        }


        public void SetFalseHardvareStatus()
        {
            Dal.SetFalseHardvareAcces(HddID, Orderclient);
        }

        private void GetMachineName()
        {
            MachineName = Environment.MachineName;
        }

        private void GetHardwareNames()
        {
            ManagementObject os = new ManagementObject("Win32_OperatingSystem=@");
            HddID = os["SerialNumber"].ToString();
        }

        private void GetCurrentHardvareStatus()
        {
            HardwareStatus = Dal.GetHardwareData(HddID);
        }
    }
}
