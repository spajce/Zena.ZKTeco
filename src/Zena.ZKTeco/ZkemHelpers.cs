using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Zena.ZKTeco.Models;

namespace Zena.ZKTeco
{
    public static class ZkemHelpers
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ActionEvent([CallerMemberName] string memberName = "")
        {
            return memberName;
        }

        public static DeviceInfoModel GetDeviceInfo(Zkem zkem, int dwMachineNumber = 1)
        {
            zkem.GetProductCode(dwMachineNumber, out string productCode);

            string mac = string.Empty;
            zkem.GetDeviceMAC(dwMachineNumber, ref mac);

            int users = 0;
            zkem.GetDeviceStatus(dwMachineNumber, (int)Zena.ZKTeco.DeviceStatus.Users, ref users);

            int attendanceLogs = 0;
            zkem.GetDeviceStatus(dwMachineNumber, (int)DeviceStatus.AttendanceLogs, ref attendanceLogs);

            string platform = string.Empty;
            zkem.GetPlatform(dwMachineNumber, ref platform);

            zkem.GetSerialNumber(dwMachineNumber, out string serialNumber);

            string ipAddress = string.Empty;
            zkem.GetDeviceIP(dwMachineNumber, ref ipAddress);
            int port = zkem.CommPort;

            var o = new DeviceInfoModel
            {
                IPAddress = ipAddress,
                Port = port,
                MAC = mac,
                ProductCode = productCode,
                Users = users,
                AttendanceLogs = attendanceLogs,
                Platform = platform,
                SerialNumber = serialNumber
            };

            return o;
        }

        public static bool PingIpAddress(string ipAddress)
        {
            try
            {
                Ping pingSender = new Ping();
                const int bufferSize = 32; // Set the size of the buffer to 32 bytes
                PingReply reply = pingSender.Send(ipAddress, 5000, new byte[bufferSize], new PingOptions());
                return reply.Status == IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<AttTransactionExModel> ReadAllGLogData(Zkem zkem)
        {
            List<AttTransactionExModel> mainList = new List<AttTransactionExModel>();

            string platform = string.Empty;
            zkem.GetPlatform(zkem.MachineNumber, ref platform);

            zkem.GetSerialNumber(zkem.MachineNumber, out string serialNumber);

            zkem.ReadAllGLogData(zkem.MachineNumber);

            int dwWorkCode = 0;
            while (zkem.SSR_GetGeneralLogData(zkem.MachineNumber,
                out string dwEnrollNumber,
                out int dwVerifyMode,
                out int dwInOutMode,
                out int dwYear,
                out int dwMonth,
                out int dwDay,
                out int dwHour,
                out int dwMinute,
                out int dwSecond,
                ref dwWorkCode))
            {
                try
                {
                    AttTransactionExModel att = new AttTransactionExModel
                    {
                        UserIdNum = int.Parse(dwEnrollNumber),
                        VerifyMethod = dwVerifyMode,
                        InOutMode = (InOutMode)dwInOutMode,
                        LogDateTime = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond),
                        WorkCode = dwWorkCode,
                        DeviceName = $"{platform}-{serialNumber}"
                    };
                    mainList.Add(att);
                }
                catch
                {
                    throw;
                }
            }

            return mainList;
        }

        public static List<UserInfoModel> GetAllUserInfo(Zkem zkem, bool includeFingerTemplates = false, bool includeFaceTemplates = false)
        {
            List<UserInfoModel> users = new List<UserInfoModel>();

            zkem.ReadAllUserID(zkem.MachineNumber);

            while (zkem.SSR_GetAllUserInfo(zkem.MachineNumber, out string dwEnrollNumber, out string name, out string password, out int privilege, out bool enabled))
            {
                UserInfoModel user = new UserInfoModel
                {
                    MachineNumber = zkem.MachineNumber,
                    UserIdNum = dwEnrollNumber,
                    Name = name,
                    Password = password,
                    Privelege = privilege,
                    Enabled = enabled,
                    FingerTemplates = new List<UserTmpExModel>()
                };

                if (includeFingerTemplates)
                {
                    zkem.ReadAllTemplate(zkem.MachineNumber);

                    var fingerTemplates = GetUserTmpExStr(zkem, dwEnrollNumber, false);
                    user.FingerTemplates = fingerTemplates;
                }

                if (includeFaceTemplates)
                {
                    throw new NotImplementedException("Get Users with Include Face Templates not yet included.");
                }

                users.Add(user);
            }
            return users;
        }

        public static UserInfoModel GetUserInfo(Zkem zkem, string dwEnrollNumber, bool includeFingerTemplates = false, bool includeFaceTemplates = false)
        {
            zkem.SSR_GetUserInfo(zkem.MachineNumber, dwEnrollNumber, out string name, out string password, out int privilege, out bool enabled);

            var user = new UserInfoModel
            {
                MachineNumber = zkem.MachineNumber,
                UserIdNum = dwEnrollNumber,
                Name = name,
                Password = password,
                Privelege = privilege,
                Enabled = enabled,
                FingerTemplates = new List<UserTmpExModel>()
            };

            if (includeFingerTemplates)
            {
                zkem.ReadAllTemplate(zkem.MachineNumber);

                var fingerTemplates = GetUserTmpExStr(zkem, dwEnrollNumber, false);
                user.FingerTemplates = fingerTemplates;
            }

            if (includeFaceTemplates)
            {
                throw new NotImplementedException("Get Users with Include Face Templates not yet included.");
            }

            return user;
        }

        public static List<UserTmpExModel> GetUserTmpExStr(Zkem zkem, string[] dwEnrollNumbers, bool readAllTemplate = true)
        {
            List<UserTmpExModel> templates = new List<UserTmpExModel>();

            if (readAllTemplate)
                zkem.ReadAllTemplate(zkem.MachineNumber);

            foreach (string dwEnrollNumber in dwEnrollNumbers)
            {
                int dwFingerIndex;
                for (dwFingerIndex = 0; dwFingerIndex < 10; dwFingerIndex++)
                {
                    if (zkem.GetUserTmpExStr(zkem.MachineNumber, dwEnrollNumber, dwFingerIndex, out int flag, out string tmpData, out int tmpLength))
                    {
                        var fingerTemp = new UserTmpExModel
                        {
                            MachineNumber = zkem.MachineNumber,
                            DeviceIdNum = dwEnrollNumber,
                            FingerIndex = dwFingerIndex,
                            Flag = flag,
                            TmpData = tmpData,
                            TmpLength = tmpLength
                        };
                        templates.Add(fingerTemp);
                    }
                }
            }

            return templates;
        }

        public static List<UserTmpExModel> GetUserTmpExStr(Zkem zkem, string dwEnrollNumber, bool readAllTemplate = true)
        {
            List<UserTmpExModel> templates = new List<UserTmpExModel>();

            if (readAllTemplate)
                zkem.ReadAllTemplate(zkem.MachineNumber);

            int dwFingerIndex;
            for (dwFingerIndex = 0; dwFingerIndex < 10; dwFingerIndex++)
            {
                if (zkem.GetUserTmpExStr(zkem.MachineNumber, dwEnrollNumber, dwFingerIndex, out int flag, out string tmpData, out int tmpLength))
                {
                    var fingerTemp = new UserTmpExModel
                    {
                        MachineNumber = zkem.MachineNumber,
                        DeviceIdNum = dwEnrollNumber,
                        FingerIndex = dwFingerIndex,
                        Flag = flag,
                        TmpData = tmpData,
                        TmpLength = tmpLength
                    };
                    templates.Add(fingerTemp);
                }
            }

            return templates;
        }

        // Note: Applicable to some customized devices
        public static void SearchDevice(Zkem zkem)
        {
            var b = zkem.SearchDevice("UDP", "192.168.88.50", out string DevBuffer, 32);

            Console.WriteLine(DevBuffer);
            //int ret = 0, j = 0;
            //byte[] buffer = new byte[64 * 1024];
            //string[] tmp = null;
            //string udp = "UDP";
            //string adr = "10.0.0.44";
            //MessageBox.Show("Start to SearchDevice!");
            //ret = zkem.SearchDevice(udp, adr, out string dev, 5);
            //MessageBox.Show("ret searchdevice=" + ret);
            //if (ret >= 0)
            //{
            //    str = Encoding.Default.GetString(buffer);
            //    str = str.Replace("\r\n", "\t");
            //    tmp = str.Split('\t');
            //    while (j < tmp.Length - 1)
            //    {
            //        string[] sub_str = tmp[j].Split(',');
            //        MessageBox.Show(tmp[0]);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("SearchDevice operation is failed!");
            //    return;
            //}
        }
    }
}
