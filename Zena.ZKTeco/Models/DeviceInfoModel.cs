using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zena.ZKTeco.Models
{
    public class DeviceInfoModel
    {
        public string IPAddress { get; set; }
        public int? Port { get; set; }
        public string MAC { get; set; }
        public int Users { get; set; }
        public int AttendanceLogs { get; set; }
        public string Platform { get; set; }
        public string ProductCode { get; set; }
        public string SerialNumber { get; set; }

        // The properties under evaluation / or research on how to the usage
        public string Password { get; set; }
        public string DeviceType { get; set; }
        public bool? Tft { get; set; }
        public int? DeviceNumber { get; set; }
        public bool? ExtendFormat { get; set; }
        public bool? FaceAvailable { get; set; }
        public bool? BatchAvailable { get; set; }
        public bool? SsrAvailable { get; set; }
        public string DateFormat { get; set; }
        public int int_0 = 9;
        public int? TotalFingerprintTemplate { get; set; }
        public int? TotalOperation { get; set; }
        public int? FingerprintTemplateCapacity { get; set; }
        public int? UserRecordCapacity { get; set; }
        public int? LogRecordCapacity { get; set; }
        public int? ResidualFingerprintTemplateCapacity { get; set; }
        public int? ResidualUserCapacity { get; set; }
        public int? ResidualLogRecordCapacity { get; set; }
        public int? TotalFaceTemplate { get; set; }
        public int? FaceTemplateCapacity { get; set; }
        public string Status { get; set; }
    }
}
