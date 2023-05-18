using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zena.ZKTeco.Models
{
    /// <summary>
    /// Finger Template
    /// </summary>
    public class UserTmpExModel
    {
        public int MachineNumber { get; set; }
        /// <summary>
        /// Primary Key
        /// </summary>
        public string DeviceIdNum { get; set; }
        public int FingerIndex { get; set; }
        public int Flag { get; set; }
        public string TmpData { get; set; }
        public int TmpLength { get; set; }
    }
}
